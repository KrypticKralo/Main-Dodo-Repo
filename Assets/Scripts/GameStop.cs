using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStop : MonoBehaviour
{
    public static bool gameIsStopped;
    
    // Update is called once per frame
    void Update()
    {
        if (gameIsStopped)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
