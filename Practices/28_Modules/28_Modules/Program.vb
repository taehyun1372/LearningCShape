Imports System

Module Program
    Sub Main(args As String())
        Console.WriteLine("Hello World!")
        While (True)
            Dim input = Console.ReadLine()
            If (input <> "exit") Then
                Dim result As Integer
                If (Integer.TryParse(input, result)) Then
                    Console.WriteLine(Utils.PLCs(result).Id)
                End If
            Else
                Exit While
            End If
        End While
    End Sub
End Module
