using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Mul
{
    public class TimeController : MonoBehaviour
    {
        [SerializeField]
        private float timeMultiplier; //controls speed of time

        [SerializeField]
        private float startHour; //set start default time

        [SerializeField]
        private TextMeshProUGUI timeText; //display current time

        private DateTime currentTime; //track current time; frame by frame progression

        // Start is called before the first frame update
        void Start()
        {
            currentTime = DateTime.Now.Date + TimeSpan.FromHours(startHour); //use dateTime comp, add start time; use timeSpan hrs from method
        }

        // Update is called once per frame
        void Update()
        {
            UpdateTimeOfDay(); //call method
        }

        private void UpdateTimeOfDay()
        {
            currentTime = currentTime.AddSeconds(Time.deltaTime * timeMultiplier); //update time

            if(timeText != null) //if not null
            {
                timeText.text = currentTime.ToString("HH:mm"); //set text to current time, display in 24hr format
            }
        }
    }
}
