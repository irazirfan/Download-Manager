Imports System.Net

Public Class Form1

    Public WithEvents download As New WebClient
    Dim SavePath As String

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Button2.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            download.CancelAsync()
            ProgressBar1.Value = 0
            My.Computer.FileSystem.DeleteFile(TextBox2.Text)
            Button1.Enabled = False
            Button2.Enabled = True
            MsgBox("Download was cancelled!")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Try
            Dim sfd As New SaveFileDialog
            sfd.Filter = "All Files|*.*"
            If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
                TextBox2.Text = sfd.FileName
                Button2.Enabled = False
                Button1.Enabled = True
                TextBox1.Enabled = False
                download.DownloadFileAsync(New Uri(TextBox1.Text), TextBox2.Text)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub download_DownloadFileCompleted(sender As Object, e As System.ComponentModel.AsyncCompletedEventArgs) Handles download.DownloadFileCompleted
        MsgBox("Your download has been completed")
        Button2.Enabled = True
        Button1.Enabled = False
        TextBox1.Enabled = True
        ProgressBar1.Value = 0
        Label1.Text = ProgressBar1.Value & "%"
    End Sub

    Private Sub download_DownloadProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs) Handles download.DownloadProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
        Label1.Text = ProgressBar1.Value & "%"

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MsgBox("Developed by SE student, Iraz Irfan from AIUB")
    End Sub

End Class
