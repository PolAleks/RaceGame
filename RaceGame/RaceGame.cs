namespace Race
{
    public partial class RaceGame : Form
    {
        public RaceGame()
        {
            InitializeComponent();
        }
        // Прерывистая разметка в игре
        private List<Label> linesGame;

        // Прерывистая разметка в меню
        private List<Label> linesMenu;

        // Монеты
        private List<PictureBox> coins;
        private int countCoins = 3;

        private List<PictureBox> carGame;
        private List<PictureBox> carMenu;

        Random r = new Random();
        int score = 0;
        int collectedCoins = 0;
        int carSpeed = 2;

        /// <summary>
        /// Инициализация разметки, монет и запуск анимации движения в панели меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RaceGame_Load(object sender, EventArgs e)
        {
            coins = CreateCoins();
            panelGame.Controls.AddRange(coins.ToArray());

            linesGame = CreateLines();
            panelGame.Controls.AddRange(linesGame.ToArray());

            linesMenu = CreateLines();
            panelMenu.Controls.AddRange(linesMenu.ToArray());

            timerRoad.Stop();
            timerTowardCars.Stop();
            panelMenu.Show();
        }

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

            MoveCoins();

            CollectCoins();
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


        /// <summary>
        /// Генерация стартовой позиции монетки
        /// </summary>
        /// <param name="widthCoin">Возвращает Point</param>
        /// <returns></returns>
        private Point GetPositionCoin(int widthCoin)
        {
            int x = r.Next(0, Width - widthCoin);
            int y = -widthCoin;
            return new Point(x, y);
        }

        /// <summary>
        /// Анимацию движения дорожней разметки
        /// </summary>
        /// <param name="lines"></param>
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
        /// Анимация движения монеток на игровом поле 
        /// </summary>
        private void MoveCoins()
        {
            foreach (var coin in coins)
            {
                coin.Top += carSpeed;
                if (coin.Top > Height)
                {
                    coin.Location = GetPositionCoin(coin.Width);
                }
            }
        }

        /// <summary>
        /// Подсчет собранных монеток
        /// </summary>
        void CollectCoins()
        {
            foreach (var coin in coins)
            {
                if (mainCar.Bounds.IntersectsWith(coin.Bounds))
                {
                    collectedCoins++;
                    labelCoins.Text = "Coins: " + collectedCoins;

                    coin.Location = GetPositionCoin(coin.Width);
                }
            }            
        }



        private void RaceGame_KeyDown(object sender, KeyEventArgs e)
        {
            if (carSpeed != 0)
            {
                if (e.KeyCode == Keys.Right)
                {
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

        private void GameOver()
        {
            timerRoad.Stop();
            timerTowardCars.Stop();
            if (collectedCoins < 15)
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
            collectedCoins -= 15;
            labelCoins.Text = "Coins: " + collectedCoins;
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
            collectedCoins = 0;
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
        /// <returns>Спиосок PictureBox из 5 линий</returns>
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

        /// <summary>
        /// Генерация монеток
        /// </summary>
        /// <returns>Спиосок PictureBox из трех монет</returns>
        private List<PictureBox> CreateCoins()
        {
            var coins = new List<PictureBox>();
            for(int i = 0;i < countCoins; i++)
            {
                var coin = new PictureBox();
                int sizeCoin = 40;

                coin.BackColor = Color.Transparent;
                coin.Image = Properties.Resources.Coin;
                coin.Margin = new Padding(4);
                coin.Size = new Size(sizeCoin, sizeCoin);
                coin.SizeMode = PictureBoxSizeMode.Zoom;               
                coin.Location = GetPositionCoin(sizeCoin);
               
                coins.Add(coin);
            }
            return coins;
        }
    }
}

