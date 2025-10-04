Imports System
Imports System.Threading

Module Program
    Sub Main(args As String())
        Console.WriteLine("Hello World!")

        Dim t1 As Task(Of Integer) = Task.Factory.StartNew(Function() Display1(5))
        Dim t2 As Task(Of Integer) = t1.ContinueWith(Function(prevTask) Display2(6))

        While (True)

            Console.WriteLine($"t1 done? {t1.IsCompleted}")
            Console.WriteLine($"t2 done? {t2.IsCompleted}")
            Console.WriteLine($"t1 result! {t1.Result}")
            Console.WriteLine($"t2 result! {t2.Result}")
            Thread.Sleep(1000)
        End While
    End Sub

    Function Display1(n As Integer) As Integer
        For i = 1 To n
            Console.WriteLine($"Display 1 : {i}")
            Thread.Sleep(1000)
        Next

        Return n
    End Function

    Function Display2(n As Integer) As Integer
        For i = 1 To n
            Console.WriteLine($"Display 2 : {i}")
            Thread.Sleep(1000)
        Next
        Return n
    End Function
End Module
