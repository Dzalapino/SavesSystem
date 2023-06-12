using UnityEngine;

public class CloudStorageMock
{
    public void Save(string key, object data)
    {
        Debug.Log("Saving data to the cloud storage...");
    }

    public object Load(string key)
    {
        Debug.Log("Loading data from the mock cloud storage...");
        return null;
    }
}
