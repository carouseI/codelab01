using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Mul
{
    public class TimeController : MonoBehaviour
    {
        #region //serialisable fields
        [SerializeField]
        private float timeMultiplier; //controls speed of time

        [SerializeField]
        private float startHour; //set start default time

        [SerializeField]
        private TextMeshProUGUI timeText; //display current time

        [SerializeField]
        private Light sunLight;

        [SerializeField]
        private float sunriseHour;

        [SerializeField]
        private float sunsetHour;
        #endregion

        private DateTime currentTime; //track current time; frame by frame progression

        private TimeSpan sunriseTime;
        private TimeSpan sunsetTime;

        // Start is called before the first frame update
        void Start()
        {
            currentTime = DateTime.Now.Date + TimeSpan.FromHours(startHour); //use dateTime comp, add start time; use timeSpan hrs from method

            sunriseTime = TimeSpan.FromHours(sunriseHour); //set sunrise hour
            sunsetTime = TimeSpan.FromHours(sunsetHour); //set sunset hour
        }

        // Update is called once per frame
        void Update()
        {
            UpdateTimeOfDay(); //call method
            RotateSun(); //call sun rotation method
        }

        private void UpdateTimeOfDay()
        {
            currentTime = currentTime.AddSeconds(Time.deltaTime * timeMultiplier); //update time

            if(timeText != null) //if not null
            {
                timeText.text = currentTime.ToString("HH:mm"); //set text to current time, display in 24hr format
            }
        }

        private void RotateSun()
        {
            float sunLightRotation; //variable to hold rotation of sun

            #region //day
            if (currentTime.TimeOfDay > sunriseTime && currentTime.TimeOfDay < sunsetTime) //check if daytime + current time of day is between sunrise/sunset
            {
                TimeSpan sunriseToSunsetDuration = CalculateTimeDifference(sunriseTime, sunriseTime); //if true, calculate total time between sunrise + sunset
                TimeSpan timeSinceSunrise = CalculateTimeDifference(sunriseTime, currentTime.TimeOfDay); //calculate amt of time has passed since sunrise

                double percentage = timeSinceSunrise.TotalMinutes / sunriseToSunsetDuration.TotalMinutes; //use 2 values above, calculate % of time has passed; divide amt of minutes since sunrise by total amt of minutes from sunrise to sunset

                sunLightRotation = Mathf.Lerp(0, 180, (float)percentage); //use % to calculate rotation, lerp between 0-180, use % as interpellation value; cast to float for full function; set rotation value to 0 @ sunrise + increase til 180 @ sunset
            }
            #endregion
            #region //night
            else
            {
                TimeSpan sunsetToSunriseDuration = CalculateTimeDifference(sunsetTime, sunriseTime); //calculate time between sunset + sunrise
                TimeSpan timeSinceSunset = CalculateTimeDifference(sunsetTime, currentTime.TimeOfDay); //calculate time since sunset

                double percentage = timeSinceSunset.TotalMinutes / sunsetToSunriseDuration.TotalMinutes; //use values to calculate % of night that has passed

                sunLightRotation = Mathf.Lerp(180, 360, (float)percentage); //calculate rotation
            }
            #endregion

            sunLight.transform.rotation = Quaternion.AngleAxis(sunLightRotation, Vector3.right); //apply rotation to sunlight, use Quaternion angle axis method; pass in Vector3.right for axis, rotate around x axis
        }

        private TimeSpan CalculateTimeDifference(TimeSpan fromTime, TimeSpan toTime) //work our rotation of sun according to time of day; takes fromTime + toTime parameters, return difference between 2 times
        {
            TimeSpan difference = toTime - fromTime; //subtract 1 from other to calculate time

            if(difference.TotalSeconds < 0) //check if difference is negative
            {
                difference += TimeSpan.FromHours(24); //if negative, 2 times span transition from 1 day to another; add 24 hrs to difference to get correct value 
            }

            return difference; //return calculated difference
        }
    }
}
