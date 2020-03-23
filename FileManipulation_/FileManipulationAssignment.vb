Imports System.IO
Imports System.Text

Module FileManipulationAssignment

    Sub Main()
        Dim dataSets = readWork(Directory.GetCurrentDirectory())
        writeWork(dataSets, "output.txt")
    End Sub

    Sub write(things As List(Of Identifier), outputFilename As String)
        Dim sbDataLines = New StringBuilder()

        Dim sbHeaderLine = New StringBuilder()
        sbHeaderLine.Append($"{DateTime.Now},26")
        Dim firstID = things(0)
        For Each thing In things
            sbHeaderLine.Append($",{thing.ID}")
            If firstID.Data.Count <> thing.Data.Count Then
                Console.WriteLine("AHHH, one of the ids is missing a data point")
                Console.ReadKey()
            End If
        Next

        Dim dataIndex = 0
        Dim lines As New List(Of String)

        While dataIndex < firstID.Data.Count()
            sbDataLines.Append($"{firstID.Data(dataIndex).Time},1")
            For Each thing In things
                Dim d = thing.Data(dataIndex)
                sbDataLines.Append($",{d.Value}")
            Next
            dataIndex += 1
        End While

        File.WriteAllText(outputFilename, sbHeaderLine.ToString())
        File.WriteAllText(outputFilename, sbDataLines.ToString())
    End Sub

    Function read(dir As String) As List(Of Identifier)
        Dim result = New List(Of Identifier)
        Dim di = New DirectoryInfo(Directory.GetCurrentDirectory) ' Directory.GetCurrentDirectory
        Dim files = di.GetFiles("*.csv")

        For Each file In files 'This is intentionally written with the assumption there will only ever be 1(unique) identifier per file
            Dim identifier = New Identifier()
            Using sr As New StreamReader(file.FullName)
                Dim line = sr.ReadLine() ' I know the first line is a header line that I don't care about this will skip it.
                While sr.Peek <> -1 'In vb i recommend checking peak.
                    line = sr.ReadLine()
                    Dim lineSplit = line.Split(","c)
                    Dim id = lineSplit(1)
                    Dim dt = DateTime.Parse(lineSplit(0))
                    Dim Value As Double
                    Dim bGoodValue = Double.TryParse(lineSplit(2), Value) '..........!
                    identifier.ID = id
                    Dim fd = New FileData()
                    fd.Time = dt
                    fd.Value = value
                    Identifier.Data.Add(fd)
                End While
            End Using
            result.Add(identifier)
        Next
        Return result
    End Function

    Function readWork(dir As String) As List(Of Identifier)
        Dim result = New List(Of Identifier)
        Dim di = New DirectoryInfo(Directory.GetCurrentDirectory()) ' Directory.GetCurrentDirectory
        Dim files = di.GetFiles("*.csv")

        For Each f In files 'This is intentionally written with the assumption there will only ever be 1(unique) identifier per file
            Dim identifier = New Identifier()
            Dim bGoodFile = True
            Dim lntCnt = 0
            Using sr As New StreamReader(f.FullName)
                Dim line = sr.ReadLine() ' I know the first line is a header line that I don't care about this will skip it.
                lntCnt += 1
                While sr.Peek() <> -1 'In vb i recommend checking peak.
                    line = sr.ReadLine()
                    lntCnt += 1
                    Dim lineSplit = line.Split(","c)
                    Dim id = lineSplit(1)
                    Dim dt = DateTime.Parse(lineSplit(0))
                    Dim value As Double = 0
                    Dim bGoodValue = Double.TryParse(lineSplit(2), value) '..........!
                    If Not bGoodValue Then
                        bGoodFile = False
                        sr.ReadToEnd()
                    Else
                        identifier.ID = id
                        Dim fd = New FileData()
                        fd.Time = dt
                        fd.Value = value
                        identifier.Data.Add(fd)
                    End If
                End While
            End Using
            If bGoodFile Then
                result.Add(identifier)
            Else
                File.WriteAllText("errors.log", $"File: {f} has an error on line: {lntCnt}. Quitting processing.")
            End If
        Next
        Return result
    End Function
    Sub writeWork(things As List(Of Identifier), outputFilename As String)
        Dim sbDataLines = New StringBuilder()

        Dim sbHeaderLine = New StringBuilder()
        sbHeaderLine.Append($"{DateTime.Now},26")
        Dim firstID = things(0)
        For Each thing In things
            sbHeaderLine.Append($",{thing.ID}")
            If firstID.Data.Count <> thing.Data.Count Then
                Console.WriteLine("AHHH, one of the ids is missing a data point")
                Console.ReadKey()
            End If
        Next
        sbHeaderLine.AppendLine()

        Dim dataIndex = 0
        Dim lines As New List(Of String)

        While dataIndex < firstID.Data.Count()
            sbDataLines.Append($"{firstID.Data(dataIndex).Time:yyyy-MM-dd HH:mm},1")
            For Each thing In things
                Dim d = thing.Data(dataIndex)
                sbDataLines.Append($",{d.Value}")
            Next
            dataIndex += 1
            sbDataLines.AppendLine()
        End While

        File.WriteAllText(outputFilename, sbHeaderLine.ToString())
        File.AppendAllText(outputFilename, sbDataLines.ToString())
    End Sub

    Sub writeFancy(things As List(Of Identifier), outputFilename As String)

    End Sub

End Module
