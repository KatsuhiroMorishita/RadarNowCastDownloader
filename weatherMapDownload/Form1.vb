Public Class Form1
    Private id_dict As Dictionary(Of String, String)
    Private target As String
    ''' <summary>
    ''' タイマーが起動するごとに、気象庁のHPを確認してレーダーナウキャストの九州の図をダウンロードする
    ''' 
    ''' [開発履歴]
    ''' 2011/9/29 今日も夜。
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub clockCheckTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clockCheckTimer.Tick
        Dim t As DateTime = Date.Now
        Dim rand As System.Random = New System.Random()
        Dim wc As New System.Net.WebClient()
        Dim path As String = "http://www.jma.go.jp/jp/radnowc/imgs/radar/" + Me.target + "/"
        Dim yy, MM, dd, hh, min As String
        Dim fname, savePath As String
        Dim minute As Integer
        Const releaseTime As Double = 300                                               ' 5分毎に更新される

        If System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() Then  ' ネットに接続しているかを確認
            Me.ICCondition.Text = "Internet Connection Condition: Connect"              ' 接続できていることを示す。
            ' ダウンロードファイル名生成の準備
            minute = Math.Floor(t.Minute / 5) * 5                                       ' 現時刻で最新のデータを示すファイル名を作る
            yy = t.Year.ToString("d4")
            MM = (t.Month).ToString("d2")
            dd = t.Day.ToString("d2")
            hh = t.Hour.ToString("d2")
            min = minute.ToString("d2")
            fname = yy + MM + dd + hh + min + "-00.png"
            savePath = System.IO.Directory.GetCurrentDirectory() + "\" + fname          ' ファイル保存用のパスを生成
            t = New DateTime(t.Year, t.Month, t.Day, t.Hour, minute, 0).AddSeconds(rand.Next(85, 95))  ' ダウンロード時刻を計算。サーバーの負荷を分散するために乱数で発生させた時間だけリリース時刻からずらす。
            ' ファイルが未ダウンロード
            If System.IO.File.Exists(savePath) = False Then
                If t < Date.Now Then                                                    ' 時間が経過していればダウンロードを実行する
                    path += fname
                    Try
                        wc.DownloadFile(path, savePath)                                 ' ダウンロード
                        Me.BackgroundImage = System.Drawing.Image.FromFile(savePath)    ' 読み込めたら、表示する
                        Me.ErrorInfo.Text = "ダウンロードしました。"
                        t = t.AddSeconds(releaseTime)                                   ' 次のリリース時刻を計算
                    Catch ex As Exception
                        Me.ErrorInfo.Text = "何らかのエラーが発生しました。orz"
                    End Try
                End If
            Else
                t = t.AddSeconds(releaseTime)                                           ' 次のリリース時刻を計算
            End If
            Me.NextDwload.Text = "Next download clock:" + t.ToString                   ' ダウンロード時刻を表示する
            Me.NextDwload.Text += "   Last:" + CInt(Date.Now.Subtract(t).TotalSeconds).ToString() + "[s]"
        Else
            Me.ICCondition.Text = "Internet Connection Condition: Disconnect"
        End If
        wc.Dispose()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() Then  ' ネットに接続しているかを確認
            Me.ICCondition.Text = "Internet Connection Condition: Connect"
        Else
            Me.ICCondition.Text = "Internet Connection Condition: Disconnect"
        End If

        Dim fname As String = "setting.txt"
        Me.id_dict = New Dictionary(Of String, String)
        If System.IO.File.Exists(fname) Then
            Using sr As New System.IO.StreamReader(fname, System.Text.Encoding.GetEncoding("utf-8"))
                '内容を一行ずつ読み込む
                While sr.Peek() > -1
                    Dim line = sr.ReadLine()
                    If line.Contains("target") Then
                        Me.target = line.Split("=")(1)
                    ElseIf Not line.Contains("#") Then
                        Dim _field = line.Split(" ")
                        Dim key = _field(0)
                        Dim value = _field(1)
                        If Not Me.id_dict.ContainsKey(key) Then
                            Me.id_dict.Add(key, value)
                        End If
                    End If
                End While
                If Me.id_dict.ContainsKey(Me.target) Then
                    Me.target = Me.id_dict(Me.target)
                Else
                    Me.target = 214 ' 214 is Kyushu in Japan
                End If
            End Using
        End If
    End Sub
End Class
