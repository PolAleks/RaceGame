namespace Race.Services
{
    public interface IConvert
    {
        string Serialize<T>(T value);
        T Deserialize<T>(string value);
    }
}
