namespace Race.Services
{
    public class Player
    {
        public Player()
        {
            
        }
        public Player(string name)
        {
            Name = name;            
        }

        public string Name { get; set; }
        public int? Score { get; set; }
        public int? Coins { get; set; }
        public DateTime? GameDate { get; set; }

        public void SaveResult(int score, int coins)
        {
            Score = score;
            Coins = coins;
            GameDate = DateTime.Now;
        }
    }
}
