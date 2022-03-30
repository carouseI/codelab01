using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Run
{
    public class PlayerStats : CharacterStats
    {
        public int healthLevel = 10;
        public int maxHealth;
        public int currentHealth;

        public HealthBar healthbar;
        
        // Start is called before the first frame update
        void Start()
        {
            maxHealth = SetMaxHealthFromHealthLevel(); //set max health accordingly
            currentHealth = maxHealth; //set to full at start of game
            healthbar.SetMaxHealth(maxHealth); //set max value to char's max health
        }

        private int SetMaxHealthFromHealthLevel() //health lvl doesn't determine health points, lvl = usually paired with formula to determine points
        {
            maxHealth = healthLevel * 10; //set max to lvl * 10 [temp]
            return maxHealth; //return value
        }

        public void TakeDamage(int damage)
        {
            currentHealth = currentHealth - damage; //deduct health when dmg is taken

            healthbar.SetCurrentHealth(currentHealth); //update health
        }
    }
}