Imports System

Module Program
    Sub Main(args As String())
        Console.WriteLine("Hello World!")

        'data feed instanciation
        Dim dataFeed As DataFeed = New DataFeed()
        Dim dict = dataFeed.GetDeviceParameterDictionary("192.168.2.1")
        'Adding some parameters
        dict.Add(1, New Parameter(10, 200, "Temperature 1"))
        dict.Add(2, New Parameter(11, 201, "Temperature 2"))
        dict.Add(3, New Parameter(12, 202, "Temperature 3"))

        dataFeed.DisplayDictionary("192.168.2.1")
    End Sub
End Module
