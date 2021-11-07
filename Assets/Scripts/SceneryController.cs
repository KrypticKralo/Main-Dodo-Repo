using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneryController : MonoBehaviour
{
    #region Declarations
    public float ScenerySpeed;

    public GameObject background;
    int backgroundMoveSpeed = 1;

    public GameObject layer1;
    int layer1MoveSpeed = 3;

    public GameObject layer2;
    int layer2MoveSpeed = 5;

    public GameObject layer3;
    int layer3MoveSpeed = 7;

    public GameObject layer4;
    int layer4MoveSpeed = 9;

    public GameObject layer5;
    int layer5MoveSpeed = 11;

    public GameObject layer6;
    int layer6MoveSpeed = 13;
    #endregion

    // Update is called once per frame
    void Update()
    {
        ScenerySpeed = LevelController.currentSpeed;
        BackgroundScrolling();
    }

    private void BackgroundScrolling()
    {
        background.transform.Translate(Vector2.left * (backgroundMoveSpeed * ScenerySpeed) * Time.deltaTime);
        if (background.transform.position.x <= -8.41)
        {
            background.transform.position = new Vector2(13, 0);
        }

        layer1.transform.Translate(Vector2.left * (layer1MoveSpeed * ScenerySpeed) * Time.deltaTime);
        if (layer1.transform.position.x <= -8.41)
        {
            layer1.transform.position = new Vector2(13, 0);
        }

        layer2.transform.Translate(Vector2.left * (layer2MoveSpeed * ScenerySpeed) * Time.deltaTime);
        if (layer2.transform.position.x <= -8.41)
        {
            layer2.transform.position = new Vector2(13, 0);
        }

        layer3.transform.Translate(Vector2.left * (layer3MoveSpeed * ScenerySpeed) * Time.deltaTime);
        if (layer3.transform.position.x <= -8.41)
        {
            layer3.transform.position = new Vector2(13, 0);
        }

        layer4.transform.Translate(Vector2.left * (layer4MoveSpeed * ScenerySpeed) * Time.deltaTime);
        if (layer4.transform.position.x <= -8.41)
        {
            layer4.transform.position = new Vector2(13, 0);
        }

        layer5.transform.Translate(Vector2.left * (layer5MoveSpeed * ScenerySpeed) * Time.deltaTime);
        if (layer5.transform.position.x <= -8.41)
        {
            layer5.transform.position = new Vector2(13, 0);
        }

        layer6.transform.Translate(Vector2.left * (layer6MoveSpeed * ScenerySpeed) * Time.deltaTime);
        if (layer6.transform.position.x <= -8.41)
        {
            layer6.transform.position = new Vector2(13, 0);
        }
    }
}
