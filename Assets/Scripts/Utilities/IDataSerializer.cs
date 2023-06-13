using System.IO;
using System.Xml.Serialization;
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

public class XmlDataSerializer : IDataSerializer
{
    public string SerializeData(object data)
    {
        using (StringWriter stringWriter = new StringWriter())
        {
            XmlSerializer serializer = new XmlSerializer(data.GetType());
            serializer.Serialize(stringWriter, data);
            return stringWriter.ToString();
        }
    }

    public object DeserializeData(string serializedData)
    {
        using (StringReader stringReader = new StringReader(serializedData))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(PlayerData));
            return serializer.Deserialize(stringReader);
        }
    }
}