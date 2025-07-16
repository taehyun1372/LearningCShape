Public Module Utils 'Module can be understood as global declaration & operation. 
    Public Const NUM_OF_DEVICES As Integer = 10
    Public PLCs As New Dictionary(Of Integer, PLC)

    Sub New()
        Console.WriteLine("Hello World")
        PLCs.Add(0, New PLC(0))
        PLCs.Add(1, New PLC(1))
        PLCs.Add(2, New PLC(2))
        PLCs.Add(3, New PLC(3))
        PLCs.Add(4, New PLC(4))
        PLCs.Add(5, New PLC(5))
        PLCs.Add(6, New PLC(6))
        PLCs.Add(7, New PLC(7))
        PLCs.Add(8, New PLC(8))
        PLCs.Add(9, New PLC(9))
        PLCs.Add(10, New PLC(10))
        PLCs.Add(11, New PLC(11))
    End Sub
End Module
