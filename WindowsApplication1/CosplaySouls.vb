'Author: CoelyPuffs

'Hooking function modified from Wulf2k's DaS-PC-Gizmo

Public Class CosplaySouls

    Private Declare Function OpenProcess Lib "kernel32.dll" (ByVal dwDesiredAccess As UInt32, ByVal bInheritHandle As Boolean, ByVal dwProcessID As Int32) As IntPtr
    Private Declare Function CloseHandle Lib "kernel32.dll" (ByVal hObject As IntPtr) As Boolean
    Private Declare Function ReadProcessMemory Lib "kernel32" (ByVal hProcess As IntPtr, ByVal lpBaseAddress As IntPtr, ByVal lpBuffer() As Byte, ByVal iSize As Integer, ByRef lpNumberOfBytesRead As Integer) As Boolean
    Private Declare Function WriteProcessMemory Lib "kernel32" (ByVal hProcess As IntPtr, ByVal lpBaseAddress As IntPtr, ByVal lpBuffer() As Byte, ByVal iSize As Integer, ByRef lpNumberOfBytesRead As Integer) As Boolean
    Private Declare Function VirtualAllocEx Lib "kernel32" (ByVal hProcess As IntPtr, ByVal lpAddress As IntPtr, ByVal dwSize As IntPtr, ByVal flAllocationType As Integer, ByVal flProtect As Integer) As IntPtr
    Private Declare Function VirtualFreeEx Lib "kernel32" (ByVal hProcess As IntPtr, ByVal lpAddress As IntPtr, ByVal dwSize As IntPtr, ByVal dwFreeType As Integer) As IntPtr

    Dim isHooked As Boolean = False
    Dim isSetup As Boolean = False
    Dim isCalibrated As Boolean = False
    Public Const processAllAccess = &H1F0FFF
    Private targetProcess As Process = Nothing
    Private targetProcessHandle As IntPtr = IntPtr.Zero
    Dim modifiedHitFunct As Integer
    Dim lastHitPtr As Integer
    Dim lastHitBytes(3) As Byte
    Dim lastHit() As Byte = {&H39, &H0, &H38, &H0, &H37, &H0, &H36, &H0}
    Dim validityCheck() As Byte = {&H0}
    Dim entity = "Entity"
    Dim fullAddress As Integer
    Public cosplayHash As New Hashtable()
    Dim previousHit As Integer = 9876
    Dim latestHit As Integer = 9876
    Dim currentCosplay(16) As Integer
    Dim equipmentBase As Integer
    Dim statBase As Integer
    Dim autoStats As Boolean
    Dim autoLvlGear As Boolean
    'Public externalCosplays() As Array
    'Dim usingExternal As Boolean

    Private WithEvents refreshTimer As New System.Windows.Forms.Timer()

    Public Function ReadUInt32(ByVal address As IntPtr) As UInt32
        Dim readBytes(3) As Byte
        ReadProcessMemory(targetProcessHandle, address, readBytes, 4, vbNull)
        Return BitConverter.ToUInt32(readBytes, 0)
    End Function

    Public Sub WriteInt32(ByVal address As IntPtr, value As Int32)
        WriteProcessMemory(targetProcessHandle, address, BitConverter.GetBytes(value), 4, Nothing)
    End Sub

    Public Function pointerToAddress(pointer As Integer) As Integer
        Dim returnBytes(3) As Byte
        Dim addressOne(0) As Byte
        Dim addressTwo(0) As Byte
        Dim addressThree(0) As Byte
        Dim addressFour(0) As Byte
        ReadProcessMemory(targetProcessHandle, pointer, addressOne, 1, vbNull)
        ReadProcessMemory(targetProcessHandle, pointer + 1, addressTwo, 1, vbNull)
        ReadProcessMemory(targetProcessHandle, pointer + 2, addressThree, 1, vbNull)
        ReadProcessMemory(targetProcessHandle, pointer + 3, addressFour, 1, vbNull)
        Array.Copy(addressOne, 0, returnBytes, 0, 1)
        Array.Copy(addressTwo, 0, returnBytes, 1, 1)
        Array.Copy(addressThree, 0, returnBytes, 2, 1)
        Array.Copy(addressFour, 0, returnBytes, 3, 1)
        Return BitConverter.ToInt32(returnBytes, 0)
    End Function

    Public Function processScan(progName As String, Optional auto As Boolean = False) As Boolean
        Dim allProcesses() As Process = Process.GetProcesses
        For Each prcs As Process In allProcesses
            If prcs.MainWindowTitle.ToLower.Equals(progName.ToLower) Then
                Return tryAttach(prcs, auto)
            End If
        Next
        Return False
    End Function

    Public Function tryAttach(ByVal prcs As Process, Optional auto As Boolean = False) As Boolean
        If Not (targetProcessHandle = IntPtr.Zero) Then
            detachFromProcess()
        End If
        targetProcess = prcs
        targetProcessHandle = OpenProcess(processAllAccess, False, targetProcess.Id)
        If targetProcessHandle = 0 Then
            If Not auto Then
                MessageBox.Show("Please rerun this as Administrator")
            End If
            Return False
        Else
            'MessageBox.Show("Hooked!")
            Return True
        End If
    End Function

    Public Sub detachFromProcess()
        If Not (targetProcessHandle = IntPtr.Zero) Then
            targetProcess = Nothing
            Try
                CloseHandle(targetProcessHandle)
                targetProcessHandle = IntPtr.Zero
            Catch ex As Exception
                MessageBox.Show("Warning: MemoryManager::DetachFromProcess::CloseHandle error" & Environment.NewLine & ex.Message)
            End Try
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        refreshTimer = New System.Windows.Forms.Timer()
        refreshTimer.Interval = 500
        refreshTimer.Enabled = True

        Me.Icon = My.Resources.maggotgradiconnochop_0zt_icon

        loadCosplays()

    End Sub

    Private Sub fullSetup_Click(sender As Object, e As EventArgs) Handles fullSetup.Click
        Dim hooked As Boolean
        'Hook
        If processScan("DARK SOULS", True) Then
            If (ReadUInt32(&H400080) = &HFC293654&) Then
                isHooked = True
                hooked = True

                'Setup
                modifiedHitFunct = VirtualAllocEx(targetProcessHandle, 0, &H1000, 8192, &H40)
                VirtualAllocEx(targetProcessHandle, modifiedHitFunct, &H1000, 4096, &H40)
                lastHitPtr = modifiedHitFunct + &H50

                Dim oldInstructions() As Byte = {&HE9, 0, 0, 0, 0, &H90, &H90, &H90}
                Dim newInstructions() As Byte = {&H89, &H1D, 0, 0, 0, 0,
                                                &H8B, &H3, &H8B, &H90, &H14, &H3, &H0, &H0,
                                                &HE9, 0, 0, 0, 0}
                Dim firstJumpAddress() As Byte
                Dim lastHitPtrAddress() As Byte
                Dim returnAddress() As Byte

                firstJumpAddress = BitConverter.GetBytes(modifiedHitFunct - &HE80247)
                lastHitPtrAddress = BitConverter.GetBytes(modifiedHitFunct + &H50)
                returnAddress = BitConverter.GetBytes((&HFFFFFFFF - ((modifiedHitFunct + 14) - &HE80247)) + 1)

                Array.Copy(firstJumpAddress, 0, oldInstructions, 1, 4)
                Array.Copy(lastHitPtrAddress, 0, newInstructions, 2, 4)
                Array.Copy(returnAddress, 0, newInstructions, 15, 4)

                WriteProcessMemory(targetProcessHandle, modifiedHitFunct, newInstructions, newInstructions.Length, 0)
                WriteProcessMemory(targetProcessHandle, &HE80242, oldInstructions, oldInstructions.Length, 0)

                isSetup = True

                'Calibration
                isCalibrated = True
                fullSetup.Text = "Hooked!"
            End If
        End If
        If Not hooked Then
            MessageBox.Show("Hooking to Dark Souls failed. Make sure Dark Souls has started, then try again.")
        End If
    End Sub

    Private Sub UnhookButton_Click(sender As Object, e As EventArgs) Handles UnhookButton.Click
        If isHooked = False Then
            Exit Sub
        End If
        Dim originalInstructions() As Byte = {&H8B, &H3, &H8B, &H90, &H14, &H3, &H0, &H0}
        WriteProcessMemory(targetProcessHandle, &HE80242, originalInstructions, originalInstructions.Length, 0)
        VirtualFreeEx(targetProcessHandle, modifiedHitFunct, &H1000, &H8000)
        fullSetup.Text = "HOOK"
        isHooked = False
        isSetup = False
        isCalibrated = False
    End Sub

    Private Sub CosplayEditor_Click(sender As Object, e As EventArgs) Handles CosplayEditor.Click
        Dim editor = New CosplayEditor(Me)
        editor.Show()
    End Sub

    Private Sub refreshing() Handles refreshTimer.Tick
        If isCalibrated Then
            getLastHitID()
            'If validityCheck Is {&H63} Then
            latestHit = Val(System.Text.Encoding.Unicode.GetString(lastHit))
            'entityName.Text = System.Text.Encoding.Unicode.GetString(lastHit)
            If latestHit <> previousHit Then
                ReadProcessMemory(targetProcessHandle, (pointerToAddress(lastHitPtr) + 56), validityCheck, 1, vbNull)
                If Convert.ToChar(validityCheck(0)) = "c" Then
                    onHit()
                End If
            End If
        End If
        autoStats = autoLevel.Checked
        autoLvlGear = autoGear.Checked
    End Sub

    Public Sub loadCosplays()
        Dim cosplayList = My.Resources.cosplays.Split(Chr(&HA))
        For i = 0 To cosplayList.Length - 1
            Dim cosplayLine(16) As Integer
            For n = 0 To 16
                cosplayLine(n) = (Convert.ToInt32(cosplayList(i).Split(":")(n)))
            Next
            cosplayHash.Add(cosplayLine(0), cosplayLine)
        Next
    End Sub

    Public Sub getLastHitID()
        fullAddress = pointerToAddress(lastHitPtr)
        fullAddress = fullAddress + 58
        ReadProcessMemory(targetProcessHandle, fullAddress, lastHit, 8, vbNull)
        ReadProcessMemory(targetProcessHandle, fullAddress - 2, validityCheck, 1, vbNull)
    End Sub

    Public Sub onHit()
        currentCosplay = cosplayHash.Item(latestHit)
        setCosplay()
        previousHit = latestHit
    End Sub

    Public Sub setCosplay()
        setEquipment()
        If autoStats Then
            setStats()
        End If
    End Sub

    Public Sub setEquipment()
        Dim tempAddress = pointerToAddress(&H1378700)
        tempAddress = pointerToAddress(tempAddress + &H8)
        equipmentBase = pointerToAddress(tempAddress + &H318)

        'Helmet
        tempAddress = equipmentBase + &HB4
        If currentCosplay(1) <> 9876 Then
            If autoLvlGear Then
                WriteProcessMemory(targetProcessHandle, tempAddress, BitConverter.GetBytes(currentCosplay(1)), 4, 0)
            Else
                WriteProcessMemory(targetProcessHandle, tempAddress, (BitConverter.GetBytes((currentCosplay(1) \ 100) * 100)), 4, 0)
            End If
        End If

        'Armor
        tempAddress = equipmentBase + &HB8
        If currentCosplay(2) <> 9876 Then
            If autoLvlGear Then
                WriteProcessMemory(targetProcessHandle, tempAddress, BitConverter.GetBytes(currentCosplay(2)), 4, 0)
            Else
                WriteProcessMemory(targetProcessHandle, tempAddress, (BitConverter.GetBytes((currentCosplay(2) \ 100) * 100)), 4, 0)
            End If
        End If

            'Gauntlets
            tempAddress = equipmentBase + &HBC
        If currentCosplay(3) <> 9876 Then
            If autoLvlGear Then
                WriteProcessMemory(targetProcessHandle, tempAddress, BitConverter.GetBytes(currentCosplay(3)), 4, 0)
            Else
                WriteProcessMemory(targetProcessHandle, tempAddress, (BitConverter.GetBytes((currentCosplay(3) \ 100) * 100)), 4, 0)
            End If
        End If

            'Leggings
            tempAddress = equipmentBase + &HC0
        If currentCosplay(4) <> 9876 Then
            If autoLvlGear Then
                WriteProcessMemory(targetProcessHandle, tempAddress, BitConverter.GetBytes(currentCosplay(4)), 4, 0)
            Else
                WriteProcessMemory(targetProcessHandle, tempAddress, (BitConverter.GetBytes((currentCosplay(4) \ 100) * 100)), 4, 0)
            End If
        End If

            'L1
            tempAddress = equipmentBase + &H94
        If currentCosplay(5) <> 9876 Then
            If autoLvlGear Then
                WriteProcessMemory(targetProcessHandle, tempAddress, BitConverter.GetBytes(currentCosplay(5)), 4, 0)
            Else
                WriteProcessMemory(targetProcessHandle, tempAddress, (BitConverter.GetBytes((currentCosplay(5) \ 100) * 100)), 4, 0)
            End If
        End If

            'R1
            tempAddress = equipmentBase + &H98
        If currentCosplay(6) <> 9876 Then
            If autoLvlGear Then
                WriteProcessMemory(targetProcessHandle, tempAddress, BitConverter.GetBytes(currentCosplay(6)), 4, 0)
            Else
                WriteProcessMemory(targetProcessHandle, tempAddress, (BitConverter.GetBytes((currentCosplay(6) \ 100) * 100)), 4, 0)
            End If
        End If

            'L2
            tempAddress = equipmentBase + &HA0
        If currentCosplay(7) <> 9876 Then
            If autoLvlGear Then
                WriteProcessMemory(targetProcessHandle, tempAddress, BitConverter.GetBytes(currentCosplay(7)), 4, 0)
            Else
                WriteProcessMemory(targetProcessHandle, tempAddress, (BitConverter.GetBytes((currentCosplay(7) \ 100) * 100)), 4, 0)
            End If
        End If

            'R2
            tempAddress = equipmentBase + &H9C
        If currentCosplay(8) <> 9876 Then
            If autoLvlGear Then
                WriteProcessMemory(targetProcessHandle, tempAddress, BitConverter.GetBytes(currentCosplay(8)), 4, 0)
            Else
                WriteProcessMemory(targetProcessHandle, tempAddress, (BitConverter.GetBytes(currentCosplay(8) \ 100 * 100)), 4, 0)
            End If
        End If
    End Sub

    Private Sub setStats()
        Dim tempAddress = pointerToAddress(&H1378700)
        statBase = pointerToAddress(tempAddress + &H8)

        'VIT
        tempAddress = statBase + &H38
        WriteProcessMemory(targetProcessHandle, tempAddress, BitConverter.GetBytes(currentCosplay(9)), 4, 0)

        'ATN
        tempAddress = statBase + &H40
        WriteProcessMemory(targetProcessHandle, tempAddress, BitConverter.GetBytes(currentCosplay(10)), 4, 0)

        'END
        tempAddress = statBase + &H48
        WriteProcessMemory(targetProcessHandle, tempAddress, BitConverter.GetBytes(currentCosplay(11)), 4, 0)

        'STR
        tempAddress = statBase + &H50
        WriteProcessMemory(targetProcessHandle, tempAddress, BitConverter.GetBytes(currentCosplay(12)), 4, 0)

        'DEX
        tempAddress = statBase + &H58
        WriteProcessMemory(targetProcessHandle, tempAddress, BitConverter.GetBytes(currentCosplay(13)), 4, 0)

        'RES
        tempAddress = statBase + &H80
        WriteProcessMemory(targetProcessHandle, tempAddress, BitConverter.GetBytes(currentCosplay(14)), 4, 0)

        'INT
        tempAddress = statBase + &H60
        WriteProcessMemory(targetProcessHandle, tempAddress, BitConverter.GetBytes(currentCosplay(15)), 4, 0)

        'FTH
        tempAddress = statBase + &H68
        WriteProcessMemory(targetProcessHandle, tempAddress, BitConverter.GetBytes(currentCosplay(16)), 4, 0)
    End Sub
End Class