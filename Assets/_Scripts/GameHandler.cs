using System;
using UnityEngine;
using System.IO;

public class GameHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //test values
        Debug.Log("test");
        PlayerData playerData = new PlayerData();
        playerData.health = 5;

        //save
        string save = JsonUtility.ToJson(playerData);
        //create file
        File.WriteAllText(Application.dataPath + "saveFile.json", save);

        /* //load
        string load = File.ReadAllText(Application.dataPath + "saveFile.json")

        PlayerData loadPlayerData = JsonUtility.FromJason<PlayerData>(load));
        playerData.healt h = loadPlayerData.health; */
    }

    [Serializable]
    // class with values to save
    class PlayerData{
        public int health;
    }
}
