﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
        Me.NI = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.CMS = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AboutGabScreenshotToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMS.SuspendLayout()
        Me.SuspendLayout()
        '
        'NI
        '
        Me.NI.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        resources.ApplyResources(Me.NI, "NI")
        Me.NI.ContextMenuStrip = Me.CMS
        '
        'CMS
        '
        resources.ApplyResources(Me.CMS, "CMS")
        Me.CMS.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.CMS.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutGabScreenshotToolStripMenuItem, Me.OptionsToolStripMenuItem, Me.ToolStripSeparator1, Me.HelpToolStripMenuItem, Me.ToolStripSeparator2, Me.ExitToolStripMenuItem})
        Me.CMS.Name = "CMS"
        '
        'AboutGabScreenshotToolStripMenuItem
        '
        resources.ApplyResources(Me.AboutGabScreenshotToolStripMenuItem, "AboutGabScreenshotToolStripMenuItem")
        Me.AboutGabScreenshotToolStripMenuItem.Name = "AboutGabScreenshotToolStripMenuItem"
        '
        'OptionsToolStripMenuItem
        '
        resources.ApplyResources(Me.OptionsToolStripMenuItem, "OptionsToolStripMenuItem")
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        '
        'ToolStripSeparator1
        '
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        '
        'HelpToolStripMenuItem
        '
        resources.ApplyResources(Me.HelpToolStripMenuItem, "HelpToolStripMenuItem")
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        '
        'ToolStripSeparator2
        '
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        '
        'ExitToolStripMenuItem
        '
        resources.ApplyResources(Me.ExitToolStripMenuItem, "ExitToolStripMenuItem")
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        '
        'FrmMain
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ControlBox = False
        Me.DataBindings.Add(New System.Windows.Forms.Binding("Opacity", Global.GabScreenshot.My.MySettings.Default, "GS_Setting_Opacity", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmMain"
        Me.Opacity = Global.GabScreenshot.My.MySettings.Default.GS_Setting_Opacity
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.TopMost = True
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.CMS.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents NI As System.Windows.Forms.NotifyIcon
    Friend WithEvents CMS As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutGabScreenshotToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
End Class
