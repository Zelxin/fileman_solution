Imports System.IO
Imports System.Text

Module FileManipulationAssignment

    Sub Main()

    End Sub

    Sub write(things As List(Of Identifier), outputFilename As String)


        Using sw = New StreamWriter(outputFilename)
            Dim sbDataLines = New StringBuilder()
            Dim sbHeaderLine = New StringBuilder()
            sbHeaderLine.Append($"{DateTime.Now},26")
            Dim dataIndex = 0
            Dim lastDatetime As DateTime = DateTime.MinValue
            Dim lines As New List(Of String)

            Dim firstID = things(0)

            For Each datum In firstID.Data

            Next

            For Each thing In things
                sbHeaderLine.Append($",{thing.ID}")

                If lastDatetime = DateTime.MinValue Then ' happens on first iteration
                    lastDatetime = thing.Data(dataIndex).Time
                End If

                sbDataLines.Append($"")

                For i As Integer = 0 To thing.Data.Count

                Next
            Next
        End Using
    End Sub

End Module
