namespace Race
{
    public partial class RaceGame : Form
    {
        public RaceGame()
        {
            InitializeComponent();
        }
        // Прерывистая разметка в игре
        List<Label> linesGame;

        // Прерывистая разметка в меню
        List<Label> linesMenu;

        Random r = new Random();
        int score = 0;
        int coins = 0;
        int carSpeed = 2;

        /// <summary>
        /// Обработчик движения трассы(полосы, монеты) в процессе игры 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerRoad_Tick(object sender, EventArgs e)
        {
            // Отображение набранных очков
            labelScore.Text = "Score: " + score / 10;

            if (carSpeed != 0)
                score++;

            MoveLines(linesGame);

            foreach (var line in linesGame)
            {
                line.Top += carSpeed;
                if (line.Top >= Height)
                {
                    line.Top = -line.Height;
                }

                if (carSpeed != 0)
                    score++;

            }


            #region Механизм генерации монет в верху в новом месте по оси X после выхода за экран нижней границы формы
            Coin1.Top += carSpeed;
            if (Coin1.Top > Height)
            {
                Coin1.Top = -Coin1.Height;
                Coin1.Left = r.Next(0, Width - Coin1.Width);
            }
            Coin2.Top += carSpeed;
            if (Coin2.Top > Height)
            {
                Coin2.Top = -Coin2.Height;
                Coin2.Left = r.Next(0, Width - Coin2.Width);
            }
            Coin3.Top += carSpeed;
            if (Coin3.Top > Height)
            {
                Coin3.Top = -Coin3.Height;
                Coin3.Left = r.Next(0, Width - Coin3.Width);
            }
            #endregion
            coinsCollect();
        }

        private void MoveLines(List<Label> lines)
        {
            foreach (var line in lines)
            {
                line.Top += carSpeed;
                if (line.Top >= Height)
                    line.Top = -line.Height;
            }
        }

        /// <summary>
        /// Метод подсчитывающий кол-во собранных монеток
        /// </summary>
        void coinsCollect()
        {
            if (mainCar.Bounds.IntersectsWith(Coin1.Bounds))
            {
                coins++;
                labelCoins.Text = "Coins: " + coins;
                Coin1.Top = -Coin1.Height;
                Coin1.Left = r.Next(0, 120);
            }
            if (mainCar.Bounds.IntersectsWith(Coin2.Bounds))
            {
                coins++;
                labelCoins.Text = "Coins: " + coins;
                Coin2.Top = -Coin2.Height;
                Coin2.Left = r.Next(120, 240);
            }
            if (mainCar.Bounds.IntersectsWith(Coin3.Bounds))
            {
                coins++;
                labelCoins.Text = "Coins: " + coins;
                Coin3.Top = -Coin3.Height;
                Coin3.Left = r.Next(240, 300);
            }
        }

        /// <summary>
        /// Инициализация разметки и запуск движения на панели меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RaceGame_Load(object sender, EventArgs e)
        {
            linesGame = CreateLines();
            panelGame.Controls.AddRange(linesGame.ToArray());

            linesMenu = CreateLines();
            panelMenu.Controls.AddRange(linesMenu.ToArray());

            timerRoad.Stop();
            timerTowardCars.Stop();
            panelMenu.Show();
        }

        private void RaceGame_KeyDown(object sender, KeyEventArgs e)
        {
            if (carSpeed != 0)
            {
                if (e.KeyCode == Keys.Right)
                {
                    //380
                    if (mainCar.Right < 500)
                        mainCar.Left += 9;
                }
                if (e.KeyCode == Keys.Left)
                {
                    if (mainCar.Left > 0)
                        mainCar.Left -= 9;
                }
            }
            if (e.KeyCode == Keys.Up)
            {
                if (carSpeed < 21)
                    carSpeed++;
            }
            if (e.KeyCode == Keys.Down)
            {
                if (carSpeed > 0)
                    carSpeed--;
            }
            if (e.KeyCode == Keys.Escape)
            {
                timerRoad.Enabled = false;
                timerTowardCars.Enabled = false;
                panelPause.Show();
            }
        }
        /// <summary>
        /// Обработчик движения встречных машин в процессе игры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerTowardCars_Tick(object sender, EventArgs e)
        {
            towardCar1.Top += carSpeed + 4;
            if (towardCar1.Top > Height)
            {
                towardCar1.Top = -towardCar1.Height;
                towardCar1.Left = r.Next(0, Width - towardCar1.Width);
            }

            towardCar2.Top += carSpeed + 2;
            if (towardCar2.Top > Height)
            {
                towardCar2.Top = -towardCar2.Height;
                towardCar2.Left = r.Next(0, Width - towardCar2.Width);
            }

            towardCar3.Top += carSpeed + 3;
            if (towardCar3.Top > Height)
            {
                towardCar3.Top = -towardCar3.Height;
                towardCar3.Left = r.Next(0, Width - towardCar3.Width);
            }

            if (mainCar.Bounds.IntersectsWith(towardCar1.Bounds))
                GameOver();
            if (mainCar.Bounds.IntersectsWith(towardCar2.Bounds))
                GameOver();
            if (mainCar.Bounds.IntersectsWith(towardCar3.Bounds))
                GameOver();
        }
        private void GameOver()
        {
            timerRoad.Stop();
            timerTowardCars.Stop();
            if (coins < 15)
            {
                DialogResult dd = MessageBox.Show("Game Over!", "Приехали!");
                panelPause.Show();
                panelMenu.Show();
            }
            else
            {
                DialogResult dr = MessageBox.Show("Продолжить? (-15 coins)", "Приехали!",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                    Restart();
                else if (dr == DialogResult.No)
                {
                    panelPause.Show();
                    panelMenu.Show();
                }
            }
        }

        private void Restart()
        {
            coins -= 15;
            labelCoins.Text = "Coins: " + coins;
            carSpeed = 2;
            timerRoad.Start();
            timerTowardCars.Start();
            towardCar1.Top = -towardCar1.Height;
            towardCar1.Left = r.Next(0, Width - towardCar1.Width);
            towardCar2.Top = -towardCar2.Height;
            towardCar2.Left = r.Next(0, Width - towardCar2.Width);
            towardCar3.Top = -towardCar3.Height;
            towardCar3.Left = r.Next(0, Width - towardCar3.Width);
        }
        private void StartGame()
        {
            score = 0;
            coins = 0;
            carSpeed = 2;
            timerRoad.Start();
            timerTowardCars.Start();
            towardCar1.Top = -towardCar1.Height;
            towardCar1.Left = r.Next(0, Width - towardCar1.Width);
            towardCar2.Top = -towardCar2.Height;
            towardCar2.Left = r.Next(0, Width - towardCar2.Width);
            towardCar3.Top = -towardCar3.Height;
            towardCar3.Left = r.Next(0, Width - towardCar3.Width);
            panelPause.Hide();
            panelGame.Show();
            panelMenu.Hide();
        }
        private void timerMenu_Tick(object sender, EventArgs e)
        {
            MoveLines(linesMenu);

            CarMenu1.Top += 5;
            if (CarMenu1.Top > Height)
            {

                CarMenu1.Top = -CarMenu1.Height;
                CarMenu1.Left = r.Next(0, Width - CarMenu1.Width);
            }
            CarMenu2.Top += 3;
            if (CarMenu2.Top > Height)
            {
                CarMenu2.Top = -CarMenu2.Height;
                CarMenu2.Left = r.Next(0, Width - CarMenu2.Width);
            }
            CarMenu3.Top += 4;
            if (CarMenu3.Top > Height)
            {
                CarMenu3.Top = -CarMenu3.Height;
                CarMenu3.Left = r.Next(0, Width - CarMenu3.Width);
            }
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {

            timerRoad.Enabled = false;
            timerTowardCars.Enabled = false;
            panelPause.Show();
        }

        private void buttonResume_Click(object sender, EventArgs e)
        {
            timerRoad.Enabled = true;
            timerTowardCars.Enabled = true;
            panelPause.Hide();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            panelMenu.Show();
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, @"C:\Users\khha4\Race\help.chm", HelpNavigator.TableOfContents);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            StartGame();
            panelGame.Show();
            panelMenu.Hide();
        }

        private void buttonMenuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Генерация дорожной разметки
        /// </summary>
        /// <returns></returns>
        private List<Label> CreateLines()
        {
            int startX = 104;
            int horisontalDistanceLines = 233;

            int startY = -49;
            int verticalDistanceLines = 162;

            var lines = new List<Label>();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Label line = new Label();

                    int X = startX + horisontalDistanceLines * j;
                    int Y = startY + verticalDistanceLines * i;
                    line.Location = new Point(X, Y);
                    line.BackColor = Color.White;
                    line.Size = new Size(18, 104);
                    lines.Add(line);
                }
            }
            return lines;
        }

    }
}

