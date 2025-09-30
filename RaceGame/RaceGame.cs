using Race.Properties;

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
        private int collectedCoins = 0;

        // Машины
        private List<PictureBox> carGame;
        private List<PictureBox> carMenu;
        private int countCars = 3;
        private int carSpeed = 2;
        private Image[] imagesCars;
        private int[] deltaSpeedTowardCar = new int[] { 4, 2, 3 };

        Random r = new Random();
        int score = 0;

        /// <summary>
        /// Инициализация разметки, монет и запуск анимации движения в панели меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RaceGame_Load(object sender, EventArgs e)
        {
            InitialTowardCarsAndCoins();

            InitialRoadMarking();

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
            for (int i = 0; i < carGame.Count; i++)
            {
                var car = carGame[i];
                car.Top += carSpeed + deltaSpeedTowardCar[i];
                if (car.Top > Height)
                {
                    car.Location = GetNewPosition(car);
                }

                if (mainCar.Bounds.IntersectsWith(car.Bounds))
                {
                    GameOver();
                }
            }
        }


        /// <summary>
        /// Генерация стартовой позиции движущегося элемента
        /// </summary>
        /// <param name="widthItem">Возвращает Point</param>
        /// <returns></returns>
        private Point GetNewPosition(PictureBox item, bool repeat = true)
        {
            int widthZone = Width / countCars;
            int zoneItem = Convert.ToInt32(item.AccessibleName);

            int x = r.Next(widthZone * zoneItem, widthZone * (zoneItem + 1));
            int y = -item.Height;

            if (!repeat) 
                y = r.Next(-item.Height * zoneItem, item.Height);

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
                    coin.Location = GetNewPosition(coin);
                }
            }
        }


        /// <summary>
        /// Подсчет собранных монеток
        /// </summary>
        private void CollectCoins()
        {
            foreach (var coin in coins)
            {
                if (mainCar.Bounds.IntersectsWith(coin.Bounds))
                {
                    collectedCoins++;
                    labelCoins.Text = "Coins: " + collectedCoins;

                    coin.Location = GetNewPosition(coin);
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
                MessageBox.Show("Game Over!", "Приехали!");
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
            foreach (var car in carGame)
            {
                car.Location = GetNewPosition(car);
            }
        }
        private void StartGame()
        {
            score = 0;
            collectedCoins = 0;
            carSpeed = 2;

            timerRoad.Start();
            timerTowardCars.Start();

            foreach (var car in carGame)
            {
                car.Location = GetNewPosition(car);
            }

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
            int sizeCoin = 40;

            for (int i = 0; i < countCoins; i++)
            {
                var coin = new PictureBox();
                coin.BackColor = Color.Transparent;
                coin.Image = Resources.Coin;
                coin.Size = new Size(sizeCoin, sizeCoin);
                coin.SizeMode = PictureBoxSizeMode.Zoom;
                coin.AccessibleName = i.ToString();
                coin.Location = GetNewPosition(coin, false);

                coins.Add(coin);
            }
            return coins;
        }

        /// <summary>
        /// Генерация машинок
        /// </summary>
        /// <returns>Список PictureBox из трех машинок</returns>
        private List<PictureBox> CreateCar()
        {
            var cars = new List<PictureBox>(countCars);
            int widthCar = 59;
            int heightCar = 127;

            for (int i = 0; i < countCars; i++)
            {
                var car = new PictureBox();
                car.BackColor = Color.Transparent;
                car.Image = imagesCars[i];
                car.Size = new Size(widthCar, heightCar);
                car.SizeMode = PictureBoxSizeMode.Zoom;
                car.AccessibleName = i.ToString();
                car.Location = GetNewPosition(car, false);

                cars.Add(car);
            }
            return cars;
        }

        private void InitialTowardCarsAndCoins()
        {
            imagesCars = new Image[] { Resources.towardsCar1, Resources.towardsCar2, Resources.towardsCar3 };

            carGame = CreateCar();
            panelGame.Controls.AddRange(carGame.ToArray());

            coins = CreateCoins();
            panelGame.Controls.AddRange(coins.ToArray());
        }

        private void InitialRoadMarking()
        {
            MiddleLane.SendToBack();

            linesGame = CreateLines();
            panelGame.Controls.AddRange(linesGame.ToArray());

            linesMenu = CreateLines();
            panelMenu.Controls.AddRange(linesMenu.ToArray());
        }
    }
}

