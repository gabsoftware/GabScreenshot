Imports GabSoftware.Utils
Imports System.Runtime.InteropServices
Imports System.Text

Public Class FrmMain

    ''' <summary>
    ''' objet qui capture les touches du clavier
    ''' </summary>
    ''' <remarks></remarks>
    Friend WithEvents keyHook As GabKeyboardHook

    Private firstPosition As Point?
    Private lastPosition As Point?
    Private rect As Rectangle

    Private bg As BufferedGraphics
    Private bgc As New BufferedGraphicsContext()
    Private g1 As Graphics

    Private currentScreen As Screen
    Private currentScreenIndex As Integer = 0

    <DllImport("user32.dll", SetLastError:=True)> _
    Private Shared Function GetForegroundWindow() As IntPtr
    End Function

    <DllImport("user32.dll")> _
    Public Shared Function GetWindowRect(ByVal hWnd As IntPtr, ByRef lpRect As RECTW32) As Boolean
    End Function

    Public Enum eCaptureMode
        AllScreens
        CurrentScreen
        CurrentWindow
        SelectedRegion
        None
    End Enum
    Private CaptureMode As eCaptureMode = eCaptureMode.None

    ''' <summary>
    ''' Type de captures
    ''' </summary>
    Public Enum ScreenShotType
        VirtualScreen
        PrimaryScreen
        CurrentScreen
        WorkingArea
    End Enum


    Public Shared Function GetCurrentDpi() As SizeF

        Using frm As Form = New Form()
            Using g As Graphics = frm.CreateGraphics()
                Dim result As SizeF = New SizeF() With {.Width = g.DpiX, .Height = g.DpiY}
                Return result
            End Using
        End Using

    End Function




    ''' <summary>
    ''' Effectue une capture d'écran 
    ''' </summary>
    ''' <param name="type">Type de capture</param>
    ''' <returns>Bitmap représentant la capture d'écran</returns>
    Public Function sCapture(ByVal type As ScreenShotType) As Bitmap

        Dim rect As Rectangle

        Try
            Select Case type
                Case ScreenShotType.CurrentScreen
                    'Obtain the handle of the active window.
                    Dim handle As IntPtr = GetForegroundWindow()

                    'capture le rectangle de l'écran
                    rect = Screen.FromHandle(handle).Bounds

                Case ScreenShotType.PrimaryScreen
                    rect = Screen.PrimaryScreen.Bounds

                Case ScreenShotType.VirtualScreen
                    rect = SystemInformation.VirtualScreen

                Case ScreenShotType.WorkingArea
                    'Obtain the handle of the active window.
                    Dim handle As IntPtr = GetForegroundWindow()
                    rect = Screen.FromHandle(handle).WorkingArea

                Case Else

            End Select

            'Bitmap = sCapture(rect)
            sCapture = scapture(rect)
        Catch ex As Exception
            Throw ex
        End Try

        ' retourne la capture
        'Return bitmap
    End Function

    '''' <summary>
    '    ''' Capture l'affichage de l'écran dont l'identifiant est 
    '''' passé en paramètre
    '''' </summary>
    '''' <param name="screen__1">Identifiant de l'écran</param>
    '''' <returns>Bitmap représentant la capture d'écran</returns>
    'Public Function sCaptureScreen(ByVal screen__1 As Integer) As Bitmap
    '    If screen__1 > Screen.AllScreens.Length Then
    '   Throw New OverflowException("Screen n°" & screen__1 & " does not exist !")
    'End If
    '    Return scapture(Screen.AllScreens(screen__1).Bounds)
    'End Function


    ''' <summary>
    ''' Capture la réprésentation graphique du Control
    ''' </summary>
    ''' <param name="control">Control à capturer</param>
    ''' <returns>Bitmap de la capture</returns>
    Public Function sCapture(ByVal control As Control) As Bitmap
        Return scapture(control.RectangleToScreen(control.ClientRectangle))
    End Function

    ''' <summary>
    ''' Capture la réprésentation graphique du formulaire
    ''' </summary>
    ''' <param name="form">Formulaire à capturer</param>
    ''' <returns>Bitmap de la capture</returns>
    Public Function sCapture(ByVal form As Form) As Bitmap
        Return sCapture(form, False)
    End Function

    ''' <summary>
    ''' Capture la réprésentation graphique du formulaire<br />
    ''' Si clientZoneOnly = true, seule la zone client sera capturée
    ''' </summary>
    ''' <param name="form">Formulaire à capturer</param>
    ''' <param name="clientZoneOnly">Capturer que la zone cliente ?</param>
    ''' <returns>Bitmap de la capture</returns>
    Public Function sCapture(ByVal form As Form, ByVal clientZoneOnly As Boolean) As Bitmap
        'Dim bitmap As Bitmap = Nothing

        If clientZoneOnly Then
            'bitmap = sCapture(form.RectangleToScreen(form.ClientRectangle))
            sCapture = scapture(form.RectangleToScreen(form.ClientRectangle))
        Else
            'bitmap = sCapture(form.Bounds)
            sCapture = scapture(form.Bounds)
        End If
        'Return bitmap
    End Function

    ''' <summary>
    ''' Capture la zone de l'écran spécifiée
    ''' </summary>
    ''' <param name="rect">Zone de l'écran à capturer</param>
    ''' <returns>Bitmap représentant la capture</returns>
    Private Function scapture(ByVal rect As Rectangle) As Bitmap

        Dim dpi As SizeF = GetCurrentDpi()
        Dim scale As SizeF = New SizeF() With {.Width = dpi.Width / 96.0F, .Height = dpi.Height / 96.0F}
        rect.X = rect.X * Convert.ToInt32(Math.Round(scale.Width, 0))
        rect.Y = rect.Y * Convert.ToInt32(Math.Round(scale.Height, 0))
        rect.Width = rect.Width * Convert.ToInt32(Math.Round(scale.Width, 0))
        rect.Height = rect.Height * Convert.ToInt32(Math.Round(scale.Height, 0))

        scapture = New Bitmap(rect.Width, rect.Height, Imaging.PixelFormat.Format32bppArgb)

        'Using g As Graphics = Graphics.FromImage(Bitmap)
        Using g As Graphics = Graphics.FromImage(scapture)
            'g.CopyFromScreen(rect.Left, rect.Top, 0, 0, rect.Size, CopyPixelOperation.SourceCopy)
            g.CopyFromScreen(GetX(rect.Left), GetY(rect.Top), 0, 0, rect.Size, CopyPixelOperation.SourceCopy)
        End Using

        'Return Bitmap
    End Function


    ''' <summary>
    ''' Capture la fenêtre correspondant au handle spécifié
    ''' </summary>
    ''' <param name="hwnd">Handle de la fenêtre à capturer</param>
    ''' <returns>Bitmap représentant la capture</returns>
    Private Function scapture(ByVal hwnd As IntPtr) As Bitmap
        'Obtain the handle of the active window.
        Dim win32rect As RECTW32
        'Dim bitmap As New Bitmap(1, 1)
        scapture = New Bitmap(1, 1)
        If GetWindowRect(hwnd, win32rect) Then
            rect = win32rect.ToRectangle()

            Dim dpi As SizeF = GetCurrentDpi()
            Dim scale As SizeF = New SizeF() With {.Width = dpi.Width / 96.0F, .Height = dpi.Height / 96.0F}
            rect.X = rect.X * Convert.ToInt32(Math.Round(scale.Width, 0))
            rect.Y = rect.Y * Convert.ToInt32(Math.Round(scale.Height, 0))
            rect.Width = rect.Width * Convert.ToInt32(Math.Round(scale.Width, 0))
            rect.Height = rect.Height * Convert.ToInt32(Math.Round(scale.Height, 0))

            'bitmap = New Bitmap(rect.Width, rect.Height, Imaging.PixelFormat.Format32bppArgb)
            'Dim g As Graphics = Graphics.FromImage(Bitmap)
            scapture = New Bitmap(rect.Width, rect.Height, Imaging.PixelFormat.Format32bppArgb)
            Dim g As Graphics = Graphics.FromImage(scapture)
            g.CopyFromScreen(rect.Left, rect.Top, 0, 0, rect.Size, CopyPixelOperation.SourceCopy)
            g.Dispose()

        End If


        'Return bitmap

    End Function

    Private Sub FrmMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'on désinstalle le hook du clavier
        Me.keyHook.Stop(True, False)
    End Sub





    Private Sub FrmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'On met les threads de l'application en basse priorité pour ne pas déranger le système
        For Each t As System.Diagnostics.ProcessThread In System.Diagnostics.Process.GetCurrentProcess().Threads
            t.PriorityLevel = ThreadPriorityLevel.Lowest 'we don't want our application to eat too much processor time !
        Next
        System.Diagnostics.Process.GetCurrentProcess().PriorityClass = System.Diagnostics.ProcessPriorityClass.Idle 'same here !
        System.Diagnostics.Process.GetCurrentProcess().PriorityBoostEnabled = True 'but prioritize when needed

        'On capture toutes les touches même si on a pas le focus
        Me.keyHook = New GabKeyboardHook(True)

        'On recherche le répertoire Mes images si aucun chemin valide n'est trouvé
        If My.Settings.GS_Setting_SavePath = "" Or Not IO.Directory.Exists(My.Settings.GS_Setting_SavePath) Then
            My.Settings.GS_Setting_SavePath = Microsoft.VisualBasic.FileIO.SpecialDirectories.MyPictures
            My.Settings.Save()
        End If

        currentScreen = getPrimaryMonitor()
        currentScreenIndex = getPrimaryMonitorIndex()

        Me.WindowState = FormWindowState.Normal
        Me.ClientSize = New Size(500, 500)
        Application.DoEvents()
        Me.StartPosition = FormStartPosition.Manual
        Me.Left = currentScreen.Bounds.Left
        Me.Top = currentScreen.Bounds.Top
        Me.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Maximized

    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click

        'On doit fermer !
        Application.Exit()
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)

        Me.g1 = Me.CreateGraphics()



    End Sub

    Private Sub FrmMain_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown

        If CaptureMode = eCaptureMode.SelectedRegion AndAlso e.Button = Windows.Forms.MouseButtons.Left AndAlso firstPosition.HasValue = False Then

            firstPosition = e.Location

        End If


    End Sub

    Private Sub FrmMain_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove

        Dim strbld As StringBuilder
        Dim strres As String
        Dim textsizef As SizeF
        Dim x As Integer
        Dim y As Integer

        If CaptureMode = eCaptureMode.SelectedRegion And e.Button = Windows.Forms.MouseButtons.Left Then

            If lastPosition.HasValue() Then

                If lastPosition.Value.X <> e.Location.X Or lastPosition.Value.Y <> e.Location.Y Then
                    lastPosition = New Point(e.Location.X, e.Location.Y)
                Else
                    Exit Sub
                End If
            Else

                lastPosition = e.Location

            End If



            If firstPosition.HasValue() Then

                If lastPosition.Value.X > firstPosition.Value.X Then
                    If lastPosition.Value.Y > firstPosition.Value.Y Then
                        rect = New Rectangle(firstPosition.Value.X, firstPosition.Value.Y, lastPosition.Value.X - firstPosition.Value.X, lastPosition.Value.Y - firstPosition.Value.Y)
                    Else
                        rect = New Rectangle(firstPosition.Value.X, lastPosition.Value.Y, lastPosition.Value.X - firstPosition.Value.X, firstPosition.Value.Y - lastPosition.Value.Y)
                    End If
                Else
                    If lastPosition.Value.Y > firstPosition.Value.Y Then
                        rect = New Rectangle(lastPosition.Value.X, firstPosition.Value.Y, firstPosition.Value.X - lastPosition.Value.X, lastPosition.Value.Y - firstPosition.Value.Y)
                    Else
                        rect = New Rectangle(lastPosition.Value.X, lastPosition.Value.Y, firstPosition.Value.X - lastPosition.Value.X, firstPosition.Value.Y - lastPosition.Value.Y)
                    End If
                End If

                strbld = New StringBuilder(rect.Width.ToString())
                strbld.Append("x")
                strbld.Append(rect.Height)
                strres = strbld.ToString()

                bg = bgc.Allocate(g1, New Rectangle(0, 0, currentScreen.Bounds.Width, currentScreen.Bounds.Height))

                bg.Graphics.FillRectangle(New SolidBrush(Me.BackColor), New Rectangle(0, 0, currentScreen.Bounds.Width, currentScreen.Bounds.Height))
                bg.Graphics.DrawRectangle(New Pen(Color.Black, 2), rect)
                bg.Graphics.FillRectangle(Brushes.Red, rect)

                textsizef = bg.Graphics.MeasureString(strres, Me.Font)
                x = CInt(rect.X + ((rect.Width / 2) - (textsizef.Width / 2)))
                y = CInt(rect.Y + ((rect.Height / 2) - (textsizef.Height / 2)))

                bg.Graphics.FillRectangle(Brushes.White, x, y, textsizef.Width, textsizef.Height)
                bg.Graphics.DrawString(strres, Me.Font, Brushes.Black, x, y)

                bg.Render()
                bg.Dispose()

            End If
        End If

    End Sub

    Private Sub FrmMain_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp

        If CaptureMode = eCaptureMode.SelectedRegion And e.Button = Windows.Forms.MouseButtons.Left Then

            'on cache la fenêtre
            Me.Invalidate()
            Me.Hide()

            If firstPosition.HasValue() AndAlso lastPosition.HasValue() Then
                'on a un rectangle à capturer !

                'On capture la portion de l'écran dans un bitmap
                Dim objBitmap As Bitmap = scapture(rect)

                'Enregistre le bitmap dans un fichier
                Save(objBitmap)

                objBitmap.Dispose()

            End If
            Cursor = Cursors.Default
            CaptureMode = eCaptureMode.None
            firstPosition = Nothing
            lastPosition = Nothing

        End If

    End Sub

    Private Sub FrmMain_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.NI.Visible = True
        Me.Hide()
        If My.Settings.GS_Setting_ShowTooltip = True Then
            Me.NI.ShowBalloonTip(5000)
        End If

    End Sub

    Private Sub keyHook_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles keyHook.KeyDown
        Me.SetKeyboardActions(e, Me.ContainsFocus)
    End Sub

    Private Sub SetKeyboardActions(ByVal touche As System.Windows.Forms.KeyEventArgs, ByVal hasFocus As Boolean)

        ' si on est en train de capturer une zone d'écran
        If CaptureMode = eCaptureMode.SelectedRegion Then

            If touche.KeyCode = Keys.Escape Then
                CaptureMode = eCaptureMode.None
                lastPosition = Nothing
                firstPosition = Nothing
                Cursor = Cursors.Default
                Me.Hide()
                Exit Sub
            ElseIf touche.KeyCode = Keys.Space Or touche.KeyCode = Keys.Tab Then
                currentScreen = getNextMonitor()
                Me.WindowState = FormWindowState.Normal
                Me.ClientSize = New Size(500, 500)
                Application.DoEvents()
                Me.StartPosition = FormStartPosition.Manual
                Me.Left = currentScreen.Bounds.Left
                Me.Top = currentScreen.Bounds.Top
                Me.WindowState = FormWindowState.Normal
                Me.WindowState = FormWindowState.Maximized
            End If

        End If

        'écran courant
        If touche.KeyCode = Keys.PrintScreen _
            And touche.Control _
            And touche.Shift Then

            CaptureMode = eCaptureMode.CurrentScreen
            touche.Handled = True

            'capture l'écran dans un bitmap
            Dim objBitmap As Bitmap = sCapture(ScreenShotType.CurrentScreen)

            'Enregistre le bitmap dans un fichier
            Save(objBitmap)

            objBitmap.Dispose()


            'ecran courant sans barre des tâches
        ElseIf touche.KeyCode = Keys.PrintScreen _
            And touche.Control _
            And touche.Alt Then

            CaptureMode = eCaptureMode.CurrentScreen
            touche.Handled = True

            'capture l'écran dans un bitmap
            Dim objBitmap As Bitmap = sCapture(ScreenShotType.WorkingArea)

            'Enregistre le bitmap dans un fichier
            Save(objBitmap)

            objBitmap.Dispose()




            'portion de l'écran
        ElseIf touche.KeyCode = Keys.PrintScreen And touche.Shift Then

            Me.Show()

            CaptureMode = eCaptureMode.SelectedRegion
            touche.Handled = True
            Cursor = Cursors.Cross

            currentScreen = getCurrentScreen()
            Me.WindowState = FormWindowState.Normal
            Me.ClientSize = New Size(500, 500)
            Application.DoEvents()
            Me.StartPosition = FormStartPosition.Manual
            Me.Left = currentScreen.Bounds.Left
            Me.Top = currentScreen.Bounds.Top
            Me.WindowState = FormWindowState.Normal
            Me.WindowState = FormWindowState.Maximized


            'fenêtre en cours
        ElseIf touche.KeyCode = Keys.PrintScreen And touche.Alt Then

            CaptureMode = eCaptureMode.CurrentWindow

            'Obtain the handle of the active window.
            Dim handle As IntPtr = GetForegroundWindow()

            Dim objBitmap As Bitmap = scapture(handle)

            'Enregistre le bitmap dans un fichier
            Save(objBitmap)
            objBitmap.Dispose()

            touche.Handled = True


            'tous les écrans
        ElseIf touche.KeyCode = Keys.PrintScreen And touche.Control Then
            CaptureMode = eCaptureMode.AllScreens
            touche.Handled = True

            'capture le rectangle de l'écran
            'Dim objRectangle As Rectangle = Screen.PrimaryScreen.Bounds

            'capture l'écran dans un bitmap
            Dim objBitmap As Bitmap = sCapture(ScreenShotType.VirtualScreen)

            'Enregistre le bitmap dans un fichier
            Save(objBitmap)

            objBitmap.Dispose()

        End If
    End Sub

    Private Sub Save(ByRef myBitmap As Bitmap)

        Dim f As Imaging.ImageFormat
        Select Case My.Settings.GS_Setting_FileType.ToLower
            Case "jpeg"
                f = Imaging.ImageFormat.Jpeg

            Case "png"
                f = Imaging.ImageFormat.Png

            Case "gif"
                f = Imaging.ImageFormat.Gif

            Case "bmp"
                f = Imaging.ImageFormat.Bmp

            Case "emf"
                f = Imaging.ImageFormat.Emf

            Case "wmf"
                f = Imaging.ImageFormat.Wmf

            Case "tiff"
                f = Imaging.ImageFormat.Tiff

            Case "icon"
                f = Imaging.ImageFormat.Icon

            Case Else
                f = Imaging.ImageFormat.Png
        End Select

        Save(myBitmap, f)

    End Sub

    Private Sub Save(ByRef myBitmap As Bitmap, ByRef format As Imaging.ImageFormat)

        Dim num As Integer = 1
        'Dim str As String
        Dim ext As String
        Dim builder As New System.Text.StringBuilder()


        Select Case format.ToString.ToLower()

            Case "jpeg"
                ext = ".jpg"

            Case "png"
                ext = ".png"

            Case "gif"
                ext = ".gif"

            Case "bmp"
                ext = ".bmp"

            Case "emf"
                ext = ".emf"

            Case "wmf"
                ext = ".wmf"

            Case "tiff"
                ext = ".tif"

            Case "icon"
                ext = ".ico"

            Case Else
                ext = ".jpg"

        End Select

        builder.Append(My.Settings.GS_Setting_SavePath)
        builder.Append("\")
        builder.Append(My.Settings.GS_Setting_FilenamePrefix)
        builder.Append(num.ToString().PadLeft(CInt(My.Settings.GS_Setting_PadLeft), CChar("0")))
        builder.Append(ext)

        While IO.File.Exists(builder.ToString())

            num += 1
            builder.Remove(0, builder.Length)
            builder.Append(My.Settings.GS_Setting_SavePath)
            builder.Append("\")
            builder.Append(My.Settings.GS_Setting_FilenamePrefix)
            builder.Append(num.ToString().PadLeft(CInt(My.Settings.GS_Setting_PadLeft), CChar("0")))
            builder.Append(ext)

        End While

        Dim dpi As SizeF = GetCurrentDpi()
        myBitmap.SetResolution(dpi.Width, dpi.Height)
        myBitmap.Save(builder.ToString(), format)


    End Sub

    Private Sub NI_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NI.MouseClick

        If e.Button = Windows.Forms.MouseButtons.Left Then
            Me.NI.ShowBalloonTip(5000)
        End If

    End Sub

    Private Sub AboutGabScreenshotToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutGabScreenshotToolStripMenuItem.Click

        MsgBox("GabScreenshot v" & Application.ProductVersion & Environment.NewLine & Environment.NewLine & "GabSoftware (c) 2010", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "GabScreenshot")

    End Sub



    <StructLayout(LayoutKind.Sequential)> _
    Public Structure RECTW32
        Public Left As Integer
        Public Top As Integer
        Public Right As Integer
        Public Bottom As Integer

        Public Sub New(ByVal pLeft As Integer, ByVal pTop As Integer, ByVal pRight As Integer, ByVal pBottom As Integer)
            Left = pLeft
            Top = pTop
            Right = pRight
            Bottom = pBottom
        End Sub

        Public ReadOnly Property Height() As Integer
            Get
                Return Bottom - Top
            End Get
        End Property
        Public ReadOnly Property Width() As Integer
            Get
                Return Right - Left
            End Get
        End Property
        Public ReadOnly Property Location() As Point
            Get
                Return New Point(Left, Top)
            End Get
        End Property
        Public ReadOnly Property Size() As Size
            Get
                Return New Size(Width, Height)
            End Get
        End Property

        Public Function ToRectangle() As Rectangle
            Return Rectangle.FromLTRB(Me.Left, Me.Top, Me.Right, Me.Bottom)
        End Function

        Public Shared Function ToRectangle(ByVal sourceRect As RECTW32) As Rectangle
            Return Rectangle.FromLTRB(sourceRect.Left, sourceRect.Top, sourceRect.Right, sourceRect.Bottom)
        End Function

        Public Shared Function FromRectangle(ByVal r As Rectangle) As RECTW32
            Return New RECTW32(r.Left, r.Top, r.Right, r.Bottom)
        End Function
    End Structure

    Private Sub OptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionsToolStripMenuItem.Click
        Dim f As New frmOptions
        f.Show()
    End Sub


    Private Function getNextMonitor() As Screen

        Dim screens As Screen() = Screen.AllScreens
        Me.currentScreenIndex += 1
        If currentScreenIndex >= screens.Length Then
            currentScreenIndex = 0
        End If

        Return screens(currentScreenIndex)

    End Function

    Private Function getPrimaryMonitor() As Screen
        Dim index As Integer = 0
        Dim screens As Screen() = Screen.AllScreens

        For Each screen As Screen In screens
            If screen.Bounds.Left = Screen.PrimaryScreen.Bounds.Left Then
                Exit For
            Else
                index += 1
            End If
        Next

        If index >= screens.Length Then
            index = 0
        End If

        Return screens(index)

    End Function

    Private Function getPrimaryMonitorIndex() As Integer
        Dim index As Integer = 0
        Dim screens As Screen() = Screen.AllScreens

        For Each screen As Screen In screens
            If screen.Bounds.Left = Screen.PrimaryScreen.Bounds.Left Then
                Exit For
            Else
                index += 1
            End If
        Next

        If index >= screens.Length Then
            index = 0
        End If

        Return index

    End Function

    Private Function getCurrentScreen() As Screen

        Dim screens As Screen() = Screen.AllScreens

        If Me.currentScreenIndex >= screens.Length Then
            Me.currentScreenIndex = 0
        End If

        Return screens(currentScreenIndex)

    End Function

    Private Function GetX(X As Integer) As Integer
        If Me.Left = 0 Then
            Return X
        ElseIf Me.Left < 0 Then
            Return X - Math.Abs(Me.Left)
        Else
            Return X + Me.Left
        End If
    End Function

    Private Function GetY(Y As Integer) As Integer
        If Me.Top = 0 Then
            Return Y
        ElseIf Me.Top < 0 Then
            Return Y - Math.Abs(Me.Top)
        Else
            Return Y + Me.Top
        End If
    End Function

    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click
        MsgBox(NI.BalloonTipText, MsgBoxStyle.OkOnly, HelpToolStripMenuItem.Text.Replace("&", ""))
    End Sub
End Class
