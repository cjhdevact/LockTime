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
'*     LockTime - LockTimeVerPage.xaml.vb              *
'*                                                     *
'*     Copyright (c) CJH.                              *
'*                                                     *
'*     About Page.                                     *
'*                                                     *
'\*****************************************************/
Public Class LockTimeVerPage
    '初始化
    Private Sub UserControl_Loaded(sender As Object, e As RoutedEventArgs)
        CopyrightText.Content = "时钟锁屏 版本：" & My.Application.Info.Version.ToString & vbCrLf &
                                "版权所有 © 2023-2025 CJH。保留所有权利。" & vbCrLf &
                                "基于GPL-3协议发布。"
        link.Content = "项目地址：" & vbCrLf &
                       "https://github.com/cjhdevact/LockTime"
        'image.Source = "pack://application:,,,/resources/appicon.png"
    End Sub
    '复制地址
    Private Async Sub Copy_Click(sender As Object, e As RoutedEventArgs)
        If CopyLink.Content = ChrW(&HE8C8) Then
            Try
                Clipboard.SetText("https://github.com/cjhdevact/LockTime")
            Catch ex As Exception
                'CopyLink.Content = ChrW(&HEA39) 'Error Icon
            End Try
            'If CopyLink.Content <> ChrW(&HEA39) Then
            CopyLink.Content = ChrW(&HE73E) 'OK Icon
            'End If
            Await Task.Delay(5000)
            CopyLink.Content = ChrW(&HE8C8) 'Copy Icon
        End If
    End Sub
End Class
