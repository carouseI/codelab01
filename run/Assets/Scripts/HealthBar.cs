using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Run
{
    public class HealthBar : MonoBehaviour
    {
        public Slider slider;

        public void SetMaxHealth(int maxHealth) //match max health to player's
        {
            slider.maxValue = maxHealth; //slide depending on player health
            slider.value = maxHealth; //adjust accordingly
        }
        public void SetCurrentHealth(int currentHealth)
        {
            slider.value = currentHealth; //set current health
        }
    }

}