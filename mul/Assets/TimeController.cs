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

        //track current time; frame by frame progression

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
