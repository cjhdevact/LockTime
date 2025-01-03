'****************************************************************************
'    LockTime
'    Copyright (C) 2023-2025  CJH
'
'    This program is free software: you can redistribute it and/or modify
'    it under the terms of the GNU General Public License as published by
'    the Free Software Foundation, either version 3 of the License, or
'    (at your option) any later version.
'
'    This program is distributed in the hope that it will be useful,
'    but WITHOUT ANY WARRANTY; without even the implied warranty of
'    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'    GNU General Public License for more details.
'
'    You should have received a copy of the GNU General Public License
'    along with this program.  If not, see <http://www.gnu.org/licenses/>.
'****************************************************************************
'/*****************************************************\
'*                                                     *
'*     LockTime - LockTimeWindow.xaml.vb               *
'*                                                     *
'*     Copyright (c) CJH.                              *
'*                                                     *
'*     Main Window.                                    *
'*                                                     *
'\*****************************************************/
Imports System.Windows.Threading
Imports Microsoft.VisualBasic
Imports System.Drawing
Imports iNKORE.UI.WPF.Modern.Controls
Imports iNKORE.UI.WPF.Modern
Imports iNKORE.UI.WPF.Modern.Controls.Helpers
Imports System.Reflection
Imports Microsoft.Win32

Class MainWindow
    Dim Timer1 As New DispatcherTimer
    '获取系统版本函数
    Function GetOSVersion() As Version
        Dim strBuild1, strBuild2, strBuild3, strBuild4 As String
        Try
            Dim regKey As Microsoft.Win32.RegistryKey
            regKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows NT\CurrentVersion")
            strBuild1 = regKey.GetValue("CurrentMajorVersionNumber").ToString
            strBuild2 = regKey.GetValue("CurrentMinorVersionNumber").ToString
            strBuild3 = regKey.GetValue("CurrentBuild").ToString
            strBuild4 = regKey.GetValue("UBR").ToString
            regKey.Close()
        Catch ex As Exception
            Return Environment.OSVersion.Version
            Exit Function
        End Try
        Return New Version(strBuild1, strBuild2, strBuild3, strBuild4)
    End Function
    '初始化
    Private Sub MainWindow_Initialized() Handles MyBase.Initialized
        Dim exists As Boolean = False
        Try
            If My.Computer.Registry.CurrentUser.OpenSubKey("Software\CJH\LockTime\2.0\Settings") IsNot Nothing Then
                exists = True
            End If
        Finally
            My.Computer.Registry.CurrentUser.Close()
        End Try
        If exists = False Then
            Try
                Dim newKey As RegistryKey
                newKey = My.Computer.Registry.CurrentUser.CreateSubKey("Software\CJH\LockTime\2.0\Settings")
            Catch ex As Exception
            End Try
        End If

        Dim keyValue As Object
        keyValue = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "Theme", "-1")
        keyValue = keyValue.ToString.ToLower
        If keyValue = "dark" Then
            ThemeManager.Current.ApplicationTheme = ApplicationTheme.Dark
            Themeb.ToolTip = "当前颜色为深色模式"
        ElseIf keyValue = "light" Then
            ThemeManager.Current.ApplicationTheme = ApplicationTheme.Light
            Themeb.ToolTip = "当前颜色为浅色模式"
        Else
            ThemeManager.Current.ApplicationTheme = ApplicationTheme.Light
            Themeb.ToolTip = "当前颜色为浅色模式"
            Try
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "Theme", "Light")
            Catch ex As Exception
            End Try
        End If

        Dim keyValue2 As Object
        keyValue2 = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "Background", "-1")
        keyValue2 = keyValue2.ToString.ToLower
        If keyValue2 = "mica" Then
            Backgroundb.ToolTip = "当前背景为云母"
            WindowHelper.SetSystemBackdropType(Me, iNKORE.UI.WPF.Modern.Helpers.Styles.BackdropType.Mica)
        ElseIf keyValue2 = "acrylic" Then
            Backgroundb.ToolTip = "当前背景为亚克力"
            WindowHelper.SetSystemBackdropType(Me, iNKORE.UI.WPF.Modern.Helpers.Styles.BackdropType.Acrylic)
        ElseIf keyValue2 = "tabbed" Then
            Backgroundb.ToolTip = "当前背景为Tabbed"
            WindowHelper.SetSystemBackdropType(Me, iNKORE.UI.WPF.Modern.Helpers.Styles.BackdropType.Tabbed)
        ElseIf keyValue2 = "acrylic10" Then
            Backgroundb.ToolTip = "当前背景为亚克力10"
            WindowHelper.SetSystemBackdropType(Me, iNKORE.UI.WPF.Modern.Helpers.Styles.BackdropType.Acrylic10)
        ElseIf keyValue2 = "acrylic11" Then
            Backgroundb.ToolTip = "当前背景为亚克力11"
            WindowHelper.SetSystemBackdropType(Me, iNKORE.UI.WPF.Modern.Helpers.Styles.BackdropType.Acrylic11)
        ElseIf keyValue2 = "none" Then
            Backgroundb.ToolTip = "当前没有背景效果"
            WindowHelper.SetSystemBackdropType(Me, iNKORE.UI.WPF.Modern.Helpers.Styles.BackdropType.None)
        Else
            Dim OSVer As New Version(10, 0)
            If GetOSVersion() <= OSVer Then
                Backgroundb.ToolTip = "当前没有背景效果"
                WindowHelper.SetSystemBackdropType(Me, iNKORE.UI.WPF.Modern.Helpers.Styles.BackdropType.None)
                Try
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "Background", "None")
                Catch ex As Exception
                End Try
            Else
                Backgroundb.ToolTip = "当前背景为亚克力"
                WindowHelper.SetSystemBackdropType(Me, iNKORE.UI.WPF.Modern.Helpers.Styles.BackdropType.Acrylic)
                Try
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "Background", "Acrylic")
                Catch ex As Exception
                End Try
            End If
        End If

    End Sub
    Private Sub MainWindow_Loaded(sender As Object, e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        'Me.Title = ""
        Me.WindowStartupLocation = WindowStartupLocation.CenterScreen

        Timer1.Interval = TimeSpan.FromMilliseconds(1000)
        AddHandler Timer1.Tick, AddressOf Timer1_Tick
        AddHandler MyBase.Closing, AddressOf MainWindow_Closing
        Timer1.Start()

        'Dim e As System.Windows.RoutedEventArgs
        Dim CurCommand() As String
        Dim SetWin As Integer = 0
        CurCommand = Split(Command.ToLower, " ")
        For i = 0 To CurCommand.Count - 1
            If CurCommand(i) = "/fulltext" Then
                Call Centerb_Click(sender, e)
            ElseIf CurCommand(i) = "/toptext" Then
                Call Topb_Click(sender, e)
            ElseIf CurCommand(i) = "/bottomtext" Then
                Call Bottomb_Click(sender, e)
            ElseIf CurCommand(i) = "/lefttext" Then
                Call Leftb_Click(sender, e)
            ElseIf CurCommand(i) = "/righttext" Then
                Call Rightb_Click(sender, e)
            ElseIf CurCommand(i) = "/hidetoolbar" Then
                CommandBar1.Visibility = Visibility.Hidden
            ElseIf CurCommand(i) = "/windowmode" Then
                Me.WindowStyle = WindowStyle.SingleBorderWindow
                Me.WindowState = WindowState.Normal
                Primitives.TitleBar.SetHeight(Me, 36)
                ' 获取当前窗体的 DPI
                Dim dpiX = CInt(GetType(SystemParameters).GetProperty("DpiX", BindingFlags.NonPublic Or BindingFlags.Static).GetValue(Nothing, Nothing))
                Dim dpiY = CInt(GetType(SystemParameters).GetProperty("Dpi", BindingFlags.NonPublic Or BindingFlags.Static).GetValue(Nothing, Nothing))
                'If currentDpiX <> DefaultDPI OrElse currentDpiY <> DefaultDPI Then
                '计算缩放比例
                Dim scaleX As Single = dpiX / 96
                Dim scaleY As Single = dpiY / 96
                'WPF 位置默认已经乘了DPI，如果调整位置，要给DPI模拟后的位置（Me.Width已经默认模拟了DPI）
                Me.Left = (System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width / scaleX - Me.Width) / 2
                Me.Top = (System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height / scaleY - Me.Height) / 2
                Me.Windowb.Label = "全屏"
                Me.Windowb.ToolTip = "全屏模式"
                SetWin = 1
            End If
        Next
        If SetWin = 0 Then
            Me.WindowStyle = WindowStyle.None
            Me.WindowState = WindowState.Maximized
        End If
    End Sub
    '定时器获取时间
    Private Sub Timer1_Tick()
        timelabel.Text = Format(Now, "HH:mm:ss")
        Dim a As String
        a = Format(Now, "yyyy年 M月 d日")
        If a <> datelabel.Text Then
            datelabel.Text = a
        End If
        a = Nothing
    End Sub
    '主题
    Private Async Sub Themeb_Click(sender As Object, e As RoutedEventArgs)
        If ThemeManager.Current.ApplicationTheme = ApplicationTheme.Dark Then
            ThemeManager.Current.ApplicationTheme = ApplicationTheme.Light
            Themeb.Label = "浅色"
            Themeb.ToolTip = "当前颜色为浅色模式"
            Await Task.Delay(2000)
            If Themeb.Label = "浅色" Then
                Themeb.Label = "颜色"
                Try
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "Theme", "Light")
                Catch ex As Exception
                End Try
            End If
        Else
            ThemeManager.Current.ApplicationTheme = ApplicationTheme.Dark
            Themeb.Label = "深色"
            Themeb.ToolTip = "当前颜色为深色模式"
            Await Task.Delay(2000)
            If Themeb.Label = "深色" Then
                Themeb.Label = "颜色"
                Try
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "Theme", "Dark")
                Catch ex As Exception
                End Try
            End If
        End If
    End Sub
    '退出
    Private Sub Exitb_Click(sender As Object, e As RoutedEventArgs)
        Me.Close()
    End Sub
    '退出事件
    Private Async Sub MainWindow_Closing(sender As Object, e As ComponentModel.CancelEventArgs) 'Handles Me.Closing
        e.Cancel = True
        Dim dialog As ContentDialog = New ContentDialog()
        dialog.Title = "确定要退出时钟锁屏吗？"
        dialog.PrimaryButtonText = "确定"
        'dialog.SecondaryButtonText = "Don't Save"
        dialog.CloseButtonText = "取消"
        dialog.DefaultButton = ContentDialogButton.Close
        dialog.Content = "这将会退出时钟锁屏"
        Dim result = Await dialog.ShowAsync()
        If result = ContentDialogResult.Primary Then
            e.Cancel = False
            'Me.Close()
            End
        Else
            e.Cancel = True
        End If
    End Sub
    '窗口/非窗口化
    Private Sub Windowsb_Click(sender As Object, e As RoutedEventArgs)
        If Me.WindowState = WindowState.Maximized Then
            Primitives.TitleBar.SetHeight(Me, 36)
            Me.WindowStyle = WindowStyle.SingleBorderWindow
            Me.WindowState = WindowState.Normal
            Me.Windowb.Label = "全屏"
            Me.Windowb.ToolTip = "全屏模式"
            ' 获取当前窗体的 DPI
            Dim dpiX = CInt(GetType(SystemParameters).GetProperty("DpiX", BindingFlags.NonPublic Or BindingFlags.Static).GetValue(Nothing, Nothing))
            Dim dpiY = CInt(GetType(SystemParameters).GetProperty("Dpi", BindingFlags.NonPublic Or BindingFlags.Static).GetValue(Nothing, Nothing))
            'If currentDpiX <> DefaultDPI OrElse currentDpiY <> DefaultDPI Then
            '计算缩放比例
            Dim scaleX As Single = dpiX / 96
            Dim scaleY As Single = dpiY / 96
            'WPF 位置默认已经乘了DPI，如果调整位置，要给DPI模拟后的位置（Me.Width已经默认模拟了DPI）
            Me.Left = (System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width / scaleX - Me.Width) / 2
            Me.Top = (System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height / scaleY - Me.Height) / 2
            'Dim FontIcon1 = New FontIcon()
            'FontIcon1.FontFamily = New FontFamily("Segoe Fluent Icons")
            'FontIcon1.Glyph = "\xE740"
            'Windowb.Icon = FontIcon1
        Else
            Primitives.TitleBar.SetHeight(Me, 0)
            Me.WindowStyle = WindowStyle.None
            Me.WindowState = WindowState.Maximized
            Me.Windowb.Label = "窗口"
            Me.Windowb.ToolTip = "窗口模式"
            Me.Left = 0
            Me.Top = 0
            'Dim FontIcon1 = New FontIcon()
            'FontIcon1.FontFamily = New FontFamily("Segoe Fluent Icons")
            'FontIcon1.Glyph = "\xF597"
            'Windowb.Icon = FontIcon1
        End If
    End Sub
    '关于
    Private Async Sub Aboutb_Click(sender As Object, e As RoutedEventArgs)
        Dim dialog As ContentDialog = New ContentDialog()
        dialog.Title = "关于时钟锁屏"
        dialog.PrimaryButtonText = "确定"
        'dialog.SecondaryButtonText = "Don't Save"
        'dialog.CloseButtonText = "取消"
        dialog.DefaultButton = ContentDialogButton.Primary
        dialog.Content = New AboutPage
        'dialog.Content = "这将会退出时钟锁屏"
        Await dialog.ShowAsync()
    End Sub
    '居中
    Private Sub Centerb_Click(sender As Object, e As RoutedEventArgs)
        datelabel.SetValue(Grid.ColumnProperty, 0)
        datelabel.SetValue(Grid.ColumnSpanProperty, 2)
        timelabel.SetValue(Grid.ColumnProperty, 0)
        timelabel.SetValue(Grid.ColumnSpanProperty, 2)
        timelabel.SetValue(Grid.RowProperty, 0)
        timelabel.SetValue(Grid.RowSpanProperty, 2)
        datelabel.SetValue(Grid.RowProperty, 2)
        datelabel.SetValue(Grid.RowSpanProperty, 2)
    End Sub
    '靠左
    Private Sub Leftb_Click(sender As Object, e As RoutedEventArgs)
        datelabel.SetValue(Grid.ColumnProperty, 0)
        datelabel.SetValue(Grid.ColumnSpanProperty, 1)
        timelabel.SetValue(Grid.ColumnProperty, 0)
        timelabel.SetValue(Grid.ColumnSpanProperty, 1)
        timelabel.SetValue(Grid.RowProperty, 0)
        timelabel.SetValue(Grid.RowSpanProperty, 2)
        datelabel.SetValue(Grid.RowProperty, 2)
        datelabel.SetValue(Grid.RowSpanProperty, 2)
    End Sub
    '靠右
    Private Sub Rightb_Click(sender As Object, e As RoutedEventArgs)
        datelabel.SetValue(Grid.ColumnProperty, 1)
        datelabel.SetValue(Grid.ColumnSpanProperty, 1)
        timelabel.SetValue(Grid.ColumnProperty, 1)
        timelabel.SetValue(Grid.ColumnSpanProperty, 1)
        timelabel.SetValue(Grid.RowProperty, 0)
        timelabel.SetValue(Grid.RowSpanProperty, 2)
        datelabel.SetValue(Grid.RowProperty, 2)
        datelabel.SetValue(Grid.RowSpanProperty, 2)
    End Sub
    '顶部
    Private Sub Topb_Click(sender As Object, e As RoutedEventArgs)
        datelabel.SetValue(Grid.ColumnProperty, 0)
        datelabel.SetValue(Grid.ColumnSpanProperty, 2)
        timelabel.SetValue(Grid.ColumnProperty, 0)
        timelabel.SetValue(Grid.ColumnSpanProperty, 2)
        timelabel.SetValue(Grid.RowProperty, 0)
        timelabel.SetValue(Grid.RowSpanProperty, 1)
        datelabel.SetValue(Grid.RowProperty, 1)
        datelabel.SetValue(Grid.RowSpanProperty, 1)
    End Sub
    '底部
    Private Sub Bottomb_Click(sender As Object, e As RoutedEventArgs)
        datelabel.SetValue(Grid.ColumnProperty, 0)
        datelabel.SetValue(Grid.ColumnSpanProperty, 2)
        timelabel.SetValue(Grid.ColumnProperty, 0)
        timelabel.SetValue(Grid.ColumnSpanProperty, 2)
        timelabel.SetValue(Grid.RowProperty, 2)
        timelabel.SetValue(Grid.RowSpanProperty, 1)
        datelabel.SetValue(Grid.RowProperty, 3)
        datelabel.SetValue(Grid.RowSpanProperty, 1)
    End Sub
    '是否隐藏工具栏
    Private Sub Grid1_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles Grid1.MouseDown
        If CommandBar1.Visibility = Visibility.Hidden Then
            CommandBar1.Visibility = Visibility.Visible
        Else
            CommandBar1.Visibility = Visibility.Hidden
        End If
    End Sub
    '更换背景
    Private Async Sub Backgroundb_Click(sender As Object, e As RoutedEventArgs)
        If WindowHelper.GetSystemBackdropType(Me) = iNKORE.UI.WPF.Modern.Helpers.Styles.BackdropType.None Then
            WindowHelper.SetSystemBackdropType(Me, iNKORE.UI.WPF.Modern.Helpers.Styles.BackdropType.Mica)
            Backgroundb.Label = "云母"
            Backgroundb.ToolTip = "当前背景效果为云母"
            Await Task.Delay(2000)
            If Backgroundb.Label = "云母" Then
                Backgroundb.Label = "背景"
                Try
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "Background", "Mica")
                Catch ex As Exception
                End Try
            End If
        ElseIf WindowHelper.GetSystemBackdropType(Me) = iNKORE.UI.WPF.Modern.Helpers.Styles.BackdropType.Mica Then
            WindowHelper.SetSystemBackdropType(Me, iNKORE.UI.WPF.Modern.Helpers.Styles.BackdropType.Acrylic)
            Backgroundb.Label = "亚克力"
            Backgroundb.ToolTip = "当前背景效果为亚克力"
            Await Task.Delay(2000)
            If Backgroundb.Label = "亚克力" Then
                Backgroundb.Label = "背景"
                Try
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "Background", "Acrylic")
                Catch ex As Exception
                End Try
            End If
        ElseIf WindowHelper.GetSystemBackdropType(Me) = iNKORE.UI.WPF.Modern.Helpers.Styles.BackdropType.Acrylic Then
            WindowHelper.SetSystemBackdropType(Me, iNKORE.UI.WPF.Modern.Helpers.Styles.BackdropType.Tabbed)
            Backgroundb.Label = "Tabbed"
            Backgroundb.ToolTip = "当前背景效果为Tabbed"
            Await Task.Delay(2000)
            If Backgroundb.Label = "Tabbed" Then
                Backgroundb.Label = "背景"
                Try
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "Background", "Tabbed")
                Catch ex As Exception
                End Try
            End If
        ElseIf WindowHelper.GetSystemBackdropType(Me) = iNKORE.UI.WPF.Modern.Helpers.Styles.BackdropType.Tabbed Then
            WindowHelper.SetSystemBackdropType(Me, iNKORE.UI.WPF.Modern.Helpers.Styles.BackdropType.Acrylic10)
            Backgroundb.Label = "亚克力10"
            Backgroundb.ToolTip = "当前背景效果为亚克力10"
            Await Task.Delay(2000)
            If Backgroundb.Label = "亚克力10" Then
                Backgroundb.Label = "背景"
                Try
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "Background", "Acrylic10")
                Catch ex As Exception
                End Try
            End If
        ElseIf WindowHelper.GetSystemBackdropType(Me) = iNKORE.UI.WPF.Modern.Helpers.Styles.BackdropType.Acrylic10 Then
            WindowHelper.SetSystemBackdropType(Me, iNKORE.UI.WPF.Modern.Helpers.Styles.BackdropType.Acrylic11)
            Backgroundb.Label = "亚克力11"
            Backgroundb.ToolTip = "当前背景效果为亚克力11"
            Await Task.Delay(2000)
            If Backgroundb.Label = "亚克力11" Then
                Backgroundb.Label = "背景"
                Try
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "Background", "Acrylic11")
                Catch ex As Exception
                End Try
            End If
        ElseIf WindowHelper.GetSystemBackdropType(Me) = iNKORE.UI.WPF.Modern.Helpers.Styles.BackdropType.Acrylic11 Then
            WindowHelper.SetSystemBackdropType(Me, iNKORE.UI.WPF.Modern.Helpers.Styles.BackdropType.None)
            Backgroundb.Label = "无"
            Backgroundb.ToolTip = "当前没有背景效果"
            Await Task.Delay(2000)
            If Backgroundb.Label = "无" Then
                Backgroundb.Label = "背景"
                Try
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "Background", "None")
                Catch ex As Exception
                End Try
            End If
        End If
    End Sub
    'Private Sub timelabel_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles timelabel.MouseUp
    '    If CommandBar1.Visibility = Visibility.Hidden Then
    '        CommandBar1.Visibility = Visibility.Visible
    '    Else
    '        CommandBar1.Visibility = Visibility.Hidden
    '    End If
    'End Sub

    'Private Sub datelabel_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles datelabel.MouseUp
    '    If CommandBar1.Visibility = Visibility.Hidden Then
    '        CommandBar1.Visibility = Visibility.Visible
    '    Else
    '        CommandBar1.Visibility = Visibility.Hidden
    '    End If
    'End Sub
End Class
