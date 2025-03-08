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
'*     LockTime - LockTimeThemePage.xaml.vb            *
'*                                                     *
'*     Copyright (c) CJH.                              *
'*                                                     *
'*     Theme settings.                                 *
'*                                                     *
'\*****************************************************/
Imports iNKORE.UI.WPF.Modern
Imports iNKORE.UI.WPF.Modern.Controls
Imports Microsoft.Win32

Class LockTimeThemePage
    '初始化页面
    Private Sub Page_Loaded(sender As Object, e As RoutedEventArgs)
        'IsEnterV = 0
        'FontSizeV = 0

        '############################################################
        '隐藏工具栏文字选项初始化
        If My.Application.HideTextState = 1 Then
            HideTextToggleSwitch.IsOn = True
        Else
            HideTextToggleSwitch.IsOn = False
        End If

        '############################################################
        '时间字体选择初始化
        Dim fontFamilies() As System.Drawing.FontFamily = System.Drawing.FontFamily.Families
        ' 遍历并打印所有字体名称
        For Each family As System.Drawing.FontFamily In fontFamilies
            TimeFontNameComboBox.Items.Add(family.Name)
        Next
        'TimeFontSizeComboBox.Items.Add(8)
        'TimeFontSizeComboBox.Items.Add(9)
        'TimeFontSizeComboBox.Items.Add(10)
        'TimeFontSizeComboBox.Items.Add(11)
        'TimeFontSizeComboBox.Items.Add(12)
        'TimeFontSizeComboBox.Items.Add(14)
        'TimeFontSizeComboBox.Items.Add(16)
        'TimeFontSizeComboBox.Items.Add(18)
        'TimeFontSizeComboBox.Items.Add(20)
        'TimeFontSizeComboBox.Items.Add(22)
        'TimeFontSizeComboBox.Items.Add(24)
        'TimeFontSizeComboBox.Items.Add(26)
        'TimeFontSizeComboBox.Items.Add(28)
        'TimeFontSizeComboBox.Items.Add(36)
        'TimeFontSizeComboBox.Items.Add(48)
        'TimeFontSizeComboBox.Items.Add(72)
        'TimeFontSizeComboBox.Items.Add(84)
        'TimeFontSizeComboBox.Items.Add(96)
        'TimeFontSizeComboBox.Items.Add(100)
        'TimeFontSizeComboBox.Items.Add(200)
        TimeFontStylePreview.FontSize = My.Application.TimeFontSize
        TimeFontStylePreview.FontFamily = New FontFamily(My.Application.TimeFontName)
        TimeFontNameComboBox.SelectedIndex = TimeFontNameComboBox.Items.IndexOf(TimeFontStylePreview.FontFamily.Source)
        'If My.Application.Runa <> 1 Then
        '    TimeFontSizeComboBox.SelectedIndex = TimeFontSizeComboBox.Items.IndexOf(20)
        '    My.Application.Runa = 1
        'End If

        '日期字体选择初始化
        For Each family As System.Drawing.FontFamily In fontFamilies
            DateFontNameComboBox.Items.Add(family.Name)
        Next
        'DateFontSizeComboBox.Items.Add(8)
        'DateFontSizeComboBox.Items.Add(9)
        'DateFontSizeComboBox.Items.Add(10)
        'DateFontSizeComboBox.Items.Add(11)
        'DateFontSizeComboBox.Items.Add(12)
        'DateFontSizeComboBox.Items.Add(14)
        'DateFontSizeComboBox.Items.Add(16)
        'DateFontSizeComboBox.Items.Add(18)
        'DateFontSizeComboBox.Items.Add(20)
        'DateFontSizeComboBox.Items.Add(22)
        'DateFontSizeComboBox.Items.Add(24)
        'DateFontSizeComboBox.Items.Add(26)
        'DateFontSizeComboBox.Items.Add(28)
        'DateFontSizeComboBox.Items.Add(36)
        'DateFontSizeComboBox.Items.Add(48)
        'DateFontSizeComboBox.Items.Add(72)
        'DateFontSizeComboBox.Items.Add(84)
        'DateFontSizeComboBox.Items.Add(96)
        'DateFontSizeComboBox.Items.Add(100)
        'DateFontSizeComboBox.Items.Add(200)
        DateFontStylePreview.FontSize = My.Application.DateFontSize
        DateFontStylePreview.FontFamily = New FontFamily(My.Application.DateFontName)
        DateFontNameComboBox.SelectedIndex = DateFontNameComboBox.Items.IndexOf(DateFontStylePreview.FontFamily.Source)
        'If My.Application.Runa <> 1 Then
        '    DateFontSizeComboBox.SelectedIndex = DateFontSizeComboBox.Items.IndexOf(DateFontStylePreview.FontSize)
        '    My.Application.Runa = 1
        'End If

        '设置显示内容
        'MsgBox(FontNameComboBox.Items.IndexOf(FontStylePreview.FontSize))
        If TimeFontNameComboBox.SelectedIndex = -1 Then
            TimeFontNameComboBox.Text = TimeFontStylePreview.FontFamily.Source
        End If
        'If TimeFontSizeComboBox.SelectedIndex = -1 Then
        TimeFontSizeComboBox.Text = My.Application.TimeFontSize
        'End If

        If DateFontNameComboBox.SelectedIndex = -1 Then
            DateFontNameComboBox.Text = DateFontStylePreview.FontFamily.Source
        End If
        'If DateFontSizeComboBox.SelectedIndex = -1 Then
        DateFontSizeComboBox.Text = My.Application.DateFontSize
        'End If

        '关联时间
        AddHandler TimeFontNameComboBox.SelectionChanged, AddressOf TimeFontNameComboBox_SelectionChanged
        AddHandler TimeFontSizeComboBox.SelectionChanged, AddressOf TimeFontSizeComboBox_SelectionChanged

        AddHandler DateFontNameComboBox.SelectionChanged, AddressOf DateFontNameComboBox_SelectionChanged
        AddHandler DateFontSizeComboBox.SelectionChanged, AddressOf DateFontSizeComboBox_SelectionChanged

        '############################################################
        '设置显示格式初始化
        TimeFormatTextBox.Text = My.Application.TimeFormat
        DateFormatTextBox.Text = My.Application.DateFormat

        '############################################################
        '初始化更新提示
        If My.Application.UpdateSetting = 1 Then
            If My.Application.UpdateOK = 1 Then
                Me.UpdateInfoBar.Title = My.Application.UpdateTitle
                Me.UpdateInfoBar.Message = My.Application.UpdateMsg
                Me.UpdateInfoBar.IsOpen = True
                Me.UpdateInfoBar.Visibility = Visibility.Visible
            Else
                Me.UpdateInfoBar.IsOpen = False
                Me.UpdateInfoBar.Visibility = Visibility.Collapsed
            End If
        Else
            Me.UpdateInfoBar.IsOpen = False
            Me.UpdateInfoBar.Visibility = Visibility.Collapsed
        End If
    End Sub
    '设置是否显示文字
    '通过把设置一个全局变量来表示是否更新设置，再在主窗口设置一个定时器来定时获取这个变量的状态来判断是否要更新主界面设置
    'WPF窗体之间传递变量怎么这么难？
    Private Sub HideTextToggleSwitch_Toggled(sender As Object, e As RoutedEventArgs) Handles HideTextToggleSwitch.Toggled
        If HideTextToggleSwitch.IsOn = True Then
            My.Application.HideTextState = 1
            Try
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "HideText", 1, RegistryValueKind.DWord)
            Catch ex As Exception
            End Try
            My.Application.SettingsState = 1
            'Dispatcher.Invoke(New LockTimeWindow.HideTextStateSub(AddressOf My.Windows.m_LockTimeWindow.SetUIText), 1)
            'My.Windows.LockTimeWindow.Exitb.LabelPosition = CommandBarLabelPosition.Collapsed
            'My.Windows.LockTimeWindow.Settingb.LabelPosition = CommandBarLabelPosition.Collapsed
            'My.Windows.LockTimeWindow.Aboutb.LabelPosition = CommandBarLabelPosition.Collapsed
            'My.Windows.LockTimeWindow.Themeb.LabelPosition = CommandBarLabelPosition.Collapsed
            'My.Windows.LockTimeWindow.Backgroundb.LabelPosition = CommandBarLabelPosition.Collapsed
            'My.Windows.LockTimeWindow.Windowb.LabelPosition = CommandBarLabelPosition.Collapsed
            'My.Windows.LockTimeWindow.Centerb.LabelPosition = CommandBarLabelPosition.Collapsed
            'My.Windows.LockTimeWindow.Topb.LabelPosition = CommandBarLabelPosition.Collapsed
            'My.Windows.LockTimeWindow.Bottomb.LabelPosition = CommandBarLabelPosition.Collapsed
            'My.Windows.LockTimeWindow.Leftb.LabelPosition = CommandBarLabelPosition.Collapsed
            'My.Windows.LockTimeWindow.Rightb.LabelPosition = CommandBarLabelPosition.Collapsed
            'My.Windows.LockTimeWindow.Exitb.Label = ""
            'My.Windows.LockTimeWindow.Settingb.Content = ""
            'My.Windows.LockTimeWindow.Aboutb.Content = ""
            'My.Windows.LockTimeWindow.Themeb.Content = ""
            'My.Windows.LockTimeWindow.Backgroundb.Content = ""
            'My.Windows.LockTimeWindow.Windowb.Content = ""
            'My.Windows.LockTimeWindow.Centerb.Content = ""
            'My.Windows.LockTimeWindow.Topb.Content = ""
            'My.Windows.LockTimeWindow.Bottomb.Content = ""
            'My.Windows.LockTimeWindow.Leftb.Content = ""
            'My.Windows.LockTimeWindow.Rightb.Content = ""
        Else
            My.Application.HideTextState = 0
            Try
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "HideText", 0, RegistryValueKind.DWord)
            Catch ex As Exception
            End Try
            My.Application.SettingsState = 1
            'Dispatcher.Invoke(New LockTimeWindow.HideTextStateSub(AddressOf My.Windows.LockTimeWindow.SetUIText), 0)
            'My.Windows.LockTimeWindow.Exitb.LabelPosition = CommandBarLabelPosition.Default
            'My.Windows.LockTimeWindow.Settingb.LabelPosition = CommandBarLabelPosition.Default
            'My.Windows.LockTimeWindow.Aboutb.LabelPosition = CommandBarLabelPosition.Default
            'My.Windows.LockTimeWindow.Themeb.LabelPosition = CommandBarLabelPosition.Default
            'My.Windows.LockTimeWindow.Backgroundb.LabelPosition = CommandBarLabelPosition.Default
            'My.Windows.LockTimeWindow.Windowb.LabelPosition = CommandBarLabelPosition.Default
            'My.Windows.LockTimeWindow.Centerb.LabelPosition = CommandBarLabelPosition.Default
            'My.Windows.LockTimeWindow.Topb.LabelPosition = CommandBarLabelPosition.Default
            'My.Windows.LockTimeWindow.Bottomb.LabelPosition = CommandBarLabelPosition.Default
            'My.Windows.LockTimeWindow.Leftb.LabelPosition = CommandBarLabelPosition.Default
            'My.Windows.LockTimeWindow.Rightb.LabelPosition = CommandBarLabelPosition.Default
            'My.Windows.LockTimeWindow.Exitb.Label = "退出"
            'My.Windows.LockTimeWindow.Settingb.Content = "设置"
            'My.Windows.LockTimeWindow.Aboutb.Content = "关于"
            'My.Windows.LockTimeWindow.Themeb.Content = "颜色"
            'My.Windows.LockTimeWindow.Backgroundb.Content = "背景"
            'My.Windows.LockTimeWindow.Windowb.Content = "窗口"
            'My.Windows.LockTimeWindow.Centerb.Content = "居中"
            'My.Windows.LockTimeWindow.Topb.Content = "顶部"
            'My.Windows.LockTimeWindow.Bottomb.Content = "底部"
            'My.Windows.LockTimeWindow.Leftb.Content = "左侧"
            'My.Windows.LockTimeWindow.Rightb.Content = "右侧"
        End If
    End Sub
    '时间字体选择处理
    Public Sub TimeFontNameComboBox_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        TimeFontStylePreview.FontFamily = New FontFamily(TimeFontNameComboBox.Items(TimeFontNameComboBox.SelectedIndex))
        My.Application.TimeFontName = TimeFontStylePreview.FontFamily.Source
        Try
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "TimeFontName", My.Application.TimeFontName, RegistryValueKind.String)
        Catch ex As Exception
        End Try
        My.Application.SettingsState = 1
    End Sub
    '时间字体大小处理
    'Dim IsEnterV As Integer
    'Dim FontSizeV As Integer
    Public Sub TimeFontSizeComboBox_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        'MessageBox.Show(TimeFontSizeComboBox.SelectedIndex)
        'If IsEnterV = 1 And TimeFontSizeComboBox.SelectedIndex = -1 Then
        'IsEnterV = 0
        Try
            TimeFontStylePreview.FontSize = Replace(TimeFontSizeComboBox.SelectedValue.ToString, "System.Windows.Controls.ComboBoxItem: ", "")
        Catch ex As Exception
            'MessageBox.Show(TimeFontSizeComboBox.Text)
            'MessageBox.Show(ex.Message & ex.ToString)
            TimeFontStylePreview.FontSize = 96.0!
            TimeFontSizeComboBox.SelectedIndex = 17
        End Try
        My.Application.TimeFontSize = TimeFontStylePreview.FontSize
        Try
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "TimeFontSize", My.Application.TimeFontSize, RegistryValueKind.DWord)
        Catch ex As Exception
        End Try
        My.Application.SettingsState = 1
        'ElseIf TimeFontSizeComboBox.SelectedIndex >= 0 Then
        '    Try
        '        FontStylePreview.FontSize = Replace(TimeFontSizeComboBox.SelectedValue.ToString, "System.Windows.Controls.ComboBoxItem: ", "")
        '    Catch ex As Exception
        '        MessageBox.Show(TimeFontSizeComboBox.Text)
        '        MessageBox.Show(ex.Message & ex.ToString)
        '        FontStylePreview.FontSize = 48.0
        '        TimeFontSizeComboBox.SelectedIndex = 14
        '    End Try
        ' End If
    End Sub
    '重置时间字体
    Private Async Sub ResetTimeFormatButton_Click(sender As Object, e As RoutedEventArgs) Handles ResetTimeFormatButton.Click
        Dim dialog As ContentDialog = New ContentDialog()
        dialog.Title = "确定要重置自定义时间字体以及样式吗？"
        dialog.PrimaryButtonText = "确定"
        dialog.CloseButtonText = "取消"
        dialog.DefaultButton = ContentDialogButton.Close
        dialog.Content = "这将会重置你的自定义时间字体以及样式格式。此操作不可恢复。"
        Dim result = Await dialog.ShowAsync()
        If result = ContentDialogResult.Primary Then
            My.Application.TimeFontSize = 96
            My.Application.TimeFontName = "Segoe UI Variable Display"
            Try
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "TimeFontSize", My.Application.TimeFontSize, RegistryValueKind.DWord)
            Catch ex As Exception
            End Try
            Try
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "TimeFontName", My.Application.TimeFontName, RegistryValueKind.String)
            Catch ex As Exception
            End Try
            TimeFontStylePreview.FontSize = My.Application.TimeFontSize
            TimeFontStylePreview.FontFamily = New FontFamily(My.Application.TimeFontName)
            TimeFontNameComboBox.SelectedIndex = TimeFontNameComboBox.Items.IndexOf(TimeFontStylePreview.FontFamily.Source)
            If TimeFontNameComboBox.SelectedIndex = -1 Then
                TimeFontNameComboBox.Text = TimeFontStylePreview.FontFamily.Source
            End If
            TimeFontSizeComboBox.Text = My.Application.TimeFontSize
            My.Application.SettingsState = 1
        End If
    End Sub
    '重置日期字体
    Private Async Sub ResetDateFormatButton_Click(sender As Object, e As RoutedEventArgs) Handles ResetDateFormatButton.Click
        Dim dialog As ContentDialog = New ContentDialog()
        dialog.Title = "确定要重置自定义日期字体以及样式格式吗？"
        dialog.PrimaryButtonText = "确定"
        dialog.CloseButtonText = "取消"
        dialog.DefaultButton = ContentDialogButton.Close
        dialog.Content = "这将会重置你的自定义日期字体以及样式格式。此操作不可恢复。"
        Dim result = Await dialog.ShowAsync()
        If result = ContentDialogResult.Primary Then
            My.Application.DateFontSize = 36
            My.Application.DateFontName = "Microsoft YaHei UI"
            Try
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "DateFontSize", My.Application.DateFontSize, RegistryValueKind.DWord)
            Catch ex As Exception
            End Try
            Try
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "DateFontName", My.Application.DateFontName, RegistryValueKind.String)
            Catch ex As Exception
            End Try
            DateFontStylePreview.FontSize = My.Application.DateFontSize
            DateFontStylePreview.FontFamily = New FontFamily(My.Application.DateFontName)
            DateFontNameComboBox.SelectedIndex = DateFontNameComboBox.Items.IndexOf(DateFontStylePreview.FontFamily.Source)
            If DateFontNameComboBox.SelectedIndex = -1 Then
                DateFontNameComboBox.Text = DateFontStylePreview.FontFamily.Source
            End If
            DateFontSizeComboBox.Text = My.Application.DateFontSize
            My.Application.SettingsState = 1
        End If
    End Sub

    'Private Sub TimeFontSizeComboBox_KeyDown(sender As Object, e As KeyEventArgs) Handles TimeFontSizeComboBox.KeyDown
    '    Dim e1 As SelectionChangedEventArgs = Nothing
    '    If e.Key = Key.Enter Then
    '        IsEnterV = 1
    '        Call TimeFontSizeComboBox_SelectionChanged(sender, e1)
    '    End If
    'End Sub

    '日期字体选择处理
    Public Sub DateFontNameComboBox_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        DateFontStylePreview.FontFamily = New FontFamily(DateFontNameComboBox.Items(DateFontNameComboBox.SelectedIndex))
        My.Application.DateFontName = DateFontStylePreview.FontFamily.Source
        Try
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "DateFontName", My.Application.DateFontName, RegistryValueKind.String)
        Catch ex As Exception
        End Try
        My.Application.SettingsState = 1
    End Sub
    '日期字体大小处理
    Public Sub DateFontSizeComboBox_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        Try
            DateFontStylePreview.FontSize = Replace(DateFontSizeComboBox.SelectedValue.ToString, "System.Windows.Controls.ComboBoxItem: ", "")
        Catch ex As Exception
            DateFontStylePreview.FontSize = 36.0!
            DateFontSizeComboBox.SelectedIndex = 13
        End Try
        My.Application.DateFontSize = DateFontStylePreview.FontSize
        Try
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "DateFontSize", My.Application.DateFontSize, RegistryValueKind.DWord)
        Catch ex As Exception
        End Try
        My.Application.SettingsState = 1
    End Sub
    '应用日期、时间格式
    Private Sub ApplyFormatButton_Click(sender As Object, e As RoutedEventArgs) Handles ApplyFormatButton.Click
        My.Application.TimeFormat = TimeFormatTextBox.Text
        My.Application.DateFormat = DateFormatTextBox.Text
        Try
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "TimeFormat", My.Application.TimeFormat, RegistryValueKind.String)
        Catch eex As Exception
        End Try
        Try
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "DateFormat", My.Application.DateFormat, RegistryValueKind.String)
        Catch eex As Exception
        End Try
    End Sub
    '重置日期、时间格式
    Private Async Sub ResetFormatButton_Click(sender As Object, e As RoutedEventArgs) Handles ResetFormatButton.Click
        Dim dialog As ContentDialog = New ContentDialog()
        dialog.Title = "确定要重置自定义格式吗？"
        dialog.PrimaryButtonText = "确定"
        dialog.CloseButtonText = "取消"
        dialog.DefaultButton = ContentDialogButton.Close
        dialog.Content = "这将会重置你的自定义格式。此操作不可恢复。"
        Dim result = Await dialog.ShowAsync()
        If result = ContentDialogResult.Primary Then
            My.Application.TimeFormat = "HH:mm:ss"
            My.Application.DateFormat = "yyyy年 M月 d日"
            TimeFormatTextBox.Text = My.Application.TimeFormat
            DateFormatTextBox.Text = My.Application.DateFormat
            Try
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "TimeFormat", My.Application.TimeFormat, RegistryValueKind.String)
            Catch eex As Exception
            End Try
            Try
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "DateFormat", My.Application.DateFormat, RegistryValueKind.String)
            Catch eex As Exception
            End Try
        End If
    End Sub
    '显示格式说明
    Private Async Sub GetFormatHelp_Click(sender As Object, e As RoutedEventArgs) Handles GetFormatHelp.Click
        Dim dialog As ContentDialog = New ContentDialog()
        dialog.Title = "显示格式说明"
        dialog.PrimaryButtonText = "确定"
        'dialog.SecondaryButtonText = "Don't Save"
        'dialog.CloseButtonText = "取消"
        dialog.DefaultButton = ContentDialogButton.Primary
        Dim HelpPage As LockTimeHelpPage = New LockTimeHelpPage
        HelpPage.textBox1.Text = My.Resources.TimeFormat
        dialog.Content = HelpPage
        'dialog.Content = "这将会退出时钟锁屏"
        Await dialog.ShowAsync()
        'Dim result = Await dialog.ShowAsync()
    End Sub
    '设置时间颜色
    Private Sub TimeColorButton_Click(sender As Object, e As RoutedEventArgs) Handles TimeColorButton.Click
        Dim ColorDialog1 As New System.Windows.Forms.ColorDialog
        ColorDialog1.FullOpen = True
        ColorDialog1.Color = My.Application.TimeColor
        If ColorDialog1.ShowDialog = Forms.DialogResult.OK Then
            My.Application.TimeColor = ColorDialog1.Color
            My.Application.SettingsState = 1
            Try
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "TimeColorR", ColorDialog1.Color.R, RegistryValueKind.DWord)
            Catch ex As Exception
            End Try
            Try
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "TimeColorG", ColorDialog1.Color.G, RegistryValueKind.DWord)
            Catch ex As Exception
            End Try
            Try
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "TimeColorB", ColorDialog1.Color.B, RegistryValueKind.DWord)
            Catch ex As Exception
            End Try
        End If
    End Sub
    '设置日期颜色
    Private Sub DateColorButton_Click(sender As Object, e As RoutedEventArgs) Handles DateColorButton.Click
        Dim ColorDialog1 As New System.Windows.Forms.ColorDialog
        ColorDialog1.FullOpen = True
        ColorDialog1.Color = My.Application.DateColor
        If ColorDialog1.ShowDialog = Forms.DialogResult.OK Then
            My.Application.DateColor = ColorDialog1.Color
            My.Application.SettingsState = 1
            Try
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "DateColorR", ColorDialog1.Color.R, RegistryValueKind.DWord)
            Catch ex As Exception
            End Try
            Try
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "DateColorG", ColorDialog1.Color.G, RegistryValueKind.DWord)
            Catch ex As Exception
            End Try
            Try
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "DateColorB", ColorDialog1.Color.B, RegistryValueKind.DWord)
            Catch ex As Exception
            End Try
        End If
    End Sub
    '重置设置
    Private Async Sub ResetColorButton_Click(sender As Object, e As RoutedEventArgs) Handles ResetColorButton.Click
        Dim dialog As ContentDialog = New ContentDialog()
        dialog.Title = "确定要重置自定义显示颜色吗？"
        dialog.PrimaryButtonText = "确定"
        dialog.CloseButtonText = "取消"
        dialog.DefaultButton = ContentDialogButton.Close
        dialog.Content = "这将会重置你的自定义显示颜色。此操作不可恢复。"
        Dim result = Await dialog.ShowAsync()
        If result = ContentDialogResult.Primary Then
            If ThemeManager.Current.ApplicationTheme = ApplicationTheme.Light Then
                Try
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "TimeColorR", 0, RegistryValueKind.DWord)
                Catch ex As Exception
                End Try
                Try
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "TimeColorG", 0, RegistryValueKind.DWord)
                Catch ex As Exception
                End Try
                Try
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "TimeColorB", 0, RegistryValueKind.DWord)
                Catch ex As Exception
                End Try
                Try
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "DateColorR", 0, RegistryValueKind.DWord)
                Catch ex As Exception
                End Try
                Try
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "DateColorG", 0, RegistryValueKind.DWord)
                Catch ex As Exception
                End Try
                Try
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "DateColorB", 0, RegistryValueKind.DWord)
                Catch ex As Exception
                End Try
                My.Application.TimeColor = System.Drawing.Color.FromArgb(0, 0, 0)
                My.Application.DateColor = System.Drawing.Color.FromArgb(0, 0, 0)
                My.Application.SettingsState = 1
            Else
                Try
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "TimeColorR", 255, RegistryValueKind.DWord)
                Catch ex As Exception
                End Try
                Try
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "TimeColorG", 255, RegistryValueKind.DWord)
                Catch ex As Exception
                End Try
                Try
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "TimeColorB", 255, RegistryValueKind.DWord)
                Catch ex As Exception
                End Try
                Try
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "DateColorR", 255, RegistryValueKind.DWord)
                Catch ex As Exception
                End Try
                Try
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "DateColorG", 255, RegistryValueKind.DWord)
                Catch ex As Exception
                End Try
                Try
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "DateColorB", 255, RegistryValueKind.DWord)
                Catch ex As Exception
                End Try
                My.Application.TimeColor = System.Drawing.Color.FromArgb(255, 255, 255)
                My.Application.DateColor = System.Drawing.Color.FromArgb(255, 255, 255)
                My.Application.SettingsState = 1
            End If
        End If
    End Sub
End Class
