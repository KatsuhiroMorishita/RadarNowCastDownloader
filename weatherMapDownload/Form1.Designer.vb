<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.clockCheckTimer = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ICCondition = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ErrorInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.NextDwload = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'clockCheckTimer
        '
        Me.clockCheckTimer.Enabled = True
        Me.clockCheckTimer.Interval = 10000
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ICCondition, Me.ErrorInfo, Me.NextDwload})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 247)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(450, 23)
        Me.StatusStrip.TabIndex = 0
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'ICCondition
        '
        Me.ICCondition.ForeColor = System.Drawing.Color.DarkGreen
        Me.ICCondition.Name = "ICCondition"
        Me.ICCondition.Size = New System.Drawing.Size(182, 18)
        Me.ICCondition.Text = "Internet Connection Condition"
        '
        'ErrorInfo
        '
        Me.ErrorInfo.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.ErrorInfo.Name = "ErrorInfo"
        Me.ErrorInfo.Size = New System.Drawing.Size(66, 18)
        Me.ErrorInfo.Text = "Error info."
        '
        'NextDwload
        '
        Me.NextDwload.Name = "NextDwload"
        Me.NextDwload.Size = New System.Drawing.Size(103, 18)
        Me.NextDwload.Text = "Download clock:"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.RadarNowCastDownloader.My.Resources.Resources.no_image2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(450, 270)
        Me.Controls.Add(Me.StatusStrip)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Radar Now-Cast Downloader"
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents clockCheckTimer As System.Windows.Forms.Timer
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ICCondition As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ErrorInfo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents NextDwload As System.Windows.Forms.ToolStripStatusLabel

End Class
