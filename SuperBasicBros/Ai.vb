Module Ai

    '           _____ 
    '    /\    |_   _|
    '   /  \     | |  
    '  / /\ \    | |  
    ' / ____ \  _| |_ 
    '/_/    \_\|_____|





    Public ai_ As New List(Of String)
    Dim ai_ai As New List(Of String)
    Dim ai_image As New List(Of Image)
    'Dim ai_loc As New List(Of Point)

    Dim ai_amount As Integer = 0


    Sub createAI(ByVal ai_name As String, ByVal ai As String, ByVal img As Image) 'Creates an AI so an entity can use it. Basically controls what the entity does.
        ai_.Add(ai_name)
        ai_amount = ai_amount + 1


        ai_ai.Add(ai)
        ai_image.Add(img)
        'ai_loc.Add(New Point(x, y))
    End Sub


    Function getName(ByVal id As Integer)
        Dim statey As String = ai_.Item(id)
        Return statey
    End Function

    Function getImage(ByVal namey As String)
        Dim amount As Integer = 0
        Dim index As Integer = 0
        For Each names In ai_
            If names = namey Then
                index = amount
                Exit For
            End If
            amount = amount + 1
        Next
        Return ai_image.Item(index)
    End Function

    Function getAI(ByVal namey As String)
        Dim amount As Integer = 0
        Dim index As Integer = 0
        For Each names In ai_
            If names = namey Then
                index = amount
                Exit For
            End If
            amount = amount + 1
        Next
        Return ai_ai.Item(index)
    End Function


    Sub resetAll()
        ai_ = New List(Of String)
        ai_ai = New List(Of String)
        ai_image = New List(Of Image)
    End Sub
End Module
