using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public int jumpForce = 22;
    public int riseGravity = 5;
    public int fallGravity = 15;
    public float maxFlyTime = 3;
    private float minFlyTime = 0;

    [Range(0f, 3f)]
    public float currentFlyTime;
    public Slider flyBar;

    public bool isGrounded;
    public bool isFlying;
    public bool ableToFly;

    private Rigidbody2D playerRb;

    public static int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        isGrounded = true;
        currentFlyTime = maxFlyTime;
        isFlying = false;
        ableToFly = true;
        flyBar.maxValue = maxFlyTime;
        flyBar.minValue = minFlyTime;
        health = numOfHearts;
    }

    void Update()
    {
        PlayerControls();
        FlightTime();
        PlayerHealth();
    }

    public void PlayerControls()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRb.velocity = Vector2.up * jumpForce;
            playerRb.gravityScale = riseGravity;
            isGrounded = false;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !isGrounded && ableToFly)
        {
            if (Input.GetKey(KeyCode.Space) && ableToFly)
            {
                isFlying = true;
            }        
        }
        else if (Input.GetKeyUp(KeyCode.Space) || !ableToFly)
        {
            playerRb.gravityScale = fallGravity;
            isFlying = false;
        }
    }

    public void PlayerHealth()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else hearts[i].sprite = emptyHeart;

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    private void FlightTime()
    {
        if (isFlying)
        {
            playerRb.velocity = Vector2.zero;
            playerRb.gravityScale = 0;
        }
        if (currentFlyTime > minFlyTime)
        {
            ableToFly = true;
        }
        else if (currentFlyTime <= minFlyTime)
        {
            ableToFly = false;
        }

        if (isFlying && currentFlyTime >= minFlyTime)
        {
            currentFlyTime -= 1 * Time.deltaTime;
            if(currentFlyTime < minFlyTime)
            {
                currentFlyTime = minFlyTime;
            }
        }
        if (isGrounded && currentFlyTime <= maxFlyTime)
        {
            currentFlyTime += 1.5f * Time.deltaTime;
            if(currentFlyTime > maxFlyTime)
            {
                currentFlyTime = maxFlyTime;
            }
        }

        flyBar.value = currentFlyTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
