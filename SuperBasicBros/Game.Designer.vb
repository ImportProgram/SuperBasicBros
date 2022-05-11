<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Game
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Game))
        Me.TimerLeft = New System.Windows.Forms.Timer(Me.components)
        Me.TimerRight = New System.Windows.Forms.Timer(Me.components)
        Me.TimerJump = New System.Windows.Forms.Timer(Me.components)
        Me.lblJumpStatus = New System.Windows.Forms.Label()
        Me.TimerPipe = New System.Windows.Forms.Timer(Me.components)
        Me.TimerIntersecting = New System.Windows.Forms.Timer(Me.components)
        Me.TimerBumpBlock = New System.Windows.Forms.Timer(Me.components)
        Me.TimerMove = New System.Windows.Forms.Timer(Me.components)
        Me.TimerRandom = New System.Windows.Forms.Timer(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TimerFallingR = New System.Windows.Forms.Timer(Me.components)
        Me.TimerFallingAdd = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TimerDialogBox = New System.Windows.Forms.Timer(Me.components)
        Me.lblPoints = New System.Windows.Forms.Label()
        Me.lblCoins = New System.Windows.Forms.Label()
        Me.lblWorld = New System.Windows.Forms.Label()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.TimerTimer = New System.Windows.Forms.Timer(Me.components)
        Me.TimerEntity = New System.Windows.Forms.Timer(Me.components)
        Me.TimerTime = New System.Windows.Forms.Timer(Me.components)
        Me.TimerMario = New System.Windows.Forms.Timer(Me.components)
        Me.lblMarioStart = New System.Windows.Forms.Label()
        Me.lblLives = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pbFireworks4 = New System.Windows.Forms.PictureBox()
        Me.pbFireworks3 = New System.Windows.Forms.PictureBox()
        Me.pbFireworks2 = New System.Windows.Forms.PictureBox()
        Me.pbFireworks1 = New System.Windows.Forms.PictureBox()
        Me.pbGameover = New System.Windows.Forms.PictureBox()
        Me.pbDummy = New System.Windows.Forms.PictureBox()
        Me.pbCoin = New System.Windows.Forms.PictureBox()
        Me.pbCloseDialog = New System.Windows.Forms.PictureBox()
        Me.pbDialog = New System.Windows.Forms.PictureBox()
        Me.pbSelector = New System.Windows.Forms.PictureBox()
        Me.pbMenuBackground = New System.Windows.Forms.PictureBox()
        Me.pbFireball = New System.Windows.Forms.PictureBox()
        Me.pbRight = New System.Windows.Forms.PictureBox()
        Me.pbLeft = New System.Windows.Forms.PictureBox()
        Me.pbMario = New System.Windows.Forms.PictureBox()
        Me.Scrolling = New System.Windows.Forms.PictureBox()
        CType(Me.pbFireworks4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbFireworks3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbFireworks2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbFireworks1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbGameover, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbDummy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbCoin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbCloseDialog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbDialog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbSelector, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbMenuBackground, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbFireball, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbRight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbMario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Scrolling, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TimerLeft
        '
        Me.TimerLeft.Interval = 1
        '
        'TimerRight
        '
        Me.TimerRight.Interval = 20
        '
        'TimerJump
        '
        Me.TimerJump.Interval = 20
        '
        'lblJumpStatus
        '
        Me.lblJumpStatus.AutoSize = True
        Me.lblJumpStatus.Location = New System.Drawing.Point(9, 274)
        Me.lblJumpStatus.Name = "lblJumpStatus"
        Me.lblJumpStatus.Size = New System.Drawing.Size(59, 13)
        Me.lblJumpStatus.TabIndex = 7
        Me.lblJumpStatus.Text = "jumpStatus"
        '
        'TimerPipe
        '
        Me.TimerPipe.Interval = 1
        '
        'TimerIntersecting
        '
        Me.TimerIntersecting.Enabled = True
        Me.TimerIntersecting.Interval = 20
        '
        'TimerBumpBlock
        '
        Me.TimerBumpBlock.Interval = 10
        '
        'TimerMove
        '
        Me.TimerMove.Enabled = True
        Me.TimerMove.Interval = 20
        '
        'TimerRandom
        '
        Me.TimerRandom.Interval = 1000
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 392)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "item"
        '
        'TimerFallingR
        '
        Me.TimerFallingR.Interval = 1
        '
        'TimerFallingAdd
        '
        Me.TimerFallingAdd.Interval = 500
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 313)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Label1"
        Me.Label1.Visible = False
        '
        'TimerDialogBox
        '
        Me.TimerDialogBox.Interval = 1
        '
        'lblPoints
        '
        Me.lblPoints.AutoSize = True
        Me.lblPoints.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPoints.ForeColor = System.Drawing.Color.Black
        Me.lblPoints.Location = New System.Drawing.Point(840, 12)
        Me.lblPoints.Name = "lblPoints"
        Me.lblPoints.Size = New System.Drawing.Size(136, 74)
        Me.lblPoints.TabIndex = 26
        Me.lblPoints.Text = "POINTS" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "000000"
        Me.lblPoints.Visible = False
        '
        'lblCoins
        '
        Me.lblCoins.AutoSize = True
        Me.lblCoins.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCoins.ForeColor = System.Drawing.Color.Black
        Me.lblCoins.Location = New System.Drawing.Point(1097, 12)
        Me.lblCoins.Name = "lblCoins"
        Me.lblCoins.Size = New System.Drawing.Size(59, 37)
        Me.lblCoins.TabIndex = 27
        Me.lblCoins.Text = "x 0"
        Me.lblCoins.Visible = False
        '
        'lblWorld
        '
        Me.lblWorld.AutoSize = True
        Me.lblWorld.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWorld.ForeColor = System.Drawing.Color.Black
        Me.lblWorld.Location = New System.Drawing.Point(840, 103)
        Me.lblWorld.Name = "lblWorld"
        Me.lblWorld.Size = New System.Drawing.Size(136, 74)
        Me.lblWorld.TabIndex = 29
        Me.lblWorld.Text = "WORLD" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "1-1" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lblWorld.Visible = False
        '
        'lblTime
        '
        Me.lblTime.AutoSize = True
        Me.lblTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTime.ForeColor = System.Drawing.Color.Black
        Me.lblTime.Location = New System.Drawing.Point(984, 103)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(92, 74)
        Me.lblTime.TabIndex = 30
        Me.lblTime.Text = "TIME" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "0000" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lblTime.Visible = False
        '
        'TimerTimer
        '
        Me.TimerTimer.Interval = 500
        '
        'TimerEntity
        '
        Me.TimerEntity.Interval = 20
        '
        'TimerTime
        '
        Me.TimerTime.Interval = 20
        '
        'TimerMario
        '
        Me.TimerMario.Enabled = True
        Me.TimerMario.Interval = 20
        '
        'lblMarioStart
        '
        Me.lblMarioStart.AutoSize = True
        Me.lblMarioStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMarioStart.ForeColor = System.Drawing.Color.Black
        Me.lblMarioStart.Location = New System.Drawing.Point(811, 264)
        Me.lblMarioStart.Name = "lblMarioStart"
        Me.lblMarioStart.Size = New System.Drawing.Size(255, 74)
        Me.lblMarioStart.TabIndex = 34
        Me.lblMarioStart.Text = "MARIO STARTS" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lblMarioStart.Visible = False
        '
        'lblLives
        '
        Me.lblLives.AutoSize = True
        Me.lblLives.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLives.ForeColor = System.Drawing.Color.Black
        Me.lblLives.Location = New System.Drawing.Point(950, 338)
        Me.lblLives.Name = "lblLives"
        Me.lblLives.Size = New System.Drawing.Size(59, 37)
        Me.lblLives.TabIndex = 35
        Me.lblLives.Text = "x 0"
        Me.lblLives.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(11, 428)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Label3"
        Me.Label3.Visible = False
        '
        'pbFireworks4
        '
        Me.pbFireworks4.Image = Global.MarioBros.My.Resources.Resources.FireBallHit
        Me.pbFireworks4.Location = New System.Drawing.Point(1007, 221)
        Me.pbFireworks4.Name = "pbFireworks4"
        Me.pbFireworks4.Size = New System.Drawing.Size(16, 16)
        Me.pbFireworks4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbFireworks4.TabIndex = 41
        Me.pbFireworks4.TabStop = False
        Me.pbFireworks4.Visible = False
        '
        'pbFireworks3
        '
        Me.pbFireworks3.Image = Global.MarioBros.My.Resources.Resources.FireBallHit
        Me.pbFireworks3.Location = New System.Drawing.Point(985, 221)
        Me.pbFireworks3.Name = "pbFireworks3"
        Me.pbFireworks3.Size = New System.Drawing.Size(16, 16)
        Me.pbFireworks3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbFireworks3.TabIndex = 40
        Me.pbFireworks3.TabStop = False
        Me.pbFireworks3.Visible = False
        '
        'pbFireworks2
        '
        Me.pbFireworks2.Image = Global.MarioBros.My.Resources.Resources.FireBallHit
        Me.pbFireworks2.Location = New System.Drawing.Point(963, 221)
        Me.pbFireworks2.Name = "pbFireworks2"
        Me.pbFireworks2.Size = New System.Drawing.Size(16, 16)
        Me.pbFireworks2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbFireworks2.TabIndex = 39
        Me.pbFireworks2.TabStop = False
        Me.pbFireworks2.Visible = False
        '
        'pbFireworks1
        '
        Me.pbFireworks1.Image = Global.MarioBros.My.Resources.Resources.FireBallHit
        Me.pbFireworks1.Location = New System.Drawing.Point(941, 221)
        Me.pbFireworks1.Name = "pbFireworks1"
        Me.pbFireworks1.Size = New System.Drawing.Size(16, 16)
        Me.pbFireworks1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbFireworks1.TabIndex = 38
        Me.pbFireworks1.TabStop = False
        Me.pbFireworks1.Visible = False
        '
        'pbGameover
        '
        Me.pbGameover.Image = Global.MarioBros.My.Resources.Resources.game_over
        Me.pbGameover.Location = New System.Drawing.Point(719, 405)
        Me.pbGameover.Name = "pbGameover"
        Me.pbGameover.Size = New System.Drawing.Size(512, 456)
        Me.pbGameover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbGameover.TabIndex = 36
        Me.pbGameover.TabStop = False
        Me.pbGameover.Visible = False
        '
        'pbDummy
        '
        Me.pbDummy.BackColor = System.Drawing.Color.Transparent
        Me.pbDummy.Image = Global.MarioBros.My.Resources.Resources.MarioStanding
        Me.pbDummy.Location = New System.Drawing.Point(872, 338)
        Me.pbDummy.Name = "pbDummy"
        Me.pbDummy.Size = New System.Drawing.Size(12, 16)
        Me.pbDummy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbDummy.TabIndex = 33
        Me.pbDummy.TabStop = False
        '
        'pbCoin
        '
        Me.pbCoin.Image = Global.MarioBros.My.Resources.Resources.CoinForBlueBG
        Me.pbCoin.Location = New System.Drawing.Point(1024, 31)
        Me.pbCoin.Name = "pbCoin"
        Me.pbCoin.Size = New System.Drawing.Size(32, 32)
        Me.pbCoin.TabIndex = 28
        Me.pbCoin.TabStop = False
        Me.pbCoin.Visible = False
        '
        'pbCloseDialog
        '
        Me.pbCloseDialog.Image = Global.MarioBros.My.Resources.Resources.space_close
        Me.pbCloseDialog.Location = New System.Drawing.Point(223, 624)
        Me.pbCloseDialog.Name = "pbCloseDialog"
        Me.pbCloseDialog.Size = New System.Drawing.Size(370, 57)
        Me.pbCloseDialog.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbCloseDialog.TabIndex = 25
        Me.pbCloseDialog.TabStop = False
        Me.pbCloseDialog.Visible = False
        '
        'pbDialog
        '
        Me.pbDialog.Location = New System.Drawing.Point(148, 338)
        Me.pbDialog.Name = "pbDialog"
        Me.pbDialog.Size = New System.Drawing.Size(512, 280)
        Me.pbDialog.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbDialog.TabIndex = 24
        Me.pbDialog.TabStop = False
        Me.pbDialog.Visible = False
        '
        'pbSelector
        '
        Me.pbSelector.Image = CType(resources.GetObject("pbSelector.Image"), System.Drawing.Image)
        Me.pbSelector.Location = New System.Drawing.Point(31, 271)
        Me.pbSelector.Name = "pbSelector"
        Me.pbSelector.Size = New System.Drawing.Size(16, 16)
        Me.pbSelector.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbSelector.TabIndex = 22
        Me.pbSelector.TabStop = False
        '
        'pbMenuBackground
        '
        Me.pbMenuBackground.Image = CType(resources.GetObject("pbMenuBackground.Image"), System.Drawing.Image)
        Me.pbMenuBackground.Location = New System.Drawing.Point(148, 243)
        Me.pbMenuBackground.Name = "pbMenuBackground"
        Me.pbMenuBackground.Size = New System.Drawing.Size(512, 456)
        Me.pbMenuBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbMenuBackground.TabIndex = 21
        Me.pbMenuBackground.TabStop = False
        '
        'pbFireball
        '
        Me.pbFireball.BackColor = System.Drawing.Color.Transparent
        Me.pbFireball.Image = Global.MarioBros.My.Resources.Resources.FireBall
        Me.pbFireball.Location = New System.Drawing.Point(117, 279)
        Me.pbFireball.Name = "pbFireball"
        Me.pbFireball.Size = New System.Drawing.Size(8, 8)
        Me.pbFireball.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbFireball.TabIndex = 19
        Me.pbFireball.TabStop = False
        Me.pbFireball.Visible = False
        '
        'pbRight
        '
        Me.pbRight.Location = New System.Drawing.Point(64, 338)
        Me.pbRight.Name = "pbRight"
        Me.pbRight.Size = New System.Drawing.Size(35, 37)
        Me.pbRight.TabIndex = 14
        Me.pbRight.TabStop = False
        Me.pbRight.Visible = False
        '
        'pbLeft
        '
        Me.pbLeft.Location = New System.Drawing.Point(12, 338)
        Me.pbLeft.Name = "pbLeft"
        Me.pbLeft.Size = New System.Drawing.Size(35, 37)
        Me.pbLeft.TabIndex = 13
        Me.pbLeft.TabStop = False
        Me.pbLeft.Visible = False
        '
        'pbMario
        '
        Me.pbMario.BackColor = System.Drawing.Color.Transparent
        Me.pbMario.Image = Global.MarioBros.My.Resources.Resources.MarioStanding
        Me.pbMario.Location = New System.Drawing.Point(87, 271)
        Me.pbMario.Name = "pbMario"
        Me.pbMario.Size = New System.Drawing.Size(12, 16)
        Me.pbMario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbMario.TabIndex = 3
        Me.pbMario.TabStop = False
        '
        'Scrolling
        '
        Me.Scrolling.BackColor = System.Drawing.Color.Transparent
        Me.Scrolling.Image = CType(resources.GetObject("Scrolling.Image"), System.Drawing.Image)
        Me.Scrolling.Location = New System.Drawing.Point(-2558, 12)
        Me.Scrolling.Name = "Scrolling"
        Me.Scrolling.Size = New System.Drawing.Size(3392, 225)
        Me.Scrolling.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.Scrolling.TabIndex = 2
        Me.Scrolling.TabStop = False
        '
        'Game
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1362, 741)
        Me.Controls.Add(Me.pbFireworks4)
        Me.Controls.Add(Me.pbFireworks3)
        Me.Controls.Add(Me.pbFireworks2)
        Me.Controls.Add(Me.pbFireworks1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.pbGameover)
        Me.Controls.Add(Me.lblLives)
        Me.Controls.Add(Me.lblMarioStart)
        Me.Controls.Add(Me.pbDummy)
        Me.Controls.Add(Me.lblTime)
        Me.Controls.Add(Me.lblWorld)
        Me.Controls.Add(Me.pbCoin)
        Me.Controls.Add(Me.lblCoins)
        Me.Controls.Add(Me.lblPoints)
        Me.Controls.Add(Me.pbCloseDialog)
        Me.Controls.Add(Me.pbDialog)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pbSelector)
        Me.Controls.Add(Me.pbMenuBackground)
        Me.Controls.Add(Me.pbFireball)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.pbRight)
        Me.Controls.Add(Me.pbLeft)
        Me.Controls.Add(Me.lblJumpStatus)
        Me.Controls.Add(Me.pbMario)
        Me.Controls.Add(Me.Scrolling)
        Me.DoubleBuffered = True
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Name = "Game"
        Me.RightToLeftLayout = True
        Me.Text = "Super Visual Bros"
        CType(Me.pbFireworks4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbFireworks3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbFireworks2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbFireworks1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbGameover, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbDummy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbCoin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbCloseDialog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbDialog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbSelector, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbMenuBackground, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbFireball, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbRight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbLeft, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbMario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Scrolling, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Scrolling As System.Windows.Forms.PictureBox
    Friend WithEvents TimerLeft As System.Windows.Forms.Timer
    Friend WithEvents TimerRight As System.Windows.Forms.Timer
    Friend WithEvents pbMario As System.Windows.Forms.PictureBox
    Friend WithEvents TimerJump As System.Windows.Forms.Timer
    Friend WithEvents lblJumpStatus As System.Windows.Forms.Label
    Friend WithEvents TimerPipe As System.Windows.Forms.Timer
    Friend WithEvents TimerIntersecting As System.Windows.Forms.Timer
    Friend WithEvents TimerBumpBlock As System.Windows.Forms.Timer
    Friend WithEvents TimerMove As System.Windows.Forms.Timer
    Friend WithEvents pbLeft As System.Windows.Forms.PictureBox
    Friend WithEvents pbRight As System.Windows.Forms.PictureBox
    Friend WithEvents TimerRandom As System.Windows.Forms.Timer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pbFireball As System.Windows.Forms.PictureBox
    Friend WithEvents pbMenuBackground As System.Windows.Forms.PictureBox
    Friend WithEvents pbSelector As System.Windows.Forms.PictureBox
    Friend WithEvents TimerFallingR As System.Windows.Forms.Timer
    Friend WithEvents TimerFallingAdd As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TimerDialogBox As System.Windows.Forms.Timer
    Friend WithEvents pbDialog As System.Windows.Forms.PictureBox
    Friend WithEvents pbCloseDialog As System.Windows.Forms.PictureBox
    Friend WithEvents lblPoints As System.Windows.Forms.Label
    Friend WithEvents lblCoins As System.Windows.Forms.Label
    Friend WithEvents pbCoin As System.Windows.Forms.PictureBox
    Friend WithEvents lblWorld As System.Windows.Forms.Label
    Friend WithEvents lblTime As System.Windows.Forms.Label
    Friend WithEvents TimerTimer As System.Windows.Forms.Timer
    Friend WithEvents TimerEntity As System.Windows.Forms.Timer
    Friend WithEvents TimerTime As System.Windows.Forms.Timer
    Friend WithEvents TimerMario As System.Windows.Forms.Timer
    Friend WithEvents pbDummy As System.Windows.Forms.PictureBox
    Friend WithEvents lblMarioStart As System.Windows.Forms.Label
    Friend WithEvents lblLives As System.Windows.Forms.Label
    Friend WithEvents pbGameover As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pbFireworks1 As System.Windows.Forms.PictureBox
    Friend WithEvents pbFireworks2 As System.Windows.Forms.PictureBox
    Friend WithEvents pbFireworks3 As System.Windows.Forms.PictureBox
    Friend WithEvents pbFireworks4 As System.Windows.Forms.PictureBox

End Class
