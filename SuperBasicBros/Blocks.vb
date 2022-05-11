Module Blocks

    ' ____   _               _         
    '|  _ \ | |             | |        
    '| |_) || |  ___    ___ | | __ ___ 
    '|  _ < | | / _ \  / __|| |/ // __|
    '| |_) || || (_) || (__ |   < \__ \
    '|____/ |_| \___/  \___||_|\_\|___/ 
    '
    '_______________________________________
    '*Allows to create block
    '*Get block data, touches, entity, so on
    '*Limit amount of touhes
    '*Image before, and after



    Public blocks As New List(Of Integer)
    Public block_coordinates As New List(Of String)

    Public block_limits As New List(Of String)
    Public block_give As New List(Of String)
    Public block_imageMain As New List(Of Image)
    Public block_imageDone As New List(Of Image)

    Public block_limit As Integer = 0


    Public saved_blocks As New Dictionary(Of String, Integer)
    Public saved_block_coordinates As New Dictionary(Of String, String)


    Public saved_block_limits As New Dictionary(Of String, String)
    Public saved_block_give As New Dictionary(Of String, String)
    Public saved_block_imageMain As New Dictionary(Of String, Image)
    Public saved_block_imageDone As New Dictionary(Of String, Image)
    Public saved_lock_limit As Integer = 0
    'Creating a block. X and Y are located from top left of background point. Use PIPELINE: | for splitter for TOUCHING and ENTITY. If limits = 0, then it won't break (get removed from screen). If TOUHCING: has 'top' the player will fall through it (for speical mario blocks in game)
    'createBlocks(100, 100, "bottom|left|right", "player|redshell|greenshell", "none", "1", My.Resources.BrickBlockBrown, My.Resources.BrickBlockBrown)
    Sub createBlocks(ByVal gridx As Integer, ByVal gridy As Integer, ByVal give As String, ByVal limits As String, ByVal imageBefore As Bitmap, ByVal imageDone As Bitmap)
        blocks.Add(block_limit)


        'TOUCHING > top|bottom|left|right
        'ENTITIES > player|greenshell|redshell  OR Do: death-coin-etc
        'GIVING [ALL CAN WORK TOO] > [ID HERE] 
        '   NOTICE ALL: mushrooms, coins and so on are entites, so they aren't counted in here
        'LIMIT AMOUNTS OF HITS > 10
        'IMAGES > [IMAGE BEFORE]|[IMAGE AFTER]


        block_coordinates.Add(gridx & "_" & gridy)
        block_limits.Add(limits)
        block_give.Add(give)
        block_imageMain.Add(imageBefore)
        block_imageDone.Add(imageDone)
        block_limit = block_limit + 1
    End Sub



    Function getBlocksAmount()
        Return block_limit
    End Function
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Function getMainImage(ByVal id As Integer)
        Return block_imageMain.Item(id)
    End Function

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Function getDoneImage(ByVal id As Integer)
        Return block_imageDone.Item(id)
    End Function

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Function getBlockX(ByVal id As Integer)
        Dim datas As String = block_coordinates.Item(id)
        Dim texts() As String = Split(datas, "_")
        Return texts(0)
    End Function

    Function getBlockY(ByVal id As Integer)
        Dim datas As String = block_coordinates.Item(id)
        Dim texts() As String = Split(datas, "_")
        Return texts(1)
    End Function
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Function getGive(ByVal id As Integer)
        Return block_give.Item(id)
    End Function

    Sub setRemoved(ByVal id As Integer)
        block_coordinates.RemoveAt(id)
        block_limits.RemoveAt(id)
        block_give.RemoveAt(id)
        block_imageMain.RemoveAt(id)
        block_imageDone.RemoveAt(id)
    End Sub

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Function getLimits(ByVal id As Integer)
        Return block_limits.Item(id)
    End Function

    Sub setLimits(ByVal id As Integer, ByVal limit As Integer)
        block_limits.Item(id) = limit
    End Sub

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    'TODO: FINISH SAVE BLOCKS AND LOAD BLOCKS
    Sub saveBlocks(ByVal id As String)
        For loops = 0 To block_limit
            saved_blocks.Add(id & "_" & loops, blocks.Item(loops))
        Next
        For loops = 0 To block_limit
            saved_block_coordinates.Add(id & "_" & loops, block_coordinates.Item(loops))
        Next
        For loops = 0 To block_limit
            saved_block_limits.Add(id & "_" & loops, block_limits.Item(loops))
        Next
        For loops = 0 To block_limit
            saved_block_give.Add(id & "_" & loops, block_give.Item(loops))
        Next
        For loops = 0 To block_limit
            saved_block_imageMain.Add(id & "_" & loops, block_imageMain.Item(loops))
        Next
        For loops = 0 To block_limit
            saved_block_imageDone.Add(id & "_" & loops, block_imageDone.Item(loops))
        Next
    End Sub


    Sub resetAll()
        blocks = New List(Of Integer)
        block_coordinates = New List(Of String)

        block_limits = New List(Of String)
        block_give = New List(Of String)
        block_imageMain = New List(Of Image)
        block_imageDone = New List(Of Image)

        block_limit = 0


        saved_blocks = New Dictionary(Of String, Integer)
        saved_block_coordinates = New Dictionary(Of String, String)


        saved_block_limits = New Dictionary(Of String, String)
        saved_block_give = New Dictionary(Of String, String)
        saved_block_imageMain = New Dictionary(Of String, Image)
        saved_block_imageDone = New Dictionary(Of String, Image)
        saved_lock_limit = 0

    End Sub
End Module
