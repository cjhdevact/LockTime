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
Imports System.IO
Imports System.Net
Imports System.Windows.Threading
Imports iNKORE.UI.WPF.Modern.Controls
Imports Newtonsoft.Json.Linq

Class Application
    ''' <summary>
    ''' 全局变量
    ''' </summary>
    Public Const AppBuildNumber As Integer = 1
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
    '顶置
    Public AppTopMost As Integer
    '更新提示内容
    Public UpdateSetting As Integer
    Public UpdateOK As Integer
    Public UpdateTitle As String
    Public UpdateVer As String
    Public UpdateMsg As String
    Public UpdateUrl As String
    'Public Runa As Integer = 0
    ' 应用程序级事件(例如 Startup、Exit 和 DispatcherUnhandledException)
    ' 可以在此文件中进行处理。

    '获取内容函数
    Public Function GetSource(ByVal url As String) As String
        Try
            'Need .Net Framework 4.5 +
            '解决无法建立安全的TLS/SSL连接问题
            ServicePointManager.Expect100Continue = True
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls
            ServicePointManager.ServerCertificateValidationCallback = Function(sender, certificate, chain, errors) True
            'ServicePointManager.SecurityProtocol = CType(192, SecurityProtocolType) Or CType(768, SecurityProtocolType) Or CType(3072, SecurityProtocolType)

            Dim httpReq As System.Net.HttpWebRequest 'HttpWebRequest 类对 WebRequest 中定义的属性和方法提供支持'，也对使用户能够直接与使用 HTTP 的服务器交互的附加属性和方法提供支持。
            Dim httpResp As System.Net.HttpWebResponse ' HttpWebResponse 类用于生成发送 HTTP 请求和接收 HTTP 响'应的 HTTP 独立客户端应用程序。
            Dim httpURL As New System.Uri(url)
            httpReq = CType(WebRequest.Create(httpURL), HttpWebRequest)
            httpReq.Timeout = 5000
            httpReq.Method = "GET"
            httpResp = CType(httpReq.GetResponse(), HttpWebResponse)
            'Dim reader As StreamReader = New StreamReader(httpResp.GetResponseStream, System.Text.Encoding.GetEncoding("GB2312")) '如是中文，要设置编码格式为“GB2312”。
            Dim reader As StreamReader = New StreamReader(httpResp.GetResponseStream, System.Text.Encoding.UTF8)
            Dim respHTML As String = reader.ReadToEnd() 'respHTML就是网页源代码
            Return respHTML
            httpResp.Close()
        Catch e As Exception
            'MessageBox.Show(e.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Return e.Message
            Return Nothing
        End Try
    End Function
End Class
