<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnFirst = New System.Windows.Forms.Button()
        Me.btnSecond = New System.Windows.Forms.Button()
        Me.btnThird = New System.Windows.Forms.Button()
        Me.btnFourth = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'btnFirst
        '
        Me.btnFirst.Location = New System.Drawing.Point(34, 112)
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.Size = New System.Drawing.Size(88, 32)
        Me.btnFirst.TabIndex = 0
        Me.btnFirst.Text = "First"
        Me.btnFirst.UseVisualStyleBackColor = True
        '
        'btnSecond
        '
        Me.btnSecond.Location = New System.Drawing.Point(151, 112)
        Me.btnSecond.Name = "btnSecond"
        Me.btnSecond.Size = New System.Drawing.Size(88, 32)
        Me.btnSecond.TabIndex = 1
        Me.btnSecond.Text = "Second"
        Me.btnSecond.UseVisualStyleBackColor = True
        '
        'btnThird
        '
        Me.btnThird.Location = New System.Drawing.Point(271, 112)
        Me.btnThird.Name = "btnThird"
        Me.btnThird.Size = New System.Drawing.Size(88, 32)
        Me.btnThird.TabIndex = 2
        Me.btnThird.Text = "Third"
        Me.btnThird.UseVisualStyleBackColor = True
        '
        'btnFourth
        '
        Me.btnFourth.Location = New System.Drawing.Point(392, 112)
        Me.btnFourth.Name = "btnFourth"
        Me.btnFourth.Size = New System.Drawing.Size(88, 32)
        Me.btnFourth.TabIndex = 3
        Me.btnFourth.Text = "Fourth"
        Me.btnFourth.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnFourth)
        Me.Controls.Add(Me.btnThird)
        Me.Controls.Add(Me.btnSecond)
        Me.Controls.Add(Me.btnFirst)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnFirst As Button
    Friend WithEvents btnSecond As Button
    Friend WithEvents btnThird As Button
    Friend WithEvents btnFourth As Button
    Friend WithEvents Timer1 As Timer
End Class
