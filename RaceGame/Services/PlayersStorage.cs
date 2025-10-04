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
            convert.Serialize<Player>(player);
        }

        public static List<Player> GetPlayers() 
        { 
            List<Player> list = new List<Player>();
            string data = FileProvider.Load(file);
            list = convert.Deserialize<List<Player>>(data);
            return list;
        }
    }
}
