Public Class PLC
    Private _id As Integer
    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property
    Sub New(id As Integer)
        _id = id
    End Sub
End Class
