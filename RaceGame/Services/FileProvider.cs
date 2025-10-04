using System.Text;

namespace Race.Services
{
    public class FileProvider
    {
        private static string path;
        public FileProvider()
        {
            path = Environment.CurrentDirectory;
        }

        public static string Load(string file)
        {
            file = Path.Combine(path, file);
            return File.ReadAllText(file, Encoding.UTF8);
        }

        public static void Save(string file, string content)
        {
            file = Path.Combine(path, file);
            File.WriteAllText(file, content, Encoding.UTF8);
        }
    }
}
