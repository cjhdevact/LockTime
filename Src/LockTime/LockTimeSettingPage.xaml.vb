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
'*     LockTime - LockTimeSettingPage.xaml.vb          *
'*                                                     *
'*     Copyright (c) CJH.                              *
'*                                                     *
'*     About Page.                                     *
'*                                                     *
'\*****************************************************/
Imports System.Net
Imports System.Windows.Threading
Imports iNKORE.UI.WPF.Modern.Controls
Imports Microsoft.Win32
Imports Newtonsoft.Json.Linq

Class LockTimeSettingPage
    Private Sub Page_Loaded(sender As Object, e As RoutedEventArgs)
        'AboutCard.Header = "时钟锁屏"
        'VersionText.Text = My.Application.Info.Version.ToString
        'AboutCard.Description = "版权所有 © 2023-2025 CJH。保留所有权利。"
        If My.Application.AppTopMost = 1 Then
            TopMostTextToggleSwitch.IsOn = True
        Else
            TopMostTextToggleSwitch.IsOn = False
        End If

        If My.Application.UpdateSetting = 1 Then
            CheckUpdateOp.IsOn = True
        Else
            CheckUpdateOp.IsOn = False
        End If
    End Sub
    '关于时钟锁屏
    Private Async Sub AboutLockTime_Click(sender As Object, e As RoutedEventArgs) Handles AboutLockTime.Click
        Dim dialog As ContentDialog = New ContentDialog()
        dialog.Title = ""
        dialog.PrimaryButtonText = "确定"
        dialog.DefaultButton = ContentDialogButton.Primary
        Dim Page As LockTimeVerPage = New LockTimeVerPage
        dialog.Content = Page
        Await dialog.ShowAsync()
    End Sub
    '启动参数说明
    Private Async Sub CmdHelp_Click(sender As Object, e As RoutedEventArgs) Handles CmdHelp.Click
        Dim dialog As ContentDialog = New ContentDialog()
        dialog.Title = "启动参数说明"
        dialog.PrimaryButtonText = "确定"
        dialog.DefaultButton = ContentDialogButton.Primary
        Dim HelpPage As LockTimeHelpPage = New LockTimeHelpPage
        HelpPage.textBox1.Text = "本程序支持的命令行：" & vbCrLf &
                        "/fulltext 居中显示时间（默认）" & vbCrLf &
                        "/toptext 在顶部显示时间" & vbCrLf &
                        "/bottomtext 在底部显示时间" & vbCrLf &
                        "/lefttext 在左侧显示时间" & vbCrLf &
                        "/righttext 在右侧显示时间" & vbCrLf &
                        "/windowmode 默认以窗口形式启动" & vbCrLf &
                        "/hidetoolbar 默认隐藏底部工具栏" & vbCrLf & vbCrLf &
                        "单击时间文本可以显示或隐藏底部工具栏。"
        dialog.Content = HelpPage
        Await dialog.ShowAsync()
    End Sub
    '反馈问题
    Private Sub BugReport_Click(sender As Object, e As RoutedEventArgs) Handles BugReport.Click
        Process.Start("https://github.com/cjhdevact/LockTime/issues")
    End Sub
    '是否顶置
    Private Sub TopMostTextToggleSwitch_Toggled(sender As Object, e As RoutedEventArgs) Handles TopMostTextToggleSwitch.Toggled
        If TopMostTextToggleSwitch.IsOn = True Then
            My.Application.AppTopMost = 1
            Try
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "TopMost", 1, RegistryValueKind.DWord)
            Catch ex As Exception
            End Try
            My.Application.SettingsState = 1
        Else
            My.Application.AppTopMost = 0
            Try
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "TopMost", 0, RegistryValueKind.DWord)
            Catch ex As Exception
            End Try
            My.Application.SettingsState = 1
        End If
    End Sub
    '检查更新
    Private Sub CheckUpdateButton_Click(sender As Object, e As RoutedEventArgs)
        CheckUpdateButton.IsEnabled = False
        ProgressRing1.IsActive = True
        ProgressRing1.Value = 0
        ProgressRing1.IsIndeterminate = True

        'If System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Temp\LockTimeUpdateTmp.exe") Then
        '    Try
        '        System.Diagnostics.Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Temp\LockTimeUpdateTmp.exe", "/verysilent /suppressmsgboxes /norestart")
        '        UpdateErrInfoBar.Title = "更新失败"
        '        UpdateErrInfoBar.Message = "无法删除被占用的预更新临时文件。"
        '        UpdateErrInfoBar.Severity = InfoBarSeverity.Error
        '        UpdateErrInfoBar.IsOpen = True
        '    Catch ex As Exception
        '        UpdateErrInfoBar.Title = "更新失败"
        '        UpdateErrInfoBar.Message = "无法删除被占用的预更新临时文件。"
        '        UpdateErrInfoBar.Severity = InfoBarSeverity.Error
        '        UpdateErrInfoBar.IsOpen = True
        '    End Try
        'End If
        CheckUpdates()
    End Sub
    '下载更新
    Sub CheckUpdates()
        If System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory & "LockTimeUpdateTmp.exe") Then
            Try
                System.IO.File.Delete(AppDomain.CurrentDomain.BaseDirectory & "LockTimeUpdateTmp.exe")
            Catch ex As Exception
                UpdateErrInfoBar.Title = "更新失败"
                UpdateErrInfoBar.Message = "无法删除被占用的预更新临时文件。"
                UpdateErrInfoBar.Severity = InfoBarSeverity.Error
                UpdateErrInfoBar.IsOpen = True
                CheckUpdateButton.IsEnabled = True
                ProgressRing1.IsActive = False
                ProgressRing1.Value = 0
                ProgressRing1.IsIndeterminate = False
                Exit Sub
            End Try
        End If
        If My.Application.UpdateUrl = "" Then
            Dim Upstate As Boolean
            Upstate = CheckUpdate()
            If Upstate = True Then
                Dim Getup As Integer
                Getup = GetUpdate()
                If Not Getup = 2 Then
                    UpdateErrInfoBar.Title = "更新失败"
                    UpdateErrInfoBar.Message = "无法获取有效的更新链接。"
                    UpdateErrInfoBar.Severity = InfoBarSeverity.Error
                    UpdateErrInfoBar.IsOpen = True
                    CheckUpdateButton.IsEnabled = True
                    ProgressRing1.IsActive = False
                    ProgressRing1.Value = 0
                    ProgressRing1.IsIndeterminate = False
                    Exit Sub
                Else
                    If My.Application.UpdateUrl = "" Then
                        UpdateErrInfoBar.Title = "更新失败"
                        UpdateErrInfoBar.Message = "无法获取有效的更新链接。"
                        UpdateErrInfoBar.Severity = InfoBarSeverity.Error
                        UpdateErrInfoBar.IsOpen = True
                        CheckUpdateButton.IsEnabled = True
                        ProgressRing1.IsActive = False
                        ProgressRing1.Value = 0
                        ProgressRing1.IsIndeterminate = False
                        Exit Sub
                    End If
                End If
            Else
                UpdateErrInfoBar.Title = "没有更新"
                UpdateErrInfoBar.Message = "你当前使用的是最新版本。"
                UpdateErrInfoBar.Severity = InfoBarSeverity.Success
                UpdateErrInfoBar.IsOpen = True
                CheckUpdateButton.IsEnabled = True
                ProgressRing1.IsActive = False
                ProgressRing1.Value = 0
                ProgressRing1.IsIndeterminate = False
                Exit Sub
            End If
        End If

        If My.Application.UpdateUrl <> "" Then
            'Dispatcher.BeginInvoke(DispatcherPriority.Background, New Action(AddressOf DownUpdates))
            DownUpdates()
        End If
    End Sub

    Sub DownUpdates()
        Dim DownloadClient As New WebClient
        AddHandler DownloadClient.DownloadProgressChanged, AddressOf DownloadClient_DownloadProgressChanged
        AddHandler DownloadClient.DownloadFileCompleted, AddressOf DownloadClient_DownloadFileCompleted
        If My.Application.UpdateUrl <> "" Then
            ProgressRing1.IsActive = True
            Try
                ProgressRing1.IsIndeterminate = False
                ProgressRing1.Value = 0
                'DownloadClient.DownloadFileAsync(New Uri(My.Application.UpdateUrl), Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Temp\LockTimeUpdateTmp.exe")
                DownloadClient.DownloadFileAsync(New Uri(My.Application.UpdateUrl), AppDomain.CurrentDomain.BaseDirectory & "LockTimeUpdateTmp.exe")
            Catch ex As Exception
                UpdateErrInfoBar.Title = "更新失败"
                UpdateErrInfoBar.Message = "无法下载更新。" & vbCrLf & ex.Message
                UpdateErrInfoBar.Severity = InfoBarSeverity.Error
                UpdateErrInfoBar.IsOpen = True
                CheckUpdateButton.IsEnabled = True
                ProgressRing1.IsActive = False
                ProgressRing1.Value = 0
                ProgressRing1.IsIndeterminate = False
                Exit Sub
            End Try
        End If
    End Sub

    '下载进度同步
    Private Sub DownloadClient_DownloadProgressChanged(ByVal sender As Object, ByVal e As System.Net.DownloadProgressChangedEventArgs)
        Me.ProgressRing1.Value = e.ProgressPercentage
    End Sub
    '下载状态处理
    Private Sub DownloadClient_DownloadFileCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
        If e.Error IsNot Nothing Then
            UpdateErrInfoBar.Title = "更新失败"
            UpdateErrInfoBar.Message = "无法下载更新。" & vbCrLf & e.Error.Message
            UpdateErrInfoBar.Severity = InfoBarSeverity.Error
            UpdateErrInfoBar.IsOpen = True
            CheckUpdateButton.IsEnabled = True
            ProgressRing1.IsActive = False
            ProgressRing1.Value = 0
            ProgressRing1.IsIndeterminate = False
            Exit Sub
        ElseIf e.Cancelled = True Then
            UpdateErrInfoBar.Title = "更新失败"
            UpdateErrInfoBar.Message = "下载已取消。"
            UpdateErrInfoBar.Severity = InfoBarSeverity.Error
            UpdateErrInfoBar.IsOpen = True
            CheckUpdateButton.IsEnabled = True
            ProgressRing1.IsActive = False
            ProgressRing1.Value = 0
            ProgressRing1.IsIndeterminate = False
            Exit Sub
        Else
            UpdateErrInfoBar.Title = "正在更新中"
            UpdateErrInfoBar.Message = "请稍候……"
            UpdateErrInfoBar.Severity = InfoBarSeverity.Informational
            UpdateErrInfoBar.IsOpen = True
            CheckUpdateButton.IsEnabled = True
            ProgressRing1.IsActive = True
            ProgressRing1.Value = 100
            ProgressRing1.IsIndeterminate = True
            If System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory & "LockTimeUpdateTmp.exe") Then
                Try
                    System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory & "LockTimeUpdateTmp.exe")
                    End
                Catch ex As Exception
                    UpdateErrInfoBar.Title = "更新失败"
                    UpdateErrInfoBar.Message = ex.Message
                    UpdateErrInfoBar.Severity = InfoBarSeverity.Error
                    UpdateErrInfoBar.IsOpen = True
                    CheckUpdateButton.IsEnabled = True
                    ProgressRing1.IsActive = False
                    ProgressRing1.Value = 0
                    ProgressRing1.IsIndeterminate = False
                    Exit Sub
                End Try
            Else
                UpdateErrInfoBar.Title = "更新失败"
                UpdateErrInfoBar.Message = "找不到更新文件。"
                UpdateErrInfoBar.Severity = InfoBarSeverity.Error
                UpdateErrInfoBar.IsOpen = True
                CheckUpdateButton.IsEnabled = True
                ProgressRing1.IsActive = False
                ProgressRing1.Value = 0
                ProgressRing1.IsIndeterminate = False
                Exit Sub
            End If
        End If
    End Sub

#Region "获取更新模块"
    '获取更新
    Public Sub PrgGetUpdate()
        Dim Upstate As Boolean
        Upstate = CheckUpdate()
        If Upstate = True Then
            Dim Getup As Integer
            Getup = GetUpdate()
            If Not Getup = 2 Then
                My.Application.UpdateOK = 0
            Else
                My.Application.UpdateOK = 1
                My.Application.UpdateTitle = Replace(My.Application.UpdateTitle, "{upver}", My.Application.UpdateVer)
                My.Application.UpdateMsg = Replace(My.Application.UpdateMsg, "{upver}", My.Application.UpdateVer)
                My.Application.UpdateTitle = Replace(My.Application.UpdateTitle, "{cuver}", My.Application.Info.Version.ToString)
                My.Application.UpdateMsg = Replace(My.Application.UpdateMsg, "{cuver}", My.Application.Info.Version.ToString)
            End If
        Else
            My.Application.UpdateOK = 0
        End If
    End Sub

    '检查更新
    Public Function CheckUpdate()
        '版本检查
        Dim verf As String
        Dim verstr As String = ""
        Dim vernum As Integer
        verf = My.Application.GetSource(My.Resources.updateurl & "/upver.json")
        If verf = "" Then
            Return False
            Exit Function
        End If
        Try
            Dim NoticeObject As JObject = JObject.Parse(verf)
            vernum = CInt(NoticeObject("verm"))
            verstr = CStr(NoticeObject("ver"))
        Catch ex As Exception
        End Try
        Dim needupt As Boolean
        If vernum > My.Application.AppBuildNumber Then
            needupt = True
        Else
            needupt = False
        End If
        My.Application.UpdateVer = verstr
        Return needupt
    End Function
    '获取更新
    Public Function GetUpdate()
        '获取更新信息
        Dim veri As String
        veri = My.Application.GetSource(My.Resources.updateurl & "/upinfo.json")
        If veri = "" Then
            Return (1)
            Exit Function
        End If
        Dim applink As String = ""
        Dim updatetitle As String = ""
        Dim updateinfo As String = ""
        Dim focupdate As Integer
        Dim rurl As String = ""
        Try
            Dim VerObject As JObject = JObject.Parse(veri)

            rurl = CStr(VerObject("rurl"))
            If rurl <> "" Then
                Exit Try
            End If

            applink = CStr(VerObject("upl"))
            updatetitle = CStr(VerObject("upt"))
            Dim InfoText As JArray = VerObject("upm")
            For i = 0 To InfoText.Count - 1
                If i = InfoText.Count - 1 Then
                    updateinfo = updateinfo & InfoText(i).ToString
                Else
                    updateinfo = updateinfo & InfoText(i).ToString & vbCrLf
                End If
            Next
            'updateinfo = CStr(VerObject("updateinfo"))
            focupdate = CStr(VerObject("uf"))
            'verstr = CStr(NoticeObject("ver"))
        Catch ex As Exception
        End Try
        '获取更新信息（重定向）
        If rurl <> "" Then
            Dim veri2 As String
            veri2 = My.Application.GetSource(rurl)
            If veri2 = "" Then
                Return (1)
                Exit Function
            End If
            Try
                Dim VerObject As JObject = JObject.Parse(veri2)

                applink = CStr(VerObject("upl"))
                updatetitle = CStr(VerObject("upt"))
                Dim InfoText As JArray = VerObject("upm")
                For i = 0 To InfoText.Count - 1
                    If i = InfoText.Count - 1 Then
                        updateinfo = updateinfo & InfoText(i).ToString
                    Else
                        updateinfo = updateinfo & InfoText(i).ToString & vbCrLf
                    End If
                Next
                'updateinfo = CStr(VerObject("updateinfo"))
                focupdate = CStr(VerObject("uf"))
                'verstr = CStr(NoticeObject("ver"))
            Catch ex As Exception
            End Try
        End If
        My.Application.UpdateUrl = applink
        My.Application.UpdateTitle = updatetitle
        My.Application.UpdateMsg = updateinfo
        Return (2)
    End Function
#End Region

    '是否自动获取更新
    Private Sub CheckUpdateOp_Toggled(sender As Object, e As RoutedEventArgs) Handles CheckUpdateOp.Toggled
        If CheckUpdateOp.IsOn = True Then
            My.Application.UpdateSetting = 1
            Try
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "AutoGetUpdate", 1, RegistryValueKind.DWord)
            Catch ex As Exception
            End Try
        Else
            My.Application.UpdateSetting = 0
            Try
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\CJH\LockTime\2.0\Settings", "AutoGetUpdate", 0, RegistryValueKind.DWord)
            Catch ex As Exception
            End Try
        End If
    End Sub
End Class
