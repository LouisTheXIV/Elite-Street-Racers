Public Class Form1
    Dim speed As Integer = 0
    Dim road(15) As PictureBox
    Dim score As Integer
    Dim file As System.IO.StreamWriter
    Dim bluefile As System.IO.StreamWriter
    Dim line As Integer
    Dim line2 As Integer
    Dim blueline As Integer
    Dim raceline As Integer
    Dim greenline As Integer
    Dim monsterline As Integer
    Dim fireline As Integer
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Menu()
        speed = 3
        road(0) = PictureBox1
        road(1) = PictureBox2
        road(2) = PictureBox3
        road(3) = PictureBox4
        road(4) = PictureBox5
        road(5) = PictureBox6
        road(6) = PictureBox7
        road(7) = PictureBox8
        road(8) = PictureBox10
        road(9) = PictureBox11
        road(10) = PictureBox12
        road(11) = PictureBox13
        road(12) = PictureBox14
        road(13) = PictureBox15
        road(14) = PictureBox16
        road(15) = PictureBox17
    End Sub

    Private Sub RoadMover_Tick(sender As Object, e As EventArgs) Handles RoadMover.Tick
        For x As Integer = 0 To 15
            road(x).Top += speed
            If road(x).Top >= Me.Height Then
                road(x).Top = -road(x).Height
            End If
        Next
        If score > 10 And score < 20 Then
            speed = 4
        End If
        If score > 20 And score < 30 Then
            speed = 5
        End If
        If score > 30 And score < 40 Then
            speed = 6
        End If
        Speed_Text.Text = "Speed: " & speed
        If (PictureBox9.Bounds.IntersectsWith(Car1.Bounds)) Then
            gameOver()
        End If
        If (PictureBox9.Bounds.IntersectsWith(Car2.Bounds)) Then
            gameOver()
        End If
        If line2 = 5 Then
            If (PictureBox9.Bounds.IntersectsWith(Car3.Bounds)) Then
                Car3.Location = New Point(22, -25)
                My.Computer.Audio.Play(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\select.wav")
            End If
        End If
        If line2 = 0 Then
            If (PictureBox9.Bounds.IntersectsWith(Car3.Bounds)) Then
                gameOver()
            End If
        End If
        If line2 = 1 Then
            If (PictureBox9.Bounds.IntersectsWith(Car3.Bounds)) Then
                gameOver()
            End If
        End If
        If line2 = 2 Then
            If (PictureBox9.Bounds.IntersectsWith(Car3.Bounds)) Then
                gameOver()
            End If
        End If
        If line2 = 3 Then
            If (PictureBox9.Bounds.IntersectsWith(Car3.Bounds)) Then
                gameOver()
            End If
        End If
        If line2 = 4 Then
            If (PictureBox9.Bounds.IntersectsWith(Car3.Bounds)) Then
                gameOver()
            End If
        End If
        If score = 20 Then
            My.Computer.FileSystem.DeleteFile(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\logs\skin_green.txt")
            file = My.Computer.FileSystem.OpenTextFileWriter(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\logs\skin_green.txt", True)
            file.WriteLine("1")
            file.Close()
        End If
        If score = 60 Then
            My.Computer.FileSystem.DeleteFile(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\logs\skin_race.txt")
            file = My.Computer.FileSystem.OpenTextFileWriter(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\logs\skin_race.txt", True)
            file.WriteLine("1")
            file.Close()
        End If
        If score = 100 Then
            My.Computer.FileSystem.DeleteFile(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\logs\skin_fire.txt")
            file = My.Computer.FileSystem.OpenTextFileWriter(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\logs\skin_green.txt", True)
            file.WriteLine("1")
            file.Close()
        End If
    End Sub
    Private Sub Menu()
        line2 = My.Computer.FileSystem.ReadAllText((System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\logs\current_skin.txt"))
        If line2 = 4 Then
            PictureBox9.Image = Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\race2.png")
            PictureBox9.BackColor = Color.Transparent
            PictureBox9.Size = New Size(60, 120)
        End If
        If line2 = 5 Then
            PictureBox9.Image = Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\monstercar.png")
            PictureBox9.BackColor = Color.Transparent
            PictureBox9.Size = New Size(76, 97)
        End If
        If line2 = 3 Then
            PictureBox9.Image = Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\greenskin.png")
            PictureBox9.BackColor = Color.Transparent
        End If
        If line2 = 2 Then
            PictureBox9.Image = Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\blue_skin.png")
            PictureBox9.BackColor = Color.Transparent
        End If
        If line2 = 1 Then
            PictureBox9.Image = Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\you.png")
            PictureBox9.BackColor = Color.Transparent
        End If
        If line2 = 0 Then
            PictureBox9.Image = Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\black.png")
            PictureBox9.BackColor = Color.Transparent
        End If
        line = My.Computer.FileSystem.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\logs\volume_check.txt")
        If line = 1 Then
            My.Computer.Audio.Stop()
        End If
        If line = 2 Then

        End If
        Start_Button.Visible = True
        Help_Button.Visible = True
        Help_Button.Enabled = True
        RoadMover.Stop()
        Enemy1_Mover.Stop()
        Enemy2_Mover.Stop()
        Enemy3_Mover.Stop()
        Label1.Visible = False
        Speed_Text.Visible = False
        Skins_Button.Visible = True
        Skins_Button.Enabled = True
    End Sub
    Private Sub gameOver()
        My.Computer.Audio.Stop()
        My.Computer.Audio.Play(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\car_broke.wav")
        line = My.Computer.FileSystem.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\logs\volume_check.txt")
        If line = 1 Then
            My.Computer.Audio.Stop()
        End If
        If line = 2 Then
            My.Computer.Audio.Play(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\car_broke.wav")
        End If
        Replay_Button.Visible = True
        End_Text.Visible = True
        RoadMover.Stop()
        Enemy1_Mover.Stop()
        Enemy2_Mover.Stop()
        Enemy3_Mover.Stop()
        Pause_Picture.Visible = False
    End Sub
    Private Sub Pause()
        My.Computer.Audio.Stop()
        Quit_Button.Visible = True
        Pause_Label.Visible = True
        Enemy1_Mover.Enabled = False
        Enemy2_Mover.Enabled = False
        Enemy3_Mover.Enabled = False
        RoadMover.Enabled = False
        Replay_Button.Visible = True
        Continue_Button.Visible = True
        Continue_Button.Enabled = True
        Replay_Button.Text = "MainMenu"
        Quit_Button.Enabled = True
    End Sub
    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Right Then
            Right_mover.Start()
        End If
        If e.KeyCode = Keys.Left Then
            Left_mover().Start()
        End If
        If e.KeyCode = Keys.P Then
            Pause()
        End If
    End Sub

    Private Sub Right_mover_Tick(sender As Object, e As EventArgs) Handles Right_mover.Tick
        If (PictureBox9.Location.X < 438) Then
            PictureBox9.Left += 4
        End If
    End Sub

    Private Sub Left_mover_Tick(sender As Object, e As EventArgs) Handles Left_mover.Tick
        If (PictureBox9.Location.X > -1) Then
            PictureBox9.Left += -4
        End If
    End Sub

    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        Right_mover.Stop()
        Left_mover.Stop()
    End Sub

    Private Sub Enemy1_Mover_Tick(sender As Object, e As EventArgs) Handles Enemy1_Mover.Tick
        Car1.Top += speed / 2
        If Car1.Top >= Me.Height Then
            score += 1
            Label1.Text = "Score: " & score
            Car1.Top = -(CInt(Math.Ceiling(Rnd() * 398)) + Car1.Height)
            Car1.Left = CInt(Math.Ceiling(Rnd() * 50)) + 0
        End If
    End Sub

    Private Sub Enemy2_Mover_Tick(sender As Object, e As EventArgs) Handles Enemy2_Mover.Tick
        Car2.Top += speed
        If Car2.Top >= Me.Height Then
            score += 1
            Label1.Text = "Score: " & score
            Car2.Top = -(CInt(Math.Ceiling(Rnd() * 398)) + Car2.Height)
            Car2.Left = CInt(Math.Ceiling(Rnd() * 50)) + 100
        End If
    End Sub

    Private Sub Enemy3_Mover_Tick(sender As Object, e As EventArgs) Handles Enemy3_Mover.Tick
        Car3.Top += speed * 3 / 2
        If Car3.Top >= Me.Height Then
            score += 1
            Label1.Text = "Score: " & score
            Car3.Top = -(CInt(Math.Ceiling(Rnd() * 150)) + Car3.Height)
            Car3.Left = CInt(Math.Ceiling(Rnd() * 438)) + 0
        End If
    End Sub

    Private Sub Replay_Button_Click(sender As Object, e As EventArgs) Handles Replay_Button.Click
        My.Computer.Audio.Stop()
        score = 0
        Me.Controls.Clear()
        InitializeComponent()
        Form1_Load(e, e)
        If line = 1 Then
            My.Computer.Audio.Stop()
        End If
        If line = 2 Then
            My.Computer.Audio.Play(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\select.wav")
        End If
    End Sub

    Private Sub Start_Button_Click(sender As Object, e As EventArgs) Handles Start_Button.Click
        If line = 1 Then
            My.Computer.Audio.Stop()
        End If
        If line = 2 Then
            My.Computer.Audio.Play(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\select.wav")
        End If
        My.Computer.Audio.Play(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\car.wav", AudioPlayMode.BackgroundLoop)
        line = My.Computer.FileSystem.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\logs\volume_check.txt")
        If line = 1 Then
            My.Computer.Audio.Stop()
        End If
        Pause_Picture.Visible = True
        Quit_Button.Visible = False
        Quit_Button.Enabled = False
        RoadMover.Start()
        Enemy1_Mover.Start()
        Enemy2_Mover.Start()
        Enemy3_Mover.Start()
        Start_Button.Visible = False
        Start_Button.Enabled = False
        Help_Button.Enabled = False
        Help_Button.Visible = False
        Settings_Button.Visible = False
        Settings_Button.Enabled = False
        Label1.Visible = True
        Speed_Text.Visible = True
        About_Button.Visible = False
        About_Button.Enabled = False
        Skins_Button.Enabled = False
        Skins_Button.Visible = False
        Settings_Label.Visible = False
    End Sub

    Private Sub Help_Button_Click(sender As Object, e As EventArgs) Handles Help_Button.Click
        Quit_Button.Visible = False
        Quit_Button.Enabled = False
        Start_Button.Visible = False
        Label1.Visible = False
        Speed_Text.Visible = False
        Car1.Visible = False
        Car2.Visible = False
        Car3.Visible = False
        PictureBox9.Visible = False
        Help_Button.Visible = False
        Back_Button.Visible = True
        Back_Button.Enabled = True
        Label2.Visible = True
        Label3.Visible = True
        Label4.Visible = True
        Label5.Visible = True
        Label6.Visible = True
        Label7.Visible = True
        Label8.Visible = True
        Label9.Visible = True
        Label10.Visible = True
        Label11.Visible = True
        Settings_Button.Visible = False
        Pause_Desc_Help.Visible = True
        About_Button.Visible = False
        Skins_Button.Visible = False
        Settings_Label.Visible = False
        If line = 1 Then
            My.Computer.Audio.Stop()
        End If
        If line = 2 Then
            My.Computer.Audio.Play(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\select.wav")
        End If
    End Sub

    Private Sub Back_Button_Click(sender As Object, e As EventArgs) Handles Back_Button.Click
        Quit_Button.Visible = True
        Quit_Button.Enabled = True
        Start_Button.Visible = True
        Label1.Visible = True
        Speed_Text.Visible = True
        Car1.Visible = True
        Car2.Visible = True
        Car3.Visible = True
        PictureBox9.Visible = True
        Help_Button.Visible = True
        Settings_Button.Visible = True
        Back_Button.Visible = False
        Back_Button.Enabled = False
        Label2.Visible = False
        Label3.Visible = False
        Label4.Visible = False
        Label5.Visible = False
        Label6.Visible = False
        Label7.Visible = False
        Label8.Visible = False
        Label9.Visible = False
        Label10.Visible = False
        Label11.Visible = False
        Volume_On.Visible = False
        Volume_Off.Visible = False
        Volume_Label.Visible = False
        speed_num.Visible = False
        speed_label.Visible = False
        minus.Visible = False
        plus.Visible = False
        Pause_Desc_Help.Visible = False
        donate_button.Visible = False
        donate_label.Visible = False
        donate_label1.Visible = False
        donate_label2.Visible = False
        created_label.Visible = False
        About_Button.Visible = True
        created_label1.Visible = False
        Label1.Visible = False
        Speed_Text.Visible = False
        Skins_Button.Visible = True
        Skins_Button.Enabled = True
        blue_skin.Visible = False
        Settings_Label.Visible = True
        Racing_Skin.Visible = False
        Skin_Label.Visible = False
        race_skin_button.Visible = False
        blueskin_button.Visible = False
        original_skin.Visible = False
        original_skin_button.Visible = False
        green_skin_button.Visible = False
        green_skin.Visible = False
        monster_skin.Visible = False
        monster_skin_button.Visible = False
        monster_skin_label.Visible = False
        fire_skin.Visible = False
        fire_skin_button.Visible = False
        If line = 1 Then
            My.Computer.Audio.Stop()
        End If
        If line = 2 Then
            My.Computer.Audio.Play(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\select.wav")
        End If
    End Sub

    Private Sub Volume_On_Click(sender As Object, e As EventArgs) Handles Volume_On.Click
        Volume_On.Visible = False
        Volume_Off.Visible = True
        My.Computer.Audio.Stop()
        My.Computer.FileSystem.DeleteFile(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\logs\volume_check.txt")
        file = My.Computer.FileSystem.OpenTextFileWriter(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\logs\volume_check.txt", True)
        file.WriteLine("1")
        file.Close()
        If line = 1 Then
            My.Computer.Audio.Stop()
        End If
        If line = 2 Then
            My.Computer.Audio.Play(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\select.wav")
        End If
    End Sub
    Private Sub Volume_Off_Click(sender As Object, e As EventArgs) Handles Volume_Off.Click
        Volume_On.Visible = True
        Volume_Off.Visible = False
        My.Computer.FileSystem.DeleteFile(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\logs\volume_check.txt")
        file = My.Computer.FileSystem.OpenTextFileWriter(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\logs\volume_check.txt", True)
        file.WriteLine("2")
        file.Close()
        If line = 1 Then
            My.Computer.Audio.Stop()
        End If
        If line = 2 Then
            My.Computer.Audio.Play(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\select.wav")
        End If
    End Sub

    Private Sub minus_Click(sender As Object, e As EventArgs) Handles minus.Click
        speed -= 1
        speed_num.Text = speed
        If speed = 0 Then
            speed_num.Text = 1
            speed += 1
        End If
        If line = 1 Then
            My.Computer.Audio.Stop()
        End If
        If line = 2 Then
            My.Computer.Audio.Play(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\select.wav")
        End If
    End Sub

    Private Sub plus_Click(sender As Object, e As EventArgs) Handles plus.Click
        speed += 1
        speed_num.Text = speed
        If speed = 6 Then
            speed_num.Text = 5
            speed -= 1
        End If
        If line = 1 Then
            My.Computer.Audio.Stop()
        End If
        If line = 2 Then
            My.Computer.Audio.Play(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\select.wav")
        End If
    End Sub
    Private Sub Quit_Button_Click(sender As Object, e As EventArgs) Handles Quit_Button.Click
        Me.Close()
    End Sub

    Private Sub Continue_Button_Click(sender As Object, e As EventArgs) Handles Continue_Button.Click
        My.Computer.Audio.Play(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\logs\volume_check.txt", AudioPlayMode.BackgroundLoop)
        Enemy1_Mover.Enabled = True
        Enemy2_Mover.Enabled = True
        Enemy3_Mover.Enabled = True
        RoadMover.Enabled = True
        Replay_Button.Visible = False
        Continue_Button.Visible = False
        Continue_Button.Enabled = False
        Pause_Label.Visible = False
        Quit_Button.Visible = False
        Quit_Button.Enabled = False
        If line = 1 Then
            My.Computer.Audio.Stop()
        End If
        If line = 2 Then
            My.Computer.Audio.Play(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\select.wav")
        End If
    End Sub
    Private Sub Pause_Picture_Click(sender As Object, e As EventArgs) Handles Pause_Picture.Click
        Pause()
    End Sub

    Private Sub About_Button_Click(sender As Object, e As EventArgs) Handles About_Button.Click
        About_Button.Visible = False
        Quit_Button.Visible = False
        Quit_Button.Enabled = False
        Settings_Button.Visible = False
        Start_Button.Visible = False
        Label1.Visible = False
        Speed_Text.Visible = False
        Car1.Visible = False
        Car2.Visible = False
        Car3.Visible = False
        PictureBox9.Visible = False
        Help_Button.Visible = False
        Back_Button.Visible = True
        Back_Button.Enabled = True
        donate_button.Visible = True
        donate_label.Visible = True
        donate_label1.Visible = True
        donate_label2.Visible = True
        donate_button.Enabled = True
        created_label.Visible = True
        created_label1.Visible = True
        Skins_Button.Visible = False
        Settings_Label.Visible = False
        If line = 1 Then
            My.Computer.Audio.Stop()
        End If
        If line = 2 Then
            My.Computer.Audio.Play(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\select.wav")
        End If
    End Sub
    Private Sub donate_button_Click(sender As Object, e As EventArgs) Handles donate_button.Click
        System.Diagnostics.Process.Start("http://patreon.com")
    End Sub

    Private Sub Skins_Button_Click(sender As Object, e As EventArgs) Handles Skins_Button.Click
        Skins_Button.Visible = False
        About_Button.Visible = False
        Quit_Button.Visible = False
        Quit_Button.Enabled = False
        Settings_Button.Visible = False
        Start_Button.Visible = False
        Label1.Visible = False
        Speed_Text.Visible = False
        Car1.Visible = False
        Car2.Visible = False
        Car3.Visible = False
        PictureBox9.Visible = False
        Help_Button.Visible = False
        Back_Button.Visible = True
        Back_Button.Enabled = True
        blue_skin.Visible = True
        Settings_Label.Visible = False
        Skin_Label.Visible = True
        Racing_Skin.Visible = True
        race_skin_button.Visible = True
        blueskin_button.Visible = True
        original_skin.Visible = True
        original_skin_button.Visible = True
        green_skin.Visible = True
        green_skin_button.Visible = True
        monster_skin.Visible = True
        monster_skin_button.Visible = True
        monster_skin_label.Visible = True
        fire_skin.Visible = True
        fire_skin_button.Visible = True
        blueline = My.Computer.FileSystem.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\logs\skin_blue.txt")
        greenline = My.Computer.FileSystem.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\logs\skin_green.txt")
        fireline = My.Computer.FileSystem.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\logs\skin_fire.txt")
        monsterline = My.Computer.FileSystem.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\logs\skin_monster.txt")
        If monsterline = 1 Then
            monster_skin_button.Text = "Select"
        End If
        If greenline = 1 Then
            green_skin_button.Text = "Select"
        End If
        If blueline = 1 Then
            blueskin_button.Text = "Select"
        End If
        If fireline = 1 Then
            fire_skin_button.Text = "Select"
        End If
        raceline = My.Computer.FileSystem.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\logs\skin_race.txt")
        If raceline = 1 Then
            race_skin_button.Text = "Select"
        End If
        If line = 1 Then
            My.Computer.Audio.Stop()
        End If
        If line = 2 Then
            My.Computer.Audio.Play(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\select.wav")
        End If
    End Sub

    Private Sub Settings_Button_Click(sender As Object, e As EventArgs) Handles Settings_Button.Click
        Quit_Button.Visible = False
        Quit_Button.Enabled = False
        Settings_Button.Visible = False
        Start_Button.Visible = False
        Label1.Visible = False
        Speed_Text.Visible = False
        Car1.Visible = False
        Car2.Visible = False
        Car3.Visible = False
        PictureBox9.Visible = False
        Help_Button.Visible = False
        Back_Button.Visible = True
        Back_Button.Enabled = True
        Volume_Label.Visible = True
        speed_num.Visible = True
        speed_label.Visible = True
        speed_num.Text = speed
        minus.Visible = True
        plus.Visible = True
        About_Button.Visible = False
        Skins_Button.Visible = False
        Skins_Button.Enabled = False
        Settings_Label.Visible = False
        line = My.Computer.FileSystem.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\logs\volume_check.txt")
        If line = 2 Then
            Volume_On.Visible = True
            Volume_Label.Text = "Click the Volume Icon to turn off Volume"
        End If
        If line = 1 Then
            Volume_Off.Visible = True
            Volume_Label.Text = "Click the Volume Icon to turn on Volume"
        End If
        If line = 1 Then
            My.Computer.Audio.Stop()
        End If
        If line = 2 Then
            My.Computer.Audio.Play(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\select.wav")
        End If
    End Sub

    Private Sub blueskin_button_Click(sender As Object, e As EventArgs) Handles blueskin_button.Click
        blueline = My.Computer.FileSystem.ReadAllText("C:\Users\alext\OneDrive\Desktop\RacingGame\RacingGame\assets\logs\skin_blue.txt")
        If blueline = 0 Then
            System.Diagnostics.Process.Start("https://www.youtube.com/channel/UChJdYcnvUGkUzl0rH4orcog/featured?sub_confirmation=1")
        End If
        PictureBox9.Image = Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\blue_skin.png")
        PictureBox9.BackColor = Color.Transparent
        PictureBox9.Size = New Size(43, 74)
        My.Computer.FileSystem.DeleteFile(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\logs\current_skin.txt")
        file = My.Computer.FileSystem.OpenTextFileWriter(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\logs\current_skin.txt", True)
        file.WriteLine("2")
        file.Close()
        My.Computer.FileSystem.DeleteFile(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\logs\skin_blue.txt")
        bluefile = My.Computer.FileSystem.OpenTextFileWriter(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\logs\skin_blue.txt", True)
        bluefile.WriteLine("1")
        bluefile.Close()
        If line = 1 Then
            My.Computer.Audio.Stop()
        End If
        If line = 2 Then
            My.Computer.Audio.Play(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\select.wav")
        End If
    End Sub

    Private Sub race_skin_button_Click(sender As Object, e As EventArgs) Handles race_skin_button.Click
        raceline = My.Computer.FileSystem.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\logs\skin_race.txt")
        If raceline = 1 Then
            PictureBox9.Image = Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\you.png")
            PictureBox9.BackColor = Color.Transparent
            PictureBox9.Size = New Size(43, 74)
            My.Computer.FileSystem.DeleteFile(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\logs\current_skin.txt")
            file = My.Computer.FileSystem.OpenTextFileWriter(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\logs\current_skin.txt", True)
            file.WriteLine("1")
            file.Close()
            If line = 1 Then
                My.Computer.Audio.Stop()
            End If
            If line = 2 Then
                My.Computer.Audio.Play(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\select.wav")
            End If
        End If
    End Sub
    Private Sub original_skin_button_Click(sender As Object, e As EventArgs) Handles original_skin_button.Click
        PictureBox9.Image = Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\black.png")
        PictureBox9.BackColor = Color.Transparent
        PictureBox9.Size = New Size(43, 74)
        My.Computer.FileSystem.DeleteFile(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\logs\current_skin.txt")
        file = My.Computer.FileSystem.OpenTextFileWriter(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\logs\current_skin.txt", True)
        file.WriteLine("0")
        file.Close()
        If line = 1 Then
            My.Computer.Audio.Stop()
        End If
        If line = 2 Then
            My.Computer.Audio.Play(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\select.wav")
        End If
    End Sub
    Private Sub green_skin_button_Click(sender As Object, e As EventArgs) Handles green_skin_button.Click
        greenline = My.Computer.FileSystem.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\logs\skin_green.txt")
        If greenline = 1 Then
            PictureBox9.Image = Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\greenskin.png")
            PictureBox9.BackColor = Color.Transparent
            PictureBox9.Size = New Size(43, 74)
            My.Computer.FileSystem.DeleteFile(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\logs\current_skin.txt")
            file = My.Computer.FileSystem.OpenTextFileWriter(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\logs\current_skin.txt", True)
            file.WriteLine("3")
            file.Close()
            If line = 1 Then
                My.Computer.Audio.Stop()
            End If
            If line = 2 Then
                My.Computer.Audio.Play(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\select.wav")
            End If
        End If
    End Sub
    Private Sub monster_skin_button_Click(sender As Object, e As EventArgs) Handles monster_skin_button.Click
        monsterline = My.Computer.FileSystem.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\logs\skin_monster.txt")
        If monsterline = 1 Then
            PictureBox9.Image = Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\monstercar.png")
            PictureBox9.BackColor = Color.Transparent
            PictureBox9.Size = New Size(76, 97)
            My.Computer.FileSystem.DeleteFile(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\logs\current_skin.txt")
            file = My.Computer.FileSystem.OpenTextFileWriter(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\logs\current_skin.txt", True)
            file.WriteLine("5")
            file.Close()
            If line = 1 Then
                My.Computer.Audio.Stop()
            End If
            If line = 2 Then
                My.Computer.Audio.Play(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\select.wav")
            End If
        End If
    End Sub

    Private Sub fire_skin_button_Click(sender As Object, e As EventArgs) Handles fire_skin_button.Click
        fireline = My.Computer.FileSystem.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\logs\skin_fire.txt")
        If fireline = 1 Then
            PictureBox9.Image = Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\race2.png")
            PictureBox9.BackColor = Color.Transparent
            PictureBox9.Size = New Size(60, 120)
            My.Computer.FileSystem.DeleteFile(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\logs\current_skin.txt")
            file = My.Computer.FileSystem.OpenTextFileWriter(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\logs\current_skin.txt", True)
            file.WriteLine("4")
            file.Close()
            If line = 1 Then
                My.Computer.Audio.Stop()
            End If
            If line = 2 Then
                My.Computer.Audio.Play(System.AppDomain.CurrentDomain.BaseDirectory & "\RacingGame\assets\select.wav")
            End If
        End If
    End Sub
End Class

