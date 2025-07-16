Imports System
Imports System.Threading


Module Program
    Public _cancellationToken As Boolean = False

    Sub Main(args As String())
        Console.WriteLine("Hello World!")

        'Dim t As New Thread(AddressOf Display1)
        't.Start()
        'While (True)
        '    Dim input As String = Console.ReadLine()
        '    If (input = "exit") Then
        '        t.Abort()
        '        Exit While
        '    End If
        'End While

        'Dim cts As New CancellationTokenSource()
        '
        'ThreadPool.QueueUserWorkItem(Sub(state)
        '                                 Dim token As CancellationToken = CType(state, CancellationToken)
        '                                 Display2(token)
        '                             End Sub, cts.Token)
        'While (True)
        '    Dim input As String = Console.ReadLine()
        '    If (input = "exit") Then
        '        cts.Cancel()
        '        Exit While
        '    End If
        'End While

        Dim task As Task = Task.Factory.StartNew(Sub() Display1(20))
        task.Wait()

        Console.WriteLine("Goodbye World!")
    End Sub

    Public Sub Display1(max As Integer)
        For counter As Integer = 0 To max Step 1
            Console.WriteLine($"Basic thread is running {counter}")
            Thread.Sleep(1000)
        Next
    End Sub

    Public Sub Display2(token As CancellationToken)
        For counter As Integer = 0 To 100 Step 1
            If token.IsCancellationRequested Then
                Console.WriteLine("Cancellation requested. Exiting Display2...")
                Exit Sub
            End If
            Console.WriteLine($"A thread is running in a thread pool {counter}")
            Thread.Sleep(1000)
        Next
    End Sub


End Module
