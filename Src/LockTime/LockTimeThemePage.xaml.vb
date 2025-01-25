Imports iNKORE.UI.WPF.Modern.Controls

Class LockTimeThemePage
    '设置是否显示文字
    '通过把设置一个全局变量来表示是否更新设置，再在主窗口设置一个定时器来定时获取这个变量的状态来判断是否要更新主界面设置
    'WPF窗体之间传递变量怎么这么难？
    Private Sub HideTextToggleSwitch_Toggled(sender As Object, e As RoutedEventArgs) Handles HideTextToggleSwitch.Toggled
        If HideTextToggleSwitch.IsOn = True Then
            My.Application.HideTextState = 1
            Try
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "HideText", 1)
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
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "HideText", 0)
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

    Private Sub Page_Loaded(sender As Object, e As RoutedEventArgs)
        'IsEnterV = 0
        'FontSizeV = 0
        If My.Application.HideTextState = 1 Then
            HideTextToggleSwitch.IsOn = True
        Else
            HideTextToggleSwitch.IsOn = False
        End If
        '时间字体选择初始化
        Dim fontFamilies() As System.Drawing.FontFamily = System.Drawing.FontFamily.Families
        ' 遍历并打印所有字体名称
        For Each family As System.Drawing.FontFamily In fontFamilies
            TimeFontNameComboBox.Items.Add(family.Name)
        Next
        TimeFontSizeComboBox.Items.Add(8)
        TimeFontSizeComboBox.Items.Add(9)
        TimeFontSizeComboBox.Items.Add(10)
        TimeFontSizeComboBox.Items.Add(11)
        TimeFontSizeComboBox.Items.Add(12)
        TimeFontSizeComboBox.Items.Add(14)
        TimeFontSizeComboBox.Items.Add(16)
        TimeFontSizeComboBox.Items.Add(18)
        TimeFontSizeComboBox.Items.Add(20)
        TimeFontSizeComboBox.Items.Add(22)
        TimeFontSizeComboBox.Items.Add(24)
        TimeFontSizeComboBox.Items.Add(26)
        TimeFontSizeComboBox.Items.Add(28)
        TimeFontSizeComboBox.Items.Add(36)
        TimeFontSizeComboBox.Items.Add(48)
        TimeFontSizeComboBox.Items.Add(72)
        TimeFontSizeComboBox.Items.Add(84)
        TimeFontSizeComboBox.Items.Add(96)
        TimeFontSizeComboBox.Items.Add(100)
        TimeFontSizeComboBox.Items.Add(200)
        TimeFontStylePreview.FontSize = My.Application.TimeFontSize
        TimeFontStylePreview.FontFamily = New FontFamily(My.Application.TimeFontName)
        TimeFontNameComboBox.SelectedIndex = TimeFontNameComboBox.Items.IndexOf(TimeFontStylePreview.FontFamily.Source)
        TimeFontSizeComboBox.SelectedIndex = TimeFontSizeComboBox.Items.IndexOf(TimeFontStylePreview.FontSize.ToString)
        '日期字体选择初始化
        For Each family As System.Drawing.FontFamily In fontFamilies
            DateFontNameComboBox.Items.Add(family.Name)
        Next
        DateFontSizeComboBox.Items.Add(8)
        DateFontSizeComboBox.Items.Add(9)
        DateFontSizeComboBox.Items.Add(10)
        DateFontSizeComboBox.Items.Add(11)
        DateFontSizeComboBox.Items.Add(12)
        DateFontSizeComboBox.Items.Add(14)
        DateFontSizeComboBox.Items.Add(16)
        DateFontSizeComboBox.Items.Add(18)
        DateFontSizeComboBox.Items.Add(20)
        DateFontSizeComboBox.Items.Add(22)
        DateFontSizeComboBox.Items.Add(24)
        DateFontSizeComboBox.Items.Add(26)
        DateFontSizeComboBox.Items.Add(28)
        DateFontSizeComboBox.Items.Add(36)
        DateFontSizeComboBox.Items.Add(48)
        DateFontSizeComboBox.Items.Add(72)
        DateFontSizeComboBox.Items.Add(84)
        DateFontSizeComboBox.Items.Add(96)
        DateFontSizeComboBox.Items.Add(100)
        DateFontSizeComboBox.Items.Add(200)
        DateFontStylePreview.FontSize = My.Application.DateFontSize
        DateFontStylePreview.FontFamily = New FontFamily(My.Application.DateFontName)
        DateFontNameComboBox.SelectedIndex = DateFontNameComboBox.Items.IndexOf(DateFontStylePreview.FontFamily.Source)
        DateFontSizeComboBox.SelectedIndex = DateFontSizeComboBox.Items.IndexOf(DateFontStylePreview.FontSize.ToString)
        '设置显示内容
        'MsgBox(FontNameComboBox.Items.IndexOf(FontStylePreview.FontSize))
        If TimeFontNameComboBox.SelectedIndex = -1 Then
            TimeFontNameComboBox.Text = TimeFontStylePreview.FontFamily.Source
        End If
        If TimeFontSizeComboBox.SelectedIndex = -1 Then
            TimeFontSizeComboBox.Text = TimeFontStylePreview.FontSize.ToString
        End If

        If DateFontNameComboBox.SelectedIndex = -1 Then
            DateFontNameComboBox.Text = DateFontStylePreview.FontFamily.Source
        End If
        If DateFontSizeComboBox.SelectedIndex = -1 Then
            DateFontSizeComboBox.Text = DateFontStylePreview.FontSize.ToString
        End If

        '关联时间
        AddHandler TimeFontNameComboBox.SelectionChanged, AddressOf TimeFontNameComboBox_SelectionChanged
        AddHandler TimeFontSizeComboBox.SelectionChanged, AddressOf TimeFontSizeComboBox_SelectionChanged

        AddHandler DateFontNameComboBox.SelectionChanged, AddressOf DateFontNameComboBox_SelectionChanged
        AddHandler DateFontSizeComboBox.SelectionChanged, AddressOf DateFontSizeComboBox_SelectionChanged
    End Sub
    '时间字体选择处理
    Private Sub TimeFontNameComboBox_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        TimeFontStylePreview.FontFamily = New FontFamily(TimeFontNameComboBox.Items(TimeFontNameComboBox.SelectedIndex))
        My.Application.TimeFontName = TimeFontStylePreview.FontFamily.Source
        Try
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "TimeFontName", My.Application.TimeFontName)
        Catch ex As Exception
        End Try
        My.Application.SettingsState = 1
    End Sub
    '时间字体大小处理
    'Dim IsEnterV As Integer
    'Dim FontSizeV As Integer
    Private Sub TimeFontSizeComboBox_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
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
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "TimeFontSize", My.Application.TimeFontSize)
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

    'Private Sub TimeFontSizeComboBox_KeyDown(sender As Object, e As KeyEventArgs) Handles TimeFontSizeComboBox.KeyDown
    '    Dim e1 As SelectionChangedEventArgs = Nothing
    '    If e.Key = Key.Enter Then
    '        IsEnterV = 1
    '        Call TimeFontSizeComboBox_SelectionChanged(sender, e1)
    '    End If
    'End Sub

    '日期字体选择处理
    Private Sub DateFontNameComboBox_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        DateFontStylePreview.FontFamily = New FontFamily(DateFontNameComboBox.Items(DateFontNameComboBox.SelectedIndex))
        My.Application.DateFontName = DateFontStylePreview.FontFamily.Source
        Try
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "DateFontName", My.Application.DateFontName)
        Catch ex As Exception
        End Try
        My.Application.SettingsState = 1
    End Sub
    '日期字体大小处理
    Private Sub DateFontSizeComboBox_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        Try
            DateFontStylePreview.FontSize = Replace(DateFontSizeComboBox.SelectedValue.ToString, "System.Windows.Controls.ComboBoxItem: ", "")
        Catch ex As Exception
            DateFontStylePreview.FontSize = 36.0!
            DateFontSizeComboBox.SelectedIndex = 13
        End Try
        My.Application.DateFontSize = DateFontStylePreview.FontSize
        Try
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "DateFontSize", My.Application.DateFontSize)
        Catch ex As Exception
        End Try
        My.Application.SettingsState = 1
    End Sub
End Class
