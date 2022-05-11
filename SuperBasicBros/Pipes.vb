Module Pipes

    '    _____ _                 
    '   |  __ (_)                
    '   | |__) | _ __   ___  ___ 
    '   |  ___/ | '_ \ / _ \/ __|
    '   | |   | | |_) |  __/\__ \
    '   |_|   |_| .__/ \___||___/
    '           | |              
    '           |_|              
    '_______________________________________
    '*Create Pipes
    '*Piranha Plant (or ggif image)
    '*Summon Entity out of it (pop out)

    Public pipes As New List(Of Integer)
    Public pipe_coordinates As New List(Of String)

    Public pipes_down As New List(Of String) ' If down is empty ignore
    Public pipes_piranha_image As New List(Of Image)
    Public pipes_piranha As New List(Of Boolean)
    Public pipes_size As New List(Of Integer)


    Public pipe_limit As Integer = 0
    Sub createPipes(ByVal gridx As Integer, ByVal gridy As Integer, ByVal size As Integer, ByVal image As Bitmap, ByVal piranha As Boolean)
        pipes.Add(block_limit)
        pipe_coordinates.Add(gridx & "_" & gridy)
        pipes_size.Add(size)
        pipes_piranha_image.Add(image)
        pipes_piranha.Add(piranha)

    End Sub




    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Function getPipeX(ByVal id As Integer)
        Dim datas As String = pipe_coordinates.Item(id)
        Dim texts() As String = Split(datas, "_")
        Return texts(0)
    End Function

    Function getPipeY(ByVal id As Integer)
        Dim datas As String = pipe_coordinates.Item(id)
        Dim texts() As String = Split(datas, "_")
        Return texts(1)
    End Function
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Function hasDown(ByVal id As Integer)
        Dim datas As String = pipe_coordinates.Item(id)
        Dim texts() As String = Split(datas, "_")
        Return texts(0)
    End Function

    Function usePiranha(ByVal id As Integer)
        Dim datas As String = pipes_piranha.Item(id)
        Return datas
    End Function


    Function getSize(ByVal id As Integer)
        Dim datas As String = pipes_size.Item(id)
        Return datas
    End Function

    Function getImage(ByVal id As Integer)
        Dim datas As Bitmap = pipes_piranha_image.Item(id)
        Return datas
    End Function


    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    'TODO: FINISH SAVE PIPES AND PIPES BLOCKS


    Sub resetAll()
        pipes = New List(Of Integer)
        pipe_coordinates = New List(Of String)

        pipes_down = New List(Of String) ' If down is empty ignore
        pipes_piranha_image = New List(Of Image)
        pipes_piranha = New List(Of Boolean)
        pipes_size = New List(Of Integer)
    End Sub
End Module
