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
        Me.SuspendLayout()
        '
        'fullSetup
        '
        Me.fullSetup.Location = New System.Drawing.Point(36, 24)
        Me.fullSetup.Margin = New System.Windows.Forms.Padding(4)
        Me.fullSetup.Name = "fullSetup"
        Me.fullSetup.Size = New System.Drawing.Size(213, 76)
        Me.fullSetup.TabIndex = 4
        Me.fullSetup.Text = "HOOK"
        Me.fullSetup.UseVisualStyleBackColor = True
        '
        'UnhookButton
        '
        Me.UnhookButton.Location = New System.Drawing.Point(65, 119)
        Me.UnhookButton.Margin = New System.Windows.Forms.Padding(4)
        Me.UnhookButton.Name = "UnhookButton"
        Me.UnhookButton.Size = New System.Drawing.Size(166, 43)
        Me.UnhookButton.TabIndex = 5
        Me.UnhookButton.Text = "UNHOOK"
        Me.UnhookButton.UseVisualStyleBackColor = True
        '
        'CosplayEditor
        '
        Me.CosplayEditor.Location = New System.Drawing.Point(288, 119)
        Me.CosplayEditor.Margin = New System.Windows.Forms.Padding(4)
        Me.CosplayEditor.Name = "CosplayEditor"
        Me.CosplayEditor.Size = New System.Drawing.Size(167, 44)
        Me.CosplayEditor.TabIndex = 6
        Me.CosplayEditor.Text = "Cosplay Editor"
        Me.CosplayEditor.UseVisualStyleBackColor = True
        '
        'autoGear
        '
        Me.autoGear.AutoSize = True
        Me.autoGear.Checked = True
        Me.autoGear.CheckState = System.Windows.Forms.CheckState.Checked
        Me.autoGear.Location = New System.Drawing.Point(279, 24)
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
        Me.autoLevel.Location = New System.Drawing.Point(279, 71)
        Me.autoLevel.Name = "autoLevel"
        Me.autoLevel.Size = New System.Drawing.Size(195, 29)
        Me.autoLevel.TabIndex = 8
        Me.autoLevel.Text = "Auto-level Stats"
        Me.autoLevel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(369, 203)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(133, 25)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Version 0.01"
        '
        'CosplaySouls
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(514, 237)
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
End Class
