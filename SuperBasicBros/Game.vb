
Imports System.Xml


Public Class Game
    Public scrollx As Integer 'The Scrolling X
    Public scrolly As Integer 'The Scrolling Y

    Public levelx As Integer 'Like scrollx but still and set at start of game
    Public levely As Integer 'Like scrolly but still and set at start of game

    Public mario_state As Integer = 0 'Marios state! Mini, Super, Fire 

    Public marioy As Integer = 100 'Mario Y, mainly for jumping and swimming

    Dim speed As Integer = 7 'Speed at which mario walks
    Dim jump As Boolean = False 'Jumping active?
    Dim gravity As Integer = 4  'Gravity for PLAYER
    Dim jumping As Boolean = False 'Is jumping active?

    Dim levelc As Integer = 600 'Level amount over

    Dim centerx, centery As Integer 'Center for board and data
    Dim scrollingx, scrollingy As Integer 'Amount of scrolling like x and y but for blocks

    Dim leftx As Integer = 0 '--
    Dim rightx As Integer = 0 '--

    Dim move_left As Boolean 'We moving left?
    Dim move_right As Boolean 'We moving right?

    Dim moving_left As Boolean
    Dim timer_left As Boolean

    Dim moving_right As Boolean
    Dim timer_right As Boolean

    Dim smallw As Integer
    Dim smallh As Integer

    Dim blocky As New List(Of PictureBox) 'Blocks
    Dim blockyr As New List(Of PictureBox) 'Block Right
    Dim blockyl As New List(Of PictureBox) 'Block Left
    Dim blocky_limit As Integer = 0 ' Limit of Blocks

    Dim entities As New List(Of PictureBox)
    Dim entities_g As New List(Of Integer)
    Dim entities_d As New List(Of Boolean)
    Dim entites_t As New List(Of Integer)
    Dim entites_x As New List(Of Integer)
    Dim entites_y As New List(Of Integer)


    Dim pipey As New List(Of PictureBox) 'All Pipes
    Dim pipeyr As New List(Of PictureBox) 'Right Col' 
    Dim pipeyl As New List(Of PictureBox) 'Left Col.
    Dim pipeyp As New List(Of PictureBox) 'Piranha Boxes

    Dim pipeyp_y As New List(Of Integer) 'Piranha Plant y
    Dim pipeyp_i As New List(Of Integer) 'That increasement
    Dim pipeyp_state As New List(Of Integer) 'The state of which its in (1-4)
    Dim pipeyp_wait As New List(Of Integer) 'The waiting time which it goes into next state
    Dim pipy_limit As Integer = 0 'Limits pipes

    Dim pole As PictureBox
    Dim flag As PictureBox
    Dim credits_done As Boolean
    Dim fireworks As Boolean = False
    Dim fireworks_t As Integer = -1
    Dim ending As Integer = 0
    Dim pole_sound As Integer = -1
    Dim flag_create As Boolean = False
    Dim fireworks_last As Integer = 0

    Dim fallingMenuEntitys As New List(Of PictureBox)
    Dim fallingMenuImages As New List(Of Image)
    Dim falling_amount As Integer = 10
    Dim falling_total As Integer = 0

    Dim bumped As Integer = 1000 'bumped block starting pos
    Dim bumped_y As Integer = -5 'If bump set gravity!

    Dim move_last As String 'Which direction was last to move? Left or Right?

    Dim floors As PictureBox 'The Floor that which PLAYER stands on (mario)

    Dim cover_width As Integer 'Blocks amount at which to cover from sides (usually 200)
    Dim blocker_left As PictureBox 'Left Side Screen - Hidden Blocker
    Dim blocker_right As PictureBox 'Right Side Screen - hIdden Blocker

    Dim fireball As Boolean = False 'Fireball activation!
    Dim fireballD As String 'Direction of Fireball
    Dim fireballG As Integer = 0 'Gravity of Fireball
    Dim fireballX As Integer 'Fireball X
    Dim fireballY As Integer 'Fireball Y
    Dim fireball_active As Boolean = False 'Is actived!

    Dim bounces As Integer
    Dim view_bounds As Boolean = False 'View left and right bounds of pipes an blocks


    Dim dialogImage As Image

    Dim dialogSizeW As Integer
    Dim dialogSizeH As Integer
    Dim dialogAfterW As Integer
    Dim dialogAfterH As Integer

    Dim dialogDone As Boolean = False
    Dim dialogRunning As Boolean = False
    Dim dialogX As Integer
    Dim dialogY As Integer

    Dim started As Boolean = False 'Game Started?
    Dim paused As Boolean = False 'Pasued?

    Dim menux As Integer 'Menu Image X
    Dim menu_sx As Integer 'Menu Image Selector's X
    Dim menuy As Integer 'Menu Image Y
    Dim menu_sy As Integer 'Menu Image Selector's Y

    Dim selection As Integer = 1 'Which Selected?
    Dim selecting As Integer = True 'Are we selecting?
    Dim selected_sprite As Integer = 0 'Animation Start?
    Dim selected_direction As Boolean = False 'Direction based var...
    '''
    Dim coins As Integer = 0
    Dim time As Integer = 0
    Dim lives As Integer = 3
    Dim points As Integer = 0
    Dim timey As Integer = 300

    Dim mute As Boolean = False

    Dim mario_dead As Boolean = False
    Dim mario_dead_t As Integer = 100

    Dim mario_start As Boolean = False
    Dim mario_start_t As Integer = 50


    Dim entity_added As List(Of Boolean)
    Dim no_keys As Boolean = False
    Dim sizes As Integer = 3
    Dim gameover As Boolean = False

    Private Sounds As New MultiSounds

    Private Sub Loads(sender As Object, e As EventArgs) Handles MyBase.Load
        ''Starts sounds here! (Add them and set an id to them)
        Sounds.AddSound("Theme", My.Application.Info.DirectoryPath + "\Sounds\Songs\super_mario_theme_song.wav")
        Sounds.AddSound("Remix", My.Application.Info.DirectoryPath + "\Sounds\Songs\mario_remix.wav")
        Sounds.AddSound("Point", My.Application.Info.DirectoryPath + "\Sounds\Collect_Point_01.wav")

        Sounds.AddSound("menu-select", My.Application.Info.DirectoryPath + "\Sounds\menu_navigate_03.wav")
        Sounds.AddSound("menu-dialog", My.Application.Info.DirectoryPath + "\Sounds\Pickup_03.wav")


        Sounds.AddSound("player-bump", My.Application.Info.DirectoryPath + "\Sounds\smb_bump.wav")
        Sounds.AddSound("player-break_block", My.Application.Info.DirectoryPath + "\Sounds\smb_breakblock.wav")
        Sounds.AddSound("player-fireball", My.Application.Info.DirectoryPath + "\Sounds\smb_fireball.wav")
        Sounds.AddSound("player-powerup", My.Application.Info.DirectoryPath + "\Sounds\smb_powerup.wav")
        Sounds.AddSound("player-powerup-appears", My.Application.Info.DirectoryPath + "\Sounds\smb_powerup_appears.wav")
        Sounds.AddSound("player-coin", My.Application.Info.DirectoryPath + "\Sounds\smb_coin.wav")
        Sounds.AddSound("player-die", My.Application.Info.DirectoryPath + "\Sounds\smb_mariodie.wav")
        Sounds.AddSound("player-over", My.Application.Info.DirectoryPath + "\Sounds\smb_gameover.wav")
        Sounds.AddSound("player-stomp", My.Application.Info.DirectoryPath + "\Sounds\smb_stomp.wav")
        Sounds.AddSound("player-world_clear", My.Application.Info.DirectoryPath + "\Sounds\smb_world_clear.wav")
        Sounds.AddSound("player-pole", My.Application.Info.DirectoryPath + "\Sounds\smb_flagpole.wav")
        Sounds.AddSound("player-fireworks", My.Application.Info.DirectoryPath + "\Sounds\smb_fireworks.wav")
        Sounds.AddSound("player-jump-s", My.Application.Info.DirectoryPath + "\Sounds\smb_jump-small.wav")
        Sounds.AddSound("player-jump-l", My.Application.Info.DirectoryPath + "\Sounds\smb_jump-super.wav")


        Sounds.AddSound("game-hurry", My.Application.Info.DirectoryPath + "\Sounds\smb_warning.wav")


        'Play theme sounds
        Sounds.Play("Theme")
        Sounds.Play("menu-dialog")
        'Set border for the main form style (full screen and no border)
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.WindowState = FormWindowState.Maximized

        'Set scrolling (map) sizes mode and set settings to mario (transparent)
        Scrolling.SizeMode = PictureBoxSizeMode.StretchImage
        pbMario.BackColor = Color.Transparent

        'Set scrolling to the width and height of Scrolling (map)
        scrollingx = Scrolling.Width
        scrollingy = Scrolling.Height
        'Checks if sizes are biger than 1, if so fix the image error and change with and size
        If sizes <> 1 Then
            Scrolling.SizeMode = PictureBoxSizeMode.StretchImage

            scrollingx = scrollingx * sizes
            scrollingy = scrollingy * sizes

            Scrolling.Width = scrollingx
            Scrolling.Height = scrollingy
        End If

        'Grab Scrolling With and Height and divide by 2
        scrollingx = scrollingx / 2
        scrollingy = scrollingy / 2

        'Get center X of Form
        centerx = Me.Width
        centery = Me.Height
        centerx = centerx / 2
        centery = centery / 2

        'Now lets get the Menu With as well but its always at size 2, any bigger is to big
        pbMenuBackground.Width = pbMenuBackground.Size.Width * 2
        pbMenuBackground.Height = pbMenuBackground.Size.Height * 2

        'Set mode for the image
        pbMenuBackground.SizeMode = PictureBoxSizeMode.StretchImage
        menux = pbMenuBackground.Size.Width / 2
        menuy = pbMenuBackground.Size.Height / 2

        'Getr location 
        menux = centerx - menux
        menuy = centery - menuy

        'Set location of Menu Background
        pbMenuBackground.Location = New Point(menux, menuy)

        'Get selectors pos, do more math and find pos and set it
        pbSelector.Width = pbSelector.Size.Width * 2
        pbSelector.Height = pbSelector.Size.Height * 2
        pbSelector.SizeMode = PictureBoxSizeMode.StretchImage
        menu_sx = menux + 400
        menu_sy = menuy + 490
        pbSelector.Location = New Point(menu_sx, menu_sy)
        pbSelector.BringToFront()

        'Now get scrollx and scrolly from the scrolling varibles set a little above
        scrollx = centerx - 500
        scrolly = centery - scrollingy

        'et the orginal levelx to be scrollx and so forth
        levelx = scrollx ' Main Side scrolling pos
        levely = scrolly

        'Set Scrolling  and Mario Location 
        Scrolling.Location = New Point(scrollx, scrolly)
        pbMario.Location = New Point(scrollx, scrolly)
        If sizes <> 1 Then
            pbMario.SizeMode = PictureBoxSizeMode.StretchImage
            pbMario.Width = pbMario.Size.Width * sizes
            pbMario.Height = pbMario.Size.Height * sizes
            smallh = pbMario.Size.Height
            smallw = pbMario.Size.Width
        End If
        leftx = levelx - 50
        rightx = levelx + 500

        pbMario.Visible = False
        Scrolling.Visible = False
        lblJumpStatus.Visible = False


        pbDummy.Width = pbDummy.Size.Width * sizes
        pbDummy.Height = pbDummy.Size.Height * sizes
        pbDummy.Visible = False
        pbDummy.Location = New Point(0, 0)

        pbGameover.Width = pbGameover.Size.Width * 2
        pbGameover.Height = pbGameover.Size.Height * 2
        pbGameover.SizeMode = PictureBoxSizeMode.StretchImage

        pbFireball.Width = pbFireball.Size.Width * sizes
        pbFireball.Height = pbFireball.Size.Height * sizes
        pbFireball.SizeMode = PictureBoxSizeMode.StretchImage

        'Create the Floor for mario 
        floors = New PictureBox
        floors.Width = Scrolling.Width
        floors.Height = 100

        floors.Location = New Point(levelx, levely + levelc) 'NOTICE: 200 Needs to be changed depending on level
        floors.BringToFront()


        flag = New PictureBox
        flag.SizeMode = PictureBoxSizeMode.AutoSize
        flag.Image = My.Resources.FlagFromPole
        flag.BringToFront()
        flag.Width = flag.Size.Width * sizes
        flag.Height = flag.Size.Height * sizes
        flag.SizeMode = PictureBoxSizeMode.StretchImage



        pbFireworks1.Width = pbFireworks1.Size.Width * sizes
        pbFireworks1.Height = pbFireworks1.Size.Height * sizes

        pbFireworks2.Width = pbFireworks2.Size.Width * sizes
        pbFireworks2.Height = pbFireworks2.Size.Height * sizes

        pbFireworks3.Width = pbFireworks3.Size.Width * sizes
        pbFireworks3.Height = pbFireworks3.Size.Height * sizes

        pbFireworks4.Width = pbFireworks4.Size.Width * sizes
        pbFireworks4.Height = pbFireworks4.Size.Height * sizes

        pbFireworks1.SizeMode = PictureBoxSizeMode.StretchImage
        pbFireworks2.SizeMode = PictureBoxSizeMode.StretchImage
        pbFireworks3.SizeMode = PictureBoxSizeMode.StretchImage
        pbFireworks4.SizeMode = PictureBoxSizeMode.StretchImage



        Me.Controls.Add(flag)
        pole = New PictureBox
        pole.Width = 8
        pole.Height = 432

        pole.Location = New Point(scrollx + 9503 + 8, scrolly + 117)
        flag.Location = New Point(pole.Location.X - (flag.Size.Width) + 20, pole.Location.Y + 9)
        flag_create = True

        flag.Visible = False
        menus() 'Start menu
        showDialogs(My.Resources.menu_dialog) 'Show menu dialog for help and info (controls)
    End Sub
    Sub menus()
        Sounds.Play("Theme")
        selecting = True 'Enable Selecting (mouse and cursor)

        TimerFallingR.Enabled = True 'Enable Falling Timer
        TimerFallingAdd.Enabled = True 'Enable adding timer
        newFalling() 'Add falling object so the timer doesn't break


        pbMenuBackground.Visible = True
        pbSelector.Visible = True

        pbMenuBackground.BringToFront()
        pbSelector.BringToFront()
        Cursor.Dispose() 'Hide Cusor
    End Sub
    Sub marioStart()
        Scrolling.SizeMode = PictureBoxSizeMode.StretchImage
        pbMario.BackColor = Color.Transparent

        'Set scrolling to the width and height of Scrolling (map)
        scrollingx = Scrolling.Width
        scrollingy = Scrolling.Height
        'Checks if sizes are biger than 1, if so fix the image error and change with and size
        
        'Grab Scrolling With and Height and divide by 2
        scrollingx = scrollingx / 2
        scrollingy = scrollingy / 2

        pole.Location = New Point(scrollx + 9503 + 8, scrolly + 117)
        flag.Location = New Point(pole.Location.X - (flag.Size.Width) + 20, pole.Location.Y + 9)
        flag.Visible = True
        flag.BringToFront()


        'Get center X of Form
        centerx = Me.Width
        centery = Me.Height
        centerx = centerx / 2
        centery = centery / 2

        'Now get scrollx and scrolly from the scrolling varibles set a little above
        scrollx = centerx - 500
        scrolly = centery - scrollingy

        'et the orginal levelx to be scrollx and so forth
        levelx = scrollx ' Main Side scrolling pos
        levely = scrolly

        'Set Scrolling  and Mario Location 
        Scrolling.Location = New Point(scrollx, scrolly)
        pbMario.Location = New Point(scrollx, scrolly)
        leftx = levelx - 50
        rightx = levelx + 500

        pbMario.Width = smallw
        pbMario.Height = smallh

        pbMario.Visible = False
        Scrolling.Visible = False
        flag.Visible = True

        'ADD MARIO START HERE AND AMOUNT OF POINTS LEFT
        removeFromScreen()
    End Sub
    Sub resetAll()
        blocky = New List(Of PictureBox) 'Blocks
        blockyr = New List(Of PictureBox) 'Block Right
        blockyl = New List(Of PictureBox) 'Block Left
        blocky_limit = 0 ' Limit of Blocks

        entities = New List(Of PictureBox)
        entities_g = New List(Of Integer)
        entities_d = New List(Of Boolean)
        entites_t = New List(Of Integer)
        entites_x = New List(Of Integer)
        entites_y = New List(Of Integer)


        pipey = New List(Of PictureBox) 'All Pipes
        pipeyr = New List(Of PictureBox) 'Right Col' 
        pipeyl = New List(Of PictureBox) 'Left Col.
        pipeyp = New List(Of PictureBox) 'Piranha Boxes

        pipeyp_y = New List(Of Integer) 'Piranha Plant y
        pipeyp_i = New List(Of Integer) 'That increasement
        pipeyp_state = New List(Of Integer) 'The state of which its in (1-4)
        pipeyp_wait = New List(Of Integer) 'The waiting time which it goes into next state
        pipy_limit = 0 'Limits pipes


        fallingMenuEntitys = New List(Of PictureBox)
        fallingMenuImages = New List(Of Image)
        falling_amount = 10
        falling_total = 0


        marioy = 100
        Blocks.resetAll()
        Pipes.resetAll()
        Ai.resetAll()
        Entity.resetAll()
    End Sub

    Sub setObjects()

        'Adding blocks and pipes (and CObjects later)

        ' - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -


        '550 = floor or use floors.Location.Y + width idk

        Blocks.createBlocks(768, 408, "coin", "5", My.Resources.QuestionBlock, My.Resources.EmptyBlock)

        Blocks.createBlocks(960, 408, "none", "1", My.Resources.BrickBlockBrown, My.Resources.BrickBlockBrown)
        Blocks.createBlocks(1008, 408, "coin", "1", My.Resources.QuestionBlock, My.Resources.EmptyBlock)
        Blocks.createBlocks(1056, 408, "none", "1", My.Resources.BrickBlockBrown, My.Resources.BrickBlockBrown)
        Blocks.createBlocks(1104, 408, "powerup", "1", My.Resources.QuestionBlock, My.Resources.EmptyBlock)
        Blocks.createBlocks(1152, 408, "none", "1", My.Resources.BrickBlockBrown, My.Resources.BrickBlockBrown)

        Blocks.createBlocks(1056, 215, "coin", "1", My.Resources.QuestionBlock, My.Resources.EmptyBlock)

        Pipes.createPipes(1345, 505, 1, My.Resources.PiranaPlant, True)
        Pipes.createPipes(1820, 455, 2, My.Resources.PiranaPlant, True)

        Pipes.createPipes(2208, 405, 3, My.Resources.PiranaPlant, True)
        Pipes.createPipes(2730, 405, 3, My.Resources.PiranaPlant, True)

        Pipes.createPipes(3000, 405, 3, My.Resources.PiranaPlant, True)

        Blocks.createBlocks(3695, 408, "none", "1", My.Resources.BrickBlockBrown, My.Resources.BrickBlockBrown)
        Blocks.createBlocks(3743, 408, "powerup", "1", My.Resources.QuestionBlock, My.Resources.EmptyBlock)
        Blocks.createBlocks(3791, 408, "none", "1", My.Resources.BrickBlockBrown, My.Resources.BrickBlockBrown)


        Blocks.createBlocks(3839, 215, "none", "1", My.Resources.BrickBlockBrown, My.Resources.BrickBlockBrown)
        Blocks.createBlocks(3887, 215, "none", "1", My.Resources.BrickBlockBrown, My.Resources.BrickBlockBrown)
        Blocks.createBlocks(3935, 215, "none", "1", My.Resources.BrickBlockBrown, My.Resources.BrickBlockBrown)
        Blocks.createBlocks(3983, 215, "none", "1", My.Resources.BrickBlockBrown, My.Resources.BrickBlockBrown)
        Blocks.createBlocks(4031, 215, "none", "1", My.Resources.BrickBlockBrown, My.Resources.BrickBlockBrown)
        Blocks.createBlocks(4079, 215, "none", "1", My.Resources.BrickBlockBrown, My.Resources.BrickBlockBrown)
        Blocks.createBlocks(4127, 215, "none", "1", My.Resources.BrickBlockBrown, My.Resources.BrickBlockBrown)
        Blocks.createBlocks(4175, 215, "none", "1", My.Resources.BrickBlockBrown, My.Resources.BrickBlockBrown)


        Blocks.createBlocks(4367, 215, "none", "1", My.Resources.BrickBlockBrown, My.Resources.BrickBlockBrown)
        Blocks.createBlocks(4415, 215, "none", "1", My.Resources.BrickBlockBrown, My.Resources.BrickBlockBrown)
        Blocks.createBlocks(4463, 215, "none", "1", My.Resources.BrickBlockBrown, My.Resources.BrickBlockBrown)
        Blocks.createBlocks(4511, 215, "coin", "5", My.Resources.QuestionBlock, My.Resources.EmptyBlock)

        Blocks.createBlocks(4511, 408, "none", "1", My.Resources.BrickBlockBrown, My.Resources.BrickBlockBrown)

        Blocks.createBlocks(4799, 408, "none", "1", My.Resources.BrickBlockBrown, My.Resources.BrickBlockBrown)
        Blocks.createBlocks(4847, 408, "superstar", "1", My.Resources.BrickBlockBrown, My.Resources.EmptyBlock)

        Blocks.createBlocks(5087, 408, "coin", "1", My.Resources.QuestionBlock, My.Resources.EmptyBlock)
        Blocks.createBlocks(5231, 408, "coin", "1", My.Resources.QuestionBlock, My.Resources.EmptyBlock)
        Blocks.createBlocks(5375, 408, "coin", "1", My.Resources.QuestionBlock, My.Resources.EmptyBlock)

        Blocks.createBlocks(5231, 215, "powerup", "1", My.Resources.QuestionBlock, My.Resources.EmptyBlock)

        Blocks.createBlocks(5663, 408, "none", "1", My.Resources.BrickBlockBrown, My.Resources.BrickBlockBrown)


        Blocks.createBlocks(5807, 215, "none", "1", My.Resources.BrickBlockBrown, My.Resources.BrickBlockBrown)
        Blocks.createBlocks(5855, 215, "none", "1", My.Resources.BrickBlockBrown, My.Resources.BrickBlockBrown)
        Blocks.createBlocks(5903, 215, "none", "1", My.Resources.BrickBlockBrown, My.Resources.BrickBlockBrown)

        '6143

        Blocks.createBlocks(6143, 215, "none", "1", My.Resources.BrickBlockBrown, My.Resources.BrickBlockBrown)
        Blocks.createBlocks(6191, 215, "coin", "1", My.Resources.QuestionBlock, My.Resources.EmptyBlock)
        Blocks.createBlocks(6239, 215, "coin", "1", My.Resources.QuestionBlock, My.Resources.EmptyBlock)
        Blocks.createBlocks(6287, 215, "none", "1", My.Resources.BrickBlockBrown, My.Resources.BrickBlockBrown)

        Blocks.createBlocks(6191, 408, "none", "1", My.Resources.BrickBlockBrown, My.Resources.BrickBlockBrown)
        Blocks.createBlocks(6239, 408, "none", "1", My.Resources.BrickBlockBrown, My.Resources.BrickBlockBrown)
        '6335

        Blocks.createBlocks(6431, 550, "none", "0", My.Resources.StairsBlock, My.Resources.StairsBlock)
        Blocks.createBlocks(6479, 502, "none", "0", My.Resources.StairsBlock, My.Resources.StairsBlock)
        Blocks.createBlocks(6527, 454, "none", "0", My.Resources.StairsBlock, My.Resources.StairsBlock)
        Blocks.createBlocks(6575, 408, "none", "0", My.Resources.StairsBlock, My.Resources.StairsBlock)

        Blocks.createBlocks(6719, 408, "none", "0", My.Resources.StairsBlock, My.Resources.StairsBlock)
        Blocks.createBlocks(6767, 454, "none", "0", My.Resources.StairsBlock, My.Resources.StairsBlock)
        Blocks.createBlocks(6815, 502, "none", "0", My.Resources.StairsBlock, My.Resources.StairsBlock)
        Blocks.createBlocks(6863, 550, "none", "0", My.Resources.StairsBlock, My.Resources.StairsBlock)


        Blocks.createBlocks(7103, 550, "none", "0", My.Resources.StairsBlock, My.Resources.StairsBlock)
        Blocks.createBlocks(7151, 502, "none", "0", My.Resources.StairsBlock, My.Resources.StairsBlock)
        Blocks.createBlocks(7199, 454, "none", "0", My.Resources.StairsBlock, My.Resources.StairsBlock)
        Blocks.createBlocks(7247, 408, "none", "0", My.Resources.StairsBlock, My.Resources.StairsBlock)
        Blocks.createBlocks(7295, 408, "none", "0", My.Resources.StairsBlock, My.Resources.StairsBlock)

        Blocks.createBlocks(7439, 408, "none", "0", My.Resources.StairsBlock, My.Resources.StairsBlock)
        Blocks.createBlocks(7487, 454, "none", "0", My.Resources.StairsBlock, My.Resources.StairsBlock)
        Blocks.createBlocks(7535, 502, "none", "0", My.Resources.StairsBlock, My.Resources.StairsBlock)
        Blocks.createBlocks(7583, 550, "none", "0", My.Resources.StairsBlock, My.Resources.StairsBlock)

        Pipes.createPipes(7823, 505, 1, My.Resources.PiranaPlant, True)

        Blocks.createBlocks(8063, 408, "none", "1", My.Resources.BrickBlockBrown, My.Resources.BrickBlockBrown)
        Blocks.createBlocks(8111, 408, "none", "1", My.Resources.BrickBlockBrown, My.Resources.BrickBlockBrown)
        Blocks.createBlocks(8159, 408, "coin", "1", My.Resources.QuestionBlock, My.Resources.EmptyBlock)
        Blocks.createBlocks(8207, 408, "none", "1", My.Resources.BrickBlockBrown, My.Resources.BrickBlockBrown)

        Pipes.createPipes(8591, 505, 1, My.Resources.PiranaPlant, True)


        Blocks.createBlocks(8687, 550, "none", "0", My.Resources.StairsBlock, My.Resources.StairsBlock)
        Blocks.createBlocks(8735, 502, "none", "0", My.Resources.StairsBlock, My.Resources.StairsBlock)
        Blocks.createBlocks(8783, 454, "none", "0", My.Resources.StairsBlock, My.Resources.StairsBlock)
        Blocks.createBlocks(8831, 408, "none", "0", My.Resources.StairsBlock, My.Resources.StairsBlock)

        Blocks.createBlocks(8879, 360, "none", "0", My.Resources.StairsBlock, My.Resources.StairsBlock)
        Blocks.createBlocks(8927, 312, "none", "0", My.Resources.StairsBlock, My.Resources.StairsBlock)
        Blocks.createBlocks(8975, 264, "none", "0", My.Resources.StairsBlock, My.Resources.StairsBlock)
        Blocks.createBlocks(9023, 216, "none", "0", My.Resources.StairsBlock, My.Resources.StairsBlock)

        Blocks.createBlocks(9071, 216, "none", "0", My.Resources.StairsBlock, My.Resources.StairsBlock)

        Blocks.createBlocks(9503, 550, "none", "0", My.Resources.StairsBlock, My.Resources.StairsBlock)
        Blocks.createBlocks(9839, 550, "invis", "0", My.Resources.StairsBlock, My.Resources.StairsBlock)


        Ai.createAI("goomba", "move-gravity-fireball-direction-top_death", My.Resources.LittleGoomba)
        Ai.createAI("superstar", "move-gravity-direction", My.Resources.Starman)
        Ai.createAI("powerup", "move-direction-gravity-power_up", My.Resources.MagicMushroom)
        Ai.createAI("coin", "coin-remove_limits", My.Resources.CoinForBlueBG)

        Entity.summonEntity("goomba", 1500, 100, 5, "none")
        Entity.summonEntity("goomba", 2500, 100, 5, "none")
        ' - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -



    End Sub



    Sub placeElements()
        ' - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        'Place blocks on FORM from Blocks API
        For Each index In Blocks.blocks
            Dim uuids As String = UUID.GenerateGUID()
            Dim element As PictureBox 'This will be the block
            element = New PictureBox

            Dim lefts As PictureBox 'The block left collision
            lefts = New PictureBox

            Dim rights As PictureBox 'The block right  collision
            rights = New PictureBox



            'Add all elements/object to LISTS
            blocky.Add(element)
            blockyr.Add(rights)
            blockyl.Add(lefts)

            'Format the block and location
            blocky.Item(blocky.IndexOf(element)).Location = New Point((levelx + getBlockX(blocky.IndexOf(element))), (levely + getBlockY(blocky.IndexOf(element))))
            blocky.Item(blocky.IndexOf(element)).Image = getMainImage(blocky.IndexOf(element))

            blocky.Item(blocky.IndexOf(element)).Name = uuids

            blocky.Item(blocky.IndexOf(element)).SizeMode = PictureBoxSizeMode.AutoSize
            If sizes <> 1 Then
                blocky.Item(blocky.IndexOf(element)).SizeMode = PictureBoxSizeMode.StretchImage
                blocky.Item(blocky.IndexOf(element)).Width = 16 * sizes
                blocky.Item(blocky.IndexOf(element)).Height = 16 * sizes
            End If


            'Format the blocks right bar and location
            blockyr.Item(blockyr.IndexOf(rights)).Location = New Point((levelx + getBlockX(blocky.IndexOf(element)) + blocky.Item(blocky.IndexOf(element)).Size.Width), (levely + getBlockY(blocky.IndexOf(element)) + (blocky.Item(blocky.IndexOf(element)).Size.Height - blocky.Item(blocky.IndexOf(element)).Size.Height / 2)))
            blockyr.Item(blockyr.IndexOf(rights)).Width = 1
            blockyr.Item(blockyr.IndexOf(rights)).Height = blocky.Item(blocky.IndexOf(element)).Size.Height / 2
            blockyr.Item(blockyr.IndexOf(rights)).Visible = False

            'Format the blocks left bar and location
            blockyl.Item(blockyl.IndexOf(lefts)).Location = New Point((levelx + getBlockX(blocky.IndexOf(element))), (levely + getBlockY(blocky.IndexOf(element)) + (blocky.Item(blocky.IndexOf(element)).Size.Height - blocky.Item(blocky.IndexOf(element)).Size.Height / 2)))
            blockyl.Item(blockyl.IndexOf(lefts)).Width = 1
            blockyl.Item(blockyl.IndexOf(lefts)).Height = blocky.Item(blocky.IndexOf(element)).Size.Height / 2
            blockyl.Item(blockyl.IndexOf(lefts)).Visible = False


            'Place them all on from
            If Blocks.getGive(blocky.IndexOf(element)) <> "invis" Then
                Me.Controls.Add(blocky.Item(blocky.IndexOf(element)))
            End If


            If view_bounds = True Then
                Me.Controls.Add(blockyr.Item(blockyr.IndexOf(rights)))
                Me.Controls.Add(blockyl.Item(blockyl.IndexOf(lefts)))
            End If


            'Fix placement on screen (Like Z-Index sort of)
            blockyr.Item(blockyr.IndexOf(rights)).BringToFront()
            blockyl.Item(blockyl.IndexOf(lefts)).BringToFront()
            blocky.Item(blocky.IndexOf(element)).BringToFront()

            If Blocks.getGive(blocky.IndexOf(element)) <> "none" Then
                Entity.summonEntity(Blocks.getGive(blocky.IndexOf(element)), Blocks.getBlockX(blocky.IndexOf(element)), Blocks.getBlockY(blocky.IndexOf(element)), -1, uuids)
            End If


            'Add to the block limit
            blocky_limit = blocky_limit + 1

        Next

        For Each index In Pipes.pipes

            Dim element As PictureBox 'This will be the pipe
            element = New PictureBox

            Dim piranha As PictureBox 'This will be the pipe
            piranha = New PictureBox

            Dim lefts As PictureBox 'The pipe left collision
            lefts = New PictureBox

            Dim rights As PictureBox 'The pipe right  collision
            rights = New PictureBox


            'Add all elements/object to LISTS
            pipey.Add(element)
            pipeyr.Add(rights)
            pipeyl.Add(lefts)
            pipeyp.Add(piranha)



            'Format the block and location
            Dim image As Bitmap
            If Pipes.getSize(pipey.IndexOf(element)) = 1 Then
                image = My.Resources.pipe_small
            ElseIf Pipes.getSize(pipey.IndexOf(element)) = 2 Then
                image = My.Resources.pipe_med
            Else
                image = My.Resources.pipe_large
            End If


            'Set the pipe location and settings

            pipey.Item(pipey.IndexOf(element)).Location = New Point((levelx + Pipes.getPipeX(pipey.IndexOf(element))), (levely + Pipes.getPipeY(pipey.IndexOf(element))))
            pipey.Item(pipey.IndexOf(element)).Image = image
            pipey.Item(pipey.IndexOf(element)).SizeMode = PictureBoxSizeMode.AutoSize
            If sizes <> 1 Then 'Size*
                pipey.Item(pipey.IndexOf(element)).SizeMode = PictureBoxSizeMode.StretchImage
                pipey.Item(pipey.IndexOf(element)).Height = pipey.Item(pipey.IndexOf(element)).Size.Height * sizes
                pipey.Item(pipey.IndexOf(element)).Width = pipey.Item(pipey.IndexOf(element)).Size.Width * sizes
            End If


            'Format the blocks right bar and location
            pipeyr.Item(pipeyr.IndexOf(rights)).Location = New Point((levelx + Pipes.getPipeX(pipey.IndexOf(element)) + pipey.Item(pipey.IndexOf(element)).Size.Width + 2), (levely + Pipes.getPipeY(pipey.IndexOf(element)) + 5))
            pipeyr.Item(pipeyr.IndexOf(rights)).Width = 5
            pipeyr.Item(pipeyr.IndexOf(rights)).Height = (pipey.Item(pipey.IndexOf(element)).Size.Height - 5)
            pipeyr.Item(pipeyr.IndexOf(rights)).Visible = False

            'Format the blocks left bar and location
            pipeyl.Item(pipeyl.IndexOf(lefts)).Location = New Point((levelx + Pipes.getPipeX(pipey.IndexOf(element))) - 2, (levely + Pipes.getPipeY(pipey.IndexOf(element)) + 5))
            pipeyl.Item(pipeyl.IndexOf(lefts)).Width = 5
            pipeyl.Item(pipeyl.IndexOf(lefts)).Height = (pipey.Item(pipey.IndexOf(element)).Size.Height - 5)
            pipeyl.Item(pipeyl.IndexOf(lefts)).Visible = False

            'Place them all on from
            Me.Controls.Add(pipey.Item(pipey.IndexOf(element)))

            If view_bounds = True Then
                Me.Controls.Add(pipeyr.Item(pipeyr.IndexOf(rights)))
                Me.Controls.Add(pipeyl.Item(pipeyl.IndexOf(lefts)))
                pipeyr.Item(pipeyr.IndexOf(rights)).Visible = True
                pipeyl.Item(pipeyl.IndexOf(lefts)).Visible = True
            End If


            'Check if THIS pipe has a pirhana plant
            If Pipes.usePiranha(pipey.IndexOf(element)) Then
                'If its has the pirhana plant enabled, do:
                pipeyp.Item(pipeyp.IndexOf(piranha)).Image = Pipes.getImage(pipey.IndexOf(element))
                pipeyp.Item(pipeyp.IndexOf(piranha)).SizeMode = PictureBoxSizeMode.AutoSize
                pipeyp.Item(pipeyp.IndexOf(piranha)).Location = New Point((levelx + Pipes.getPipeX(pipey.IndexOf(element))) + (pipey.Item(pipey.IndexOf(element)).Size.Width / 2) - (pipeyp.Item(pipeyp.IndexOf(piranha)).Size.Width / 2), (levely + Pipes.getPipeY(pipey.IndexOf(element)) + 1))
                If sizes <> 1 Then 'Size*
                    pipeyp.Item(pipeyp.IndexOf(piranha)).SizeMode = PictureBoxSizeMode.StretchImage
                    pipeyp.Item(pipeyp.IndexOf(piranha)).Height = pipeyp.Item(pipeyp.IndexOf(piranha)).Size.Height * sizes
                    pipeyp.Item(pipeyp.IndexOf(piranha)).Width = pipeyp.Item(pipeyp.IndexOf(piranha)).Size.Width * sizes
                End If

                Me.Controls.Add(pipeyp.Item(pipeyp.IndexOf(piranha)))
                pipeyp_state.Add(0)
            Else
                'If no pirhana plant then don't show one  but still add it (its for id conflicts, still needs to be in list) :(
                pipeyp.Item(pipeyp.IndexOf(piranha)).Location = New Point((levelx + Pipes.getPipeX(pipey.IndexOf(element))) + (pipey.Item(pipey.IndexOf(element)).Size.Width / 2), (levely + Pipes.getPipeY(pipey.IndexOf(element)) + 5))
                pipeyp.Item(pipeyp.IndexOf(piranha)).Width = 1
                pipeyp.Item(pipeyp.IndexOf(piranha)).Height = 1
                pipeyp.Item(pipeyp.IndexOf(piranha)).Visible = False
                pipeyp_state.Add(-1)
            End If

            'Add the wait time at start
            pipeyp_wait.Add(100)

            'Get location of pirhana plant
            Dim piranhaLoc As Point
            piranhaLoc = piranha.Location
            pipeyp_y.Add(piranhaLoc.Y)
            pipeyp_i.Add(0)

            'Fix placement on screen (Like Z-Index sort of)
            pipeyp.Item(pipeyp.IndexOf(piranha)).BringToFront()
            pipey.Item(pipey.IndexOf(element)).BringToFront()
            pipeyr.Item(pipeyr.IndexOf(rights)).BringToFront()
            pipeyl.Item(pipeyl.IndexOf(lefts)).BringToFront()
        Next



        For Each index In Entity.entity_
            Dim element As PictureBox
            element = New PictureBox
            entities.Add(element)
            Me.Controls.Add(element)
            entities.Item(entities.IndexOf(element)).SizeMode = PictureBoxSizeMode.AutoSize
            entities.Item(entities.IndexOf(element)).Image = Ai.getImage(Entity.getAI(entities.IndexOf(element)))
            entities.Item(entities.IndexOf(element)).SizeMode = PictureBoxSizeMode.StretchImage
            entities.Item(entities.IndexOf(element)).Width = entities.Item(entities.IndexOf(element)).Size.Width * sizes
            entities.Item(entities.IndexOf(element)).Height = entities.Item(entities.IndexOf(element)).Size.Height * sizes

            entities.Item(entities.IndexOf(element)).Location = Entity.getLoc(entities.IndexOf(element))
            entities.Item(entities.IndexOf(element)).Location = New Point(entities.Item(entities.IndexOf(element)).Location.X, entities.Item(entities.IndexOf(element)).Location.Y - entities.Item(entities.IndexOf(element)).Size.Height)

            entities.Item(entities.IndexOf(element)).Visible = False


            entities_d.Add(entities.IndexOf(element))
            entities_d.Item(entities.IndexOf(element)) = True

            entities_g.Add(entities.IndexOf(element))
            entities_g.Item(entities.IndexOf(element)) = Entity.getGravity((entities.IndexOf(element)))

            entites_t.Add(entities.IndexOf(element))
            entites_t.Item(entities.IndexOf(element)) = 0

            entites_x.Add(entities.IndexOf(element))
            entites_x.Item(entities.IndexOf(element)) = entities.Item(entities.IndexOf(element)).Location.X

            entites_y.Add(entities.IndexOf(element))
            entites_y.Item(entities.IndexOf(element)) = entities.Item(entities.IndexOf(element)).Location.Y

        Next
        'Enabled Random Timer (made for random entities, like Pirhana's out of pipes (1,3.45)
        TimerRandom.Enabled = True
        'Movement of Pirhana's in Pipes
        TimerPipe.Enabled = True

        'Timer Entity for all entity needs!
        TimerEntity.Enabled = True
        TimerTime.Enabled = True



        'Width of cover, basically the middle should be the same hopefully on everyscreen?
        cover_width = 200

        'Place Left Cover
        pbLeft.Location = New Point(0, levely)
        pbLeft.Width = cover_width
        pbLeft.Height = Scrolling.Height
        pbLeft.BringToFront()

        'Place Right Cover
        pbRight.Location = New Point(Me.Width - cover_width, levely)
        pbRight.Width = cover_width
        pbRight.Height = Scrolling.Height
        pbRight.BringToFront()


        'Set mario, map and textboxes
        pbMario.Visible = True
        Scrolling.Visible = True
        lblJumpStatus.Visible = True

        fireballX = pbMario.Location.X + (pbMario.Size.Width / 2)
        fireballY = pbMario.Location.Y - (pbMario.Size.Height / 2) + ((pbMario.Size.Height / 2))
        pbFireball.Location = New Point(pbMario.Location.Y, pbMario.Location.Y)
        pbFireball.BringToFront()
        pbFireball.Visible = False

        lblCoins.Visible = True
        lblPoints.Visible = True
        lblTime.Visible = True
        lblWorld.Visible = True
        pbCoin.Visible = True

        pbCoin.SizeMode = PictureBoxSizeMode.AutoSize
        pbCoin.Width = pbCoin.Size.Width * sizes
        pbCoin.Height = pbCoin.Size.Height * sizes
        pbCoin.SizeMode = PictureBoxSizeMode.StretchImage

        flag.Visible = True
        pole.Location = New Point(scrollx + 9503 + 8, scrolly + 117)
        flag.Location = New Point(pole.Location.X - (flag.Size.Width) + 20, pole.Location.Y + 9)

        pbFireworks1.Visible = False
        pbFireworks2.Visible = False
        pbFireworks3.Visible = False
        pbFireworks4.Visible = False

        lblPoints.Location = New Point(500 - 10, levely - lblPoints.Height)

        pbCoin.Location = New Point(500 + lblPoints.Width + pbCoin.Width + 200, levely - pbCoin.Height)
        lblCoins.Location = New Point(500 + lblPoints.Width + pbCoin.Width + (lblCoins.Width / 2) + 200, levely - pbCoin.Height)

        lblWorld.Location = New Point(500 + lblPoints.Width + pbCoin.Width + lblCoins.Width + lblWorld.Width + 300, levely - lblWorld.Height)

        lblTime.Location = New Point(500 + lblPoints.Width + pbCoin.Width + lblCoins.Width + lblWorld.Width + lblTime.Width + 600, levely - lblTime.Height)

        TimerTimer.Enabled = True
        no_keys = False
    End Sub




    'When the keys are pressed
    Private Sub KeyUps(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If no_keys = False Then
            'Move Right
            If started = True And paused = False Then
                If e.KeyValue = Keys.D Then
                    move_left = False
                    If move_right = False Then
                        moving_right = True
                        TimerRight.Enabled = True
                        move_right = True
                        move_last = "r"
                    End If


                End If
                'Move Left
                If e.KeyValue = Keys.A Then
                    move_right = False
                    If move_left = False Then
                        moving_left = True
                        TimerLeft.Enabled = True
                        move_left = True
                        move_last = "l"
                    End If
                End If
                If e.KeyValue = Keys.Space Then
                    If mario_state = 2 Then
                        fireball = True
                    End If
                End If
                If e.KeyValue = Keys.Escape Then
                    'pauseMenu()
                End If

                If e.KeyValue = Keys.Q Then
                    If mute = False Then
                        mute = True
                        Sounds.setState(True)
                    Else
                        mute = False
                        Sounds.setState(False)
                    End If
                End If
                'Jump
                If e.KeyValue = Keys.W Then
                    jump = True
                    move_right = False
                    move_left = False
                End If
                'Run
                If e.KeyValue = Keys.LShiftKey Then
                    speed = 10
                End If
                'PowerUp (grow)
                If e.KeyValue = Keys.C Then
                    powerUp()
                End If
            Else
                If started = False And paused = False Then
                    If e.KeyValue = Keys.W Then
                        menuUp()
                    End If
                    If e.KeyValue = Keys.S Then
                        menuDown()
                    End If
                    If e.KeyValue = Keys.Space Then
                        If selecting = True Then
                            menuSelect()
                        Else
                            If dialogDone = True Then
                                selecting = True
                                closeDialog()
                            End If
                            If dialogRunning <> True Then
                                If gameover = True Then
                                    menus()
                                    gameover = False
                                    pbGameover.Visible = False
                                End If
                            End If
                        End If
                    End If
                Else

                End If
            End If
            'Exit!
            If e.KeyValue = Keys.End Then
                Me.Close()
            End If
        End If
      

    End Sub
    Private Sub KeyDowns(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If no_keys = False Then
            If e.KeyValue = Keys.D Then
                Dim cont As Boolean = True
                For Each element In blockyr
                    If pbMario.Bounds.IntersectsWith(element.Bounds) Then
                        cont = False
                    End If
                Next
                If cont = True Then
                    move_right = False
                End If
                TimerRight.Enabled = False
                moving_right = False
                timer_right = False
                jumpUpdate()
            End If
            If e.KeyValue = Keys.A Then
                Dim cont As Boolean = True
                For Each element In blockyl
                    If pbMario.Bounds.IntersectsWith(element.Bounds) Then
                        cont = False
                    End If
                Next
                If cont = True Then
                    move_left = False
                End If
                TimerLeft.Enabled = False
                moving_left = False
                timer_left = False
                jumpUpdate()
            End If
            If e.KeyValue = Keys.RShiftKey Then
                speed = 7
            End If
        End If

    End Sub


    'MOVE LEFT
    Private Sub MoveLeft(sender As Object, e As EventArgs) Handles TimerLeft.Tick
        Dim moving = True
        For Each element In blockyr
            If pbMario.Bounds.IntersectsWith(element.Bounds) Then
                If Blocks.getGive(blockyr.IndexOf(element)) = "invis" Then
                    moving = True
                Else
                    moving = False
                End If
            End If
        Next
        For Each element In pipeyr
            If pbMario.Bounds.IntersectsWith(element.Bounds) Then          
                moving = False
            End If
        Next

        If moving = True Then
            scrollx = scrollx + speed
            For Each item In blocky
                If blocky.IndexOf(item) <> bumped Then
                    item.Location = New Point((scrollx + Blocks.getBlockX(blocky.IndexOf(item))), (scrolly + Blocks.getBlockY(blocky.IndexOf(item))))
                    blockyr.Item(blocky.IndexOf(item)).Location = New Point((scrollx + Blocks.getBlockX(blocky.IndexOf(item)) + blocky.Item(blocky.IndexOf(item)).Size.Width + 2), (scrolly + Blocks.getBlockY(blocky.IndexOf(item)) + (blocky.Item(blocky.IndexOf(item)).Size.Height - blocky.Item(blocky.IndexOf(item)).Size.Height / 2)))
                    blockyl.Item(blocky.IndexOf(item)).Location = New Point((scrollx + Blocks.getBlockX(blocky.IndexOf(item))) - 3, (scrolly + Blocks.getBlockY(blocky.IndexOf(item)) + (blocky.Item(blocky.IndexOf(item)).Size.Height - blocky.Item(blocky.IndexOf(item)).Size.Height / 2)))
                End If
            Next
            For Each item In pipey
                pipey.Item(pipey.IndexOf(item)).Location = New Point((scrollx + Pipes.getPipeX(pipey.IndexOf(item))), (scrolly + Pipes.getPipeY(pipey.IndexOf(item))))
                pipeyr.Item(pipey.IndexOf(item)).Location = New Point((scrollx + Pipes.getPipeX(pipey.IndexOf(item)) + pipey.Item(pipey.IndexOf(item)).Size.Width + 3), (scrolly + Pipes.getPipeY(pipey.IndexOf(item)) + 5))
                pipeyl.Item(pipey.IndexOf(item)).Location = New Point((scrollx + Pipes.getPipeX(pipey.IndexOf(item))) - 7, (scrolly + Pipes.getPipeY(pipey.IndexOf(item)) + 5))
            Next
            For Each item In pipeyp
                If pipeyp_state.Item(pipeyp.IndexOf(item)) = 0 Then
                    pipeyp.Item(pipeyp.IndexOf(item)).Location = New Point((scrollx + Pipes.getPipeX(pipeyp.IndexOf(item))) + (pipey.Item(pipeyp.IndexOf(item)).Size.Width / 2) - (pipeyp.Item(pipeyp.IndexOf(item)).Size.Width / 2), (scrolly + Pipes.getPipeY(pipeyp.IndexOf(item)) + 5))
                End If
            Next
            Scrolling.Location = New Point(scrollx, scrolly)
            floors.Location = New Point(scrollx, levely + levelc)
            pole.Location = New Point(scrollx + 9503 + 8, scrolly + 117)
            flag.Location = New Point(pole.Location.X - (flag.Size.Width) + 20, pole.Location.Y + 9)
        Else
            TimerLeft.Enabled = False
            move_left = True
        End If
    End Sub
    'MOVE RIGHT TIMER
    Private Sub MoveRight(sender As Object, e As EventArgs) Handles TimerRight.Tick
        Dim moving = True


        For Each element In blockyl
            If pbMario.Bounds.IntersectsWith(element.Bounds) Then
                If Blocks.getGive(blockyl.IndexOf(element)) = "invis" Then
                    moving = True
                Else
                    moving = False
                End If
            End If
        Next
        For Each element In pipeyl
            If pbMario.Bounds.IntersectsWith(element.Bounds) Then
                moving = False
            End If
        Next
        If moving = True Then
            scrollx = scrollx - speed
            For Each item In blocky
                If blocky.IndexOf(item) <> bumped Then
                    item.Location = New Point((scrollx + Blocks.getBlockX(blocky.IndexOf(item))), (scrolly + Blocks.getBlockY(blocky.IndexOf(item))))
                    blockyr.Item(blocky.IndexOf(item)).Location = New Point((scrollx + Blocks.getBlockX(blocky.IndexOf(item)) + blocky.Item(blocky.IndexOf(item)).Size.Width + 2), (scrolly + Blocks.getBlockY(blocky.IndexOf(item)) + (blocky.Item(blocky.IndexOf(item)).Size.Height - blocky.Item(blocky.IndexOf(item)).Size.Height / 2)))
                    blockyl.Item(blocky.IndexOf(item)).Location = New Point((scrollx + Blocks.getBlockX(blocky.IndexOf(item))) - 3, (scrolly + Blocks.getBlockY(blocky.IndexOf(item)) + (blocky.Item(blocky.IndexOf(item)).Size.Height - blocky.Item(blocky.IndexOf(item)).Size.Height / 2)))

                End If
            Next
            For Each item In pipey
                pipey.Item(pipey.IndexOf(item)).Location = New Point((scrollx + Pipes.getPipeX(pipey.IndexOf(item))), (scrolly + Pipes.getPipeY(pipey.IndexOf(item))))
                pipeyr.Item(pipey.IndexOf(item)).Location = New Point((scrollx + Pipes.getPipeX(pipey.IndexOf(item)) + pipey.Item(pipey.IndexOf(item)).Size.Width + 3), (scrolly + Pipes.getPipeY(pipey.IndexOf(item)) + 5))
                pipeyl.Item(pipey.IndexOf(item)).Location = New Point((scrollx + Pipes.getPipeX(pipey.IndexOf(item))) - 7, (scrolly + Pipes.getPipeY(pipey.IndexOf(item)) + 5))
            Next
            For Each item In pipeyp
                If pipeyp_state.Item(pipeyp.IndexOf(item)) = 0 Then
                    pipeyp.Item(pipeyp.IndexOf(item)).Location = New Point((scrollx + Pipes.getPipeX(pipeyp.IndexOf(item))) + (pipey.Item(pipeyp.IndexOf(item)).Size.Width / 2) - (pipeyp.Item(pipeyp.IndexOf(item)).Size.Width / 2), (scrolly + Pipes.getPipeY(pipeyp.IndexOf(item)) + 5))
                End If
            Next
            Scrolling.Location = New Point(scrollx, scrolly)
            floors.Location = New Point(scrollx, levely + levelc)
            pole.Location = New Point(scrollx + 9503 + 8, scrolly + 117)
            flag.Location = New Point(pole.Location.X - (flag.Size.Width) + 20, pole.Location.Y + 9)
        Else
            TimerRight.Enabled = False
            move_right = True
        End If

    End Sub

    '       _                           _               
    '      | |                         (_)              
    '      | | _   _  _ __ ___   _ __   _  _ __    __ _ 
    '  _   | || | | || '_ ` _ \ | '_ \ | || '_ \  / _` |
    ' | |__| || |_| || | | | | || |_) || || | | || (_| |
    '  \____/  \__,_||_| |_| |_|| .__/ |_||_| |_| \__, |
    '                          | |                __/ |
    '                          |_|               |___/ 
    '___________________________________________________
    '*Allows for player to jump (vines not included)
    Private Sub Jump_Tick(sender As Object, e As EventArgs) Handles TimerJump.Tick

        Dim mariox As Integer
        Dim touched As Integer = False
        Dim top As Boolean = False

        mariox = centerx
        marioy = marioy + gravity
        pbMario.Location = New Point(mariox, marioy)

        gravity = gravity + 5
        If gravity < 0 Then
            lblJumpStatus.Text = "JUMPING!"
        Else
            lblJumpStatus.Text = "FALLING!"
            move_right = False
            move_left = False
        End If
        Dim loc As Point
        loc = pbMario.Location

        Dim floor As Point
        floor = floors.Location
        Dim h_mario As Integer




        If pbMario.Bounds.IntersectsWith(floors.Bounds) Then
            If touched = False Then
                touched = True

                lblJumpStatus.Text = "ON FLOOR!"
                If mario_state = 0 Then
                    h_mario = 15 * sizes
                ElseIf mario_state = 1 Then
                    h_mario = 31 * sizes
                ElseIf mario_state = 2 Then
                    h_mario = 31 * sizes

                End If
                marioy = floor.Y - h_mario
                gravity = 0
                jumping = False
            End If
        End If

        For Each pipe In pipey
            If pbMario.Bounds.IntersectsWith(pipey.Item(pipey.IndexOf(pipe)).Bounds) Then
                If touched = False Then
                    touched = True
                    If mario_state = 0 Then
                        h_mario = 15 * sizes
                    ElseIf mario_state = 1 Then
                        h_mario = 31 * sizes
                    ElseIf mario_state = 2 Then
                        h_mario = 31 * sizes

                    End If
                    marioy = levely + Pipes.getPipeY(pipey.IndexOf(pipe)) - h_mario
                    gravity = 0
                    jumping = False
                End If
            End If
        Next
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim touches As String = " "
        Dim hit(100) As Integer
        For i = 0 To hit.Length - 1
            hit(i) = 10000
        Next i

        Dim go As Integer = False
        For x = blocky.Count - 1 To 0 Step -1
            Dim element = blocky.Item(x)
            Dim index As Integer = x
            If Blocks.getGive(x) <> "invis" Then
                If pbMario.Bounds.IntersectsWith(blocky(index).Bounds) Then


                    Dim locs As Point
                    Dim break As Boolean = False
                    locs = element.Location
                    touches = touches & vbCrLf & "ID: " & index & ", Y: " & locs.Y
                    If touched = False Then
                        touched = True
                        If gravity < 0 Then

                            lblJumpStatus.Text = "HIT BOTTOM!"
                            For i = 0 To hit.Length - 1
                                hit(i) = 10000
                            Next i
                            pbMario.Location = New Point(mariox, marioy)
                            If mario_state = 0 Then
                                If Blocks.getLimits(index) = 0 Then
                                    'give item or what ever
                                    blocky(index).Image = Blocks.getDoneImage(index)
                                    Blocks.setLimits(index, -1)
                                Else
                                    If Blocks.getLimits(index) <> 0 And Blocks.getLimits(index) <> -1 Then
                                        If Blocks.getGive(index) <> "none" Then
                                            For Each enti In entities
                                                If Entity.getBlock(entities.IndexOf(enti)) = element.Name Then
                                                    Entity.setEnabled(entities.IndexOf(enti))
                                                    Blocks.setLimits(index, Blocks.getLimits(index) - 1)
                                                End If
                                            Next
                                        Else
                                            bumped = index
                                            Sounds.Play("player-bump")
                                            TimerBumpBlock.Enabled = True
                                        End If

                                    End If
                                End If
                            ElseIf mario_state = 1 Or mario_state = 2 Then
                                If Blocks.getLimits(index) <> 0 And Blocks.getLimits(index) <> -1 Then
                                    If Blocks.getGive(index) <> "none" Then
                                        For Each enti In entities
                                            If Entity.getBlock(entities.IndexOf(enti)) = element.Name Then
                                                Entity.setEnabled(entities.IndexOf(enti))
                                                entities_d.Item(entities.IndexOf(enti)) = False
                                                Blocks.setLimits(index, Blocks.getLimits(index) - 1)
                                            End If
                                        Next
                                    Else
                                        Me.Controls.Remove(blocky(index))  ' Add Button to the container.
                                        Me.Controls.Remove(blockyr(index))
                                        Me.Controls.Remove(blockyl(index))
                                        blocky.RemoveAt(index)
                                        blockyr.RemoveAt(index)
                                        blockyl.RemoveAt(index)
                                        setRemoved(index)
                                        Sounds.Play("player-break_block")
                                        addPoints(5)
                                        break = True
                                    End If

                                Else
                                    If Blocks.getLimits(index) = 0 Then
                                        'give item or what ever
                                        blocky(index).Image = Blocks.getDoneImage(index)
                                        Blocks.setLimits(index, -1)
                                    End If
                                End If

                            End If
                            touched = True
                            If break = False Then
                                top = True
                                gravity = 0
                                marioy = levely + Blocks.getBlockY(index) + (16 * sizes) + 5
                            End If
                            Exit For
                        Else
                            lblJumpStatus.Text = "ON BLOCK!"
                            gravity = 0
                            jumping = False
                        End If
                    End If
                    hit(index) = locs.Y
                Else
                    go = True
                End If
            End If
        Next
        If top = True Then
            go = False
        End If


        If go = True Then

            Dim lowest As Integer = hit.Min
            Dim block As Integer
            Dim goes As Boolean = False
            For i = 0 To hit.Length - 1
                If lowest = hit(i) Then
                    If lowest <> 10000 Then
                        block = i
                        goes = True
                    End If
                End If
            Next

            If mario_state = 0 Then
                h_mario = 15 * sizes
            ElseIf mario_state = 1 Then
                h_mario = 31 * sizes
            ElseIf mario_state = 2 Then
                h_mario = 31 * sizes

            End If
            If goes = True Then
                marioy = levely + getBlockY(block) - h_mario
            End If

        End If


        'touches = touches & vbCrLf & "P:" & marioLoc.X & ":" & marioLoc.Y


        If (jump = True And gravity = 0 And jumping = False) Then
            lblJumpStatus.Text = "JUMPING!"
            gravity = -50
            jumping = True
            jump = False
            touched = False
            If mario_state = 0 Then
                Sounds.Play("player-jump-s")
                If move_last = "l" Then
                    pbMario.Image = My.Resources.MarioJumpingLeft
                Else
                    pbMario.Image = My.Resources.MarioJumping
                End If
            ElseIf mario_state = 1 Then
                Sounds.Play("player-jump-l")
                If move_last = "l" Then
                    pbMario.Image = My.Resources.SuperMarioJumpingLeft
                Else
                    pbMario.Image = My.Resources.SuperMarioJumping
                End If
            ElseIf mario_state = 2 Then
                Sounds.Play("player-jump-l")
                If move_last = "l" Then
                    pbMario.Image = My.Resources.FieryMarioJumpingLeft
                Else
                    pbMario.Image = My.Resources.FieryMarioJumping
                End If
            End If

        End If
    End Sub


    Sub powerUp()
        If mario_state = 0 Then
            Sounds.Play("player-powerup")
            mario_state = 1
            pbMario.Width = 12
            pbMario.Height = 32
            If sizes <> 1 Then
                pbMario.SizeMode = PictureBoxSizeMode.StretchImage
                pbMario.Width = pbMario.Size.Width * sizes
                pbMario.Height = pbMario.Size.Height * sizes
            End If
            If move_last = "l" Then
                pbMario.Image = My.Resources.SuperMarioLeft
            Else
                pbMario.Image = My.Resources.SuperMario
            End If

        ElseIf mario_state = 1 Then
            Sounds.Play("player-powerup")
            mario_state = 2
            pbMario.Width = 12
            pbMario.Height = 32
            If sizes <> 1 Then
                pbMario.SizeMode = PictureBoxSizeMode.StretchImage
                pbMario.Width = pbMario.Size.Width * sizes
                pbMario.Height = pbMario.Size.Height * sizes
            End If
            If move_last = "l" Then
                pbMario.Image = My.Resources.FieryMarioLeft
            Else
                pbMario.Image = My.Resources.FieryMario
            End If
        End If
    End Sub
    Sub powerDown()
        If mario_state = 1 Then
            Sounds.Play("player-powerup")
            mario_state = 0
            pbMario.Width = 12
            pbMario.Height = 32
            If sizes <> 1 Then
                pbMario.SizeMode = PictureBoxSizeMode.StretchImage
                pbMario.Width = pbMario.Size.Width * sizes
                pbMario.Height = pbMario.Size.Height * sizes
            End If
        ElseIf mario_state = 2 Then
            Sounds.Play("player-powerup")
            mario_state = 1
            pbMario.Width = 12
            pbMario.Height = 32
            If sizes <> 1 Then
                pbMario.SizeMode = PictureBoxSizeMode.StretchImage
                pbMario.Width = pbMario.Size.Width * sizes
                pbMario.Height = pbMario.Size.Height * sizes
            End If
        End If
    End Sub
    Sub coinUp()
        coins = coins + 1
        lblCoins.Text = "X " & coins
    End Sub


    Sub addPoints(ByVal pointy As Integer)
        points = points + pointy
        Dim lbl As String = ""
        If points <= 99999 Then
            lbl = lbl & "0"
        End If
        If points <= 9999 Then
            lbl = lbl & "0"
        End If
        If points <= 999 Then
            lbl = lbl & "0"
        End If
        If points <= 99 Then
            lbl = lbl & "0"
        End If
        If points <= 9 Then
            lbl = lbl & "0"
        End If
        lblPoints.Text = "POINTS" & vbCrLf & lbl & points
    End Sub






    Sub jumpUpdate()
        If move_left = False And move_right = False Then
            If mario_state = 0 Then
                If move_last = "l" Then
                    pbMario.Image = My.Resources.MarioStandingLeft
                Else
                    pbMario.Image = My.Resources.MarioStanding
                End If
            ElseIf mario_state = 1 Then
                If move_last = "l" Then
                    pbMario.Image = My.Resources.SuperMarioStandingLeft
                Else
                    pbMario.Image = My.Resources.SuperMarioStanding
                End If
            ElseIf mario_state = 2 Then
                If move_last = "l" Then
                    pbMario.Image = My.Resources.FieryMarioStandingLeft
                Else
                    pbMario.Image = My.Resources.FieryMarioStanding
                End If
            End If
        End If

    End Sub


    'Bumpy Blocks!
    Private Sub TimerBumpBlock_Tick(sender As Object, e As EventArgs) Handles TimerBumpBlock.Tick
        blocky.Item(bumped).BringToFront()
        If bumped_y < 4 Then
            bumped_y = bumped_y + 1
            Dim locs As Point
            locs = blocky.Item(bumped).Location
            blocky.Item(bumped).Location = New Point((scrollx + Blocks.getBlockX(blocky.IndexOf(blocky.Item(bumped)))), locs.Y + bumped_y)
            blockyr.Item(bumped).Location = New Point((scrollx + Blocks.getBlockX(blocky.IndexOf(blocky.Item(bumped))) + blocky.Item(blocky.IndexOf(blocky.Item(bumped))).Size.Width + 2), (locs.Y + (blocky.Item(blocky.IndexOf(blocky.Item(bumped))).Size.Height - blocky.Item(blocky.IndexOf(blocky.Item(bumped))).Size.Height / 2) + bumped_y))
            blockyl.Item(bumped).Location = New Point((scrollx + Blocks.getBlockX(blocky.IndexOf(blocky.Item(bumped)))) - 2, (locs.Y + (blocky.Item(blocky.IndexOf(blocky.Item(bumped))).Size.Height - blocky.Item(blocky.IndexOf(blocky.Item(bumped))).Size.Height / 2) + bumped_y))


        Else
            bumped_y = -5
            bumped = 1000
            TimerBumpBlock.Enabled = False
            pbLeft.BringToFront()
            pbRight.BringToFront()
            ' blocky.Item(bumped).Location = New Point((scrollx + Blocks.getBlockX(blocky.IndexOf(blocky.Item(bumped)))), (scrolly + Blocks.getBlockY(blocky.IndexOf(blocky.Item(bumped)))))
        End If


    End Sub



    'Timer move is different from EntityMove because it only is based on player objects, like Fireball and throwing objects
    Private Sub TimerMove_Tick(sender As Object, e As EventArgs) Handles TimerMove.Tick
        If fireball = True And fireball_active = False Then
            Sounds.Play("player-fireballd")
            fireball = False
            fireball_active = True
            fireballD = move_last
            fireballG = -20
            bounces = 0
            pbFireball.Visible = True
            pbFireball.Location = pbMario.Location
            pbFireball.BringToFront()
            Dim loc As Point
            loc = pbFireball.Location

            pbFireball.Location = New Point(loc.X + (pbMario.Size.Width / 2), loc.Y + (pbMario.Size.Height / 2))
        End If
        If fireball_active = True Then

            fireballG = fireballG + 5
            If fireballD = "l" Then
                pbFireball.Left -= 15
            Else
                pbFireball.Left += 15
            End If

            Dim loc As Point
            loc = pbFireball.Location

            pbFireball.Location = New Point(loc.X, loc.Y + fireballG)
            If bounces < 3 Then
                For Each block In blocky
                    If pbFireball.Bounds.IntersectsWith(block.Bounds) Then
                        bounces = bounces + 1
                        fireballG = -30
                    End If
                Next
                For Each pipes In pipey
                    If pbFireball.Bounds.IntersectsWith(pipes.Bounds) Then
                        bounces = bounces + 1
                        fireballG = -30
                    End If
                Next
                If pbFireball.Bounds.IntersectsWith(floors.Bounds) Then
                    bounces = bounces + 1
                    fireballG = -30
                End If
            Else
                fireball_active = False
                pbFireball.Visible = False
            End If
            For Each side In blockyr
                If pbFireball.Bounds.IntersectsWith(side.Bounds) Then
                    fireball_active = False
                    pbFireball.Visible = False
                    fireballG = 0
                End If
            Next
            For Each side In blockyl
                If pbFireball.Bounds.IntersectsWith(side.Bounds) Then
                    fireball_active = False
                    pbFireball.Visible = False
                    fireballG = 0
                End If
            Next
            For Each side In pipeyr
                If pbFireball.Bounds.IntersectsWith(side.Bounds) Then
                    fireball_active = False
                    pbFireball.Visible = False
                    fireballG = 0
                End If
            Next
            For Each side In pipeyl
                If pbFireball.Bounds.IntersectsWith(side.Bounds) Then
                    fireball_active = False
                    pbFireball.Visible = False
                    fireballG = 0
                End If
            Next
        End If

        If selecting = True Then
            If selected_direction = False Then
                If selected_sprite > 5 Then
                    selected_direction = True
                Else

                    pbSelector.Image = My.Resources.MagicMushroomSelector
                    selected_sprite = selected_sprite + 1
                End If
            Else
                If selected_sprite < 0 Then
                    selected_direction = False
                Else

                    selected_sprite = selected_sprite - 1
                    pbSelector.Image = My.Resources._1upMushroomSelector
                End If
            End If
        End If


        If moving_left = True And timer_left = False Then
            timer_left = True
            If mario_state = 0 And jumping = False Then
                pbMario.Image = My.Resources.MarioLeft
            ElseIf mario_state = 1 And jumping = False Then
                pbMario.Image = My.Resources.SuperMarioLeft
            ElseIf mario_state = 2 And jumping = False Then
                pbMario.Image = My.Resources.FieryMarioLeft
            End If
        End If
        If moving_right = True And timer_right = False Then
            timer_right = True
            If mario_state = 0 And jumping = False Then
                pbMario.Image = My.Resources.Mario
            ElseIf mario_state = 1 And jumping = False Then
                pbMario.Image = My.Resources.SuperMario
            ElseIf mario_state = 2 And jumping = False Then
                pbMario.Image = My.Resources.FieryMario
            End If
        End If
    End Sub

    Private Sub TimerEntity_Tick(sender As Object, e As EventArgs) Handles TimerEntity.Tick
        For x = entities.Count - 1 To 0 Step -1
            Dim element = entities.Item(x)
            element.BringToFront()
            Dim index As Integer = x
            If Entity.getState(entities.IndexOf(element)) = True Then
                Dim splits As String = Ai.getAI(Entity.getAI(entities.IndexOf(element)))
                Dim items As String() = splits.Split(New Char() {"-"c})
                entities.Item(x).Visible = True
                For Each item In items
                    entities.Item(entities.IndexOf(element)).Location = New Point(scrollx + entites_x.Item(entities.IndexOf(element)), scrolly + entites_y.Item(entities.IndexOf(element)))
                    If item = "move" Then
                        If entities_d(entities.IndexOf(element)) = False Then 'LEFT
                            entites_x.Item(entities.IndexOf(element)) = entites_x.Item(entities.IndexOf(element)) - 5
                        Else 'RIGHT
                            entites_x.Item(entities.IndexOf(element)) = entites_x.Item(entities.IndexOf(element)) + 5
                        End If

                    End If
                    If item = "direction" Then
                        Dim directional As Boolean = False
                        For Each blocks_ In blockyl
                            If element.Bounds.IntersectsWith(blocks_.Bounds) Then
                                directional = True
                            End If
                        Next
                        For Each pipes_ In pipeyl
                            If element.Bounds.IntersectsWith(pipes_.Bounds) Then
                                directional = True
                            End If
                        Next
                        For Each blocks_ In blockyr
                            If element.Bounds.IntersectsWith(blocks_.Bounds) Then
                                directional = True
                            End If
                        Next
                        For Each pipes_ In pipeyr
                            If element.Bounds.IntersectsWith(pipes_.Bounds) Then
                                directional = True
                            End If
                        Next


                        If directional = True Then
                            If entities_d(entities.IndexOf(element)) = False Then
                                entities_d(entities.IndexOf(element)) = True
                            Else
                                entities_d(entities.IndexOf(element)) = False
                            End If
                        End If
                    End If
                    If item = "gravity" Then
                        Dim floor As Point
                        Dim touch As Boolean = False
                        floor = floors.Location
                        entites_y.Item(entities.IndexOf(element)) = entites_y.Item(entities.IndexOf(element)) + entities_g.Item(entities.IndexOf(element))

                        entities.Item(entities.IndexOf(element)).Location = New Point(scrollx + entites_x.Item(entities.IndexOf(element)), scrolly + entites_y.Item(entities.IndexOf(element)))
                        entities_g.Item(entities.IndexOf(element)) = entities_g.Item(entities.IndexOf(element)) + 5

                        If element.Bounds.IntersectsWith(floors.Bounds) Then
                            entities_g.Item(entities.IndexOf(element)) = -1
                            touch = True
                        End If

                        For Each pipe In pipey
                            If touch = False Then
                                If element.Bounds.IntersectsWith(pipey.Item(pipey.IndexOf(pipe)).Bounds) Then
                                    entities_g.Item(entities.IndexOf(element)) = 0
                                    entites_y.Item(entities.IndexOf(element)) = Pipes.getPipeY(pipey.IndexOf(pipe)) - (element.Size.Height)


                                End If
                            End If
                        Next

                        For Each block In blocky
                            If touch = False Then
                                If element.Bounds.IntersectsWith(blocky.Item(blocky.IndexOf(block)).Bounds) Then
                                    entities_g.Item(entities.IndexOf(element)) = 0
                                    entites_y.Item(entities.IndexOf(element)) = Blocks.getBlockY(blocky.IndexOf(block)) - (element.Size.Height)
                                End If
                            End If
                        Next

                    End If
                    If item = "fireball" Then
                        If element.Bounds.IntersectsWith(pbFireball.Bounds) Then
                            addPoints(250)
                            Sounds.Play("player-stomp")
                            Entity.setDisabled(x)
                            entites_t.Item(x) = 2
                        End If
                    End If
                    If item = "power_up" Then
                        If element.Bounds.IntersectsWith(pbMario.Bounds) Then
                            powerUp()
                            addPoints(1000)
                            Me.Controls.Remove(element)
                            element.Enabled = False
                            Entity.setDisabled(x)
                            Exit For
                        Else
                            Dim limits As Integer
                            For z = blocky.Count - 1 To 0 Step -1
                                Dim element_ = blocky.Item(z)
                                Dim index_ = z

                                If element_.Name = Entity.getBlock(x) Then
                                    limits = Blocks.getLimits(z)
                                End If
                            Next

                            If limits = 0 Then
                                Sounds.Play("player-powerup-appears")
                                For z = blocky.Count - 1 To 0 Step -1
                                    Dim element_ = blocky.Item(z)
                                    Dim index_ = z

                                    If element_.Name = Entity.getBlock(x) Then
                                        element_.Image = Blocks.getDoneImage(z)
                                        Blocks.setLimits(z, -1)
                                    End If
                                Next
                            End If

                        End If
                    End If
                    If item = "coin" Then

                        coinUp()
                        addPoints(100)
                        Sounds.Play("player-coin")
                        Entity.setDisabled(x)
                        entites_t.Item(x) = 10
                        Dim coin_loc As Point = Entity.getLoc(x)
                        entites_x.Item(x) = coin_loc.X + 6

                    End If
                    If item = "top_death" Then
                        If pbMario.Bounds.IntersectsWith(element.Bounds) Then
                            If gravity = 0 And jump = False And jumping = False Then
                                mario_dead = True
                                started = False
                                removeFromScreen()
                                Sounds.Play("player-die")
                                Entity.setDisabled(x)
                                Exit For
                            Else
                                addPoints(250)
                                Sounds.Play("player-stomp")
                                Entity.setDisabled(x)
                                entites_t.Item(x) = 2
                            End If
                        End If
                    End If


                    If item = "remove_limits" Then
                        Dim limits As Integer
                        Dim strings As String = ""
                        For z = blocky.Count - 1 To 0 Step -1
                            Dim element_ = blocky.Item(z)
                            Dim index_ = z
                            strings = strings & vbCrLf & Blocks.getLimits(z)
                            If element_.Name = Entity.getBlock(x) Then
                                limits = Blocks.getLimits(z)
                            End If
                        Next
                        Entity.setDisabled(x)
                        If limits = 0 Then
                            For z = blocky.Count - 1 To 0 Step -1
                                Dim element_ = blocky.Item(z)
                                Dim index_ = z

                                If element_.Name = Entity.getBlock(x) Then
                                    element_.Image = Blocks.getDoneImage(z)
                                    Blocks.setLimits(z, -1)
                                End If
                            Next
                            element.Enabled = False

                            Exit For
                        End If
                    End If
                Next
            End If
        Next
    End Sub

    Private Sub TimerTime_Tick(sender As Object, e As EventArgs) Handles TimerTime.Tick

        For x = entities.Count - 1 To 0 Step -1
            Dim element = entities.Item(x)
            element.BringToFront()
            Dim index As Integer = x
            If entites_t.Item(entities.IndexOf(element)) > 0 Then
                entities.Item(entities.IndexOf(element)).Location = New Point(scrollx + entites_x.Item(entities.IndexOf(element)), scrolly + entites_y.Item(entities.IndexOf(element)))
                entites_t.Item(entities.IndexOf(element)) = entites_t.Item(entities.IndexOf(element)) - 1

            End If
            If entites_t.Item(entities.IndexOf(element)) = 0 Then
                entities.Item(entities.IndexOf(element)).Location = New Point(scrollx + entites_x.Item(entities.IndexOf(element)), scrolly + entites_y.Item(entities.IndexOf(element)))
                entites_t.Item(entities.IndexOf(element)) = -1
                element.Visible = False
            End If
        Next
    End Sub


    Private Sub TimerPipe_Tick(sender As Object, e As EventArgs) Handles TimerPipe.Tick
        Dim heights As Integer
        Dim location As Integer
        Dim piranhaLoc As Point
        For Each item In pipeyp
            If pipeyp_state.Item(pipeyp.IndexOf(item)) = 1 Then
                pipeyp_i.Item(pipeyp.IndexOf(item)) = pipeyp_i.Item(pipeyp.IndexOf(item)) + 1
                pipeyp.Item(pipeyp.IndexOf(item)).Location = New Point((scrollx + Pipes.getPipeX(pipeyp.IndexOf(item))) + (pipey.Item(pipeyp.IndexOf(item)).Size.Width / 2) - (pipeyp.Item(pipeyp.IndexOf(item)).Size.Width / 2), (scrolly + Pipes.getPipeY(pipeyp.IndexOf(item)) + 5 - pipeyp_i.Item(pipeyp.IndexOf(item))))
                heights = pipeyp.Item(pipeyp.IndexOf(item)).Size.Height
                location = pipeyp_y.Item(pipeyp.IndexOf(item)) 'Orignal Y Location
                piranhaLoc = pipeyp.Item(pipeyp.IndexOf(item)).Location 'Location Now
                If (location - heights) >= piranhaLoc.Y Then
                    Randomize()
                    pipeyp_state.Item(pipeyp.IndexOf(item)) = 2
                    pipeyp_wait.Item(pipeyp.IndexOf(item)) = (Rnd() * 100) + 100
                End If

            ElseIf pipeyp_state.Item(pipeyp.IndexOf(item)) = 2 Then
                pipeyp_wait.Item(pipeyp.IndexOf(item)) = pipeyp_wait.Item(pipeyp.IndexOf(item)) - 1
                pipeyp.Item(pipeyp.IndexOf(item)).Location = New Point((scrollx + Pipes.getPipeX(pipeyp.IndexOf(item))) + (pipey.Item(pipeyp.IndexOf(item)).Size.Width / 2) - (pipeyp.Item(pipeyp.IndexOf(item)).Size.Width / 2), (scrolly + Pipes.getPipeY(pipeyp.IndexOf(item)) + 5 - pipeyp_i.Item(pipeyp.IndexOf(item))))
                If pipeyp_wait.Item(pipeyp.IndexOf(item)) <= 0 Then
                    pipeyp_state.Item(pipeyp.IndexOf(item)) = 3
                End If

            ElseIf pipeyp_state.Item(pipeyp.IndexOf(item)) = 3 Then
                pipeyp_i.Item(pipeyp.IndexOf(item)) = pipeyp_i.Item(pipeyp.IndexOf(item)) - 1
                pipeyp.Item(pipeyp.IndexOf(item)).Location = New Point((scrollx + Pipes.getPipeX(pipeyp.IndexOf(item))) + (pipey.Item(pipeyp.IndexOf(item)).Size.Width / 2) - (pipeyp.Item(pipeyp.IndexOf(item)).Size.Width / 2), (scrolly + Pipes.getPipeY(pipeyp.IndexOf(item)) + 5 - pipeyp_i.Item(pipeyp.IndexOf(item))))
                heights = pipeyp.Item(pipeyp.IndexOf(item)).Size.Height
                location = pipeyp_y.Item(pipeyp.IndexOf(item)) 'Orignal Y Locationc 
                piranhaLoc = pipeyp.Item(pipeyp.IndexOf(item)).Location 'Location Now
                If (location) <= piranhaLoc.Y Then
                    Randomize()
                    pipeyp_state.Item(pipeyp.IndexOf(item)) = 4
                    pipeyp_i.Item(pipeyp.IndexOf(item)) = heights
                    pipeyp_wait.Item(pipeyp.IndexOf(item)) = (Rnd() * 100) + 25
                End If

            ElseIf pipeyp_state.Item(pipeyp.IndexOf(item)) = 4 Then
                pipeyp_wait.Item(pipeyp.IndexOf(item)) = pipeyp_wait.Item(pipeyp.IndexOf(item)) - 1
                pipeyp.Item(pipeyp.IndexOf(item)).Location = New Point((scrollx + Pipes.getPipeX(pipeyp.IndexOf(item))) + (pipey.Item(pipeyp.IndexOf(item)).Size.Width / 2) - (pipeyp.Item(pipeyp.IndexOf(item)).Size.Width / 2), (scrolly + Pipes.getPipeY(pipeyp.IndexOf(item)) + 5))
                If pipeyp_wait.Item(pipeyp.IndexOf(item)) <= 0 Then
                    pipeyp_state.Item(pipeyp.IndexOf(item)) = 0
                    pipeyp_i.Item(pipeyp.IndexOf(item)) = 0
                End If
            End If
        Next
        '- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        Dim died As Boolean = False
        For Each p In pipeyp
            If pbMario.Bounds.IntersectsWith(p.Bounds) Then
                mario_dead = True
                started = False
                Sounds.Play("player-die")
                died = True
            End If
        Next

        For Each p In pipeyp
            If pbFireball.Bounds.IntersectsWith(p.Bounds) Then
                If pipeyp_state.Item(pipeyp.IndexOf(p)) = 1 Or pipeyp_state.Item(pipeyp.IndexOf(p)) = 2 Or pipeyp_state.Item(pipeyp.IndexOf(p)) = 3 Then
                    p.Visible = False
                    pipeyp_state.Item(pipeyp.IndexOf(p)) = 5
                    p.Location = New Point(0, 0)
                End If
            End If
        Next


        If died = True Then
            TimerPipe.Enabled = False
        End If

    End Sub
    ' _____                    _                   
    '|  __ \                  | |                  
    '| |__) | __ _  _ __    __| |  ___   _ __ ___  
    '|  _  / / _` || '_ \  / _` | / _ \ | '_ ` _ \ 
    '| | \ \| (_| || | | || (_| || (_) || | | | | |
    '|_|  \_\\__,_||_| |_| \__,_| \___/ |_| |_| |_|

    Private Sub TimerRandom_Tick(sender As Object, e As EventArgs) Handles TimerRandom.Tick
        Dim hit = False
        Randomize()
        Dim rand As Integer = Rnd() * 1
        If rand = 1 Then
            While True
                Dim pipeyp_amount As Integer = -1
                For Each piranha In pipeyp
                    pipeyp_amount = pipeyp_amount + 1
                Next
                Dim plant As Integer = (Rnd() * pipeyp_amount)
                If pipeyp_state.Item(plant) <> -1 Then
                    If pipeyp_state.Item(plant) < 2 Then
                        If pbMario.Bounds.IntersectsWith(pipey.Item(plant).Bounds) Then
                            Exit While
                        Else
                            hit = True
                            pipeyp_state.Item(plant) = 1
                        End If
                    Else
                        Exit While
                    End If
                End If
                If hit = True Then
                    Exit While
                End If
            End While
        End If
    End Sub




    Private Sub TimerTimer_Tick(sender As Object, e As EventArgs) Handles TimerTimer.Tick
        If timey > 100 Then
            lblTime.Text = "TIME" & vbCrLf & timey
        Else
            If timey < 100 And timey > 10 Then
                lblTime.Text = "TIME" & vbCrLf & "0" & timey
            Else
                If timey <= 10 Then
                    lblTime.Text = "TIME" & vbCrLf & "00" & timey
                End If
            End If
        End If



        timey = timey - 1

        If timey = 100 Then
            Sounds.Play("game-hurry")
        ElseIf timey = 0 Then
            TimerTimer.Enabled = False
            mario_dead = True
            started = False
            Sounds.Play("player-die")
        End If
    End Sub















    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    Private Sub TimerRainingMario_Tick(sender As Object, e As EventArgs) Handles TimerFallingR.Tick
        For x = fallingMenuEntitys.Count - 1 To 0 Step -1
            Dim element = fallingMenuEntitys.Item(x)
            If element.Location.Y > (Me.Height - 100) Then
                Me.Controls.Remove(element)
                fallingMenuEntitys.Remove(element)
                falling_total = falling_total + 1
            Else
                element.Location = New Point(element.Location.X, element.Location.Y + 5)
            End If
        Next
    End Sub
    Private Sub TimerFallingAdd_Tick(sender As Object, e As EventArgs) Handles TimerFallingAdd.Tick
        newFalling()
    End Sub
    Sub newFalling()
        Randomize()


        Dim newEntity As PictureBox
        newEntity = New PictureBox
        fallingMenuEntitys.Add(newEntity)
        Dim images As Integer = Rnd() * 20
        If images = 0 Then
            fallingMenuEntitys(fallingMenuEntitys.IndexOf(newEntity)).Image = My.Resources.Princess
        ElseIf images = 1 Then
            fallingMenuEntitys(fallingMenuEntitys.IndexOf(newEntity)).Image = My.Resources.CoinForBlackBG
        ElseIf images = 2 Then
            fallingMenuEntitys(fallingMenuEntitys.IndexOf(newEntity)).Image = My.Resources.FireBall
        ElseIf images = 3 Then
            fallingMenuEntitys(fallingMenuEntitys.IndexOf(newEntity)).Image = My.Resources.QuestionBlock
        ElseIf images = 4 Then
            fallingMenuEntitys(fallingMenuEntitys.IndexOf(newEntity)).Image = My.Resources.BrickBlockBrown
        ElseIf images = 5 Then
            fallingMenuEntitys(fallingMenuEntitys.IndexOf(newEntity)).Image = My.Resources.BrickBlockDark
        ElseIf images = 6 Then
            fallingMenuEntitys(fallingMenuEntitys.IndexOf(newEntity)).Image = My.Resources._1upMushroom
        ElseIf images = 7 Then
            fallingMenuEntitys(fallingMenuEntitys.IndexOf(newEntity)).Image = My.Resources.MagicMushroom
        ElseIf images = 8 Then
            fallingMenuEntitys(fallingMenuEntitys.IndexOf(newEntity)).Image = My.Resources.KoopaParatroopaGreen
        ElseIf images = 9 Then
            fallingMenuEntitys(fallingMenuEntitys.IndexOf(newEntity)).Image = My.Resources.KoopaParatroopaRed
        ElseIf images = 10 Then
            fallingMenuEntitys(fallingMenuEntitys.IndexOf(newEntity)).Image = My.Resources.KoopaTroopaShellGreen
        ElseIf images = 11 Then
            fallingMenuEntitys(fallingMenuEntitys.IndexOf(newEntity)).Image = My.Resources.KoopaTroopaShellRed
        ElseIf images = 12 Then
            fallingMenuEntitys(fallingMenuEntitys.IndexOf(newEntity)).Image = My.Resources.PiranaPlant
        ElseIf images = 13 Then
            fallingMenuEntitys(fallingMenuEntitys.IndexOf(newEntity)).Image = My.Resources.Podoboo
        ElseIf images = 14 Then
            fallingMenuEntitys(fallingMenuEntitys.IndexOf(newEntity)).Image = My.Resources.Spiny
        ElseIf images = 15 Then
            fallingMenuEntitys(fallingMenuEntitys.IndexOf(newEntity)).Image = My.Resources.TheHammerBrothers
        ElseIf images = 16 Then
            fallingMenuEntitys(fallingMenuEntitys.IndexOf(newEntity)).Image = My.Resources.BulletBill
        ElseIf images = 17 Then
            fallingMenuEntitys(fallingMenuEntitys.IndexOf(newEntity)).Image = My.Resources.Axe
        ElseIf images = 18 Then
            fallingMenuEntitys(fallingMenuEntitys.IndexOf(newEntity)).Image = My.Resources.BuzzyBeetle
        ElseIf images = 19 Then
            fallingMenuEntitys(fallingMenuEntitys.IndexOf(newEntity)).Image = My.Resources.CheepCheepRed
        ElseIf images = 20 Then
            fallingMenuEntitys(fallingMenuEntitys.IndexOf(newEntity)).Image = My.Resources.FireFlower
        End If

        fallingMenuEntitys(fallingMenuEntitys.IndexOf(newEntity)).SizeMode = PictureBoxSizeMode.AutoSize
        fallingMenuEntitys(fallingMenuEntitys.IndexOf(newEntity)).Width = fallingMenuEntitys(fallingMenuEntitys.IndexOf(newEntity)).Size.Width * sizes
        fallingMenuEntitys(fallingMenuEntitys.IndexOf(newEntity)).Height = fallingMenuEntitys(fallingMenuEntitys.IndexOf(newEntity)).Size.Height * sizes
        fallingMenuEntitys(fallingMenuEntitys.IndexOf(newEntity)).SizeMode = PictureBoxSizeMode.StretchImage
        Dim rand As Integer = Rnd() * 1
        Dim x As Integer = 0
        If rand = 1 Then
            x = (Rnd() * menux) - (menux / 3) + fallingMenuEntitys(fallingMenuEntitys.IndexOf(newEntity)).Size.Width
        Else
            x = (Rnd() * menux) + (menux + pbMenuBackground.Size.Width) + (menux / 3) + fallingMenuEntitys(fallingMenuEntitys.IndexOf(newEntity)).Size.Width + 10
        End If

        fallingMenuEntitys(fallingMenuEntitys.IndexOf(newEntity)).Location = New Point(x, 0)
        falling_total = falling_total + 1
        Me.Controls.Add(fallingMenuEntitys(fallingMenuEntitys.IndexOf(newEntity)))
        fallingMenuEntitys(fallingMenuEntitys.IndexOf(newEntity)).BringToFront()

    End Sub





    Private Sub TimerDialogBox_Tick(sender As Object, e As EventArgs) Handles TimerDialogBox.Tick
        Dim widthy As Boolean
        Dim lengthy As Boolean

        Dim dialogX As Integer
        Dim dialogY As Integer

        If pbDialog.Size.Width < dialogAfterW Then
            pbDialog.Width = pbDialog.Size.Width + 32
        Else
            widthy = True
        End If
        If pbDialog.Size.Height < dialogAfterH Then
            pbDialog.Height = pbDialog.Size.Height + 10
        Else
            lengthy = True
        End If
        '= pbDialog.Size.Width & ":" & dialogAfterW & vbCrLf & pbDialog.Size.Height & ":" & dialogAfterH
        dialogX = centerx - (pbDialog.Width / 2)
        dialogY = centery - (pbDialog.Height / 2)
        pbDialog.BringToFront()
        pbDialog.Location = New Point(dialogX, dialogY)
        If lengthy = True And widthy = True Then
            pbCloseDialog.Visible = True
            pbCloseDialog.Location = New Point((pbDialog.Location.X + (pbDialog.Size.Width / 2)) - (pbCloseDialog.Width / 2), pbDialog.Location.Y + pbDialog.Size.Height + 5)

            pbDialog.Image = dialogImage
            dialogDone = True
            dialogRunning = False
            TimerFallingR.Enabled = True
            TimerFallingAdd.Enabled = True
            TimerDialogBox.Enabled = False
        End If
    End Sub




    Sub showDialogs(ByVal image As Image)
        dialogImage = image
        pbDialog.Image = image
        pbDialog.SizeMode = PictureBoxSizeMode.AutoSize
        dialogAfterH = pbDialog.Size.Height * 2
        dialogAfterW = pbDialog.Size.Width * 2

        dialogSizeH = pbDialog.Size.Height
        dialogSizeW = pbDialog.Size.Width

        pbDialog.SizeMode = PictureBoxSizeMode.StretchImage

        pbDialog.Width = dialogSizeW / 2
        pbDialog.Height = dialogSizeH / 2

        pbDialog.Image = My.Resources.black
        pbDialog.Visible = True

        dialogDone = False
        dialogRunning = True
        selecting = False

        TimerFallingR.Enabled = False
        TimerFallingAdd.Enabled = False
        TimerDialogBox.Enabled = True
        pbCloseDialog.BringToFront()
    End Sub

    Sub closeDialog()
        pbCloseDialog.Visible = False
        pbDialog.Visible = False
    End Sub
    ' - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -







    Sub menuUp()
        If selecting = True Then
            Sounds.Play("menu-select")
            If selection = 1 Then
                selection = 3
                menu_sx = menux + 400
                menu_sy = menuy + 640
                pbSelector.Location = New Point(menu_sx, menu_sy)
                pbSelector.BringToFront()
            ElseIf selection = 2 Then
                selection = 1
                menu_sx = menux + 400
                menu_sy = menuy + 490
                pbSelector.Location = New Point(menu_sx, menu_sy)
                pbSelector.BringToFront()
            ElseIf selection = 3 Then
                selection = 2
                menu_sx = menux + 400
                menu_sy = menuy + 570
                pbSelector.Location = New Point(menu_sx, menu_sy)
                pbSelector.BringToFront()
            End If
        End If



    End Sub

    Sub menuDown()
        If selecting = True Then
            Sounds.Play("menu-select")
            If selection = 3 Then
                selection = 1
                menu_sx = menux + 400
                menu_sy = menuy + 490
                pbSelector.Location = New Point(menu_sx, menu_sy)
                pbSelector.BringToFront()
            ElseIf selection = 1 Then
                selection = 2
                menu_sx = menux + 400
                menu_sy = menuy + 570
                pbSelector.Location = New Point(menu_sx, menu_sy)
                pbSelector.BringToFront()
            ElseIf selection = 2 Then
                selection = 3
                menu_sx = menux + 400
                menu_sy = menuy + 640
                pbSelector.Location = New Point(menu_sx, menu_sy)
                pbSelector.BringToFront()
            End If
        End If

    End Sub
    Sub menuSelect()
        If selecting = True Then
            If selection = 1 Then
                If started = False Then
                    selecting = False


                    For x = fallingMenuEntitys.Count - 1 To 0 Step -1
                        Dim element = fallingMenuEntitys.Item(x)
                        Me.Controls.Remove(element)
                        fallingMenuEntitys.Remove(element)
                    Next
                    TimerFallingAdd.Enabled = False
                    TimerFallingR.Enabled = False

                    resetAll()
                    setObjects()
                    placeElements()
                    TimerJump.Enabled = True
                    started = True
                    pbMenuBackground.Visible = False
                    pbSelector.Visible = False
                    Sounds.Stop("Theme")
                End If
            ElseIf selection = 2 Then
                showDialogs(My.Resources.menu_dialog)
                Sounds.Play("menu-dialog")
            ElseIf selection = 3 Then
                showDialogs(My.Resources.options_dialog)
                Sounds.Play("menu-dialog")
            End If
        End If

    End Sub

    Private Sub TimerMario_Tick(sender As Object, e As EventArgs) Handles TimerMario.Tick
        If mario_dead = True Then
            mario_dead_t = mario_dead_t - 1
        End If
        If mario_dead_t = 0 Then
            If lives = 0 Then
                mario_dead = False
                mario_dead_t = 100

                lblCoins.Visible = False
                lblPoints.Visible = False
                lblWorld.Visible = False
                lblTime.Visible = False
                pbCoin.Visible = False
                Scrolling.Visible = False
                pbMario.Visible = False
                flag.Visible = False
                removeFromScreen()

                pbGameover.Location = New Point(centerx - (pbGameover.Size.Width / 2), centery - (pbGameover.Size.Height / 2) - 75)
                pbGameover.Visible = True
                pbGameover.BringToFront()
                Sounds.Play("player-over")

                'LATER ADD WORLD SUPPORT TO START AT LAST WORLD
                gameover = True
                started = False
                paused = False
                selecting = False

                'Reset all varibles
                resetAll()
                marioStart()

                points = 0
                coins = 0

                lblCoins.Text = "X " & 0
                lblPoints.Text = "POINTS" & vbCrLf & "000000"
                lblWorld.Text = "WORLD" & vbCrLf & "1-1"
                lives = 5
                mario_state = 0
            Else
                no_keys = True
                lblCoins.Visible = False
                lblPoints.Visible = False
                lblWorld.Visible = False
                lblTime.Visible = False
                Scrolling.Visible = False
                pbMario.Visible = False
                pbCoin.Visible = False
                flag.Visible = False
                removeFromScreen()

                mario_dead_t = 100
                mario_start_t = 50
                mario_dead = False
                mario_start = True
                mario_state = 0

                lives = lives - 1
                lblLives.Text = "X " & lives

                lblMarioStart.Location = New Point(centerx - (lblMarioStart.Size.Width / 2), centery - 50)
                lblMarioStart.Visible = True
                lblMarioStart.BringToFront()

                pbDummy.Visible = True
                pbDummy.BringToFront()
                pbDummy.Location = New Point(centerx - (lblMarioStart.Size.Width / 2) - 100, centery + 100)

                lblLives.Location = New Point(centerx - (lblMarioStart.Size.Width / 2) + 100, centery + 100)
                lblLives.Visible = True
                lblLives.BringToFront()



                points = 0
                coins = 0
            End If
        End If


        If mario_start = True Then
            mario_start_t = mario_start_t - 1
        End If
        If mario_start_t = 0 Then
            'Disabled the wait sytsem
            mario_start = False
            mario_start_t = -1

            'Reset all varibles
            resetAll()
            'Set up all required PictureBoxes
            marioStart()

            'Set the objects in place
            setObjects()

            'Place objects
            placeElements()


            'Enable label's
            lblLives.Visible = False
            pbDummy.Visible = False
            lblMarioStart.Visible = False

            pbCoin.Visible = True


            'Enable the timers
            TimerRandom.Enabled = True
            TimerPipe.Enabled = True
            TimerJump.Enabled = True
            TimerTime.Enabled = True


   
            lblCoins.Text = "X " & 0
            lblPoints.Text = "POINTS" & vbCrLf & "000000"
            lblWorld.Text = "WORLD" & vbCrLf & "1-1"



            'Set mario to mini mario
            mario_start = 0

            'Start the game once again!
            started = True

        End If

        If flag_create Then
            flag.BringToFront()
            Dim flag_touch As Boolean = False
            For Each element In blocky
                If flag.Bounds.IntersectsWith(element.Bounds) Then
                    flag_touch = True
                End If
            Next

            If flag_touch = True Then
                speed = 7
                jump = True
                TimerRight.Enabled = True
                TimerJump.Enabled = True
                credits_done = True
                flag.Location = New Point(0, 0)
                flag.Visible = False
                Sounds.Play("player-world_clear")
            Else
                If pbMario.Bounds.IntersectsWith(pole.Bounds) Then
                    If credits_done = False Then
                        started = False
                        TimerRandom.Enabled = False
                        TimerPipe.Enabled = False
                        TimerJump.Enabled = False
                        TimerEntity.Enabled = False
                        TimerLeft.Enabled = False
                        TimerRight.Enabled = False
                        TimerTimer.Enabled = False
                        If pole_sound = -1 Then
                            pole_sound = 1
                        End If
                        flag.BringToFront()



                        flag.Top += 8
                    End If


                End If
                If pbMario.Bounds.IntersectsWith(flag.Bounds) Then
                    flag.BringToFront()
                   
                End If
            End If
            If pole_sound = 1 Then
                pole_sound = 0
                Sounds.Play("player-pole")
            End If
            If credits_done = True Then
                For Each element In blocky
                    If pbMario.Bounds.IntersectsWith(element.Bounds) Then
                        If Blocks.getGive(blocky.IndexOf(element)) = "invis" Then
                            pbMario.Visible = False
                            TimerRight.Enabled = False
                            fireworks = True
                            fireworks_t = 200
                            ending = 0
                            credits_done = False

                            Dim locs As Point = pbMario.Location
                            pbFireworks1.Location = New Point(locs.X - 100, scrolly + 250)
                            pbFireworks2.Location = New Point(locs.X - 110, scrolly + 200)
                            pbFireworks3.Location = New Point(locs.X + 110, scrolly + 200)
                            pbFireworks3.Location = New Point(locs.X + 100, scrolly + 250)


                        End If
                    End If
                Next
            End If
            Label3.Text = fireworks_t
            If fireworks = True Then
                If fireworks_t > 0 Then
                    fireworks_t = fireworks_t - 1
                    ending = ending + 1
                End If
            End If
            If ending = 15 Then
                pbFireworks1.Visible = False
                pbFireworks2.Visible = False
                pbFireworks3.Visible = False
                pbFireworks4.Visible = False

                Sounds.Play("player-fireworks")
                ending = 0
                While True
                    Randomize()
                    Dim rands As Integer = Rnd() * 3 + 1
                    If rands <> fireworks_last Then
                        If rands = 1 Then
                            pbFireworks1.Visible = True
                            pbFireworks1.BringToFront()
                        ElseIf rands = 2 Then
                            pbFireworks2.Visible = True
                            pbFireworks2.Visible = True
                        ElseIf rands = 3 Then
                            pbFireworks3.Visible = True
                            pbFireworks3.Visible = True
                        ElseIf rands = 4 Then
                            pbFireworks4.Visible = True
                            pbFireworks4.Visible = True
                        End If
                        fireworks_last = rands
                        Exit While
                    End If
                End While
            End If
            If fireworks_t = 0 Then

                fireworks = False
                ending = 0
                fireworks_t = 200


                lives = 3
                lblCoins.Visible = False
                lblPoints.Visible = False
                lblWorld.Visible = False
                lblTime.Visible = False
                pbCoin.Visible = False
                Scrolling.Visible = False
                pbMario.Visible = False
                'LATER ADD WORLD SUPPORT TO START AT LAST WORLD
                gameover = False
                started = False
                paused = False
                selecting = True

                'Reset all varibles
                removeFromScreen()
                resetAll()
                marioStart()

                points = 0
                coins = 0

                lblCoins.Text = "X " & 0
                lblPoints.Text = "POINTS" & vbCrLf & "000000"
                lblWorld.Text = "WORLD" & vbCrLf & "1-1"

                menus()
                flag.Visible = False
            End If
        End If

    End Sub


    'Remove all elements from screen
    Sub removeFromScreen()
        'Disabled timers (so nothing crashes)
        TimerRandom.Enabled = False
        TimerPipe.Enabled = False
        TimerJump.Enabled = False
        TimerLeft.Enabled = False
        TimerRight.Enabled = False
        TimerTimer.Enabled = False
        timey = 300
        'Loop respected lists and remove from screen
        For x = blocky.Count - 1 To 0 Step -1
            Dim element = blocky.Item(x)
            Dim index As Integer = x
            Me.Controls.Remove(element)
        Next
        For x = pipey.Count - 1 To 0 Step -1
            Dim element = pipey.Item(x)
            Dim index As Integer = x
            Me.Controls.Remove(element)
        Next
        For x = entities.Count - 1 To 0 Step -1
            Dim element = entities.Item(x)
            Dim index As Integer = x
            Me.Controls.Remove(element)
        Next
        For x = pipeyp.Count - 1 To 0 Step -1
            Dim element = pipeyp.Item(x)
            Dim index As Integer = x
            Me.Controls.Remove(element)
        Next

        For x = pipeyr.Count - 1 To 0 Step -1
            Dim element = pipeyr.Item(x)
            Dim index As Integer = x
            Me.Controls.Remove(element)
        Next
        For x = pipeyl.Count - 1 To 0 Step -1
            Dim element = pipeyl.Item(x)
            Dim index As Integer = x
            Me.Controls.Remove(element)
        Next

        For x = blockyr.Count - 1 To 0 Step -1
            Dim element = blockyr.Item(x)
            Dim index As Integer = x
            Me.Controls.Remove(element)
        Next
        For x = blockyl.Count - 1 To 0 Step -1
            Dim element = blockyl.Item(x)
            Dim index As Integer = x
            Me.Controls.Remove(element)
        Next

    End Sub
End Class
