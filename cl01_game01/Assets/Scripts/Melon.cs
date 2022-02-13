using UnityEngine;
using UnityEngine.UI;

public class Melon : MonoBehaviour
{
    public Text score; //accessible across project
    public Text highScore;

    void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString(); //store number as high score, display next time game is restarted 
    }

    public void UpdateScore()
    {
        int number = Random.Range(1, 10); //int = store in variables
        score.text = number.ToString(); //ToString = convert to string to add up/match with score

        PlayerPrefs.SetInt("HighScore", number);
    }
}
