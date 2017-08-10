<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CosplaySouls
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.fullSetup = New System.Windows.Forms.Button()
        Me.UnhookButton = New System.Windows.Forms.Button()
        Me.CosplayEditor = New System.Windows.Forms.Button()
        Me.autoGear = New System.Windows.Forms.CheckBox()
        Me.autoLevel = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.enemyScale = New System.Windows.Forms.RadioButton()
        Me.areaNormal = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.areaChallenge = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout()
        '
        'fullSetup
        '
        Me.fullSetup.Location = New System.Drawing.Point(24, 24)
        Me.fullSetup.Margin = New System.Windows.Forms.Padding(4)
        Me.fullSetup.Name = "fullSetup"
        Me.fullSetup.Size = New System.Drawing.Size(167, 176)
        Me.fullSetup.TabIndex = 4
        Me.fullSetup.Text = "START"
        Me.fullSetup.UseVisualStyleBackColor = True
        '
        'UnhookButton
        '
        Me.UnhookButton.Location = New System.Drawing.Point(24, 228)
        Me.UnhookButton.Margin = New System.Windows.Forms.Padding(4)
        Me.UnhookButton.Name = "UnhookButton"
        Me.UnhookButton.Size = New System.Drawing.Size(167, 64)
        Me.UnhookButton.TabIndex = 5
        Me.UnhookButton.Text = "UNHOOK"
        Me.UnhookButton.UseVisualStyleBackColor = True
        '
        'CosplayEditor
        '
        Me.CosplayEditor.Location = New System.Drawing.Point(231, 24)
        Me.CosplayEditor.Margin = New System.Windows.Forms.Padding(4)
        Me.CosplayEditor.Name = "CosplayEditor"
        Me.CosplayEditor.Size = New System.Drawing.Size(195, 44)
        Me.CosplayEditor.TabIndex = 6
        Me.CosplayEditor.Text = "Cosplay Editor"
        Me.CosplayEditor.UseVisualStyleBackColor = True
        '
        'autoGear
        '
        Me.autoGear.AutoSize = True
        Me.autoGear.Checked = True
        Me.autoGear.CheckState = System.Windows.Forms.CheckState.Checked
        Me.autoGear.Location = New System.Drawing.Point(231, 76)
        Me.autoGear.Name = "autoGear"
        Me.autoGear.Size = New System.Drawing.Size(193, 29)
        Me.autoGear.TabIndex = 7
        Me.autoGear.Text = "Auto-level Gear"
        Me.autoGear.UseVisualStyleBackColor = True
        '
        'autoLevel
        '
        Me.autoLevel.AutoSize = True
        Me.autoLevel.Checked = True
        Me.autoLevel.CheckState = System.Windows.Forms.CheckState.Checked
        Me.autoLevel.Location = New System.Drawing.Point(231, 123)
        Me.autoLevel.Name = "autoLevel"
        Me.autoLevel.Size = New System.Drawing.Size(195, 29)
        Me.autoLevel.TabIndex = 8
        Me.autoLevel.Text = "Auto-level Stats"
        Me.autoLevel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 316)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(133, 25)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Version 0.06"
        '
        'enemyScale
        '
        Me.enemyScale.AutoSize = True
        Me.enemyScale.Checked = True
        Me.enemyScale.Location = New System.Drawing.Point(255, 213)
        Me.enemyScale.Name = "enemyScale"
        Me.enemyScale.Size = New System.Drawing.Size(296, 29)
        Me.enemyScale.TabIndex = 11
        Me.enemyScale.TabStop = True
        Me.enemyScale.Text = "By Enemy (recommended)"
        Me.enemyScale.UseVisualStyleBackColor = True
        '
        'areaNormal
        '
        Me.areaNormal.AutoSize = True
        Me.areaNormal.Location = New System.Drawing.Point(255, 263)
        Me.areaNormal.Name = "areaNormal"
        Me.areaNormal.Size = New System.Drawing.Size(204, 29)
        Me.areaNormal.TabIndex = 12
        Me.areaNormal.Text = "By Area (normal)"
        Me.areaNormal.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(226, 175)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(202, 25)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "HP/Stamina Scaling"
        '
        'areaChallenge
        '
        Me.areaChallenge.AutoSize = True
        Me.areaChallenge.Location = New System.Drawing.Point(255, 312)
        Me.areaChallenge.Name = "areaChallenge"
        Me.areaChallenge.Size = New System.Drawing.Size(232, 29)
        Me.areaChallenge.TabIndex = 15
        Me.areaChallenge.TabStop = True
        Me.areaChallenge.Text = "By Area (challenge)"
        Me.areaChallenge.UseVisualStyleBackColor = True
        '
        'CosplaySouls
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(574, 380)
        Me.Controls.Add(Me.areaChallenge)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.areaNormal)
        Me.Controls.Add(Me.enemyScale)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.autoLevel)
        Me.Controls.Add(Me.autoGear)
        Me.Controls.Add(Me.CosplayEditor)
        Me.Controls.Add(Me.UnhookButton)
        Me.Controls.Add(Me.fullSetup)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "CosplaySouls"
        Me.Text = "CosplaySouls"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents fullSetup As Button
    Friend WithEvents UnhookButton As Button
    Friend WithEvents CosplayEditor As Button
    Friend WithEvents autoGear As CheckBox
    Friend WithEvents autoLevel As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents enemyScale As RadioButton
    Friend WithEvents areaNormal As RadioButton
    Friend WithEvents Label2 As Label
    Friend WithEvents areaChallenge As RadioButton
End Class
