using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    public int damageValue = 1;
    public float obstacleMoveSpeed = 10;

    void Update()
    {
        transform.Translate(Vector2.left * (LevelController.currentSpeed * obstacleMoveSpeed) * Time.deltaTime);
        if (transform.position.x <= -8.41)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController.health--;
        }
    }
}
