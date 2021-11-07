using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static float scoreAmount;
    public Text scoreText;
    public float pointsIncreasedPerSecond;
    public int scoreMultiplyer;

    void Start()
    {
        scoreAmount = 0f;
        pointsIncreasedPerSecond = 1f;
        //UpdateScore();
    }

    void Update()
    {
        scoreText.text = "Score: " + (int)scoreAmount;
        scoreAmount += pointsIncreasedPerSecond * Time.deltaTime * scoreMultiplyer;
    }
}
