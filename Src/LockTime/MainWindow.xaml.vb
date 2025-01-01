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
'*     LockTime - MainWindows.xaml.vb                  *
'*                                                     *
'*     Copyright (c) CJH.                              *
'*                                                     *
'*     Main Window.                                    *
'*                                                     *
'\*****************************************************/
Imports System.Windows.Threading
Imports Microsoft.VisualBasic
Imports iNKORE.UI.WPF.Modern.Controls
Imports iNKORE.UI.WPF.Modern
Imports iNKORE.UI.WPF.Modern.Controls.Helpers

Class MainWindow
    Dim Timer1 As New DispatcherTimer
    '初始化
    Private Sub MainWindow_Initialized() Handles MyBase.Initialized
        ThemeManager.Current.ApplicationTheme = ApplicationTheme.Dark
        Themeb.ToolTip = "当前颜色为深色模式"
        Backgroundb.ToolTip = "当前背景为亚克力"
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
                Me.Left = (System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width - Me.Width) / 2
                Me.Top = (System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height - Me.Height) / 2
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
            End If
        Else
            ThemeManager.Current.ApplicationTheme = ApplicationTheme.Dark
            Themeb.Label = "深色"
            Themeb.ToolTip = "当前颜色为深色模式"
            Await Task.Delay(2000)
            If Themeb.Label = "深色" Then
                Themeb.Label = "颜色"
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
            Me.Left = (System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width - Me.Width) / 2
            Me.Top = (System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height - Me.Height) / 2
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
            End If
        ElseIf WindowHelper.GetSystemBackdropType(Me) = iNKORE.UI.WPF.Modern.Helpers.Styles.BackdropType.Mica Then
            WindowHelper.SetSystemBackdropType(Me, iNKORE.UI.WPF.Modern.Helpers.Styles.BackdropType.Acrylic)
            Backgroundb.Label = "亚克力"
            Backgroundb.ToolTip = "当前背景效果为亚克力"
            Await Task.Delay(2000)
            If Backgroundb.Label = "亚克力" Then
                Backgroundb.Label = "背景"
            End If
        ElseIf WindowHelper.GetSystemBackdropType(Me) = iNKORE.UI.WPF.Modern.Helpers.Styles.BackdropType.Acrylic Then
            WindowHelper.SetSystemBackdropType(Me, iNKORE.UI.WPF.Modern.Helpers.Styles.BackdropType.Tabbed)
            Backgroundb.Label = "Tabbed"
            Backgroundb.ToolTip = "当前背景效果为Tabbed"
            Await Task.Delay(2000)
            If Backgroundb.Label = "Tabbed" Then
                Backgroundb.Label = "背景"
            End If
        ElseIf WindowHelper.GetSystemBackdropType(Me) = iNKORE.UI.WPF.Modern.Helpers.Styles.BackdropType.Tabbed Then
            WindowHelper.SetSystemBackdropType(Me, iNKORE.UI.WPF.Modern.Helpers.Styles.BackdropType.Acrylic10)
            Backgroundb.Label = "亚克力10"
            Backgroundb.ToolTip = "当前背景效果为亚克力10"
            Await Task.Delay(2000)
            If Backgroundb.Label = "亚克力10" Then
                Backgroundb.Label = "背景"
            End If
        ElseIf WindowHelper.GetSystemBackdropType(Me) = iNKORE.UI.WPF.Modern.Helpers.Styles.BackdropType.Acrylic10 Then
            WindowHelper.SetSystemBackdropType(Me, iNKORE.UI.WPF.Modern.Helpers.Styles.BackdropType.Acrylic11)
            Backgroundb.Label = "亚克力11"
            Backgroundb.ToolTip = "当前背景效果为亚克力11"
            Await Task.Delay(2000)
            If Backgroundb.Label = "亚克力11" Then
                Backgroundb.Label = "背景"
            End If
        ElseIf WindowHelper.GetSystemBackdropType(Me) = iNKORE.UI.WPF.Modern.Helpers.Styles.BackdropType.Acrylic11 Then
            WindowHelper.SetSystemBackdropType(Me, iNKORE.UI.WPF.Modern.Helpers.Styles.BackdropType.None)
            Backgroundb.Label = "无"
            Backgroundb.ToolTip = "当前没有背景效果"
            Await Task.Delay(2000)
            If Backgroundb.Label = "无" Then
                Backgroundb.Label = "背景"
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
