using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using System.IO;

public class DialogManager : MonoBehaviour
{

    public int score = 0;

    public Text scoreText;

    public Text dialogText;

    public Text choice1Text;
    public Text choice2Text;

    public GameObject choice1Button;
    public GameObject choice2Button;

    public GameObject continueButton;

    public string dialogFile;

    public string storyScene;

    public int storyIndex;

    JSONObject storyData;
    string storyText;

    // Start is called before the first frame update
    void Start()
    {
        choice1Button.SetActive(false);
        choice2Button.SetActive(false);

        scoreText.text = "Points: " + score;

        LoadJsonFromFile(dialogFile);
        StartScene();

    }

    void LoadJsonFromFile(string fileName)
    {
        string jsonString = File.ReadAllText(fileName);
        storyData = (JSONObject)JSON.Parse(jsonString);
    }

    void StartScene()
    {
        dialogText.text = storyData[storyScene][storyIndex]["line"]; //storyScene = sceneOne (array in text json), storyIndex = index 0 (object in array), line = designated line (see array objects)
    }

    public void ProgressStory()
    {
        dialogText.text = storyData[storyScene][storyIndex]["line"];
        if(storyData[storyScene][storyIndex]["choices"].Count > 0)
        {
            ChoiceDialog();
        }
        else
        {
            RegularDialog();
        }
    }

    void ChoiceDialog()
    {
            continueButton.SetActive(false);
            choice1Button.SetActive(true);
            choice2Button.SetActive(true);

            choice1Text.text = storyData[storyScene][storyIndex]["choice"][0];
            choice2Text.text = storyData[storyScene][storyIndex]["choices"][1];

            choice1Button.GetComponent<Buttons>().nextIndex = storyData[storyScene][storyIndex]["goto"][0];
            choice2Button.GetComponent<Buttons>().nextIndex = storyData[storyScene][storyIndex]["goto"][1];

    }

    void RegularDialog() 
    {
            continueButton.SetActive(true);
            choice1Button.SetActive(false);
            choice2Button.SetActive(false);
            scoreText.text = "Points: " + score;
            //StartCoroutine(JSONServer.PostScore(scoreURL, newScore));

            continueButton.GetComponent<Buttons>().nextIndex = storyData[storyIndex][storyScene]["goto"];
    }
}
