using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{

    //public Text scoreText;
    public Text numberScore;
    //public GameObject scoreText;

    public float addScore = 10f;
    public float currentScore = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other) //setup collision event
    {
        if (other.gameObject.tag == "Enemy") //check if player collided with enemy
        {

            currentScore += addScore; //increase score each time player collides
            numberScore.text = currentScore.ToString(); //display and updated score

        }

    }

}
