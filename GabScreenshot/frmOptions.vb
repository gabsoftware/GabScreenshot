Imports System.Windows.Forms
Imports Microsoft.Win32

Public Class frmOptions

    Public _filetypes As New ArrayList()
    Private _loaded As Boolean = False

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        If Not IsPrefixInvalid() Then
            My.Settings.Save()
            Me.ApplySettings()
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            txtPreview.ForeColor = Color.Red
            txtPrefix.Focus()
        End If


    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        My.Settings.Reload()
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmOptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        _filetypes.Add(New cFileType("Jpeg", "jpg"))
        _filetypes.Add(New cFileType("Png", "png"))
        _filetypes.Add(New cFileType("Gif", "gif"))
        _filetypes.Add(New cFileType("Bmp", "bmp"))
        _filetypes.Add(New cFileType("Icon", "ico"))
        _filetypes.Add(New cFileType("Tiff", "tif"))
        _filetypes.Add(New cFileType("Wmf", "wmf"))
        _filetypes.Add(New cFileType("Emf", "emf"))


        cboFileType.DataSource = _filetypes


        For Each f As cFileType In cboFileType.Items
            If f.Name = My.Settings.GS_Setting_FileType Then

                cboFileType.SelectedItem = f

            End If
        Next


        NUD_Opacity.Value = CDec(My.Settings.GS_Setting_Opacity * 100)


        _loaded = True

    End Sub

    Private Sub cboFileType_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFileType.SelectedValueChanged
        Dim f As cFileType = DirectCast(cboFileType.SelectedItem, cFileType)

        If _loaded = True Then
            My.Settings.GS_Setting_FileType = f.Name
        End If
    End Sub

    Private Sub cboFileType_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFileType.TextChanged

    End Sub

    Private Sub btnSelectPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectPath.Click
        fbd.SelectedPath = My.Settings.GS_Setting_SavePath
        Dim dr As DialogResult = fbd.ShowDialog()
        If dr = Windows.Forms.DialogResult.OK Then
            txtLocation.Text = fbd.SelectedPath
            My.Settings.GS_Setting_SavePath = fbd.SelectedPath
        End If
    End Sub

    Public Class cFileType

        Public _name As String
        Public Property Name() As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                _name = value
            End Set
        End Property

        Public _value As String
        Public Property Value() As String
            Get
                Return _value
            End Get
            Set(ByVal value As String)
                _value = value
            End Set
        End Property
        Public Sub New(ByVal thisname As String, ByVal thisvalue As String)
            Name = thisname
            Value = thisvalue
        End Sub
        Public Overrides Function ToString() As String
            Return Name
        End Function
    End Class

    Private Sub ApplySettings()

        'opacity
        My.Settings.GS_Setting_Opacity = CDbl(NUD_Opacity.Value / 100)


        'load on startup
        Dim hStartKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True)
        If hStartKey IsNot Nothing Then
            Try
                If chkLoadOnStartup.Checked Then
                    Dim strPath As String = Application.ExecutablePath
                    strPath = """" & strPath & """"
                    hStartKey.SetValue("GabScreenshot", strPath)
                Else
                    hStartKey.DeleteValue("GabScreenshot")
                End If
            Catch
                'Catching exceptions is for communists
            End Try
            hStartKey.Close()
        End If

        My.Settings.GS_Setting_LoadOnStartup = chkLoadOnStartup.Checked

    End Sub

    Private Sub UpdatePreview(Optional ByVal sender As System.Object = Nothing, Optional ByVal e As System.EventArgs = Nothing) Handles txtPrefix.TextChanged, NUDPadLeft.ValueChanged

        If IsPrefixInvalid() Then
            txtPreview.ForeColor = SystemColors.WindowText
            txtPreview.Text = """, \, /, :, ?, *, |, <, > illegal."
        Else
            Dim str1 As String = txtPrefix.Text & "1".ToString().PadLeft(CInt(NUDPadLeft.Value), CChar("0")) & ".jpg"
            Dim str2 As String = txtPrefix.Text & "1234".ToString().PadLeft(CInt(NUDPadLeft.Value), CChar("0")) & ".png"
            Dim str3 As String = txtPrefix.Text & "1234567".ToString().PadLeft(CInt(NUDPadLeft.Value), CChar("0")) & ".tif"
            txtPreview.Text = str1 & ", " & str2 & ", " & str3
        End If

    End Sub

    Private Function IsPrefixInvalid() As Boolean

        Dim isInvalid As Boolean = False
        Dim invalid() As String = {"""", "\", "/", ":", "?", "*", "|", "<", ">"}

        For Each token As String In invalid
            If txtPrefix.Text.Contains(token) Then
                isInvalid = True
                Exit For
            End If
        Next

        Return isInvalid

    End Function

End Class
