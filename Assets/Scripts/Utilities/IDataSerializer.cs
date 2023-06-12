using UnityEngine;

public interface IDataSerializer
{
    string SerializeData(object data);
    object DeserializeData(string serializedData);
}

public class JsonDataSerializer : IDataSerializer
{
    public string SerializeData(object data)
    {
        return JsonUtility.ToJson(data, true);
    }
    
    public object DeserializeData(string serializedData)
    {
        return JsonUtility.FromJson(serializedData, typeof(PlayerData));
    }
}

public class BinaryDataSerializer : IDataSerializer
{
    public string SerializeData(object data)
    {
        throw new System.NotImplementedException();
    }

    public object DeserializeData(string serializedData)
    {
        throw new System.NotImplementedException();
    }
}