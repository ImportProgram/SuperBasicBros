Module Entity

    ' ______       _   _ _         
    '|  ____|     | | (_) |        
    '| |__   _ __ | |_ _| |_ _   _ 
    '|  __| | '_ \| __| | __| | | |
    '| |____| | | | |_| | |_| |_| |
    '|______|_| |_|\__|_|\__|\__, |
    '                         __/ |
    '                        |___/ 


    'STARTING LOCATIONS


    Public entity_ As New List(Of String)
    Dim entity_ai As New List(Of String)
    Dim entity_loc As New List(Of Point) 'Starting Location
    Dim entity_gravity As New List(Of Integer) 'Starting Gravity
    Dim entity_enabled As New List(Of Boolean)
    Dim entity_block As New List(Of String)
    Dim entity_amount As Integer = 0


    Sub summonEntity(ByVal ai As String, ByVal x As Integer, ByVal y As Integer, ByVal gravity As Integer, ByVal block As String)  'Add it to screen basically
        entity_.Add(entity_amount)
        entity_amount = entity_amount + 1

        entity_ai.Add(ai) ' name of ai
        entity_loc.Add(New Point(x, y))
        entity_gravity.Add(gravity)
        entity_block.Add(block)
        If block = "null" Or block = "none" Then
            entity_enabled.Add(True)
        Else
            entity_enabled.Add(False)
        End If
    End Sub

    Function getEntities()
        Return entity_
    End Function
    Function getAI(ByVal id As Integer)
        Dim ai As String = entity_ai.Item(id)
        Return ai
    End Function

    Function getLoc(ByVal id As Integer)
        Dim loc As Point = entity_loc.Item(id)
        Return loc
    End Function

    Function getGravity(ByVal id As Integer)
        Dim gravity As Integer = entity_gravity.Item(id)
        Return gravity
    End Function

    Function setEnabled(ByVal id As Integer)
        entity_enabled.Item(id) = True
        Return True
    End Function

    Function setDisabled(ByVal id As Integer)
        entity_enabled.Item(id) = False
        Return False
    End Function

    Function getState(ByVal id As Integer)
        Return entity_enabled.Item(id)
    End Function

    Function getBlock(ByVal id As Integer)
        Return entity_block.Item(id)
    End Function

    Function isBlock(ByVal id As Integer)
        Dim statement As String = entity_block.Item(id)
        If statement = "null" Or statement = "none" Then
            Return False
        Else
            Return True
        End If
    End Function


    Sub removeAt(ByVal id As Integer)
        entity_.RemoveAt(id)
        entity_amount = entity_amount - 1

        entity_ai.RemoveAt(id)
        entity_loc.RemoveAt(id)
        entity_gravity.RemoveAt(id)
        entity_block.RemoveAt(id)

        entity_enabled.RemoveAt(id)
    End Sub

    Sub resetAll()
        entity_ = New List(Of String)
        entity_ai = New List(Of String)
        entity_loc = New List(Of Point) 'Starting Location
        entity_gravity = New List(Of Integer) 'Starting Gravity
        entity_enabled = New List(Of Boolean)
        entity_block = New List(Of String)
        entity_amount = 0
    End Sub
End Module
