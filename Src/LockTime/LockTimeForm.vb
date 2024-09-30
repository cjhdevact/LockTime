'****************************************************************************
'    LockTime
'    Copyright (C) 2023-2024  CJH
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
'*     LockTime - LockTimeForm.vb                      *
'*                                                     *
'*     Copyright (c) CJH.                              *
'*                                                     *
'*     Main Window.                                    *
'*                                                     *
'\*****************************************************/
Public Class LockTimeForm
    Public m As Integer
    Public scaleX As Single
    Public scaleY As Single
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label1.Text = Format(Now(), "HH:mm:ss")
        Label2.Text = Format(Now(), "yyyy年 M月 d日")
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim mw As Integer = SystemInformation.PrimaryMonitorSize.Width
        ' 获取当前窗体的 DPI
        'Dim currentDpiX As Single = Me.CreateGraphics().DpiX
        'Dim currentDpiY As Single = Me.CreateGraphics().DpiY

        'If currentDpiX <> 96 OrElse currentDpiY <> 96 Then
        'End If
        '计算缩放比例
        'scaleX = currentDpiX / 96
        'scaleY = currentDpiY / 96

        'FlowLayoutPanel1.Height = FlowLayoutPanel1.Height * scaleY
        Timer1.Enabled = True
        m = 0
        'Dim a As New System.Drawing.Point
        'a.X = 0
        'a.Y = 0
        'Me.Location = a
        Dim CurCommand() As String
        CurCommand = Split(Command.ToLower, " ")
        For i = 0 To CurCommand.Count - 1
            If CurCommand(i) = "/fulltext" Then
                Call textfull_Click(sender, e)
            ElseIf CurCommand(i) = "/toptext" Then
                Call texttop_Click(sender, e)
            ElseIf CurCommand(i) = "/bottomtext" Then
                Call textbottom_Click(sender, e)
            ElseIf CurCommand(i) = "/lefttext" Then
                Call textleft_Click(sender, e)
            ElseIf CurCommand(i) = "/righttext" Then
                Call textright_Click(sender, e)
            ElseIf CurCommand(i) = "/hidetoolbar" Then
                FlowLayoutPanel1.Visible = False
            End If
        Next
    End Sub

    'Private Sub ToolStrip1_Paint(ByVal sender As Object, ByVal e As PaintEventArgs)
    '    If (TryCast(sender, ToolStrip).RenderMode = ToolStripRenderMode.System) Then
    '        Dim rect As New Rectangle(0, 0, (Me.ToolStrip1.Width - 1.7), (Me.ToolStrip1.Height - 1.7))
    '        e.Graphics.SetClip(rect)
    '    End If
    'End Sub

    Private Sub exitb_Click(sender As System.Object, e As System.EventArgs) Handles exitb.Click
        'If m <> 2 Then
        '    m = m + 1
        'Else
        '    If MessageBox.Show("是否要退出时钟锁屏？", "时钟锁屏", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
        '        'End
        '        Me.Dispose()
        '    End If
        'End If
        Me.Close()
    End Sub

    Private Sub texttop_Click(sender As System.Object, e As System.EventArgs) Handles texttop.Click
        Me.TableLayoutPanel1.SetRowSpan(Me.Label1, 1)
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label1, 2)
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label2, 2)
        Me.TableLayoutPanel1.SetRowSpan(Me.Label2, 1)

        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
    End Sub

    Private Sub textbottom_Click(sender As System.Object, e As System.EventArgs) Handles textbottom.Click
        Me.TableLayoutPanel1.SetRowSpan(Me.Label1, 1)
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label1, 2)
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label2, 2)
        Me.TableLayoutPanel1.SetRowSpan(Me.Label2, 1)

        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 3)
    End Sub

    Private Sub textleft_Click(sender As System.Object, e As System.EventArgs) Handles textleft.Click
        Me.TableLayoutPanel1.SetRowSpan(Me.Label1, 2)
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label1, 1)
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label2, 1)
        Me.TableLayoutPanel1.SetRowSpan(Me.Label2, 2)

        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 2)
    End Sub

    Private Sub textright_Click(sender As System.Object, e As System.EventArgs) Handles textright.Click
        Me.TableLayoutPanel1.SetRowSpan(Me.Label1, 2)
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label1, 1)
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label2, 1)
        Me.TableLayoutPanel1.SetRowSpan(Me.Label2, 2)

        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 1, 2)
    End Sub

    Private Sub textfull_Click(sender As System.Object, e As System.EventArgs) Handles textfull.Click
        Me.TableLayoutPanel1.SetRowSpan(Me.Label1, 2)
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label1, 2)
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label2, 2)
        Me.TableLayoutPanel1.SetRowSpan(Me.Label2, 2)

        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 2)
    End Sub

    Private Sub aboutb_Click(sender As System.Object, e As System.EventArgs) Handles aboutb.Click
        MessageBox.Show("时钟锁屏 版本：" & My.Application.Info.Version.ToString & vbCrLf & vbCrLf & _
                        "版权所有 © 2023-2024 CJH。保留所有权利。" & vbCrLf & vbCrLf & _
                        "本程序支持的命令行：" & vbCrLf & _
                        "/fulltext 居中显示时间（默认）" & vbCrLf & _
                        "/toptext 在顶部显示时间" & vbCrLf & _
                        "/bottomtext 在底部显示时间" & vbCrLf & _
                        "/lefttext 在左侧显示时间" & vbCrLf & _
                        "/righttext 在右侧显示时间" & vbCrLf & _
                        "/hidetoolbar 默认隐藏底部工具栏" & vbCrLf & vbCrLf & _
                        "双击时间文本可以显示或隐藏底部工具栏。" & vbCrLf & vbCrLf & _
                        "项目地址：（Ctrl+C复制）" & vbCrLf & _
                        "https://github.com/cjhdevact/LockTime" & vbCrLf & vbCrLf & _
                        "基于GPL-3协议发布。" _
                        , "关于时钟锁屏", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Winb_Click(sender As System.Object, e As System.EventArgs) Handles Winb.Click
        'If Me.WindowState = FormWindowState.Maximized Then
        '    Me.WindowState = FormWindowState.Normal
        '    Winb.Text = "全屏"
        '    Me.Text = "时间锁屏"
        '    Me.ShowIcon = True
        '    Me.ShowInTaskbar = True
        '    Me.ControlBox = True
        '    Me.MaximizeBox = True
        '    Me.MinimizeBox = True
        '    Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
        '    Me.Location = New Point((System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width - Me.Width) / 2, (System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height - Me.Height) / 2)
        'Else
        '    Me.WindowState = FormWindowState.Maximized
        '    Winb.Text = "窗口"
        '    Me.Text = ""
        '    Me.ShowIcon = False
        '    Me.ShowInTaskbar = False
        '    Me.ControlBox = True
        '    Me.MaximizeBox = False
        '    Me.MinimizeBox = False
        '    Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        '    Me.Location = New Point(0, 0)
        'End If

        If Me.WindowState = FormWindowState.Maximized Then
            Me.ControlBox = True
            Me.WindowState = FormWindowState.Normal
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
            Winb.Text = "全屏"
            Me.MaximizeBox = True
            Me.MinimizeBox = True
            Me.Location = New Point((System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width - Me.Width) / 2, (System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height - Me.Height) / 2)
        Else
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.ControlBox = False
            Me.WindowState = FormWindowState.Maximized
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Winb.Text = "窗口"
            Me.Location = New Point(0, 0)
        End If
    End Sub
    Private Sub Me_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        If MessageBox.Show("是否要退出时钟锁屏？", "时钟锁屏", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
            e.Cancel = True
        End If
    End Sub

    Private Sub Label1_DoubleClick(sender As System.Object, e As System.EventArgs) Handles Label1.DoubleClick
        If FlowLayoutPanel1.Visible = True Then
            FlowLayoutPanel1.Visible = False
        Else
            FlowLayoutPanel1.Visible = True
        End If
    End Sub

    Private Sub Label2_DoubleClick(sender As System.Object, e As System.EventArgs) Handles Label2.DoubleClick
        If FlowLayoutPanel1.Visible = True Then
            FlowLayoutPanel1.Visible = False
        Else
            FlowLayoutPanel1.Visible = True
        End If
    End Sub

    Private Sub TableLayoutPanel1_DoubleClick(sender As System.Object, e As System.EventArgs) Handles TableLayoutPanel1.DoubleClick
        If FlowLayoutPanel1.Visible = True Then
            FlowLayoutPanel1.Visible = False
        Else
            FlowLayoutPanel1.Visible = True
        End If
    End Sub
End Class
