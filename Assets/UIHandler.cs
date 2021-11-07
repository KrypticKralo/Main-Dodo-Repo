using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIHandler : MonoBehaviour
{
    #region Declarations
    public GameObject pauseMenuScreen;
    public bool pauseMenuActive;

    public GameObject gameOverScreen;
    public bool gameOverActive;
    public Text playerScoreText;
    public Text highScoreText;

    public bool stopGame;
    #endregion

    void Start()
    {
        pauseMenuActive = false;
        gameOverActive = false;
    }

    void Update()
    {
        PauseMenu();
        GameOverMenu();
        UniversalFunctions();
    }

    #region Pause Menu----------------------------------------------------------------------------
    public void PauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gameOverActive)
        {
            if (pauseMenuActive)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenuActive = true;
    }

    public void ResumeGame()
    {
        pauseMenuActive = false;
    }
    #endregion

    #region Game Over Menu-----------------------------------------------------------------------
    public void GameOverMenu()
    {
        if (PlayerController.health <= 0)
        {     
            gameOverActive = true;
            playerScoreText.text = "Your Score: " + (int)Score.scoreAmount;

            if(Score.scoreAmount > DataManager.Instance.highScore)
            {
                DataManager.Instance.highScoreName = DataManager.Instance.playerName;
                DataManager.Instance.highScore = (int)Score.scoreAmount;
            }

            highScoreText.text = "High Score: " + DataManager.Instance.highScore;
        }
    }

    //Buttons for Game Over Menu;
    public void RestartApplication()
    {
        DataManager.Instance.SaveGame();
        SceneManager.LoadScene(0);
    }
    #endregion

    #region Universal Functions-------------------------------------------------------------------

    public void UniversalFunctions()
    {
        //If true, stop time;
        if (stopGame)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }

        //Sets the Pause Menu, and Game Over Menu on and off, sets their Objects active and inactive, and stops time when any of them of active;
        if (pauseMenuActive && gameOverActive)
        {
            pauseMenuScreen.SetActive(false);
            gameOverScreen.SetActive(false);
            stopGame = true;
        }
        else if (!pauseMenuActive && !gameOverActive)
        {
            pauseMenuScreen.SetActive(false);
            gameOverScreen.SetActive(false);
            stopGame = false;
        }
        else if (pauseMenuActive && !gameOverActive)
        {
            pauseMenuScreen.SetActive(true);
            gameOverScreen.SetActive(false);
            stopGame = true;
        }
        else if (!pauseMenuActive && gameOverActive)
        {
            pauseMenuScreen.SetActive(false);
            gameOverScreen.SetActive(true);
            stopGame = true;
        }
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


    /* SCRIPT OUTLINE!!!
     
     1.) Main Menu OMIT
     
     2.) Pause Menu
     
     3.) Game Over Screen
     
     4.) Universal Functions
     
     */
}
