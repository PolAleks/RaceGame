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
            InitialCarsMenu();
            InitialRoadMarking();

            panelMenu.Show();
        }

        /// <summary>
        /// Переключение таймеров
        /// </summary>
        private void TurningTimer()
        {
            timerRoad.Enabled = !timerRoad.Enabled;
            timerTowardCars.Enabled = !timerTowardCars.Enabled;
            timerMenu.Enabled = !timerMenu.Enabled;
        }

        /// <summary>
        /// Обработчик движения трассы(полосы, монеты) в процессе игры 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerRoad_Tick(object sender, EventArgs e)
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
        private void TimerTowardCars_Tick(object sender, EventArgs e)
        {
            MoveCar(carGame);

            for (int i = 0; i < carGame.Count; i++)
            {
                var car = carGame[i];

                if (mainCar.Bounds.IntersectsWith(car.Bounds))
                {
                    GameOver();
                }
            }
        }

        /// <summary>
        /// Обработчик движения встречных машин в меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerMenu_Tick(object sender, EventArgs e)
        {
            MoveLines(linesMenu);
            ResetCarSpeed();
            MoveCar(carMenu);
        }

        /// <summary>
        /// Анимация движения встречных машинок
        /// </summary>
        /// <param name="cars"></param>
        private void MoveCar(List<PictureBox> cars)
        {
            for (int i = 0; i < cars.Count; i++)
            {
                var car = cars[i];
                car.Top += carSpeed + deltaSpeedTowardCar[i];
                if (car.Top > Height)
                    car.Location = GetPositonMovingItem(car);
            }
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
                    coin.Location = GetPositonMovingItem(coin);
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

                    coin.Location = GetPositonMovingItem(coin);
                }
            }
        }

        private void RaceGame_KeyDown(object sender, KeyEventArgs e)
        {
            if (carSpeed != 0)
            {
                if (e.KeyCode == Keys.Right)
                {
                    if (mainCar.Right < Width)
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
                ButtonPause_Click(this, new EventArgs());
            }
        }

        private void GameOver()
        {
            TurningTimer();

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
            
            ResetCarSpeed();
            TurningTimer();

            foreach (var car in carGame)
            {
                car.Location = GetPositonMovingItem(car);
            }
        }

        private void StartGame()
        {
            score = 0;
            collectedCoins = 0;

            ResetCarSpeed();
            TurningTimer();

            foreach (var car in carGame)
            {
                car.Location = GetPositonMovingItem(car, true);
            }

            panelPause.Hide();
            panelGame.Show();
            panelMenu.Hide();
        }

        private void ResetCarSpeed() => carSpeed = 2;

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            StartGame();
            panelGame.Show();
            panelMenu.Hide();
        }

        private void ButtonPause_Click(object sender, EventArgs e)
        {
            TurningTimer();
            panelPause.Show();
        }

        private void ButtonResume_Click(object sender, EventArgs e)
        {
            TurningTimer();
            panelPause.Hide();
        }

        private void ButtonExit_Click(object sender, EventArgs e) => Close();

        private void ButtonHelp_Click(object sender, EventArgs e) => Help.ShowHelp(this, @"C:\Users\khha4\Race\help.chm", HelpNavigator.TableOfContents);

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
                coin.Location = GetPositonMovingItem(coin, false);

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
                car.Location = GetPositonMovingItem(car, false);

                cars.Add(car);
            }
            return cars;
        }


        /// <summary>
        /// Генерация стартовой позиции движущегося элемента
        /// </summary>
        /// <param name="widthItem">Возвращает Point</param>
        /// <returns></returns>
        private Point GetPositonMovingItem(PictureBox item, bool repeat = true)
        {
            int widthZone = Width / countCars;
            int zoneItem = Convert.ToInt32(item.AccessibleName);

            int x = r.Next(widthZone * zoneItem, widthZone * (zoneItem + 1));
            int y = -item.Height;

            if (!repeat)
                y = r.Next(-item.Height * zoneItem, item.Height);

            return new Point(x, y);
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
            MiddleLaneGame.SendToBack();
            MiddleLineMenu.SendToBack();

            linesGame = CreateLines();
            panelGame.Controls.AddRange(linesGame.ToArray());

            linesMenu = CreateLines();
            panelMenu.Controls.AddRange(linesMenu.ToArray());
        }

        private void InitialCarsMenu()
        {
            carMenu = CreateCar();
            panelMenu.Controls.AddRange(carMenu.ToArray());
        }
    }
}