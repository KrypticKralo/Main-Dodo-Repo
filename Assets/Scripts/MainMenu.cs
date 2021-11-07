using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenu : MonoBehaviour
{    
    public Text highScorePlayer;
    public Text highScore;

    public void Start()
    {
        Debug.Log(Application.persistentDataPath);
        DataManager.Instance.LoadGame();
        UpdateHighScore();
    }

    public void UpdateHighScore()
    {
        highScorePlayer.text = DataManager.Instance.highScoreName;
        highScore.text = "" + DataManager.Instance.highScore;
    }

    #region Buttons
    public void RecordName(string name)
    {
        DataManager.Instance.playerName = name;
        Debug.Log(DataManager.Instance.playerName);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        DataManager.Instance.SaveGame();
        EditorApplication.ExitPlaymode();
#else
        DataManager.Instance.SaveGame();
        Application.Quit();
        
#endif
    }
    #endregion
}
