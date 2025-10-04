

Public Class DataFeed
    Private _parameterCollections As Dictionary(Of String, Dictionary(Of Integer, Parameter)) = New Dictionary(Of String, Dictionary(Of Integer, Parameter))()

    Sub New()

        _parameterCollections.Add("192.168.2.1", New Dictionary(Of Integer, Parameter))
        _parameterCollections.Add("192.168.2.2", New Dictionary(Of Integer, Parameter))
        _parameterCollections.Add("192.168.2.3", New Dictionary(Of Integer, Parameter))
    End Sub

    Public Function GetDeviceParameterDictionary(input As String) As Dictionary(Of Integer, Parameter)
        If (_parameterCollections.ContainsKey(input)) Then
            Return _parameterCollections(input)
        Else
            Return Nothing
        End If
    End Function

    Public Sub DisplayDictionary(input As String)
        If (_parameterCollections.ContainsKey(input)) Then
            Dim dict As Dictionary(Of Integer, Parameter) = _parameterCollections(input)

            For Each kvp As KeyValuePair(Of Integer, Parameter) In dict
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}")
                Dim param As Parameter = TryCast(kvp.Value, Parameter)

                Console.WriteLine($"Parameter Id : {param.Id}")
                Console.WriteLine($"Parameter Value : {param.Value}")
                Console.WriteLine($"Parameter Description : {param.Description}")

            Next
        End If
    End Sub

End Class


Public Class Parameter

    Public Property Id As Integer
    Public Property Value As Integer
    Public Property Description As String

    Sub New(id As Integer, value As Integer, description As String)
        Me.Id = id
        Me.Value = value
        Me.Description = description
    End Sub
End Class