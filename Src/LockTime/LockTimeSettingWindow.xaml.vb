Imports iNKORE.UI.WPF.Modern.Controls
Imports Page = iNKORE.UI.WPF.Modern.Controls.Page
Public Class LockTimeSettingWindow
    Public Page_About As LockTimeAboutPage = New LockTimeAboutPage()
    Public Page_Setting As LockTimeSettingPage = New LockTimeSettingPage
    Public Page_Theme As LockTimeThemePage = New LockTimeThemePage()
    Private Sub SettingNV_SelectionChanged(sender As NavigationView, args As NavigationViewSelectionChangedEventArgs) Handles SettingNV.SelectionChanged
        Dim item = sender.SelectedItem
        Dim page As iNKORE.UI.WPF.Modern.Controls.Page = Nothing

        If item Is LockTime_LockTimeThemePage Then
            If My.Application.HideTextState = 1 Then
                Page_Theme.HideTextToggleSwitch.IsOn = True
            Else
                Page_Theme.HideTextToggleSwitch.IsOn = False
            End If
            ContentFrame1.Navigate(Page_Theme)
            Me.SettingNV.Header = "个性化"
        ElseIf item Is LockTime_LockTimeAboutPage Then
            ContentFrame1.Navigate(New LockTimeAboutPage())
            Me.SettingNV.Header = "关于"
        ElseIf item Is LockTime_LockTimeSettingPage Then
            ContentFrame1.Navigate(New LockTimeSettingPage())
            Me.SettingNV.Header = "设置"
        End If

        If page IsNot Nothing Then
            SettingNV.Header = page.Title
            ContentFrame1.Navigate(page)
        End If
    End Sub

    Private Sub LockTimeSettingWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles SettingNV.Loaded
        SettingNV.SelectedItem = LockTime_LockTimeThemePage
    End Sub
End Class
