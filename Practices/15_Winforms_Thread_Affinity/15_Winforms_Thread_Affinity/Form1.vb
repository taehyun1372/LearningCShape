Imports System.Threading
Imports System.Diagnostics

Public Class Form1
    Private myTimer As Timer
    Dim sw As New Stopwatch()

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load



        myTimer = New Timer(AddressOf TimerCallback, Nothing, 1000, 2000)
        'Timer1.Interval = 2000
        'Timer1.Enabled = True
    End Sub

    Private Sub TimerCallback(state As Object)
        Console.WriteLine("In background thread call back : start")
        Thread.Sleep(3000) 'Long running process
        Me.Invoke(Sub() UIUpdate(1, 2, 3))
        Console.WriteLine("In background thread call back : finish")
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Console.WriteLine("In winfrom timer call back : start")
        Thread.Sleep(3000)
        btnFirst.Text = "Changed"
        Console.WriteLine("In winfrom timer call back : finish")
    End Sub

    Private Sub UIUpdate(data1 As Integer, data2 As Integer, data3 As Integer)
        sw.Start()
        For i = 1 To 20000
            btnFirst.Text = data1
            btnSecond.Text = data2
            btnThird.Text = data3
        Next
        sw.Stop()
        Console.WriteLine($"Elapsed Time : {sw.ElapsedMilliseconds}")
        sw.Reset()
    End Sub
End Class
