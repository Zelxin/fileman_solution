Public Class Identifier
    Private _id As String
    Public Property ID() As String
        Get
            Return _id
        End Get
        Set(ByVal value As String)
            _id = value
        End Set
    End Property

    Private _data As List(Of FileData)
    Public Property Data() As List(Of FileData)
        Get
            Return _data
        End Get
        Set(ByVal value As List(Of FileData))
            _data = value
        End Set
    End Property

End Class
