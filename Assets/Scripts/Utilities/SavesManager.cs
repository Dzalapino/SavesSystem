public class SavesManager
{
    private static readonly LocalStorage localStorage = new("Saves");
    private static readonly CloudStorageMock cloudStorageMock = new();

    public static void Save(string key, PlayerData data, bool useCloudStorage = false)
    {
        if (useCloudStorage)
        {
            cloudStorageMock.Save(key, data);
        }
        else
        {
            localStorage.Save(key, data);
        }
    }

    public static PlayerData Load(string key, bool useCloudStorage = false)
    {
        if (useCloudStorage)
        {
            return (PlayerData)cloudStorageMock.Load(key);
        }
        else
        {
            return (PlayerData)localStorage.Load(key);
        }
    }
}
