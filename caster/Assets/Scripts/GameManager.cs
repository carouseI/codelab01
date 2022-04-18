using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public Text scoreText;
    public Text highScoreText;
    public float highScore;

    public GameObject prefab;

    public GameObject playersPlatform;

    // Start is called before the first frame update
    void Start()
    {
        //level
        for (int i = 0; i < 100; i++)
        {
            GameObject platform = Instantiate(prefab); // instantiate a new platform
            platform.transform.position = new Vector3( // randomize its position
                                           Random.Range(-9, 9),
                                            i * 3,
                                            transform.position.z
                );
            platform.transform.localScale = new Vector3( // randomize its scale
                                           Random.Range(10, 30),
                                            1.5f,
                                            transform.localScale.z
                );
        }

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score:" + Mathf.Round((player.transform.position.y + 4.9f)); // display score according to its y position
        highScoreText.text = "High Score:" + Mathf.Round(highScore); // display the high score
        if (player.transform.position.y + 4.9f > highScore)
        {
            highScore = player.transform.position.y + 4.9f; // change the high score the current score is higher
        }

        //difficulities

        for (int j = 0; j < 10; j++)
        {
            if (player.transform.position.y > j * 30)
            {
                playersPlatform.transform.localScale = new Vector3(15 - j, 1.5f, transform.localScale.z); // the platform will shrink as the player jump higher
                //player.GetComponent<Player>().moveSpeed = 5 + (j / 2); // the frog will speed up as the player jump higher
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset(); // press R to reset the frog's, the platform's and camera's position to starting point

        }

    }

    void Reset()
    {
        player.transform.position = new Vector3(0, -4.9f, 0);
        playersPlatform.transform.position = new Vector3(-6.5f, -2.9f, 0);
        Camera.main.transform.position = new Vector3(0, 0, -10);
    }

}