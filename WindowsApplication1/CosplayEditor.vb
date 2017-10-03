'Author: CoelyPuffs

Public Class CosplayEditor

    Dim cosplayFile = My.Resources.emptyCosplays
    Dim cosplayFileName As String
    Dim externalPath As String

    Dim isExternal As Boolean = False

    'Dim editorCosplayHash As New Hashtable
    Public allCosplaysArray(217) As Array
    Dim entityIDArray(217) As Integer
    Dim entityNameArray(217) As String
    Dim helmetIDArray(72) As Integer
    Dim helmetNameArray(72) As String
    Dim helmetLimitArray(72) As Integer
    Dim armorIDArray(60) As Integer
    Dim armorNameArray(60) As String
    Dim armorLimitArray(60) As Integer
    Dim gauntletIDArray(56) As Integer
    Dim gauntletNameArray(56) As String
    Dim gauntletLimitArray(56) As Integer
    Dim leggingIDArray(60) As Integer
    Dim leggingNameArray(60) As String
    Dim leggingLimitArray(60) As Integer
    Dim weaponIDArray(185) As Integer
    Dim weaponNameArray(185) As String
    Dim weaponLimitArray(185) As Integer
    Dim spellIDArray(74) As Integer
    Dim spellNameArray(74) As String
    Dim isApplied As Boolean = True
    Dim isExported As Boolean = True

    Private WithEvents editorTimer As New System.Windows.Forms.Timer()

    Public Sub New(mainWindow As CosplaySouls)
        InitializeComponent()
    End Sub

    Private Sub CosplayEditor_Load(Sender As Object, e As EventArgs) Handles MyBase.Load
        editorLoadCosplays()
        editorLoadDualLists()
    End Sub

    Private Sub editorClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Not isExported Then
            If (MessageBox.Show("Your cosplays must be exported to be saved. Are you sure you want to close?", "Unsaved Work!", MessageBoxButtons.YesNo) = DialogResult.No) Then
                e.Cancel = True
            End If
        End If
    End Sub

    Public Sub editorLoadCosplays()
        If isExternal Then
            cosplayFile = My.Computer.FileSystem.ReadAllText(cosplayFileName)
        End If
        Dim editorCosplayList = cosplayFile.Split(Chr(&HA))
        For i = 0 To editorCosplayList.Length - 1
            Dim editorCosplayLine(32) As Integer
            For n = 0 To 16
                editorCosplayLine(n) = (Convert.ToInt32(editorCosplayList(i).Split(":")(n)))
            Next
            For n = 17 To 22
                editorCosplayLine(n) = (Convert.ToDouble(editorCosplayList(i).Split(":")(n)))
            Next
            For n = 23 To 32
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
            helmetLimitArray(i) = My.Resources.helmets.Split(Chr(&HA))(i).Split(":")(2)
        Next
        For i = 0 To My.Resources.armors.Split(Chr(&HA)).Length - 1
            armorIDArray(i) = Convert.ToInt32(My.Resources.armors.Split(Chr(&HA))(i).Split(":")(0))
            armorNameArray(i) = My.Resources.armors.Split(Chr(&HA))(i).Split(":")(1)
            armorLimitArray(i) = My.Resources.armors.Split(Chr(&HA))(i).Split(":")(2)
        Next
        For i = 0 To My.Resources.gauntlets.Split(Chr(&HA)).Length - 1
            gauntletIDArray(i) = Convert.ToInt32(My.Resources.gauntlets.Split(Chr(&HA))(i).Split(":")(0))
            gauntletNameArray(i) = My.Resources.gauntlets.Split(Chr(&HA))(i).Split(":")(1)
            gauntletLimitArray(i) = My.Resources.gauntlets.Split(Chr(&HA))(i).Split(":")(2)
        Next
        For i = 0 To My.Resources.leggings.Split(Chr(&HA)).Length - 1
            leggingIDArray(i) = Convert.ToInt32(My.Resources.leggings.Split(Chr(&HA))(i).Split(":")(0))
            leggingNameArray(i) = My.Resources.leggings.Split(Chr(&HA))(i).Split(":")(1)
            leggingLimitArray(i) = My.Resources.leggings.Split(Chr(&HA))(i).Split(":")(2)
        Next
        For i = 0 To My.Resources.weapons.Split(Chr(&HA)).Length - 1
            weaponIDArray(i) = Convert.ToInt32(My.Resources.weapons.Split(Chr(&HA))(i).Split(":")(0))
            weaponNameArray(i) = My.Resources.weapons.Split(Chr(&HA))(i).Split(":")(1)
            weaponLimitArray(i) = My.Resources.weapons.Split(Chr(&HA))(i).Split(":")(2)
        Next
        For i = 0 To My.Resources.Spells.Split(Chr(&HA)).Length - 1
            spellIDArray(i) = Convert.ToInt32(My.Resources.Spells.Split(Chr(&HA))(i).Split(":")(0))
            spellNameArray(i) = My.Resources.Spells.Split(Chr(&HA))(i).Split(":")(1)
        Next
    End Sub

    Private Sub onEntityBoxClicked() Handles entityBox.Click
        If Not isApplied Then
            MessageBox.Show("Your changes have not been applied. If you want to save this cosplay, please press Apply")
        End If
        isApplied = True
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

        If (currentData(0) >= 1330000 And currentData(0) < 1333600) Then
            If currentData(0) < 1331600 Then
                leftOneName.SelectedIndex = 141
                leftOneInfusion.SelectedIndex = 0
                leftOneLevel.SelectedIndex = currentData(1)
            Else
                leftOneName.SelectedIndex = 140
                leftOneInfusion.SelectedIndex = 0
                leftOneLevel.SelectedIndex = currentData(1)
            End If
        Else
            leftOneName.SelectedIndex = Array.IndexOf(weaponIDArray, currentData(0))
            leftOneInfusion.SelectedIndex = currentData(1)
            leftOneLevel.SelectedIndex = currentData(2)
        End If

        currentData = analyzeName(selectedLine(6), True)
        If (currentData(0) >= 1330000 And currentData(0) < 1333600) Then
            If currentData(0) < 1331600 Then
                rightOneName.SelectedIndex = 141
                rightOneInfusion.SelectedIndex = 0
                rightOneLevel.SelectedIndex = currentData(1)
            Else
                rightOneName.SelectedIndex = 140
                rightOneInfusion.SelectedIndex = 0
                rightOneLevel.SelectedIndex = currentData(1)
            End If
        Else
            rightOneName.SelectedIndex = Array.IndexOf(weaponIDArray, currentData(0))
            rightOneInfusion.SelectedIndex = currentData(1)
            rightOneLevel.SelectedIndex = currentData(2)
        End If

        currentData = analyzeName(selectedLine(7), True)
        If (currentData(0) >= 1330000 And currentData(0) < 1333600) Then
            If currentData(0) < 1331600 Then
                leftTwoName.SelectedIndex = 141
                leftTwoInfusion.SelectedIndex = 0
                LeftTwoLevel.SelectedIndex = currentData(1)
            Else
                leftTwoName.SelectedIndex = 140
                leftTwoInfusion.SelectedIndex = 0
                LeftTwoLevel.SelectedIndex = currentData(1)
            End If
        Else
            leftTwoName.SelectedIndex = Array.IndexOf(weaponIDArray, currentData(0))
            leftTwoInfusion.SelectedIndex = currentData(1)
            LeftTwoLevel.SelectedIndex = currentData(2)
        End If

        currentData = analyzeName(selectedLine(8), True)
        If (currentData(0) >= 1330000 And currentData(0) < 1333600) Then
            If currentData(0) < 1331600 Then
                rightTwoName.SelectedIndex = 141
                rightTwoInfusion.SelectedIndex = 0
                rightTwoLevel.SelectedIndex = currentData(1)
            Else
                rightTwoName.SelectedIndex = 140
                rightTwoInfusion.SelectedIndex = 0
                rightTwoLevel.SelectedIndex = currentData(1)
            End If
        Else
            rightTwoName.SelectedIndex = Array.IndexOf(weaponIDArray, currentData(0))
            rightTwoInfusion.SelectedIndex = currentData(1)
            rightTwoLevel.SelectedIndex = currentData(2)
        End If

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
        headSize.Value = selectedLine(17)
        chestSize.Value = selectedLine(18)
        abdomenSize.Value = selectedLine(19)
        handSize.Value = selectedLine(20)
        legSize.Value = selectedLine(21)
        speedBar.Value = selectedLine(22)
        Spell1Name.SelectedIndex = Array.IndexOf(spellIDArray, selectedLine(23))
        Spell1Num.Value = selectedLine(24)
        Spell2Name.SelectedIndex = Array.IndexOf(spellIDArray, selectedLine(25))
        Spell2Num.Value = selectedLine(26)
        Spell3Name.SelectedIndex = Array.IndexOf(spellIDArray, selectedLine(27))
        Spell3Num.Value = selectedLine(28)
        Spell4Name.SelectedIndex = Array.IndexOf(spellIDArray, selectedLine(29))
        Spell4Num.Value = selectedLine(30)
        Spell5Name.SelectedIndex = Array.IndexOf(spellIDArray, selectedLine(31))
        Spell5Num.Value = selectedLine(32)
        isApplied = True
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

    Private Sub onR1BoxChanged() Handles rightOneName.SelectedIndexChanged
        isApplied = False
        rightOneLevel.Items.Clear()
        rightOneInfusion.Items.Clear()
        addUpgrades(weaponLimitArray, rightOneName, rightOneLevel)
        rightOneLevel.SelectedIndex = 0
        addInfusions(rightOneName, rightOneInfusion)
        rightOneInfusion.SelectedIndex = 0
    End Sub

    Private Sub onR2BoxChanged() Handles rightTwoName.SelectedIndexChanged
        isApplied = False
        rightTwoLevel.Items.Clear()
        rightTwoInfusion.Items.Clear()
        addUpgrades(weaponLimitArray, rightTwoName, rightTwoLevel)
        rightTwoLevel.SelectedIndex = 0
        addInfusions(rightTwoName, rightTwoInfusion)
        rightTwoInfusion.SelectedIndex = 0
    End Sub

    Private Sub onL1BoxChanged() Handles leftOneName.SelectedIndexChanged
        isApplied = False
        leftOneLevel.Items.Clear()
        leftOneInfusion.Items.Clear()
        addUpgrades(weaponLimitArray, leftOneName, leftOneLevel)
        leftOneLevel.SelectedIndex = 0
        addInfusions(leftOneName, leftOneInfusion)
        leftOneInfusion.SelectedIndex = 0
    End Sub

    Private Sub onL2BoxChanged() Handles leftTwoName.SelectedIndexChanged
        isApplied = False
        LeftTwoLevel.Items.Clear()
        leftTwoInfusion.Items.Clear()
        addUpgrades(weaponLimitArray, leftTwoName, LeftTwoLevel)
        LeftTwoLevel.SelectedIndex = 0
        addInfusions(leftTwoName, leftTwoInfusion)
        leftTwoInfusion.SelectedIndex = 0
    End Sub

    Private Sub onHelmChanged() Handles helmetName.SelectedIndexChanged
        isApplied = False
        helmetLevel.Items.Clear()
        addUpgrades(helmetLimitArray, helmetName, helmetLevel)
        helmetLevel.SelectedIndex = 0
    End Sub

    Private Sub onChestChanged() Handles armorName.SelectedIndexChanged
        isApplied = False
        armorLevel.Items.Clear()
        addUpgrades(armorLimitArray, armorName, armorLevel)
        armorLevel.SelectedIndex = 0
    End Sub

    Private Sub onArmsChanged() Handles gauntletsName.SelectedIndexChanged
        isApplied = False
        gauntletsLevel.Items.Clear()
        addUpgrades(gauntletLimitArray, gauntletsName, gauntletsLevel)
        gauntletsLevel.SelectedIndex = 0
    End Sub

    Private Sub onFeetChanged() Handles leggingsName.SelectedIndexChanged
        isApplied = False
        leggingsLevel.Items.Clear()
        addUpgrades(leggingLimitArray, leggingsName, leggingsLevel)
        leggingsLevel.SelectedIndex = 0
    End Sub

    Public Sub addUpgrades(type As Integer(), nameBox As ComboBox, box As ComboBox)
        Dim numString As String
        For n = 0 To type(nameBox.SelectedIndex)
            numString = n
            box.Items.Add("+" + numString)
        Next
    End Sub

    Public Sub addInfusions(nameBox As ComboBox, box As ComboBox)
        If weaponLimitArray(nameBox.SelectedIndex) = 15 And nameBox.SelectedIndex <> 141 Then
            box.Items.Add("Standard")
            box.Items.Add("Crystal")
            box.Items.Add("Lightning")
            box.Items.Add("Raw")
            box.Items.Add("Magic")
            box.Items.Add("Enchanted")
            box.Items.Add("Divine")
            box.Items.Add("Occult")
            box.Items.Add("Fire")
            box.Items.Add("Chaos")
        Else
            box.Items.Add("No Infusion")
        End If
    End Sub

    Private Sub onVitSetClicked() Handles vitSet.Click
        isApplied = False
        noChangeStats.Checked = False
    End Sub

    Private Sub onAtnSetClicked() Handles atnSet.Click
        isApplied = False
        noChangeStats.Checked = False
    End Sub

    Private Sub onEndSetClicked() Handles endSet.Click
        isApplied = False
        noChangeStats.Checked = False
    End Sub

    Private Sub onStrSetClicked() Handles strSet.Click
        isApplied = False
        noChangeStats.Checked = False
    End Sub

    Private Sub onDexSetClicked() Handles dexSet.Click
        isApplied = False
        noChangeStats.Checked = False
    End Sub

    Private Sub onResSetClicked() Handles resSet.Click
        isApplied = False
        noChangeStats.Checked = False
    End Sub

    Private Sub onIntSetClicked() Handles intSet.Click
        isApplied = False
        noChangeStats.Checked = False
    End Sub

    Private Sub onFthSetClicked() Handles fthSet.Click
        isApplied = False
        noChangeStats.Checked = False
    End Sub

    Private Sub applyButton_Click(sender As Object, e As EventArgs) Handles applyButton.Click
        If entityBox.SelectedIndex < 0 Then
            Exit Sub
        End If
        Dim applyLine(33) As Integer
        applyLine(0) = entityIDArray(entityBox.SelectedIndex + 1)
        applyLine(1) = helmetIDArray(helmetName.SelectedIndex) + helmetLevel.SelectedIndex
        applyLine(2) = armorIDArray(armorName.SelectedIndex) + armorLevel.SelectedIndex
        applyLine(3) = gauntletIDArray(gauntletsName.SelectedIndex) + gauntletsLevel.SelectedIndex
        applyLine(4) = leggingIDArray(leggingsName.SelectedIndex) + leggingsLevel.SelectedIndex

        If leftOneName.SelectedIndex > 0 Then
            If leftOneName.SelectedIndex = 140 Or leftOneName.SelectedIndex = 141 Then
                applyLine(5) = (weaponIDArray(leftOneName.SelectedIndex) + (leftOneLevel.SelectedIndex * 100))
            Else
                applyLine(5) = (weaponIDArray(leftOneName.SelectedIndex) + (leftOneInfusion.SelectedIndex * 100) + leftOneLevel.SelectedIndex)
            End If
        Else
            applyLine(5) = 9876
        End If

        If rightOneName.SelectedIndex > 0 Then
            If rightOneName.SelectedIndex = 140 Or rightOneName.SelectedIndex = 141 Then
                applyLine(6) = (weaponIDArray(rightOneName.SelectedIndex) + (rightOneLevel.SelectedIndex * 100))
            Else
                applyLine(6) = (weaponIDArray(rightOneName.SelectedIndex) + (rightOneInfusion.SelectedIndex * 100) + rightOneLevel.SelectedIndex)
            End If
        Else
            applyLine(6) = 9876
        End If

        If leftTwoName.SelectedIndex > 0 Then
            If leftTwoName.SelectedIndex = 140 Or leftTwoName.SelectedIndex = 141 Then
                applyLine(7) = (weaponIDArray(leftTwoName.SelectedIndex) + (LeftTwoLevel.SelectedIndex * 100))
            Else
                applyLine(7) = (weaponIDArray(leftTwoName.SelectedIndex) + (leftTwoInfusion.SelectedIndex * 100) + LeftTwoLevel.SelectedIndex)
            End If
        Else
            applyLine(7) = 9876
        End If

        If rightTwoName.SelectedIndex > 0 Then
            If rightTwoName.SelectedIndex = 140 Or rightTwoName.SelectedIndex = 141 Then
                applyLine(8) = (weaponIDArray(rightTwoName.SelectedIndex) + (rightTwoLevel.SelectedIndex * 100))
            Else
                applyLine(8) = (weaponIDArray(rightTwoName.SelectedIndex) + (rightTwoInfusion.SelectedIndex * 100) + rightTwoLevel.SelectedIndex)
            End If
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
        applyLine(17) = headSize.Value
        applyLine(18) = chestSize.Value
        applyLine(19) = abdomenSize.Value
        applyLine(20) = handSize.Value
        applyLine(21) = legSize.Value
        applyLine(22) = speedBar.Value
        applyLine(23) = spellIDArray(Spell1Name.SelectedIndex)
        applyLine(24) = Spell1Num.Value
        applyLine(25) = spellIDArray(Spell2Name.SelectedIndex)
        applyLine(26) = Spell2Num.Value
        applyLine(27) = spellIDArray(Spell3Name.SelectedIndex)
        applyLine(28) = Spell3Num.Value
        applyLine(29) = spellIDArray(Spell4Name.SelectedIndex)
        applyLine(30) = Spell4Num.Value
        applyLine(31) = spellIDArray(Spell5Name.SelectedIndex)
        applyLine(32) = Spell5Num.Value
        allCosplaysArray(entityBox.SelectedIndex) = applyLine
        CosplaySouls.cosplayHash.Item(applyLine(0)) = applyLine
        isApplied = True
        isExported = False
        MessageBox.Show("Applied!")
    End Sub

    Private Function makeCurrentString(applyLine() As Integer) As String
        Dim currentString = applyLine(0).ToString + ":"
        For i = 1 To 31
            currentString = currentString + applyLine(i).ToString + ":"
        Next
        currentString = currentString + applyLine(32).ToString
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
            For i = 1 To 216
                currentString = makeCurrentString(allCosplaysArray(i))
                My.Computer.FileSystem.WriteAllText(externalPath, Environment.NewLine, True)
                My.Computer.FileSystem.WriteAllText(externalPath, currentString, True)
            Next
        End If
        isExported = True
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

    Public Sub onNoSpellsClick() Handles NoSpells.Click
        Spell1Name.SelectedIndex = 1
        Spell1Num.Value = 0
        Spell2Name.SelectedIndex = 1
        Spell2Num.Value = 0
        Spell3Name.SelectedIndex = 1
        Spell3Num.Value = 0
        Spell4Name.SelectedIndex = 1
        Spell4Num.Value = 0
        Spell5Name.SelectedIndex = 1
        Spell5Num.Value = 0
    End Sub

    Public Sub onDepriveClick() Handles deprive.Click
        leftOneName.SelectedIndex = 1
        leftTwoName.SelectedIndex = 1
        rightOneName.SelectedIndex = 1
        rightTwoName.SelectedIndex = 1
        helmetName.SelectedIndex = 1
        armorName.SelectedIndex = 1
        gauntletsName.SelectedIndex = 1
        leggingsName.SelectedIndex = 1
        noChangeStats.Checked = True
        headSize.Value = -1
        chestSize.Value = -1
        abdomenSize.Value = -1
        handSize.Value = -1
        legSize.Value = -1
        speedBar.Value = 10
        Spell1Name.SelectedIndex = 1
        Spell1Num.Value = 0
        Spell2Name.SelectedIndex = 1
        Spell2Num.Value = 0
        Spell3Name.SelectedIndex = 1
        Spell3Num.Value = 0
        Spell4Name.SelectedIndex = 1
        Spell4Num.Value = 0
        Spell5Name.SelectedIndex = 1
        Spell5Num.Value = 0
    End Sub

    Private Sub onCosplayNowClick() Handles cosplayNow.Click
        If CosplaySouls.targetProcessHandle = vbNull Then
            Exit Sub
        End If

        'apply from current boxes
        If entityBox.SelectedIndex < 0 Then
            Exit Sub
        End If
        Dim applyLine(32) As Integer
        applyLine(0) = entityIDArray(entityBox.SelectedIndex + 1)
        applyLine(1) = helmetIDArray(helmetName.SelectedIndex) + helmetLevel.SelectedIndex
        applyLine(2) = armorIDArray(armorName.SelectedIndex) + armorLevel.SelectedIndex
        applyLine(3) = gauntletIDArray(gauntletsName.SelectedIndex) + gauntletsLevel.SelectedIndex
        applyLine(4) = leggingIDArray(leggingsName.SelectedIndex) + leggingsLevel.SelectedIndex

        If leftOneName.SelectedIndex > 0 Then
            If leftOneName.SelectedIndex = 140 Or leftOneName.SelectedIndex = 141 Then
                applyLine(5) = (weaponIDArray(leftOneName.SelectedIndex) + (leftOneLevel.SelectedIndex * 100))
            Else
                applyLine(5) = (weaponIDArray(leftOneName.SelectedIndex) + (leftOneInfusion.SelectedIndex * 100) + leftOneLevel.SelectedIndex)
            End If
        Else
            applyLine(5) = 9876
        End If

        If rightOneName.SelectedIndex > 0 Then
            If rightOneName.SelectedIndex = 140 Or rightOneName.SelectedIndex = 141 Then
                applyLine(6) = (weaponIDArray(rightOneName.SelectedIndex) + (rightOneLevel.SelectedIndex * 100))
            Else
                applyLine(6) = (weaponIDArray(rightOneName.SelectedIndex) + (rightOneInfusion.SelectedIndex * 100) + rightOneLevel.SelectedIndex)
            End If
        Else
            applyLine(6) = 9876
        End If

        If leftTwoName.SelectedIndex > 0 Then
            If leftTwoName.SelectedIndex = 140 Or leftTwoName.SelectedIndex = 141 Then
                applyLine(7) = (weaponIDArray(leftTwoName.SelectedIndex) + (LeftTwoLevel.SelectedIndex * 100))
            Else
                applyLine(7) = (weaponIDArray(leftTwoName.SelectedIndex) + (leftTwoInfusion.SelectedIndex * 100) + LeftTwoLevel.SelectedIndex)
            End If
        Else
            applyLine(7) = 9876
        End If

        If rightTwoName.SelectedIndex > 0 Then
            If rightTwoName.SelectedIndex = 140 Or rightTwoName.SelectedIndex = 141 Then
                applyLine(8) = (weaponIDArray(rightTwoName.SelectedIndex) + (rightTwoLevel.SelectedIndex * 100))
            Else
                applyLine(8) = (weaponIDArray(rightTwoName.SelectedIndex) + (rightTwoInfusion.SelectedIndex * 100) + rightTwoLevel.SelectedIndex)
            End If
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
        applyLine(17) = headSize.Value
        applyLine(18) = chestSize.Value
        applyLine(19) = abdomenSize.Value
        applyLine(20) = handSize.Value
        applyLine(21) = legSize.Value
        applyLine(22) = speedBar.Value
        applyLine(23) = spellIDArray(Spell1Name.SelectedIndex)
        applyLine(24) = Spell1Num.Value
        applyLine(25) = spellIDArray(Spell2Name.SelectedIndex)
        applyLine(26) = Spell2Num.Value
        applyLine(27) = spellIDArray(Spell3Name.SelectedIndex)
        applyLine(28) = Spell3Num.Value
        applyLine(29) = spellIDArray(Spell4Name.SelectedIndex)
        applyLine(30) = Spell4Num.Value
        applyLine(31) = spellIDArray(Spell5Name.SelectedIndex)
        applyLine(32) = Spell5Num.Value

        'setBases
        Dim tempAddress = CosplaySouls.pointerToAddress(&H1378700)
        statBase = CosplaySouls.pointerToAddress(tempAddress + &H8)
        equipmentBase = CosplaySouls.pointerToAddress(statBase + &H318)

        'setGear

        'Helmet
        tempAddress = equipmentBase + &HB4
        If applyLine(1) <> 9876 Then
            CosplaySouls.WriteProcessMemory(CosplaySouls.targetProcessHandle, tempAddress, BitConverter.GetBytes(applyLine(1)), 4, 0)
        End If

        'Armor
        tempAddress = equipmentBase + &HB8
        If applyLine(2) <> 9876 Then
            CosplaySouls.WriteProcessMemory(CosplaySouls.targetProcessHandle, tempAddress, BitConverter.GetBytes(applyLine(2)), 4, 0)
        End If

        'Gauntlets
        tempAddress = equipmentBase + &HBC
        If applyLine(3) <> 9876 Then
            CosplaySouls.WriteProcessMemory(CosplaySouls.targetProcessHandle, tempAddress, BitConverter.GetBytes(applyLine(3)), 4, 0)
        End If

        'Leggings
        tempAddress = equipmentBase + &HC0
        If applyLine(4) <> 9876 Then
            CosplaySouls.WriteProcessMemory(CosplaySouls.targetProcessHandle, tempAddress, BitConverter.GetBytes(applyLine(4)), 4, 0)
        End If

        'L1
        tempAddress = equipmentBase + &H94
        If applyLine(5) <> 9876 Then
            CosplaySouls.WriteProcessMemory(CosplaySouls.targetProcessHandle, tempAddress, BitConverter.GetBytes(applyLine(5)), 4, 0)
        End If

        'R1
        tempAddress = equipmentBase + &H98
        If applyLine(6) <> 9876 Then
            CosplaySouls.WriteProcessMemory(CosplaySouls.targetProcessHandle, tempAddress, BitConverter.GetBytes(applyLine(6)), 4, 0)
        End If

        'L2
        tempAddress = equipmentBase + &H9C
        If applyLine(7) <> 9876 Then
            CosplaySouls.WriteProcessMemory(CosplaySouls.targetProcessHandle, tempAddress, BitConverter.GetBytes(applyLine(7)), 4, 0)
        End If

        'R2
        tempAddress = equipmentBase + &HA0
        If applyLine(8) <> 9876 Then
            CosplaySouls.WriteProcessMemory(CosplaySouls.targetProcessHandle, tempAddress, BitConverter.GetBytes(applyLine(8)), 4, 0)
        End If

        'setStats
        If applyLine(9) <> 9876 Then
            Dim hpStamBase = CosplaySouls.pointerToAddress(CosplaySouls.statPtr)

            'VIT
            tempAddress = statBase + &H38
            Dim vit As Integer
            vit = applyLine(9)
            CosplaySouls.WriteProcessMemory(CosplaySouls.targetProcessHandle, (hpStamBase + &H14), BitConverter.GetBytes(CosplaySouls.vitalityConv(vit - 1)), 4, 0)
            CosplaySouls.WriteProcessMemory(CosplaySouls.targetProcessHandle, tempAddress, BitConverter.GetBytes(vit), 4, 0)

            'ATN
            tempAddress = statBase + &H40
            CosplaySouls.WriteProcessMemory(CosplaySouls.targetProcessHandle, tempAddress, BitConverter.GetBytes(applyLine(10)), 4, 0)

            'END
            tempAddress = statBase + &H48
            Dim endurance As Integer
            endurance = applyLine(11)
            CosplaySouls.WriteProcessMemory(CosplaySouls.targetProcessHandle, (hpStamBase + &H30), BitConverter.GetBytes(CosplaySouls.enduranceConv(endurance - 1)), 4, 0)
            CosplaySouls.WriteProcessMemory(CosplaySouls.targetProcessHandle, tempAddress, BitConverter.GetBytes(endurance), 4, 0)

            'STR
            tempAddress = statBase + &H50
            CosplaySouls.WriteProcessMemory(CosplaySouls.targetProcessHandle, tempAddress, BitConverter.GetBytes(applyLine(12)), 4, 0)

            'DEX
            tempAddress = statBase + &H58
            CosplaySouls.WriteProcessMemory(CosplaySouls.targetProcessHandle, tempAddress, BitConverter.GetBytes(applyLine(13)), 4, 0)

            'RES
            tempAddress = statBase + &H80
            CosplaySouls.WriteProcessMemory(CosplaySouls.targetProcessHandle, tempAddress, BitConverter.GetBytes(applyLine(14)), 4, 0)

            'INT
            tempAddress = statBase + &H60
            CosplaySouls.WriteProcessMemory(CosplaySouls.targetProcessHandle, tempAddress, BitConverter.GetBytes(applyLine(15)), 4, 0)

            'FTH
            tempAddress = statBase + &H68
            CosplaySouls.WriteProcessMemory(CosplaySouls.targetProcessHandle, tempAddress, BitConverter.GetBytes(applyLine(16)), 4, 0)
        End If

        'setSpells
        Dim spellPtr = CosplaySouls.pointerToAddress(statBase + &H30C)

        'Spell 1
        If (applyLine(23) <> 9876) Then
            tempAddress = spellPtr + &HC
            CosplaySouls.WriteProcessMemory(CosplaySouls.targetProcessHandle, tempAddress, BitConverter.GetBytes(applyLine(23)), 4, 0)
            tempAddress = spellPtr + &H10
            CosplaySouls.WriteProcessMemory(CosplaySouls.targetProcessHandle, tempAddress, BitConverter.GetBytes(applyLine(24) * 3), 4, 0)
        End If

        'Spell 2
        If (applyLine(25) <> 9876) Then
            tempAddress = spellPtr + &H14
            CosplaySouls.WriteProcessMemory(CosplaySouls.targetProcessHandle, tempAddress, BitConverter.GetBytes(applyLine(25)), 4, 0)
            tempAddress = spellPtr + &H18
            CosplaySouls.WriteProcessMemory(CosplaySouls.targetProcessHandle, tempAddress, BitConverter.GetBytes(applyLine(26) * 3), 4, 0)
        End If

        'Spell 3
        If (applyLine(27) <> 9876) Then
            tempAddress = spellPtr + &H1C
            CosplaySouls.WriteProcessMemory(CosplaySouls.targetProcessHandle, tempAddress, BitConverter.GetBytes(applyLine(27)), 4, 0)
            tempAddress = spellPtr + &H20
            CosplaySouls.WriteProcessMemory(CosplaySouls.targetProcessHandle, tempAddress, BitConverter.GetBytes(applyLine(28) * 3), 4, 0)
        End If

        'Spell 4
        If (applyLine(29) <> 9876) Then
            tempAddress = spellPtr + &H24
            CosplaySouls.WriteProcessMemory(CosplaySouls.targetProcessHandle, tempAddress, BitConverter.GetBytes(applyLine(29)), 4, 0)
            tempAddress = spellPtr + &H28
            CosplaySouls.WriteProcessMemory(CosplaySouls.targetProcessHandle, tempAddress, BitConverter.GetBytes(applyLine(30) * 3), 4, 0)
        End If

        'Spell 5
        If (applyLine(31) <> 9876) Then
            tempAddress = spellPtr + &H2C
            CosplaySouls.WriteProcessMemory(CosplaySouls.targetProcessHandle, tempAddress, BitConverter.GetBytes(applyLine(31)), 4, 0)
            tempAddress = spellPtr + &H20
            CosplaySouls.WriteProcessMemory(CosplaySouls.targetProcessHandle, tempAddress, BitConverter.GetBytes(applyLine(32) * 3), 4, 0)
        End If

        'setProportions
        tempAddress = CosplaySouls.pointerToAddress(&H1378700)
        Dim proportionBase = CosplaySouls.pointerToAddress(tempAddress + &H8)
        Dim tempBytes() As Byte
        Dim proportionSingle As Single

        'Head Proportion
        tempAddress = proportionBase + &H2AC
        proportionSingle = applyLine(17) / 2
        tempBytes = BitConverter.GetBytes(proportionSingle)
        CosplaySouls.WriteProcessMemory(CosplaySouls.targetProcessHandle, tempAddress, tempBytes, 4, 0)

        'Chest Proportion
        tempAddress = proportionBase + &H2B0
        proportionSingle = applyLine(18) / 2
        tempBytes = BitConverter.GetBytes(proportionSingle)
        CosplaySouls.WriteProcessMemory(CosplaySouls.targetProcessHandle, tempAddress, tempBytes, 4, 0)

        'Abdomen Proportion
        tempAddress = proportionBase + &H2B4
        proportionSingle = applyLine(19) / 2
        tempBytes = BitConverter.GetBytes(proportionSingle)
        CosplaySouls.WriteProcessMemory(CosplaySouls.targetProcessHandle, tempAddress, tempBytes, 4, 0)

        'Arm Proportion
        tempAddress = proportionBase + &H2B8
        proportionSingle = applyLine(20) / 2
        tempBytes = BitConverter.GetBytes(proportionSingle)
        CosplaySouls.WriteProcessMemory(CosplaySouls.targetProcessHandle, tempAddress, tempBytes, 4, 0)

        'Leg Proportion
        tempAddress = proportionBase + &H2BC
        proportionSingle = applyLine(21) / 2
        tempBytes = BitConverter.GetBytes(proportionSingle)
        CosplaySouls.WriteProcessMemory(CosplaySouls.targetProcessHandle, tempAddress, tempBytes, 4, 0)

        'Speed Modifier
        tempAddress = CosplaySouls.pointerToAddress(&H12E29E8)
        tempAddress = CosplaySouls.pointerToAddress(tempAddress)
        tempAddress = CosplaySouls.pointerToAddress(tempAddress + &H28)
        tempAddress = CosplaySouls.pointerToAddress(tempAddress + &H14)
        tempAddress = tempAddress + &H64
        Dim speedSingle As Single
        speedSingle = applyLine(22) / 10
        tempBytes = BitConverter.GetBytes(speedSingle)
        CosplaySouls.WriteProcessMemory(CosplaySouls.targetProcessHandle, tempAddress, tempBytes, 4, 0)
    End Sub

End Class