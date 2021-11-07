using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        string json = File.ReadAllText(Application.dataPath + "saveFile.json");
        PlayerData loadedPlayerData = JsonUtility.FromJson<PlayerData>(json);
        Debug.Log("Name: " + loadedPlayerData.playerName);
        Debug.Log("High Score: " + loadedPlayerData.highScore);
    }

    public void SaveData()
    {
        PlayerData playerData = new PlayerData();
        //playerData.playerName = MainMenu.playerName;
        playerData.highScore = 80;

        string json = JsonUtility.ToJson(playerData);

        File.WriteAllText(Application.dataPath + "saveFile.json", json);
    }

    private class PlayerData
    {
        public string playerName;
        public int highScore;
    }
}


/*
public class SaveData
{
    #region High Score-----------------------------------------------------------------------------------------------------------------------------------------------------------------
    public int savedHighScore;
    public Text CurrentHighScore;
    public Text PlayerName;
    public string savedPlayerName;

    public void SaveScoreData()
    {
        SaveData data = new SaveData();
        data.savedHighScore = (int)Score.scoreAmount;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefule.json", json);
    }

    public void SaveNameData()
    {
        SaveData data = new SaveData();
        data.savedPlayerName = PlayerName.text;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefule.json", json);
    }

    public void LoadNameData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            savedPlayerName = data.savedPlayerName;
        }
    }

    public void LoadScoreData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            savedHighScore = data.savedHighScore;
        }
    }
    #endregion
}*/
