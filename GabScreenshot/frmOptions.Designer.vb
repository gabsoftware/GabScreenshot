<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOptions
    Inherits System.Windows.Forms.Form

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOptions))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboFileType = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtPreview = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPrefix = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.NUDPadLeft = New System.Windows.Forms.NumericUpDown()
        Me.btnSelectPath = New System.Windows.Forms.Button()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.fbd = New System.Windows.Forms.FolderBrowserDialog()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chkLoadOnStartup = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.NUD_Opacity = New System.Windows.Forms.NumericUpDown()
        Me.chkShowTooltip = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.NUDPadLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.NUD_Opacity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        resources.ApplyResources(Me.TableLayoutPanel1, "TableLayoutPanel1")
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        '
        'OK_Button
        '
        resources.ApplyResources(Me.OK_Button, "OK_Button")
        Me.OK_Button.Name = "OK_Button"
        '
        'Cancel_Button
        '
        resources.ApplyResources(Me.Cancel_Button, "Cancel_Button")
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Name = "Cancel_Button"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'cboFileType
        '
        Me.cboFileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFileType.FormattingEnabled = True
        resources.ApplyResources(Me.cboFileType, "cboFileType")
        Me.cboFileType.Name = "cboFileType"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cboFileType)
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtPreview)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtPrefix)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.NUDPadLeft)
        Me.GroupBox2.Controls.Add(Me.btnSelectPath)
        Me.GroupBox2.Controls.Add(Me.txtLocation)
        Me.GroupBox2.Controls.Add(Me.Label2)
        resources.ApplyResources(Me.GroupBox2, "GroupBox2")
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.TabStop = False
        '
        'txtPreview
        '
        Me.txtPreview.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtPreview, "txtPreview")
        Me.txtPreview.Name = "txtPreview"
        Me.txtPreview.ReadOnly = True
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'txtPrefix
        '
        Me.txtPrefix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrefix.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.GabScreenshot.My.MySettings.Default, "GS_Setting_FilenamePrefix", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        resources.ApplyResources(Me.txtPrefix, "txtPrefix")
        Me.txtPrefix.Name = "txtPrefix"
        Me.txtPrefix.Text = Global.GabScreenshot.My.MySettings.Default.GS_Setting_FilenamePrefix
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'NUDPadLeft
        '
        Me.NUDPadLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NUDPadLeft.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.GabScreenshot.My.MySettings.Default, "GS_Setting_PadLeft", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        resources.ApplyResources(Me.NUDPadLeft, "NUDPadLeft")
        Me.NUDPadLeft.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NUDPadLeft.Name = "NUDPadLeft"
        Me.NUDPadLeft.Value = Global.GabScreenshot.My.MySettings.Default.GS_Setting_PadLeft
        '
        'btnSelectPath
        '
        resources.ApplyResources(Me.btnSelectPath, "btnSelectPath")
        Me.btnSelectPath.Name = "btnSelectPath"
        Me.btnSelectPath.UseVisualStyleBackColor = True
        '
        'txtLocation
        '
        Me.txtLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLocation.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.GabScreenshot.My.MySettings.Default, "GS_Setting_SavePath", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        resources.ApplyResources(Me.txtLocation, "txtLocation")
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Text = Global.GabScreenshot.My.MySettings.Default.GS_Setting_SavePath
        '
        'fbd
        '
        resources.ApplyResources(Me.fbd, "fbd")
        Me.fbd.RootFolder = System.Environment.SpecialFolder.MyComputer
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkLoadOnStartup)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.NUD_Opacity)
        Me.GroupBox3.Controls.Add(Me.chkShowTooltip)
        resources.ApplyResources(Me.GroupBox3, "GroupBox3")
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.TabStop = False
        '
        'chkLoadOnStartup
        '
        resources.ApplyResources(Me.chkLoadOnStartup, "chkLoadOnStartup")
        Me.chkLoadOnStartup.Checked = Global.GabScreenshot.My.MySettings.Default.GS_Setting_LoadOnStartup
        Me.chkLoadOnStartup.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.GabScreenshot.My.MySettings.Default, "GS_Setting_LoadOnStartup", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.chkLoadOnStartup.Name = "chkLoadOnStartup"
        Me.chkLoadOnStartup.UseVisualStyleBackColor = True
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'NUD_Opacity
        '
        Me.NUD_Opacity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.NUD_Opacity, "NUD_Opacity")
        Me.NUD_Opacity.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NUD_Opacity.Name = "NUD_Opacity"
        Me.NUD_Opacity.Value = New Decimal(New Integer() {50, 0, 0, 0})
        '
        'chkShowTooltip
        '
        resources.ApplyResources(Me.chkShowTooltip, "chkShowTooltip")
        Me.chkShowTooltip.Checked = Global.GabScreenshot.My.MySettings.Default.GS_Setting_ShowTooltip
        Me.chkShowTooltip.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShowTooltip.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.GabScreenshot.My.MySettings.Default, "GS_Setting_ShowTooltip", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.chkShowTooltip.Name = "chkShowTooltip"
        Me.chkShowTooltip.UseVisualStyleBackColor = True
        '
        'frmOptions
        '
        Me.AcceptButton = Me.OK_Button
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOptions"
        Me.ShowInTaskbar = False
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.NUDPadLeft, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.NUD_Opacity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents cboFileType As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtLocation As System.Windows.Forms.TextBox
    Friend WithEvents btnSelectPath As System.Windows.Forms.Button
    Friend WithEvents fbd As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents chkShowTooltip As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents NUD_Opacity As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkLoadOnStartup As System.Windows.Forms.CheckBox
    Friend WithEvents txtPreview As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtPrefix As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents NUDPadLeft As System.Windows.Forms.NumericUpDown

End Class
