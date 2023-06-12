using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
   private void Start()
    {
        // Saving data to local storage
        string key = "player_data";
        PlayerData playerData = new("Meetra Surik", 1000, 1000, 1, new List<Quest>());
        SavesManager.Save(key, playerData);

        // Loading data from local storage
        var loadedData = SavesManager.Load(key);
        if (loadedData != null)
        {
            Debug.Log("Loaded data from local storage: " + loadedData.name);
        }
        else
        {
            Debug.Log("No data found in local storage.");
        }

        // Saving data to mocked cloud storage
        SavesManager.Save(key, playerData, true);

        // Loading data from mocked cloud storage
        loadedData = SavesManager.Load(key, true);
        if (loadedData != null)
        {
            Debug.Log("Loaded data from mocked cloud storage: " + loadedData.name);
        }
        else
        {
            Debug.Log("No data found in mocked cloud storage.");
        }
    }
}
