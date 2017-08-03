'Author: CoelyPuffs

Public Class CosplayEditor

    Dim cosplayFile = My.Resources.emptyCosplays
    Dim cosplayFileName As String
    Dim externalPath As String

    Dim isExternal As Boolean = False

    'Dim editorCosplayHash As New Hashtable
    Public allCosplaysArray(136) As Array
    Dim entityIDArray(137) As Integer
    Dim entityNameArray(137) As String
    Dim helmetIDArray(72) As Integer
    Dim helmetNameArray(72) As String
    Dim armorIDArray(60) As Integer
    Dim armorNameArray(60) As String
    Dim gauntletIDArray(56) As Integer
    Dim gauntletNameArray(56) As String
    Dim leggingIDArray(60) As Integer
    Dim leggingNameArray(60) As String
    Dim weaponIDArray(185) As Integer
    Dim weaponNameArray(185) As String
    Public isApplied As Boolean = False

    Private WithEvents editorTimer As New System.Windows.Forms.Timer()

    Public Sub New(mainWindow As CosplaySouls)
        InitializeComponent()
    End Sub

    Private Sub CosplayEditor_Load(Sender As Object, e As EventArgs) Handles MyBase.Load
        editorLoadCosplays()
        editorLoadDualLists()
    End Sub

    Public Sub editorLoadCosplays()
        If isExternal Then
            cosplayFile = My.Computer.FileSystem.ReadAllText(cosplayFileName)
        End If
        Dim editorCosplayList = cosplayFile.Split(Chr(&HA))
        For i = 0 To editorCosplayList.Length - 1
            Dim editorCosplayLine(16) As Integer
            For n = 0 To 16
                editorCosplayLine(n) = (Convert.ToInt32(editorCosplayList(i).Split(":")(n)))
            Next
            allCosplaysArray(i) = editorCosplayLine
            CosplaySouls.cosplayHash.Item(editorCosplayLine(0)) = editorCosplayLine
            'editorCosplayHash.Add(editorCosplayLine(0), editorCosplayLine)
        Next
    End Sub

    Public Sub editorLoadDualLists()
        For i = 0 To My.Resources.entities.Split(Chr(&HA)).Length - 1
            entityIDArray(i) = Convert.ToInt32(My.Resources.entities.Split(Chr(&HA))(i).Split(":")(0))
            entityNameArray(i) = My.Resources.entities.Split(Chr(&HA))(i).Split(":")(1)
        Next
        For i = 0 To My.Resources.helmets.Split(Chr(&HA)).Length - 1
            helmetIDArray(i) = Convert.ToInt32(My.Resources.helmets.Split(Chr(&HA))(i).Split(":")(0))
            helmetNameArray(i) = My.Resources.helmets.Split(Chr(&HA))(i).Split(":")(1)
        Next
        For i = 0 To My.Resources.armors.Split(Chr(&HA)).Length - 1
            armorIDArray(i) = Convert.ToInt32(My.Resources.armors.Split(Chr(&HA))(i).Split(":")(0))
            armorNameArray(i) = My.Resources.armors.Split(Chr(&HA))(i).Split(":")(1)
        Next
        For i = 0 To My.Resources.gauntlets.Split(Chr(&HA)).Length - 1
            gauntletIDArray(i) = Convert.ToInt32(My.Resources.gauntlets.Split(Chr(&HA))(i).Split(":")(0))
            gauntletNameArray(i) = My.Resources.gauntlets.Split(Chr(&HA))(i).Split(":")(1)
        Next
        For i = 0 To My.Resources.leggings.Split(Chr(&HA)).Length - 1
            leggingIDArray(i) = Convert.ToInt32(My.Resources.leggings.Split(Chr(&HA))(i).Split(":")(0))
            leggingNameArray(i) = My.Resources.leggings.Split(Chr(&HA))(i).Split(":")(1)
        Next
        For i = 0 To My.Resources.weapons.Split(Chr(&HA)).Length - 1
            weaponIDArray(i) = Convert.ToInt32(My.Resources.weapons.Split(Chr(&HA))(i).Split(":")(0))
            weaponNameArray(i) = My.Resources.weapons.Split(Chr(&HA))(i).Split(":")(1)
        Next
    End Sub

    Private Sub onEntityBoxChanged() Handles entityBox.SelectedIndexChanged
        Dim selectedLine = allCosplaysArray(entityBox.SelectedIndex)
        Dim currentData() = analyzeName(selectedLine(1), False)
        helmetName.SelectedIndex = Array.IndexOf(helmetIDArray, currentData(0))
        helmetLevel.SelectedIndex = currentData(2)
        currentData = analyzeName(selectedLine(2), False)
        armorName.SelectedIndex = Array.IndexOf(armorIDArray, currentData(0))
        armorLevel.SelectedIndex = currentData(2)
        currentData = analyzeName(selectedLine(3), False)
        gauntletsName.SelectedIndex = Array.IndexOf(gauntletIDArray, currentData(0))
        gauntletsLevel.SelectedIndex = currentData(2)
        currentData = analyzeName(selectedLine(4), False)
        leggingsName.SelectedIndex = Array.IndexOf(leggingIDArray, currentData(0))
        leggingsLevel.SelectedIndex = currentData(2)
        currentData = analyzeName(selectedLine(5), True)
        leftOneName.SelectedIndex = Array.IndexOf(weaponIDArray, currentData(0))
        leftOneInfusion.SelectedIndex = currentData(1)
        leftOneLevel.SelectedIndex = currentData(2)
        currentData = analyzeName(selectedLine(6), True)
        rightOneName.SelectedIndex = Array.IndexOf(weaponIDArray, currentData(0))
        rightOneInfusion.SelectedIndex = currentData(1)
        rightOneLevel.SelectedIndex = currentData(2)
        currentData = analyzeName(selectedLine(7), True)
        leftTwoName.SelectedIndex = Array.IndexOf(weaponIDArray, currentData(0))
        leftTwoInfusion.SelectedIndex = currentData(1)
        LeftTwoLevel.SelectedIndex = currentData(2)
        currentData = analyzeName(selectedLine(8), True)
        rightTwoName.SelectedIndex = Array.IndexOf(weaponIDArray, currentData(0))
        rightTwoInfusion.SelectedIndex = currentData(1)
        rightTwoLevel.SelectedIndex = currentData(2)
        If selectedLine(9) = 9876 Then
            noChangeStats.Checked = True
        Else
            noChangeStats.Checked = False
            vitSet.Value = selectedLine(9)
            atnSet.Value = selectedLine(10)
            endSet.Value = selectedLine(11)
            strSet.Value = selectedLine(12)
            dexSet.Value = selectedLine(13)
            resSet.Value = selectedLine(14)
            intSet.Value = selectedLine(15)
            fthSet.Value = selectedLine(16)
        End If
    End Sub

    Private Function analyzeName(name As Integer, hasInfusion As Boolean) As Integer()
        Dim returnNums() As Integer = {0, 0, 0}
        If name <> 9876 Then
            returnNums(0) = (name \ 1000) * 1000
            If hasInfusion Then
                returnNums(1) = (name \ 100) - ((name \ 1000) * 10)
            Else
                returnNums(1) = 9876
            End If
            returnNums(2) = name - ((name \ 100) * 100)
        Else
            returnNums(0) = 9876
            returnNums(1) = 0
            returnNums(2) = 0
        End If
        Return returnNums
    End Function

    Private Sub applyButton_Click(sender As Object, e As EventArgs) Handles applyButton.Click
        If entityBox.SelectedIndex < 0 Then
            Exit Sub
        End If
        Dim applyLine(17) As Integer
        applyLine(0) = entityIDArray(entityBox.SelectedIndex + 1)
        applyLine(1) = helmetIDArray(helmetName.SelectedIndex) + helmetLevel.SelectedIndex
        applyLine(2) = armorIDArray(armorName.SelectedIndex) + armorLevel.SelectedIndex
        applyLine(3) = gauntletIDArray(gauntletsName.SelectedIndex) + gauntletsLevel.SelectedIndex
        applyLine(4) = leggingIDArray(leggingsName.SelectedIndex) + leggingsLevel.SelectedIndex
        If leftOneName.SelectedIndex > 0 Then
            applyLine(5) = (weaponIDArray(leftOneName.SelectedIndex) + (leftOneInfusion.SelectedIndex * 100) + leftOneLevel.SelectedIndex)
        Else
            applyLine(5) = 9876
        End If
        If rightOneName.SelectedIndex > 0 Then
            applyLine(6) = (weaponIDArray(rightOneName.SelectedIndex) + (rightOneInfusion.SelectedIndex * 100) + rightOneLevel.SelectedIndex)
        Else
            applyLine(6) = 9876
        End If
        If leftTwoName.SelectedIndex > 0 Then
            applyLine(7) = (weaponIDArray(leftTwoName.SelectedIndex) + (leftTwoInfusion.SelectedIndex * 100) + LeftTwoLevel.SelectedIndex)
        Else
            applyLine(7) = 9876
        End If
        If rightTwoName.SelectedIndex > 0 Then
            applyLine(8) = (weaponIDArray(rightTwoName.SelectedIndex) + (rightTwoInfusion.SelectedIndex * 100) + rightTwoLevel.SelectedIndex)
        Else
            applyLine(8) = 9876
        End If

        If noChangeStats.Checked Then
            For i = 9 To 16
                applyLine(i) = 9876
            Next
        Else
            applyLine(9) = vitSet.Value
            applyLine(10) = atnSet.Value
            applyLine(11) = endSet.Value
            applyLine(12) = strSet.Value
            applyLine(13) = dexSet.Value
            applyLine(14) = resSet.Value
            applyLine(15) = intSet.Value
            applyLine(16) = fthSet.Value
        End If
        allCosplaysArray(entityBox.SelectedIndex) = applyLine
        CosplaySouls.cosplayHash.Item(applyLine(0)) = applyLine
        MessageBox.Show("Applied!")
    End Sub

    Private Function makeCurrentString(applyLine() As Integer) As String
        Dim currentString = applyLine(0).ToString + ":"
        For i = 1 To 15
            currentString = currentString + applyLine(i).ToString + ":"
        Next
        currentString = currentString + applyLine(16).ToString
        Return currentString
    End Function

    Private Sub externalButton_Click(sender As Object, e As EventArgs) Handles exportButton.Click
        Dim Export As New SaveFileDialog()
        Export.InitialDirectory = "C:\"
        Export.Filter = "txt files (*.txt)|*.txt"
        Export.FilterIndex = 1
        Export.RestoreDirectory = True
        If Export.ShowDialog() = DialogResult.OK Then
            externalPath = Export.FileName
            Dim currentString = makeCurrentString(allCosplaysArray(0))
            My.Computer.FileSystem.WriteAllText(externalPath, currentString, False)
            For i = 1 To 136
                currentString = makeCurrentString(allCosplaysArray(i))
                My.Computer.FileSystem.WriteAllText(externalPath, Environment.NewLine, True)
                My.Computer.FileSystem.WriteAllText(externalPath, currentString, True)
            Next
        End If
    End Sub

    Private Sub importButton_Click(sender As Object, e As EventArgs) Handles importButton.Click
        Dim Import As New OpenFileDialog()
        Import.InitialDirectory = "C:\"
        Import.Filter = "txt files (*.txt)|*.txt"
        Import.FilterIndex = 1
        Import.RestoreDirectory = True
        If Import.ShowDialog() = DialogResult.OK Then
            If Dir(Import.FileName) <> "" Then
                cosplayFileName = Import.FileName
                isExternal = True
                editorLoadCosplays()
            Else
                MessageBox.Show("Error finding file")
            End If
        End If
    End Sub
End Class