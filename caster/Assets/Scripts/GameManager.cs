using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player; //player
    public Text scoreText; //score

    public Text highScoreText;
    public float highScore;

    //public GameObject prefab;

    //public GameObject playersPlatform;

    #region //mod 1
    public RaycastHit hit; //hit
    public GameObject enemy;

    public bool hitOnce = false; //bool, update once

    private int score;
    private int UpdateScore;
    Text text;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        score = 0; //starting score

        #region //level
        //for (int i = 0; i < 100; i++)
        //{
        //    GameObject platform = Instantiate(prefab); // instantiate a new platform
        //    platform.transform.position = new Vector3( // randomize its position
        //                                   Random.Range(-9, 9),
        //                                    i * 3,
        //                                    transform.position.z
        //        );
        //    platform.transform.localScale = new Vector3( // randomize its scale
        //                                   Random.Range(10, 30),
        //                                    1.5f,
        //                                    transform.localScale.z
        //        );
        //}
        #endregion

    }

    public void ISCORE()
    {
        UpdateScore++;

        Debug.Log("scored");
    }

    // Update is called once per frame
    void Update()
    {
        #region //old
        //scoreText.text = "Score:" + Mathf.Round((player.transform.position.y + 4.9f)); // display score according to its y position
        //highScoreText.text = "High Score:" + Mathf.Round(highScore); // display the high score
        //if (player.transform.position.y + 4.9f > highScore)
        //{
        //    highScore = player.transform.position.y + 4.9f; // change the high score the current score is higher
        //}

        ////difficulities

        //for (int j = 0; j < 10; j++)
        //{
        //    if (player.transform.position.y > j * 30)
        //    {
        //        playersPlatform.transform.localScale = new Vector3(15 - j, 1.5f, transform.localScale.z); // the platform will shrink as the player jump higher
        //        //player.GetComponent<Player>().moveSpeed = 5 + (j / 2); // the frog will speed up as the player jump higher
        //    }
        //}

        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    Reset(); // press R to reset the frog's, the platform's and camera's position to starting point

        //}
        #endregion

        #region //attempt 2
        //Debug.DrawRay(transform.position, Vector3.down * 0.6f, Color.red);

        //if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.6f))
        //{
        //    if (hit.collider.name == "Enemy" && !hitOnce)
        //    {
        //print("hit");
        //Change 'hitOnce' to 'true' so that 'if' statement is not executed every frame while player is sitting on the Cube.'
        //hitOnce = true;
        //isAir = false;
        //PlatformMovement.platformMovement.shouldMove = false;
        //GameController.controller.score += 1; // i increase my score here
        //        score = UpdateScore;
        //    }
        //}
        //Change 'hitOnce' back to false when player moves away from Cube. That is 'RayCast' return false.
        //else hitOnce = false;
        #endregion

        #region //attemp 3
        if (Physics.Raycast(transform.position, Vector3.down * 0.6f))
        {
            if(hit.collider.name == "Enemy" && !hitOnce)
            {
                print("hit");
                hitOnce = true;

                //score = UpdateScore;
                score++;
            }
        }

        #endregion

    }
}