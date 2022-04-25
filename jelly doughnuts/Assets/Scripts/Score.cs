using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text score;
    private int scoreAmount;

    // Start is called before the first frame update
    void Start()
    {
        scoreAmount = 0; //set default
        score = GetComponent<Text>(); //get comp
    }

    // Update is called once per frame
    void Update()
    {
        score.text = scoreAmount.ToString();
    }

    public void AddScore()
    {
        scoreAmount += 10; //increment by 10
    }
}
