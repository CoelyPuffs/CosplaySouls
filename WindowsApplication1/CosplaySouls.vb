'Author: CoelyPuffs

'Hooking function modified from Wulf2k's DaS-PC-Gizmo

Public Class CosplaySouls

    Private Declare Function OpenProcess Lib "kernel32.dll" (ByVal dwDesiredAccess As UInt32, ByVal bInheritHandle As Boolean, ByVal dwProcessID As Int32) As IntPtr
    Private Declare Function CloseHandle Lib "kernel32.dll" (ByVal hObject As IntPtr) As Boolean
    Private Declare Function ReadProcessMemory Lib "kernel32" (ByVal hProcess As IntPtr, ByVal lpBaseAddress As IntPtr, ByVal lpBuffer() As Byte, ByVal iSize As Integer, ByRef lpNumberOfBytesRead As Integer) As Boolean
    Public Declare Function WriteProcessMemory Lib "kernel32" (ByVal hProcess As IntPtr, ByVal lpBaseAddress As IntPtr, ByVal lpBuffer() As Byte, ByVal iSize As Integer, ByRef lpNumberOfBytesRead As Integer) As Boolean
    Private Declare Function VirtualAllocEx Lib "kernel32" (ByVal hProcess As IntPtr, ByVal lpAddress As IntPtr, ByVal dwSize As IntPtr, ByVal flAllocationType As Integer, ByVal flProtect As Integer) As IntPtr
    Private Declare Function VirtualFreeEx Lib "kernel32" (ByVal hProcess As IntPtr, ByVal lpAddress As IntPtr, ByVal dwSize As IntPtr, ByVal dwFreeType As Integer) As IntPtr

    Dim isHooked As Boolean = False
    Dim isSetup As Boolean = False
    Dim isCalibrated As Boolean = False
    Public Const processAllAccess = &H1F0FFF
    Private targetProcess As Process = Nothing
    Public targetProcessHandle As IntPtr = IntPtr.Zero
    Dim modifiedHitFunct As Integer
    Dim lastHitPtr As Integer
    'Dim lastHitBytes(3) As Byte
    Dim lastAtkPtr As Integer
    Dim lastHit() As Byte = {&H39, &H0, &H38, &H0, &H37, &H0, &H36, &H0}
    Dim lastAtk() As Byte = {&H39, &H0, &H38, &H0, &H37, &H0, &H36, &H0}
    Dim validityCheck() As Byte = {&H0}
    Dim entity = "Entity"
    Dim fullAddress As Integer
    Public cosplayHash As New Hashtable()
    Dim previousHit As Integer = 9876
    Dim latestHit As Integer = 9876
    Dim latestAtk As Integer = 9876
    Dim currentCosplay(21) As Integer
    'Dim equipmentBase As Integer
    Dim statBase As Integer
    Dim autoStats As Boolean
    Dim autoLvlGear As Boolean
    Dim cosplayList = My.Resources.T_H_I_C_C.Split(Chr(&HA))
    Dim entityList = My.Resources.entities.Split(Chr(&HA))
    Dim entityLine(183) As Integer
    Dim entityScale(183) As Double
    Dim helmetList = My.Resources.helmets.Split(Chr(&HA))
    Dim armorList = My.Resources.armors.Split(Chr(&HA))
    Dim gauntletList = My.Resources.gauntlets.Split(Chr(&HA))
    Dim leggingList = My.Resources.leggings.Split(Chr(&HA))
    Dim weaponList = My.Resources.weapons.Split(Chr(&HA))
    'Dim helmetWeights(73) As Double
    'Dim armorWeights(61) As Double
    'Dim gauntletWeights(56) As Double
    'Dim leggingWeights(60) As Double
    'Dim weaponWeights(185) As Double
    'Dim protectHash As New Hashtable
    'Dim weaponHash As New Hashtable
    Public vitalityConv(98) As Integer
    Public enduranceConv(98) As Integer
    Public statPtr As Integer
    'Dim modifiedLHFunct As Integer
    'Public leftHandPtr As Integer
    'Dim equipPtr As Integer
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
        loadEntities()
        loadVitEnd()
        'loadGear() obsolete because of index
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
                lastHitPtr = modifiedHitFunct + &H74
                lastAtkPtr = modifiedHitFunct + &H70

                'Dim oldInstructions() As Byte = {&HE9, 0, 0, 0, 0, &H90, &H90, &H90}
                'Dim newInstructions() As Byte = {&H89, &H1D, 0, 0, 0, 0,
                '                                &H8B, &H3, &H8B, &H90, &H14, &H3, &H0, &H0,
                '                                &HE9, 0, 0, 0, 0}
                Dim oldInstructions() As Byte = {&HE9, 0, 0, 0, 0, &H90}
                Dim newInstructions() As Byte = {&H89, &H35, 0, 0, 0, 0,
                                                 &H89, &H0D, 0, 0, 0, 0,
                                                 &H51,
                                                 &H56,
                                                 &H8B, &HF1,
                                                 &H8B, &H06,
                                                 &HE9, 0, 0, 0, 0}

                Dim firstJumpAddress() As Byte
                Dim lastHitPtrAddress() As Byte
                Dim lastAtkPtrAddress() As Byte
                Dim returnAddress() As Byte

                'firstJumpAddress = BitConverter.GetBytes(modifiedHitFunct - &HE80247)
                firstJumpAddress = BitConverter.GetBytes(modifiedHitFunct - &HE527C5)
                lastHitPtrAddress = BitConverter.GetBytes(modifiedHitFunct + &H70)
                lastAtkPtrAddress = BitConverter.GetBytes(modifiedHitFunct + &H74)
                'returnAddress = BitConverter.GetBytes((&HFFFFFFFF - ((modifiedHitFunct + 14) - &HE80247)) + 1)
                returnAddress = BitConverter.GetBytes((&HFFFFFFFF - ((modifiedHitFunct + 12) - &HE527C5)) - 9)

                Array.Copy(firstJumpAddress, 0, oldInstructions, 1, 4)
                Array.Copy(lastHitPtrAddress, 0, newInstructions, 2, 4)
                Array.Copy(lastAtkPtrAddress, 0, newInstructions, 8, 4)
                Array.Copy(returnAddress, 0, newInstructions, 19, 4)

                WriteProcessMemory(targetProcessHandle, modifiedHitFunct, newInstructions, newInstructions.Length, 0)
                'WriteProcessMemory(targetProcessHandle, &HE80242, oldInstructions, oldInstructions.Length, 0)
                WriteProcessMemory(targetProcessHandle, &HE527C0, oldInstructions, oldInstructions.Length, 0)

                'Vit/End Setup (statPtr now used for gear too)
                statPtr = modifiedHitFunct + &H80
                Dim statBaseAddress() As Byte

                Dim oldStatFunct() As Byte = {&HE9, 0, 0, 0, 0, &H90}
                Dim newStatFunct() As Byte = {&H89, &H35, 0, 0, 0, 0,
                                              &H8B, &HBE, &H8C, &H00, &H00, &H00,
                                              &HE9, 0, 0, 0, 0}

                firstJumpAddress = BitConverter.GetBytes(modifiedHitFunct + &H1F - &HBFC4B9)
                statBaseAddress = BitConverter.GetBytes(modifiedHitFunct + &H80)
                returnAddress = BitConverter.GetBytes((&HFFFFFFFF - ((modifiedHitFunct + &H2B) - &HBFC4B5)) + 1)

                Array.Copy(firstJumpAddress, 0, oldStatFunct, 1, 4)
                Array.Copy(statBaseAddress, 0, newStatFunct, 2, 4)
                Array.Copy(returnAddress, 0, newStatFunct, 13, 4)

                WriteProcessMemory(targetProcessHandle, (modifiedHitFunct + &H1F), newStatFunct, newStatFunct.Length(), 0)
                WriteProcessMemory(targetProcessHandle, &HBFC4B4, oldStatFunct, oldStatFunct.Length(), 0)

                'Infinite Durability Setup
                Dim oldDuraOneFunct() As Byte = {&HE9, &H00, &H00, &H00, &H00}
                Dim newDuraOneFunct() As Byte = {&H39, &H50, &H14,
                                                 &H0F, &H8E, &H03, &H00, &H00, &H00,
                                                 &H8B, &H50, &H14,
                                                 &H89, &H50, &H14,
                                                 &HB0, &H01,
                                                 &HE9, &H00, &H00, &H00, &H00}
                Dim oldDuraTwoFunct() As Byte = {&HE9, &H00, &H00, &H00, &H00, &H90}
                Dim newDuraTwoFunct() As Byte = {&H39, &H53, &H14,
                                                 &H0F, &H8E, &H03, &H00, &H00, &H00,
                                                 &H8B, &H53, &H14,
                                                 &H89, &H53, &H14,
                                                 &H3B, &H71, &H10,
                                                 &HE9, &H00, &H00, &H00, &H00}

                firstJumpAddress = BitConverter.GetBytes(modifiedHitFunct + &H30 - &HC08C4F)
                returnAddress = BitConverter.GetBytes((&HFFFFFFFF - ((modifiedHitFunct + &H41) - &HC08C4B)))

                Array.Copy(firstJumpAddress, 0, oldDuraOneFunct, 1, 4)
                Array.Copy(returnAddress, 0, newDuraOneFunct, &H12, 4)

                WriteProcessMemory(targetProcessHandle, (modifiedHitFunct + &H30), newDuraOneFunct, newDuraOneFunct.Length(), 0)
                WriteProcessMemory(targetProcessHandle, (&HC08C4A), oldDuraOneFunct, oldDuraOneFunct.Length(), 0)

                firstJumpAddress = BitConverter.GetBytes(modifiedHitFunct + &H50 - &HC08B92)
                returnAddress = BitConverter.GetBytes((&HFFFFFFFF - ((modifiedHitFunct + &H62) - &HC08BA0)))

                Array.Copy(firstJumpAddress, 0, oldDuraTwoFunct, 1, 4)
                Array.Copy(returnAddress, 0, newDuraTwoFunct, &H13, 4)

                WriteProcessMemory(targetProcessHandle, (modifiedHitFunct + &H50), newDuraTwoFunct, newDuraTwoFunct.Length(), 0)
                WriteProcessMemory(targetProcessHandle, (&HC08B8D), oldDuraTwoFunct, oldDuraTwoFunct.Length(), 0)

                isSetup = True

                'Calibration (has minor error somewhere, work was halted after discussion between CoelyPuffs and Mayfield about the value of permanent fastrolls
                'equipPtr = modifiedHitFunct + &H70
                'Dim equipBaseAddress() As Byte
                '
                'Dim oldEquipFunct() As Byte = {&HE9, &H00, &H00, &H00, &H00}
                'Dim newEquipFunct() As Byte = {&H89, &H35, &H00, &H00, &H00, &H00, &H51, &H8B, &H4E, &H04, &H51, &HE9, &H00, &H00, &H00, &H00}
                '
                'firstJumpAddress = BitConverter.GetBytes(modifiedHitFunct + &H2F - &HC67F45)
                'equipBaseAddress = BitConverter.GetBytes(modifiedHitFunct + &H70)
                'returnAddress = BitConverter.GetBytes((&HFFFFFFFF - ((modifiedHitFunct + &H3A) - &HC67F41)) + 1)
                '
                'WriteProcessMemory(targetProcessHandle, (modifiedHitFunct + &H2F), newEquipFunct, newEquipFunct.Length(), 0)
                'WriteProcessMemory(targetProcessHandle, &HC67F45, oldEquipFunct, oldEquipFunct.Length(), 0)

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
        'Dim originalInstructions() As Byte = {&H8B, &H3, &H8B, &H90, &H14, &H3, &H0, &H0}
        Dim originalHitFunct() As Byte = {&H51, &H56, &H8B, &HF1, &H8B, &H06}
        Dim originalStatFunct() As Byte = {&H8B, &HBE, &H8C, 0, 0, 0}
        Dim originalDuraOneFunct() As Byte = {&H89, &H50, &H14, &HB0, &H01}
        Dim originalDuraTwoFunct() As Byte = {&H89, &H53, &H14, &H3B, &H71, &H10}
        'WriteProcessMemory(targetProcessHandle, &HE80242, originalInstructions, originalInstructions.Length(), 0)
        WriteProcessMemory(targetProcessHandle, &HE527C0, originalHitFunct, originalHitFunct.Length(), 0)
        WriteProcessMemory(targetProcessHandle, &HBFC4B4, originalStatFunct, originalStatFunct.Length(), 0)
        WriteProcessMemory(targetProcessHandle, &H808C4A, originalDuraOneFunct, originalDuraOneFunct.Length(), 0)
        WriteProcessMemory(targetProcessHandle, &H808B8D, originalDuraTwoFunct, originalDuraTwoFunct.Length(), 0)
        VirtualFreeEx(targetProcessHandle, modifiedHitFunct, &H1000, &H8000)
        fullSetup.Text = "START"
        isHooked = False
        isSetup = False
        isCalibrated = False
    End Sub

    Private Sub CosplayEditor_Click(sender As Object, e As EventArgs) Handles CosplayEditor.Click
        Dim editor = New CosplayEditor(Me)
        editor.Show()
    End Sub

    Private Sub levelCheckChanged() Handles autoLevel.CheckStateChanged
        enemyScale.Enabled = autoLevel.Checked
        areaNormal.Enabled = autoLevel.Checked
        areaChallenge.Enabled = autoLevel.Checked
    End Sub

    Private Sub refreshing() Handles refreshTimer.Tick
        If isCalibrated Then
            getLastHitID()
            'If validityCheck Is {&H63} Then
            latestHit = Val(System.Text.Encoding.Unicode.GetString(lastHit))
            latestAtk = Val(System.Text.Encoding.Unicode.GetString(lastAtk))
            'entityName.Text = System.Text.Encoding.Unicode.GetString(lastHit)
            If latestHit <> previousHit Then
                ReadProcessMemory(targetProcessHandle, (pointerToAddress(lastHitPtr) + 56), validityCheck, 1, vbNull)
                If Convert.ToChar(validityCheck(0)) = "c" Then
                    If latestHit = 0 Then
                        fullAddress = pointerToAddress(lastHitPtr) + &H68
                        latestHit = ReadUInt32(fullAddress)
                        If latestHit < 6800 Then
                            latestHit = (latestHit \ 10) * 10
                        End If
                    End If
                    If Array.IndexOf(entityLine, latestHit) <> -1 And latestAtk = 0 Then
                        onHit()
                    End If
                End If
            End If
        End If
            autoStats = autoLevel.Checked
        autoLvlGear = autoGear.Checked
    End Sub

    Public Sub loadCosplays()
        'Dim cosplayList = My.Resources.basicCosplays.Split(Chr(&HA))
        For i = 0 To cosplayList.Length - 1
            Dim cosplayLine(22) As Integer
            For n = 0 To 16
                cosplayLine(n) = (Convert.ToInt32(cosplayList(i).Split(":")(n)))
            Next
            For n = 17 To 22
                cosplayLine(n) = (Convert.ToDouble(cosplayList(i).Split(":")(n)))
            Next
            cosplayHash.Add(cosplayLine(0), cosplayLine)
        Next
    End Sub

    Public Sub loadEntities()
        For i = 0 To entityList.Length - 1
            entityLine(i) = Convert.ToInt32(entityList(i).Split(":")(0))
            entityScale(i) = Convert.ToDouble(entityList(i).Split(":")(2))
        Next
    End Sub

    'Public Sub loadGear()
    '    For i = 0 To helmetList.Length - 1
    '        protectHash.Add(Convert.ToInt32(helmetList(i).Split(":")(0)), Convert.ToDouble(helmetList(i).Split(":")(3)))
    '    Next
    '    For i = 1 To armorList.Length - 1
    '        protectHash.Add(Convert.ToInt32(armorList(i).Split(":")(0)), Convert.ToDouble(armorList(i).Split(":")(3)))
    '    Next
    '    For i = 1 To gauntletList.Length - 1
    '        protectHash.Add(Convert.ToInt32(gauntletList(i).Split(":")(0)), Convert.ToDouble(gauntletList(i).Split(":")(3)))
    '    Next
    '    For i = 1 To leggingList.Length - 1
    '        protectHash.Add(Convert.ToInt32(leggingList(i).Split(":")(0)), Convert.ToDouble(leggingList(i).Split(":")(3)))
    '    Next
    '    For i = 0 To weaponList.Length - 1
    '        weaponHash.Add(Convert.ToInt32(weaponList(i).Split(":")(0)), Convert.ToDouble(weaponList(i).Split(":")(3)))
    '    Next
    'End Sub

    Public Sub loadVitEnd()
        For i = 0 To 98
            vitalityConv(i) = Convert.ToInt32(My.Resources.vitality.Split(Chr(&HA))(i))
            enduranceConv(i) = Convert.ToInt32(My.Resources.endurance.Split(Chr(&HA))(i))
        Next
    End Sub

    Public Sub getLastHitID()
        fullAddress = pointerToAddress(lastHitPtr)
        fullAddress = fullAddress + 58
        ReadProcessMemory(targetProcessHandle, fullAddress, lastHit, 8, vbNull)
        'ReadProcessMemory(targetProcessHandle, fullAddress - 2, validityCheck, 1, vbNull)
        fullAddress = pointerToAddress(lastAtkPtr)
        fullAddress = fullAddress + 58
        ReadProcessMemory(targetProcessHandle, fullAddress, lastAtk, 8, vbNull)
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
        setProportions()
    End Sub

    Public Sub setEquipment()

        'Helmet
        Dim tempAddress = pointerToAddress(statPtr) + &H26C
        If currentCosplay(1) <> 9876 Then
            If autoLvlGear Then
                Dim temp1 = targetProcessHandle
                Dim temp2 = tempAddress
                Dim temp3 = BitConverter.GetBytes(currentCosplay(1))
                WriteProcessMemory(targetProcessHandle, tempAddress, temp3, 4, 0)
            Else
                WriteProcessMemory(targetProcessHandle, tempAddress, (BitConverter.GetBytes((currentCosplay(1) \ 100) * 100)), 4, 0)
            End If
        End If

        'Armor
        tempAddress = pointerToAddress(statPtr) + &H270
        If currentCosplay(2) <> 9876 Then
            If autoLvlGear Then
                WriteProcessMemory(targetProcessHandle, tempAddress, BitConverter.GetBytes(currentCosplay(2)), 4, 0)
            Else
                WriteProcessMemory(targetProcessHandle, tempAddress, (BitConverter.GetBytes((currentCosplay(2) \ 100) * 100)), 4, 0)
            End If
        End If

        'Gauntlets
        tempAddress = pointerToAddress(statPtr) + &H274
        If currentCosplay(3) <> 9876 Then
            If autoLvlGear Then
                WriteProcessMemory(targetProcessHandle, tempAddress, BitConverter.GetBytes(currentCosplay(3)), 4, 0)
            Else
                WriteProcessMemory(targetProcessHandle, tempAddress, (BitConverter.GetBytes((currentCosplay(3) \ 100) * 100)), 4, 0)
            End If
        End If

        'Leggings
        tempAddress = pointerToAddress(statPtr) + &H278
        If currentCosplay(4) <> 9876 Then
            If autoLvlGear Then
                WriteProcessMemory(targetProcessHandle, tempAddress, BitConverter.GetBytes(currentCosplay(4)), 4, 0)
            Else
                WriteProcessMemory(targetProcessHandle, tempAddress, (BitConverter.GetBytes((currentCosplay(4) \ 100) * 100)), 4, 0)
            End If
        End If

        'L1
        tempAddress = pointerToAddress(statPtr) + &H24C
        If currentCosplay(5) <> 9876 Then
            If autoLvlGear Then
                WriteProcessMemory(targetProcessHandle, tempAddress, BitConverter.GetBytes(currentCosplay(5)), 4, 0)
            Else
                WriteProcessMemory(targetProcessHandle, tempAddress, (BitConverter.GetBytes((currentCosplay(5) \ 100) * 100)), 4, 0)
            End If
        End If

        'R1
        tempAddress = pointerToAddress(statPtr) + &H250
        If currentCosplay(6) <> 9876 Then
            If autoLvlGear Then
                WriteProcessMemory(targetProcessHandle, tempAddress, BitConverter.GetBytes(currentCosplay(6)), 4, 0)
            Else
                WriteProcessMemory(targetProcessHandle, tempAddress, (BitConverter.GetBytes((currentCosplay(6) \ 100) * 100)), 4, 0)
            End If
        End If

        'L2
        tempAddress = pointerToAddress(statPtr) + &H254
        If currentCosplay(7) <> 9876 Then
            If autoLvlGear Then
                WriteProcessMemory(targetProcessHandle, tempAddress, BitConverter.GetBytes(currentCosplay(7)), 4, 0)
            Else
                WriteProcessMemory(targetProcessHandle, tempAddress, (BitConverter.GetBytes((currentCosplay(7) \ 100) * 100)), 4, 0)
            End If
        End If

        'R2
        tempAddress = pointerToAddress(statPtr) + &H258
        If currentCosplay(8) <> 9876 Then
            If autoLvlGear Then
                WriteProcessMemory(targetProcessHandle, tempAddress, BitConverter.GetBytes(currentCosplay(8)), 4, 0)
            Else
                WriteProcessMemory(targetProcessHandle, tempAddress, (BitConverter.GetBytes(currentCosplay(8) \ 100 * 100)), 4, 0)
            End If
        End If
    End Sub

    Private Sub setStats()
        If currentCosplay(9) = 9876 Then
            Exit Sub
        End If

        Dim tempAddress = pointerToAddress(&H1378700)
        statBase = pointerToAddress(tempAddress + &H8)
        Dim hpStamBase = pointerToAddress(statPtr)

        'VIT
        tempAddress = pointerToAddress(statPtr) + &H38
        Dim vit As Integer
        If areaNormal.Checked Then
            vit = (entityScale(Array.IndexOf(entityLine, latestHit)) * 30) + 10
        ElseIf areaChallenge.Checked Then
            vit = (entityScale(Array.IndexOf(entityLine, latestHit)) * 15) + 5
        Else
            vit = currentCosplay(9)
        End If
        WriteProcessMemory(targetProcessHandle, (hpStamBase + &H14), BitConverter.GetBytes(vitalityConv(vit - 1)), 4, 0)
        WriteProcessMemory(targetProcessHandle, tempAddress, BitConverter.GetBytes(vit), 4, 0)

        'ATN
        tempAddress = pointerToAddress(statPtr) + &H40
        WriteProcessMemory(targetProcessHandle, tempAddress, BitConverter.GetBytes(currentCosplay(10)), 4, 0)

        'END
        tempAddress = pointerToAddress(statPtr) + &H48
        Dim endurance As Integer
        If areaNormal.Checked Then
            endurance = (entityScale(Array.IndexOf(entityLine, latestHit)) * 30) + 10
        ElseIf areaChallenge.Checked Then
            endurance = (entityScale(Array.IndexOf(entityLine, latestHit)) * 20) + 10
        Else
            endurance = currentCosplay(11)
        End If
        WriteProcessMemory(targetProcessHandle, (hpStamBase + &H30), BitConverter.GetBytes(enduranceConv(endurance - 1)), 4, 0)
        WriteProcessMemory(targetProcessHandle, tempAddress, BitConverter.GetBytes(endurance), 4, 0)

        'STR
        tempAddress = pointerToAddress(statPtr) + &H50
        WriteProcessMemory(targetProcessHandle, tempAddress, BitConverter.GetBytes(currentCosplay(12)), 4, 0)

        'DEX
        tempAddress = pointerToAddress(statPtr) + &H58
        WriteProcessMemory(targetProcessHandle, tempAddress, BitConverter.GetBytes(currentCosplay(13)), 4, 0)

        'RES
        tempAddress = pointerToAddress(statPtr) + &H80
        WriteProcessMemory(targetProcessHandle, tempAddress, BitConverter.GetBytes(currentCosplay(14)), 4, 0)

        'INT
        tempAddress = pointerToAddress(statPtr) + &H60
        WriteProcessMemory(targetProcessHandle, tempAddress, BitConverter.GetBytes(currentCosplay(15)), 4, 0)

        'FTH
        tempAddress = pointerToAddress(statPtr) + &H68
        WriteProcessMemory(targetProcessHandle, tempAddress, BitConverter.GetBytes(currentCosplay(16)), 4, 0)
    End Sub

    Private Sub setSpells()
        Dim spellPtr = pointerToAddress(pointerToAddress(statPtr) + &H30C)
        Dim tempAddress As Integer

        'Spell 1
        If (currentCosplay(23) <> 9876) Then
            tempAddress = spellPtr + &HC
            WriteProcessMemory(targetProcessHandle, tempAddress, BitConverter.GetBytes(currentCosplay(23)), 4, 0)
            tempAddress = spellPtr + &H10
            WriteProcessMemory(targetProcessHandle, tempAddress, BitConverter.GetBytes(currentCosplay(24) * 3), 4, 0)
        End If

        'Spell 2
        If (currentCosplay(25) <> 9876) Then
            tempAddress = spellPtr + &H14
            WriteProcessMemory(targetProcessHandle, tempAddress, BitConverter.GetBytes(currentCosplay(25)), 4, 0)
            tempAddress = spellPtr + &H18
            WriteProcessMemory(targetProcessHandle, tempAddress, BitConverter.GetBytes(currentCosplay(26) * 3), 4, 0)
        End If

        'Spell 3
        If (currentCosplay(27) <> 9876) Then
            tempAddress = spellPtr + &H1C
            WriteProcessMemory(targetProcessHandle, tempAddress, BitConverter.GetBytes(currentCosplay(27)), 4, 0)
            tempAddress = spellPtr + &H20
            WriteProcessMemory(targetProcessHandle, tempAddress, BitConverter.GetBytes(currentCosplay(28) * 3), 4, 0)
        End If

        'Spell 4
        If (currentCosplay(29) <> 9876) Then
            tempAddress = spellPtr + &H24
            WriteProcessMemory(targetProcessHandle, tempAddress, BitConverter.GetBytes(currentCosplay(29)), 4, 0)
            tempAddress = spellPtr + &H28
            WriteProcessMemory(targetProcessHandle, tempAddress, BitConverter.GetBytes(currentCosplay(30) * 3), 4, 0)
        End If

        'Spell 5
        If (currentCosplay(31) <> 9876) Then
            tempAddress = spellPtr + &H2C
            WriteProcessMemory(targetProcessHandle, tempAddress, BitConverter.GetBytes(currentCosplay(31)), 4, 0)
            tempAddress = spellPtr + &H20
            WriteProcessMemory(targetProcessHandle, tempAddress, BitConverter.GetBytes(currentCosplay(32) * 3), 4, 0)
        End If

    End Sub

    Private Sub setProportions()
        Dim tempAddress = pointerToAddress(&H1378700)
        Dim proportionBase = pointerToAddress(tempAddress + &H8)
        Dim tempBytes() As Byte
        Dim proportionSingle As Single

        'Head Proportion
        tempAddress = proportionBase + &H2AC
        proportionSingle = currentCosplay(17) / 2
        tempBytes = BitConverter.GetBytes(proportionSingle)
        WriteProcessMemory(targetProcessHandle, tempAddress, tempBytes, 4, 0)

        'Chest Proportion
        tempAddress = proportionBase + &H2B0
        proportionSingle = currentCosplay(18) / 2
        tempBytes = BitConverter.GetBytes(proportionSingle)
        WriteProcessMemory(targetProcessHandle, tempAddress, tempBytes, 4, 0)

        'Abdomen Proportion
        tempAddress = proportionBase + &H2B4
        proportionSingle = currentCosplay(19) / 2
        tempBytes = BitConverter.GetBytes(proportionSingle)
        WriteProcessMemory(targetProcessHandle, tempAddress, tempBytes, 4, 0)

        'Arm Proportion
        tempAddress = proportionBase + &H2B8
        proportionSingle = currentCosplay(20) / 2
        tempBytes = BitConverter.GetBytes(proportionSingle)
        WriteProcessMemory(targetProcessHandle, tempAddress, tempBytes, 4, 0)

        'Leg Proportion
        tempAddress = proportionBase + &H2BC
        proportionSingle = currentCosplay(21) / 2
        tempBytes = BitConverter.GetBytes(proportionSingle)
        WriteProcessMemory(targetProcessHandle, tempAddress, tempBytes, 4, 0)

        'Speed Modifier
        tempAddress = pointerToAddress(&H12E29E8)
        tempAddress = pointerToAddress(tempAddress)
        tempAddress = pointerToAddress(tempAddress + &H28)
        tempAddress = pointerToAddress(tempAddress + &H14)
        tempAddress = tempAddress + &H64
        proportionSingle = currentCosplay(22) / 10
        tempBytes = BitConverter.GetBytes(proportionSingle)
        WriteProcessMemory(targetProcessHandle, tempAddress, tempBytes, 4, 0)
    End Sub
End Class