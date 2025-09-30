namespace Race
{
	partial class RaceGame
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RaceGame));
            timerRoad = new System.Windows.Forms.Timer(components);
            panelGame = new Panel();
            panelPause = new Panel();
            panelMenu = new Panel();
            buttonHelp = new Button();
            buttonMenuExit = new Button();
            buttonStart = new Button();
            label3 = new Label();
            CarMenu1 = new PictureBox();
            CarMenu3 = new PictureBox();
            CarMenu2 = new PictureBox();
            label12 = new Label();
            buttonExit = new Button();
            buttonResume = new Button();
            pictureFlag = new PictureBox();
            labelPause = new Label();
            labelScore = new Label();
            labelCoins = new Label();
            label = new Label();
            towardCar2 = new PictureBox();
            towardCar1 = new PictureBox();
            towardCar3 = new PictureBox();
            //Coin3 = new PictureBox();
            //Coin2 = new PictureBox();
            //Coin1 = new PictureBox();
            buttonPause = new Button();
            mainCar = new PictureBox();
            MiddleLane = new Label();
            timerTowardCars = new System.Windows.Forms.Timer(components);
            timerMenu = new System.Windows.Forms.Timer(components);
            panelGame.SuspendLayout();
            panelPause.SuspendLayout();
            panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CarMenu1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CarMenu3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CarMenu2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureFlag).BeginInit();
            ((System.ComponentModel.ISupportInitialize)towardCar2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)towardCar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)towardCar3).BeginInit();
            //((System.ComponentModel.ISupportInitialize)Coin3).BeginInit();
            //((System.ComponentModel.ISupportInitialize)Coin2).BeginInit();
            //((System.ComponentModel.ISupportInitialize)Coin1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mainCar).BeginInit();
            SuspendLayout();
            // 
            // timerRoad
            // 
            timerRoad.Enabled = true;
            timerRoad.Interval = 1;
            timerRoad.Tick += timerRoad_Tick;
            // 
            // panelGame
            // 
            panelGame.BackColor = SystemColors.ControlDarkDark;
            panelGame.Controls.Add(panelPause);
            panelGame.Controls.Add(labelScore);
            panelGame.Controls.Add(labelCoins);
            panelGame.Controls.Add(label);
            panelGame.Controls.Add(towardCar2);
            panelGame.Controls.Add(towardCar1);
            panelGame.Controls.Add(towardCar3);
            //panelGame.Controls.Add(Coin3);
            //panelGame.Controls.Add(Coin2);
            //panelGame.Controls.Add(Coin1);
            panelGame.Controls.Add(buttonPause);
            panelGame.Controls.Add(mainCar);
            panelGame.Controls.Add(MiddleLane);
            panelGame.Location = new Point(0, 0);
            panelGame.Margin = new Padding(4);
            panelGame.Name = "panelGame";
            panelGame.Size = new Size(448, 650);
            panelGame.TabIndex = 0;
            // 
            // panelPause
            // 
            panelPause.BackColor = SystemColors.ControlDarkDark;
            panelPause.Controls.Add(panelMenu);
            panelPause.Controls.Add(buttonExit);
            panelPause.Controls.Add(buttonResume);
            panelPause.Controls.Add(pictureFlag);
            panelPause.Controls.Add(labelPause);
            panelPause.Location = new Point(0, 0);
            panelPause.Margin = new Padding(4);
            panelPause.Name = "panelPause";
            panelPause.Size = new Size(451, 654);
            panelPause.TabIndex = 57;
            // 
            // panelMenu
            // 
            panelMenu.BackColor = SystemColors.ControlDarkDark;
            panelMenu.Controls.Add(buttonHelp);
            panelMenu.Controls.Add(buttonMenuExit);
            panelMenu.Controls.Add(buttonStart);
            panelMenu.Controls.Add(label3);
            panelMenu.Controls.Add(CarMenu1);
            panelMenu.Controls.Add(CarMenu3);
            panelMenu.Controls.Add(CarMenu2);
            panelMenu.Controls.Add(label12);
            panelMenu.Location = new Point(0, 0);
            panelMenu.Margin = new Padding(4);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(450, 650);
            panelMenu.TabIndex = 57;
            // 
            // buttonHelp
            // 
            buttonHelp.Font = new Font("Microsoft YaHei", 10F, FontStyle.Bold, GraphicsUnit.Point);
            buttonHelp.Location = new Point(361, 609);
            buttonHelp.Margin = new Padding(4);
            buttonHelp.Name = "buttonHelp";
            buttonHelp.Size = new Size(81, 37);
            buttonHelp.TabIndex = 82;
            buttonHelp.Text = "Help";
            buttonHelp.UseVisualStyleBackColor = true;
            buttonHelp.Click += buttonHelp_Click;
            // 
            // buttonMenuExit
            // 
            buttonMenuExit.Font = new Font("Microsoft YaHei", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            buttonMenuExit.Location = new Point(146, 380);
            buttonMenuExit.Margin = new Padding(4);
            buttonMenuExit.Name = "buttonMenuExit";
            buttonMenuExit.Size = new Size(154, 54);
            buttonMenuExit.TabIndex = 67;
            buttonMenuExit.Text = "Exit";
            buttonMenuExit.UseVisualStyleBackColor = true;
            buttonMenuExit.Click += buttonMenuExit_Click;
            // 
            // buttonStart
            // 
            buttonStart.Font = new Font("Microsoft YaHei", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            buttonStart.Location = new Point(130, 304);
            buttonStart.Margin = new Padding(4);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(186, 68);
            buttonStart.TabIndex = 65;
            buttonStart.Text = "Start";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(64, 64, 64);
            label3.Font = new Font("Microsoft Tai Le", 105F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(0, 0);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(384, 178);
            label3.TabIndex = 66;
            label3.Text = "Race";
            // 
            // CarMenu1
            // 
            CarMenu1.BackColor = Color.Transparent;
            CarMenu1.Image = (Image)resources.GetObject("CarMenu1.Image");
            CarMenu1.Location = new Point(14, 15);
            CarMenu1.Margin = new Padding(4);
            CarMenu1.Name = "CarMenu1";
            CarMenu1.Size = new Size(59, 127);
            CarMenu1.SizeMode = PictureBoxSizeMode.Zoom;
            CarMenu1.TabIndex = 80;
            CarMenu1.TabStop = false;
            // 
            // CarMenu3
            // 
            CarMenu3.BackColor = Color.Transparent;
            CarMenu3.Image = (Image)resources.GetObject("CarMenu3.Image");
            CarMenu3.Location = new Point(375, 30);
            CarMenu3.Margin = new Padding(4);
            CarMenu3.Name = "CarMenu3";
            CarMenu3.Size = new Size(59, 127);
            CarMenu3.SizeMode = PictureBoxSizeMode.Zoom;
            CarMenu3.TabIndex = 81;
            CarMenu3.TabStop = false;
            // 
            // CarMenu2
            // 
            CarMenu2.BackColor = Color.Transparent;
            CarMenu2.Image = (Image)resources.GetObject("CarMenu2.Image");
            CarMenu2.Location = new Point(150, 4);
            CarMenu2.Margin = new Padding(4);
            CarMenu2.Name = "CarMenu2";
            CarMenu2.Size = new Size(59, 127);
            CarMenu2.SizeMode = PictureBoxSizeMode.Zoom;
            CarMenu2.TabIndex = 79;
            CarMenu2.TabStop = false;
            // 
            // label12
            // 
            label12.BackColor = Color.White;
            label12.ForeColor = SystemColors.Control;
            label12.Location = new Point(214, -4);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(20, 654);
            label12.TabIndex = 68;
            label12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonExit
            // 
            buttonExit.Font = new Font("Microsoft YaHei", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            buttonExit.Location = new Point(139, 555);
            buttonExit.Margin = new Padding(4);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(178, 46);
            buttonExit.TabIndex = 53;
            buttonExit.Text = "Exit";
            buttonExit.UseVisualStyleBackColor = true;
            buttonExit.Click += buttonExit_Click;
            // 
            // buttonResume
            // 
            buttonResume.Font = new Font("Microsoft YaHei", 22F, FontStyle.Bold, GraphicsUnit.Point);
            buttonResume.Location = new Point(139, 469);
            buttonResume.Margin = new Padding(4);
            buttonResume.Name = "buttonResume";
            buttonResume.Size = new Size(178, 67);
            buttonResume.TabIndex = 52;
            buttonResume.Text = "Resume";
            buttonResume.UseVisualStyleBackColor = true;
            buttonResume.Click += buttonResume_Click;
            // 
            // pictureFlag
            // 
            pictureFlag.BackColor = SystemColors.ControlDarkDark;
            pictureFlag.Image = (Image)resources.GetObject("pictureFlag.Image");
            pictureFlag.Location = new Point(-3, 124);
            pictureFlag.Margin = new Padding(4);
            pictureFlag.Name = "pictureFlag";
            pictureFlag.Size = new Size(451, 364);
            pictureFlag.SizeMode = PictureBoxSizeMode.Zoom;
            pictureFlag.TabIndex = 55;
            pictureFlag.TabStop = false;
            // 
            // labelPause
            // 
            labelPause.AutoSize = true;
            labelPause.Font = new Font("Microsoft YaHei", 90F, FontStyle.Bold, GraphicsUnit.Point);
            labelPause.Location = new Point(0, 0);
            labelPause.Margin = new Padding(4, 0, 4, 0);
            labelPause.Name = "labelPause";
            labelPause.Size = new Size(422, 159);
            labelPause.TabIndex = 54;
            labelPause.Text = "Pause";
            // 
            // labelScore
            // 
            labelScore.AutoSize = true;
            labelScore.BackColor = Color.Black;
            labelScore.Font = new Font("Microsoft YaHei", 22F, FontStyle.Bold, GraphicsUnit.Point);
            labelScore.ForeColor = SystemColors.ButtonHighlight;
            labelScore.Location = new Point(14, 10);
            labelScore.Margin = new Padding(4, 0, 4, 0);
            labelScore.Name = "labelScore";
            labelScore.Size = new Size(110, 40);
            labelScore.TabIndex = 56;
            labelScore.Text = "Score:";
            // 
            // labelCoins
            // 
            labelCoins.AutoSize = true;
            labelCoins.BackColor = Color.Black;
            labelCoins.Font = new Font("Microsoft YaHei", 22F, FontStyle.Bold, GraphicsUnit.Point);
            labelCoins.ForeColor = SystemColors.ButtonHighlight;
            labelCoins.Location = new Point(242, 10);
            labelCoins.Margin = new Padding(4, 0, 4, 0);
            labelCoins.Name = "labelCoins";
            labelCoins.Size = new Size(109, 40);
            labelCoins.TabIndex = 57;
            labelCoins.Text = "Coins:";
            // 
            // label
            // 
            label.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label.BackColor = SystemColors.ActiveCaptionText;
            label.Font = new Font("Microsoft Sans Serif", 100F, FontStyle.Regular, GraphicsUnit.Point);
            label.ForeColor = SystemColors.ControlText;
            label.Location = new Point(-3, 0);
            label.Margin = new Padding(4, 0, 4, 0);
            label.Name = "label";
            label.Size = new Size(451, 68);
            label.TabIndex = 55;
            // 
            // towardCar2
            // 
            towardCar2.BackColor = Color.Transparent;
            towardCar2.Image = Properties.Resources.towardsCar2;
            towardCar2.Location = new Point(14, 26);
            towardCar2.Margin = new Padding(4);
            towardCar2.Name = "towardCar2";
            towardCar2.Size = new Size(59, 127);
            towardCar2.SizeMode = PictureBoxSizeMode.Zoom;
            towardCar2.TabIndex = 49;
            towardCar2.TabStop = false;
            // 
            // towardCar1
            // 
            towardCar1.BackColor = Color.Transparent;
            towardCar1.Image = Properties.Resources.towardsCar1;
            towardCar1.Location = new Point(150, 15);
            towardCar1.Margin = new Padding(4);
            towardCar1.Name = "towardCar1";
            towardCar1.Size = new Size(59, 127);
            towardCar1.SizeMode = PictureBoxSizeMode.Zoom;
            towardCar1.TabIndex = 48;
            towardCar1.TabStop = false;
            // 
            // towardCar3
            // 
            towardCar3.BackColor = Color.Transparent;
            towardCar3.Image = Properties.Resources.towardsCar3;
            towardCar3.Location = new Point(375, 41);
            towardCar3.Margin = new Padding(4);
            towardCar3.Name = "towardCar3";
            towardCar3.Size = new Size(59, 127);
            towardCar3.SizeMode = PictureBoxSizeMode.Zoom;
            towardCar3.TabIndex = 50;
            towardCar3.TabStop = false;
            //// 
            //// Coin3
            //// 
            //Coin3.BackColor = Color.Transparent;
            //Coin3.Image = Properties.Resources.Coin;
            //Coin3.Location = new Point(375, 257);
            //Coin3.Margin = new Padding(4);
            //Coin3.Name = "Coin3";
            //Coin3.Size = new Size(39, 37);
            //Coin3.SizeMode = PictureBoxSizeMode.Zoom;
            //Coin3.TabIndex = 54;
            //Coin3.TabStop = false;
            //// 
            //// Coin2
            //// 
            //Coin2.BackColor = Color.Transparent;
            //Coin2.Image = Properties.Resources.Coin;
            //Coin2.Location = new Point(258, 180);
            //Coin2.Margin = new Padding(4);
            //Coin2.Name = "Coin2";
            //Coin2.Size = new Size(39, 37);
            //Coin2.SizeMode = PictureBoxSizeMode.Zoom;
            //Coin2.TabIndex = 53;
            //Coin2.TabStop = false;
            //// 
            //// Coin1
            //// 
            //Coin1.BackColor = Color.Transparent;
            //Coin1.Image = Properties.Resources.Coin;
            //Coin1.Location = new Point(129, 291);
            //Coin1.Margin = new Padding(4);
            //Coin1.Name = "Coin1";
            //Coin1.Size = new Size(39, 37);
            //Coin1.SizeMode = PictureBoxSizeMode.Zoom;
            //Coin1.TabIndex = 52;
            //Coin1.TabStop = false;
            // 
            // buttonPause
            // 
            buttonPause.Font = new Font("Microsoft YaHei", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonPause.Location = new Point(0, 602);
            buttonPause.Margin = new Padding(4);
            buttonPause.Name = "buttonPause";
            buttonPause.Size = new Size(95, 44);
            buttonPause.TabIndex = 1;
            buttonPause.Text = "Pause";
            buttonPause.UseVisualStyleBackColor = true;
            buttonPause.Click += buttonPause_Click;
            // 
            // mainCar
            // 
            mainCar.BackColor = Color.Transparent;
            mainCar.BackgroundImageLayout = ImageLayout.None;
            mainCar.Image = (Image)resources.GetObject("mainCar.Image");
            mainCar.Location = new Point(258, 508);
            mainCar.Margin = new Padding(4);
            mainCar.Name = "mainCar";
            mainCar.Size = new Size(59, 127);
            mainCar.SizeMode = PictureBoxSizeMode.Zoom;
            mainCar.TabIndex = 47;
            mainCar.TabStop = false;
            // 
            // MiddleLane
            // 
            MiddleLane.BackColor = Color.White;
            MiddleLane.ForeColor = SystemColors.Control;
            MiddleLane.Location = new Point(214, -4);
            MiddleLane.Margin = new Padding(4, 0, 4, 0);
            MiddleLane.Name = "MiddleLane";
            MiddleLane.Size = new Size(20, 654);
            MiddleLane.TabIndex = 33;
            MiddleLane.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timerTowardCars
            // 
            timerTowardCars.Enabled = true;
            timerTowardCars.Interval = 1;
            timerTowardCars.Tick += timerTowardCars_Tick;
            // 
            // timerMenu
            // 
            timerMenu.Enabled = true;
            timerMenu.Interval = 1;
            timerMenu.Tick += timerMenu_Tick;
            // 
            // RaceGame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(448, 649);
            Controls.Add(panelGame);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            KeyPreview = true;
            Margin = new Padding(4);
            Name = "RaceGame";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Race";
            Load += RaceGame_Load;
            KeyDown += RaceGame_KeyDown;
            panelGame.ResumeLayout(false);
            panelGame.PerformLayout();
            panelPause.ResumeLayout(false);
            panelPause.PerformLayout();
            panelMenu.ResumeLayout(false);
            panelMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)CarMenu1).EndInit();
            ((System.ComponentModel.ISupportInitialize)CarMenu3).EndInit();
            ((System.ComponentModel.ISupportInitialize)CarMenu2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureFlag).EndInit();
            ((System.ComponentModel.ISupportInitialize)towardCar2).EndInit();
            ((System.ComponentModel.ISupportInitialize)towardCar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)towardCar3).EndInit();
            //((System.ComponentModel.ISupportInitialize)Coin3).EndInit();
            //((System.ComponentModel.ISupportInitialize)Coin2).EndInit();
            //((System.ComponentModel.ISupportInitialize)Coin1).EndInit();
            ((System.ComponentModel.ISupportInitialize)mainCar).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Timer timerRoad;
		private System.Windows.Forms.Panel panelGame;
		
		private System.Windows.Forms.Label MiddleLane;
		private System.Windows.Forms.PictureBox towardCar2;
		private System.Windows.Forms.PictureBox towardCar3;
		private System.Windows.Forms.PictureBox towardCar1;
		private System.Windows.Forms.PictureBox mainCar;
		private System.Windows.Forms.Timer timerTowardCars;
		private System.Windows.Forms.Timer timerMenu;
		private System.Windows.Forms.Label labelPause;
		private System.Windows.Forms.Button buttonExit;
		private System.Windows.Forms.Button buttonResume;
		private System.Windows.Forms.Button buttonPause;
		//private System.Windows.Forms.PictureBox Coin1;
		//private System.Windows.Forms.PictureBox Coin3;
		//private System.Windows.Forms.PictureBox Coin2;
		private System.Windows.Forms.Panel panelPause;
		private System.Windows.Forms.PictureBox pictureFlag;
		private System.Windows.Forms.Label labelCoins;
		private System.Windows.Forms.Label labelScore;
		private System.Windows.Forms.Label label;
		private Panel panelMenu;
		private Button buttonHelp;
		private Button buttonMenuExit;
		private Button buttonStart;
		private Label label3;
		private PictureBox CarMenu1;
		private PictureBox CarMenu3;
		private PictureBox CarMenu2;
		
		private Label label12;
	}
}