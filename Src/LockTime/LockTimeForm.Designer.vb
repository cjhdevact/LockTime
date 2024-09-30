<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LockTimeForm
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LockTimeForm))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.textright = New System.Windows.Forms.Button()
        Me.textleft = New System.Windows.Forms.Button()
        Me.textbottom = New System.Windows.Forms.Button()
        Me.texttop = New System.Windows.Forms.Button()
        Me.textfull = New System.Windows.Forms.Button()
        Me.Winb = New System.Windows.Forms.Button()
        Me.aboutb = New System.Windows.Forms.Button()
        Me.exitb = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label1, 2)
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("微软雅黑", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.TableLayoutPanel1.SetRowSpan(Me.Label1, 2)
        Me.Label1.Size = New System.Drawing.Size(800, 278)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = " " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Label2
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label2, 2)
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("微软雅黑", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label2.Location = New System.Drawing.Point(0, 278)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.TableLayoutPanel1.SetRowSpan(Me.Label2, 2)
        Me.Label2.Size = New System.Drawing.Size(800, 279)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = " " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(800, 557)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.textright)
        Me.FlowLayoutPanel1.Controls.Add(Me.textleft)
        Me.FlowLayoutPanel1.Controls.Add(Me.textbottom)
        Me.FlowLayoutPanel1.Controls.Add(Me.texttop)
        Me.FlowLayoutPanel1.Controls.Add(Me.textfull)
        Me.FlowLayoutPanel1.Controls.Add(Me.Winb)
        Me.FlowLayoutPanel1.Controls.Add(Me.aboutb)
        Me.FlowLayoutPanel1.Controls.Add(Me.exitb)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 557)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(800, 43)
        Me.FlowLayoutPanel1.TabIndex = 5
        '
        'textright
        '
        Me.textright.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.textright.FlatAppearance.BorderSize = 0
        Me.textright.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray
        Me.textright.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
        Me.textright.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.textright.Image = CType(resources.GetObject("textright.Image"), System.Drawing.Image)
        Me.textright.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.textright.Location = New System.Drawing.Point(736, 3)
        Me.textright.Name = "textright"
        Me.textright.Size = New System.Drawing.Size(61, 35)
        Me.textright.TabIndex = 10
        Me.textright.Text = "右侧"
        Me.textright.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.textright.UseVisualStyleBackColor = True
        '
        'textleft
        '
        Me.textleft.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.textleft.FlatAppearance.BorderSize = 0
        Me.textleft.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray
        Me.textleft.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
        Me.textleft.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.textleft.Image = CType(resources.GetObject("textleft.Image"), System.Drawing.Image)
        Me.textleft.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.textleft.Location = New System.Drawing.Point(669, 3)
        Me.textleft.Name = "textleft"
        Me.textleft.Size = New System.Drawing.Size(61, 35)
        Me.textleft.TabIndex = 9
        Me.textleft.Text = "左侧"
        Me.textleft.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.textleft.UseVisualStyleBackColor = True
        '
        'textbottom
        '
        Me.textbottom.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.textbottom.FlatAppearance.BorderSize = 0
        Me.textbottom.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray
        Me.textbottom.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
        Me.textbottom.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.textbottom.Image = CType(resources.GetObject("textbottom.Image"), System.Drawing.Image)
        Me.textbottom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.textbottom.Location = New System.Drawing.Point(602, 3)
        Me.textbottom.Name = "textbottom"
        Me.textbottom.Size = New System.Drawing.Size(61, 35)
        Me.textbottom.TabIndex = 7
        Me.textbottom.Text = "底部"
        Me.textbottom.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.textbottom.UseVisualStyleBackColor = True
        '
        'texttop
        '
        Me.texttop.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.texttop.FlatAppearance.BorderSize = 0
        Me.texttop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray
        Me.texttop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
        Me.texttop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.texttop.Image = CType(resources.GetObject("texttop.Image"), System.Drawing.Image)
        Me.texttop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.texttop.Location = New System.Drawing.Point(535, 3)
        Me.texttop.Name = "texttop"
        Me.texttop.Size = New System.Drawing.Size(61, 35)
        Me.texttop.TabIndex = 8
        Me.texttop.Text = "顶部"
        Me.texttop.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.texttop.UseVisualStyleBackColor = True
        '
        'textfull
        '
        Me.textfull.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.textfull.FlatAppearance.BorderSize = 0
        Me.textfull.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray
        Me.textfull.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
        Me.textfull.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.textfull.Image = CType(resources.GetObject("textfull.Image"), System.Drawing.Image)
        Me.textfull.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.textfull.Location = New System.Drawing.Point(468, 3)
        Me.textfull.Name = "textfull"
        Me.textfull.Size = New System.Drawing.Size(61, 35)
        Me.textfull.TabIndex = 6
        Me.textfull.Text = "居中"
        Me.textfull.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.textfull.UseVisualStyleBackColor = True
        '
        'Winb
        '
        Me.Winb.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.Winb.FlatAppearance.BorderSize = 0
        Me.Winb.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray
        Me.Winb.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
        Me.Winb.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Winb.Image = CType(resources.GetObject("Winb.Image"), System.Drawing.Image)
        Me.Winb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Winb.Location = New System.Drawing.Point(401, 3)
        Me.Winb.Name = "Winb"
        Me.Winb.Size = New System.Drawing.Size(61, 35)
        Me.Winb.TabIndex = 11
        Me.Winb.Text = "窗口"
        Me.Winb.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Winb.UseVisualStyleBackColor = True
        '
        'aboutb
        '
        Me.aboutb.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.aboutb.FlatAppearance.BorderSize = 0
        Me.aboutb.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray
        Me.aboutb.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
        Me.aboutb.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.aboutb.Image = CType(resources.GetObject("aboutb.Image"), System.Drawing.Image)
        Me.aboutb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.aboutb.Location = New System.Drawing.Point(334, 3)
        Me.aboutb.Name = "aboutb"
        Me.aboutb.Size = New System.Drawing.Size(61, 35)
        Me.aboutb.TabIndex = 5
        Me.aboutb.Text = "关于"
        Me.aboutb.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.aboutb.UseVisualStyleBackColor = True
        '
        'exitb
        '
        Me.exitb.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.exitb.FlatAppearance.BorderSize = 0
        Me.exitb.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray
        Me.exitb.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
        Me.exitb.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.exitb.Image = CType(resources.GetObject("exitb.Image"), System.Drawing.Image)
        Me.exitb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.exitb.Location = New System.Drawing.Point(267, 3)
        Me.exitb.Name = "exitb"
        Me.exitb.Size = New System.Drawing.Size(61, 35)
        Me.exitb.TabIndex = 4
        Me.exitb.Text = "退出"
        Me.exitb.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.exitb.UseVisualStyleBackColor = True
        '
        'LockTimeForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(800, 600)
        Me.ControlBox = False
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(800, 600)
        Me.Name = "LockTimeForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "时钟锁屏"
        Me.TopMost = True
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents exitb As System.Windows.Forms.Button
    Friend WithEvents aboutb As System.Windows.Forms.Button
    Friend WithEvents textright As System.Windows.Forms.Button
    Friend WithEvents textleft As System.Windows.Forms.Button
    Friend WithEvents textbottom As System.Windows.Forms.Button
    Friend WithEvents texttop As System.Windows.Forms.Button
    Friend WithEvents textfull As System.Windows.Forms.Button
    Friend WithEvents Winb As System.Windows.Forms.Button

End Class
