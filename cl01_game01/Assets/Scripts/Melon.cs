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

        if(number > PlayerPrefs.GetInt("HighScore", 0)) //check if score is greater/higher than high score
        {
            PlayerPrefs.SetInt("HighScore", number); //if beat, set to new number
            highScore.text = number.ToString(); //update immediately
        }   
    }

    public void Reset()
    {
        PlayerPrefs.DeleteKey("HighScore"); //reset settings + start over
        highScore.text = "0";
    }
}
