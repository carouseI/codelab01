using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score;
    public Text scoreText;

    void Update()
    {
        scoreText.text = score.ToString();
    }

    public void AddScore()
    {
        score++;
    }
    
}
