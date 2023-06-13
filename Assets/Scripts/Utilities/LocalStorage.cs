using System.IO;

public class LocalStorage
{
    private readonly string savesDirectory;
    // here provide the desired Serializer type
    // Remember to change the file extension at the bottom of this file in the GetFullPath method
    private static readonly IDataSerializer dataSerializer = new JsonDataSerializer();

    public LocalStorage(string directory)
    {
        savesDirectory = directory;
    }

    public void Save(string key, object data)
    {
        string filePath = GetFullPath(key);
        var serializedData = dataSerializer.SerializeData(data);
        if (Directory.Exists(filePath))
        {
            File.WriteAllText(filePath, serializedData);
        }
        else
        {
            Directory.CreateDirectory(savesDirectory);
            File.WriteAllText(filePath, serializedData);
        }
    }

    public object Load(string key)
    {
        string filePath = GetFullPath(key);
        
        if (File.Exists(filePath))
        {
            var serializedData = File.ReadAllText(filePath);
            return dataSerializer.DeserializeData(serializedData);
        }
        else
        {
            return null;
        }
    }

    private string GetFullPath(string key)
    {
        string fileName = key + ".json";
        return Path.Combine(savesDirectory, fileName);
    }
}
