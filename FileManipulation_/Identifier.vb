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

    ''' <summary>
    ''' gets the filedata with the matching timestamp
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <returns>the file data with the matching time, otherwise nothing.</returns>
    Public Function GetDataFromTime(dt As DateTime) As FileData
        Dim result As FileData = Nothing
        For Each datum In Data
            If datum.Time = dt Then
                result = datum
            End If
        Next
        Return result
    End Function
End Class
