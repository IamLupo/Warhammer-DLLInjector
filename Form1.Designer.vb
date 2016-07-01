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
        Me.InjectTimer = New System.Windows.Forms.Timer(Me.components)
        Me.DelayTimer = New System.Windows.Forms.Timer(Me.components)
        Me.EndTimer = New System.Windows.Forms.Timer(Me.components)
        Me.pnl_searching = New System.Windows.Forms.Panel()
        Me.pb_searching = New System.Windows.Forms.ProgressBar()
        Me.lbl_searching = New System.Windows.Forms.Label()
        Me.pnl_injected = New System.Windows.Forms.Panel()
        Me.lbl_process_name = New System.Windows.Forms.Label()
        Me.lbl_process_id = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lbl_injected = New System.Windows.Forms.Label()
        Me.AnimateTimer = New System.Windows.Forms.Timer(Me.components)
        Me.pnl_injecting = New System.Windows.Forms.Panel()
        Me.pb_injecting = New System.Windows.Forms.ProgressBar()
        Me.lbl_injecting = New System.Windows.Forms.Label()
        Me.pnl_searching.SuspendLayout()
        Me.pnl_injected.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_injecting.SuspendLayout()
        Me.SuspendLayout()
        '
        'InjectTimer
        '
        Me.InjectTimer.Interval = 5000
        '
        'DelayTimer
        '
        Me.DelayTimer.Interval = 10000
        '
        'EndTimer
        '
        Me.EndTimer.Interval = 5000
        '
        'pnl_searching
        '
        Me.pnl_searching.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnl_searching.Controls.Add(Me.pb_searching)
        Me.pnl_searching.Controls.Add(Me.lbl_searching)
        Me.pnl_searching.Location = New System.Drawing.Point(12, 224)
        Me.pnl_searching.Name = "pnl_searching"
        Me.pnl_searching.Size = New System.Drawing.Size(332, 100)
        Me.pnl_searching.TabIndex = 0
        '
        'pb_searching
        '
        Me.pb_searching.Location = New System.Drawing.Point(177, 44)
        Me.pb_searching.Maximum = 10
        Me.pb_searching.Name = "pb_searching"
        Me.pb_searching.Size = New System.Drawing.Size(119, 23)
        Me.pb_searching.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pb_searching.TabIndex = 0
        '
        'lbl_searching
        '
        Me.lbl_searching.AutoSize = True
        Me.lbl_searching.Location = New System.Drawing.Point(174, 16)
        Me.lbl_searching.Name = "lbl_searching"
        Me.lbl_searching.Size = New System.Drawing.Size(122, 13)
        Me.lbl_searching.TabIndex = 1
        Me.lbl_searching.Text = "Searching for process ..."
        '
        'pnl_injected
        '
        Me.pnl_injected.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnl_injected.Controls.Add(Me.lbl_process_name)
        Me.pnl_injected.Controls.Add(Me.lbl_process_id)
        Me.pnl_injected.Controls.Add(Me.PictureBox1)
        Me.pnl_injected.Controls.Add(Me.lbl_injected)
        Me.pnl_injected.Location = New System.Drawing.Point(12, 118)
        Me.pnl_injected.Name = "pnl_injected"
        Me.pnl_injected.Size = New System.Drawing.Size(332, 100)
        Me.pnl_injected.TabIndex = 1
        '
        'lbl_process_name
        '
        Me.lbl_process_name.AutoSize = True
        Me.lbl_process_name.Location = New System.Drawing.Point(21, 26)
        Me.lbl_process_name.Name = "lbl_process_name"
        Me.lbl_process_name.Size = New System.Drawing.Size(74, 13)
        Me.lbl_process_name.TabIndex = 4
        Me.lbl_process_name.Text = "Processname:"
        '
        'lbl_process_id
        '
        Me.lbl_process_id.AutoSize = True
        Me.lbl_process_id.Location = New System.Drawing.Point(21, 44)
        Me.lbl_process_id.Name = "lbl_process_id"
        Me.lbl_process_id.Size = New System.Drawing.Size(62, 13)
        Me.lbl_process_id.TabIndex = 2
        Me.lbl_process_id.Text = "Process ID:"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = Global.Manager.My.Resources.Resources.icon_803718_640
        Me.PictureBox1.Location = New System.Drawing.Point(232, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 100)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'lbl_injected
        '
        Me.lbl_injected.AutoSize = True
        Me.lbl_injected.Location = New System.Drawing.Point(3, 3)
        Me.lbl_injected.Name = "lbl_injected"
        Me.lbl_injected.Size = New System.Drawing.Size(67, 13)
        Me.lbl_injected.TabIndex = 0
        Me.lbl_injected.Text = "DLL injected"
        '
        'AnimateTimer
        '
        Me.AnimateTimer.Enabled = True
        '
        'pnl_injecting
        '
        Me.pnl_injecting.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnl_injecting.Controls.Add(Me.pb_injecting)
        Me.pnl_injecting.Controls.Add(Me.lbl_injecting)
        Me.pnl_injecting.Location = New System.Drawing.Point(12, 12)
        Me.pnl_injecting.Name = "pnl_injecting"
        Me.pnl_injecting.Size = New System.Drawing.Size(332, 100)
        Me.pnl_injecting.TabIndex = 2
        '
        'pb_injecting
        '
        Me.pb_injecting.Location = New System.Drawing.Point(177, 44)
        Me.pb_injecting.Maximum = 10
        Me.pb_injecting.Name = "pb_injecting"
        Me.pb_injecting.Size = New System.Drawing.Size(119, 23)
        Me.pb_injecting.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pb_injecting.TabIndex = 0
        '
        'lbl_injecting
        '
        Me.lbl_injecting.AutoSize = True
        Me.lbl_injecting.Location = New System.Drawing.Point(174, 16)
        Me.lbl_injecting.Name = "lbl_injecting"
        Me.lbl_injecting.Size = New System.Drawing.Size(85, 13)
        Me.lbl_injecting.TabIndex = 1
        Me.lbl_injecting.Text = " Injecting DLL ..."
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(356, 122)
        Me.Controls.Add(Me.pnl_searching)
        Me.Controls.Add(Me.pnl_injecting)
        Me.Controls.Add(Me.pnl_injected)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Form1"
        Me.Text = "Vermintide DLL Injector"
        Me.pnl_searching.ResumeLayout(False)
        Me.pnl_searching.PerformLayout()
        Me.pnl_injected.ResumeLayout(False)
        Me.pnl_injected.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_injecting.ResumeLayout(False)
        Me.pnl_injecting.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents InjectTimer As System.Windows.Forms.Timer
    Friend WithEvents DelayTimer As System.Windows.Forms.Timer
    Friend WithEvents EndTimer As System.Windows.Forms.Timer
    Friend WithEvents pnl_searching As System.Windows.Forms.Panel
    Friend WithEvents lbl_searching As System.Windows.Forms.Label
    Friend WithEvents pb_searching As System.Windows.Forms.ProgressBar
    Friend WithEvents pnl_injected As System.Windows.Forms.Panel
    Friend WithEvents lbl_injected As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lbl_process_id As System.Windows.Forms.Label
    Friend WithEvents AnimateTimer As System.Windows.Forms.Timer
    Friend WithEvents lbl_process_name As System.Windows.Forms.Label
    Friend WithEvents pnl_injecting As System.Windows.Forms.Panel
    Friend WithEvents pb_injecting As System.Windows.Forms.ProgressBar
    Friend WithEvents lbl_injecting As System.Windows.Forms.Label

End Class
