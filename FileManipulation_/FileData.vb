Public Class FileData
    Private _time As DateTime
    Public Property Time() As DateTime
        Get
            Return _time
        End Get
        Set(ByVal value As DateTime)
            _time = value
        End Set
    End Property

    Private _value As Double
    Public Property Value() As Double
        Get
            Return _value
        End Get
        Set(ByVal value As Double)
            _value = value
        End Set
    End Property
End Class
