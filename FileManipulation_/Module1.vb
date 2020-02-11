Imports System.IO
Imports System.Text

Module Module1

    Sub Main()

    End Sub

    Sub write(things As List(Of Identifier), outputFilename As String)


        Using sw = New StreamWriter(outputFilename)
            Dim sbDataLines = New StringBuilder()
            Dim sbHeaderLine = New StringBuilder()
            sbHeaderLine.Append($"{DateTime.Now},26")
            Dim dataIndex = 0

            For Each thing In things
                sbHeaderLine.Append($",{thing.ID}")

                For i As Integer = 0 To thing.Data.Count
                    sbDataLines.Append($"")
                Next
            Next
        End Using

    End Sub
End Module
