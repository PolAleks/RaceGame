namespace Race.Services
{
    public class PlayersStorage
    {
        private static string file = "results.json";
        private static IConvert convert = new JsonConverter();
        public static void Add(Player player)
        {
            var list = GetPlayers();
            list.Add(player);

            string saveData = convert.Serialize(list);
            FileProvider.Save(file, saveData);
        }

        public static List<Player> GetPlayers() 
        { 
            string data = FileProvider.Load(file);

            if (string.IsNullOrEmpty(data))
                return new List<Player>();
            else 
                return convert.Deserialize<List<Player>>(data);
        }
    }
}
