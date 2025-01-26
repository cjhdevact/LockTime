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
'*     LockTime - LockTimeSettingWindow.xaml.vb        *
'*                                                     *
'*     Copyright (c) CJH.                              *
'*                                                     *
'*     Settings window.                                *
'*                                                     *
'\*****************************************************/
Imports iNKORE.UI.WPF.Modern.Controls
Imports Page = iNKORE.UI.WPF.Modern.Controls.Page
Public Class LockTimeSettingWindow
    Public Page_About As LockTimeAboutPage = New LockTimeAboutPage()
    Public Page_Setting As LockTimeSettingPage = New LockTimeSettingPage()
    Public Page_Theme As LockTimeThemePage = New LockTimeThemePage()
    Private Sub SettingNV_SelectionChanged(sender As NavigationView, args As NavigationViewSelectionChangedEventArgs) Handles SettingNV.SelectionChanged
        Dim item = sender.SelectedItem
        Dim page As iNKORE.UI.WPF.Modern.Controls.Page = Nothing

        If item Is LockTime_LockTimeThemePage Then
            'LockTimeConfig()
            ContentFrame1.Navigate(Page_Theme)
            Me.SettingNV.Header = "个性化"
        ElseIf item Is LockTime_LockTimeAboutPage Then
            ContentFrame1.Navigate(Page_About)
            Me.SettingNV.Header = "关于"
        ElseIf item Is LockTime_LockTimeSettingPage Then
            ContentFrame1.Navigate(Page_Setting)
            Me.SettingNV.Header = "设置"
        End If

        If page IsNot Nothing Then
            SettingNV.Header = page.Title
            ContentFrame1.Navigate(page)
        End If
    End Sub

    Sub LockTimeConfig()
        '############################################################
        '隐藏工具栏文字选项初始化
        If My.Application.HideTextState = 1 Then
            Page_Theme.HideTextToggleSwitch.IsOn = True
        Else
            Page_Theme.HideTextToggleSwitch.IsOn = False
        End If

        '############################################################
        '时间字体选择初始化
        Dim fontFamilies() As System.Drawing.FontFamily = System.Drawing.FontFamily.Families
        ' 遍历并打印所有字体名称
        For Each family As System.Drawing.FontFamily In fontFamilies
            Page_Theme.TimeFontNameComboBox.Items.Add(family.Name)
        Next
        'Page_Theme.TimeFontSizeComboBox.Items.Add(8)
        'Page_Theme.TimeFontSizeComboBox.Items.Add(9)
        'Page_Theme.TimeFontSizeComboBox.Items.Add(10)
        'Page_Theme.TimeFontSizeComboBox.Items.Add(11)
        'Page_Theme.TimeFontSizeComboBox.Items.Add(12)
        'Page_Theme.TimeFontSizeComboBox.Items.Add(14)
        'Page_Theme.TimeFontSizeComboBox.Items.Add(16)
        'Page_Theme.TimeFontSizeComboBox.Items.Add(18)
        'Page_Theme.TimeFontSizeComboBox.Items.Add(20)
        'Page_Theme.TimeFontSizeComboBox.Items.Add(22)
        'Page_Theme.TimeFontSizeComboBox.Items.Add(24)
        'Page_Theme.TimeFontSizeComboBox.Items.Add(26)
        'Page_Theme.TimeFontSizeComboBox.Items.Add(28)
        'Page_Theme.TimeFontSizeComboBox.Items.Add(36)
        'Page_Theme.TimeFontSizeComboBox.Items.Add(48)
        'Page_Theme.TimeFontSizeComboBox.Items.Add(72)
        'Page_Theme.TimeFontSizeComboBox.Items.Add(84)
        'Page_Theme.TimeFontSizeComboBox.Items.Add(96)
        'Page_Theme.TimeFontSizeComboBox.Items.Add(100)
        'Page_Theme.TimeFontSizeComboBox.Items.Add(200)
        Page_Theme.TimeFontStylePreview.FontSize = My.Application.TimeFontSize
        Page_Theme.TimeFontStylePreview.FontFamily = New FontFamily(My.Application.TimeFontName)
        Page_Theme.TimeFontNameComboBox.SelectedIndex = Page_Theme.TimeFontNameComboBox.Items.IndexOf(Page_Theme.TimeFontStylePreview.FontFamily.Source)
        Page_Theme.TimeFontSizeComboBox.SelectedIndex = Page_Theme.TimeFontSizeComboBox.Items.IndexOf(My.Application.TimeFontSize)
        '日期字体选择初始化
        For Each family As System.Drawing.FontFamily In fontFamilies
            Page_Theme.DateFontNameComboBox.Items.Add(family.Name)
        Next
        'Page_Theme.DateFontSizeComboBox.Items.Add(8)
        'Page_Theme.DateFontSizeComboBox.Items.Add(9)
        'Page_Theme.DateFontSizeComboBox.Items.Add(10)
        'Page_Theme.DateFontSizeComboBox.Items.Add(11)
        'Page_Theme.DateFontSizeComboBox.Items.Add(12)
        'Page_Theme.DateFontSizeComboBox.Items.Add(14)
        'Page_Theme.DateFontSizeComboBox.Items.Add(16)
        'Page_Theme.DateFontSizeComboBox.Items.Add(18)
        'Page_Theme.DateFontSizeComboBox.Items.Add(20)
        'Page_Theme.DateFontSizeComboBox.Items.Add(22)
        'Page_Theme.DateFontSizeComboBox.Items.Add(24)
        'Page_Theme.DateFontSizeComboBox.Items.Add(26)
        'Page_Theme.DateFontSizeComboBox.Items.Add(28)
        'Page_Theme.DateFontSizeComboBox.Items.Add(36)
        'Page_Theme.DateFontSizeComboBox.Items.Add(48)
        'Page_Theme.DateFontSizeComboBox.Items.Add(72)
        'Page_Theme.DateFontSizeComboBox.Items.Add(84)
        'Page_Theme.DateFontSizeComboBox.Items.Add(96)
        'Page_Theme.DateFontSizeComboBox.Items.Add(100)
        'Page_Theme.DateFontSizeComboBox.Items.Add(200)
        Page_Theme.DateFontStylePreview.FontSize = My.Application.DateFontSize
        Page_Theme.DateFontStylePreview.FontFamily = New FontFamily(My.Application.DateFontName)
        Page_Theme.DateFontNameComboBox.SelectedIndex = Page_Theme.DateFontNameComboBox.Items.IndexOf(Page_Theme.DateFontStylePreview.FontFamily.Source)
        Page_Theme.DateFontSizeComboBox.SelectedIndex = Page_Theme.DateFontSizeComboBox.Items.IndexOf(My.Application.DateFontSize)
        '设置显示内容
        'MsgBox(FontNameComboBox.Items.IndexOf(FontStylePreview.FontSize))
        If Page_Theme.TimeFontNameComboBox.SelectedIndex = -1 Then
            Page_Theme.TimeFontNameComboBox.Text = Page_Theme.TimeFontStylePreview.FontFamily.Source
        End If
        If Page_Theme.TimeFontSizeComboBox.SelectedIndex = -1 Then
            MessageBox.Show(My.Application.TimeFontSize)
            Page_Theme.TimeFontSizeComboBox.Text = My.Application.TimeFontSize
        End If

        If Page_Theme.DateFontNameComboBox.SelectedIndex = -1 Then
            Page_Theme.DateFontNameComboBox.Text = Page_Theme.DateFontStylePreview.FontFamily.Source
        End If
        If Page_Theme.DateFontSizeComboBox.SelectedIndex = -1 Then
            MessageBox.Show(My.Application.DateFontSize)
            Page_Theme.DateFontSizeComboBox.Text = My.Application.DateFontSize
        End If

        '关联时间
        AddHandler Page_Theme.TimeFontNameComboBox.SelectionChanged, AddressOf Page_Theme.TimeFontNameComboBox_SelectionChanged
        AddHandler Page_Theme.TimeFontSizeComboBox.SelectionChanged, AddressOf Page_Theme.TimeFontSizeComboBox_SelectionChanged

        AddHandler Page_Theme.DateFontNameComboBox.SelectionChanged, AddressOf Page_Theme.DateFontNameComboBox_SelectionChanged
        AddHandler Page_Theme.DateFontSizeComboBox.SelectionChanged, AddressOf Page_Theme.DateFontSizeComboBox_SelectionChanged

        '############################################################
        '设置显示格式初始化
        Page_Theme.TimeFormatTextBox.Text = My.Application.TimeFormat
        Page_Theme.DateFormatTextBox.Text = My.Application.DateFormat
    End Sub

    Private Sub LockTimeSettingWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles SettingNV.Loaded
        SettingNV.SelectedItem = LockTime_LockTimeThemePage
    End Sub
End Class
