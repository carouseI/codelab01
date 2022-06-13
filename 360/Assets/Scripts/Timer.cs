using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Run
{
    public class Timer : MonoBehaviour
    {
        public float timeRemaining = 60f;
        public bool timerIsRunning = false;

        public Text timeText; //initialise time text

        public GameObject endText;
        public GameObject labelText;

        public GameObject player;

        public string endScene;

        public float TIME_LIMIT = 5F; //initialise scene change after 5 seconds

        public GameObject sceneChanger;


        private void Start()
        {
            timerIsRunning = true; //auto start timer
        }

        // Update is called once per frame
        void Update()
        {
            if (timerIsRunning) //set countdown trigger
            {
                if (timeRemaining > 0) //check time remaining
                {
                    timeRemaining -= Time.deltaTime; //generate countdown; decrease time
                }

                else
                {
                    Debug.Log("Time's up");
                    timeRemaining = 0;
                    timerIsRunning = false; //stops timer at countdown

                    labelText.SetActive(false); //hides label text at countdown
                    gameObject.GetComponent<Text>().enabled = false; //hides timer at countdown
                    endText.SetActive(true); //replace with end game text
                    
                    StartCoroutine(SwitchScene());
                }
            }


            DisplayTime(timeRemaining);
        }

        void SceneChange()
        {
            SceneManager.LoadScene(endScene);
        }

        IEnumerator SwitchScene() //load end scene attempt 2
        {
            yield return new WaitForSeconds(TIME_LIMIT); //wait time between scene transition

            SceneManager.LoadScene(endScene);
            Debug.Log("Loading scene");
        }

        void DisplayTime(float timeToDisplay) //hide timer frame glitch where value is less than 0
        {
            if (timeToDisplay < 0)
            {
                timeToDisplay = 0;

            }

            float minutes = Mathf.FloorToInt(timeToDisplay / 60); //calculate minute; FloorToInt to round down
            float seconds = Mathf.FloorToInt(timeToDisplay % 60); // % = modulo, removes full minutes and returns leftover values/return remainder of equation; calculate number of seconds in time value that don't add to a full minute
            float milliseconds = timeToDisplay % 1 * 1000; //show milliseconds

            timeText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds); //{parameters}

        }
    }
}