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
'*     LockTime - Application.xaml.vb                  *
'*                                                     *
'*     Copyright (c) CJH.                              *
'*                                                     *
'*     Application Code.                               *
'*                                                     *
'\*****************************************************/
Imports iNKORE.UI.WPF.Modern.Controls

Class Application
    ''' <summary>
    ''' 全局变量
    ''' </summary>
    '更新设置判断状态
    Public SettingsState As Integer
    '隐藏工具栏文字
    Public HideTextState As Integer
    '时间字体
    Public TimeFontName As String
    Public TimeFontSize As Integer
    '日期字体
    Public DateFontName As String
    Public DateFontSize As Integer
    '显示格式
    Public DateFormat As String
    Public TimeFormat As String
    '颜色
    Public DateColor As System.Drawing.Color
    Public TimeColor As System.Drawing.Color
    'Public Runa As Integer = 0
    ' 应用程序级事件(例如 Startup、Exit 和 DispatcherUnhandledException)
    ' 可以在此文件中进行处理。
End Class
