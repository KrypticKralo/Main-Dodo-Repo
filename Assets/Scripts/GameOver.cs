using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Text highScore;
    public Text yourScore;
    public Text recordedScore;
    public static bool isGameOver;

    private void Start()
    {
        isGameOver = false;
        gameOverScreen.SetActive(false);
    }
  
    void Update()
    {
        GameOverMenu();
    }

    public void GameOverMenu()
    {
        if (PlayerController.health <= 0)
        {
            isGameOver = true;
            Time.timeScale = 0f;
            gameOverScreen.SetActive(true);           
        }

        yourScore.text += "Your Score: " + Score.scoreAmount;
    }

    public void RestartApplication()
    {
        SceneManager.LoadScene(0);
    }
}
