using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] floatingObstacles;
    public GameObject[] groundObstacles;
    public static float obstacleSpeed = 11;
    public float floatSpawnTime = .5f;
    public float groundSpawnTime = .4f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FloatingSpawner());
        StartCoroutine(GroundSpawner());
    }

    public IEnumerator FloatingSpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(.5f, 1.5f));
            int floatingObstacleIndex = Random.Range(0, floatingObstacles.Length);
            Instantiate(floatingObstacles[floatingObstacleIndex], new Vector2(13, Random.Range(0, 3f)), floatingObstacles[floatingObstacleIndex].transform.rotation);
        }      
    }
    public IEnumerator GroundSpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(.7f, 2f));
            int obstacleIndex = Random.Range(0, groundObstacles.Length);
            Instantiate(groundObstacles[obstacleIndex], new Vector2(13, -2.3f), groundObstacles[obstacleIndex].transform.rotation);
        }
    }
}
