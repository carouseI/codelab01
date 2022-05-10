using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace PaleBlue
{
    public class InventoryUI : MonoBehaviour
    {
        private TextMeshProUGUI crystalText;

        private int crystalTotal;

        [SerializeField]
        private int maxCollectibles;

        // Start is called before the first frame update
        void Start()
        {
            crystalText = GetComponent<TextMeshProUGUI>(); //get tmp comp
            crystalTotal = 0; //set inventory start count
        }

        public void UpdateCrystalText(PlayerInventory playerInventory) //use playerInvetory as parameter
        {
            crystalText.text = playerInventory.CrystalCount.ToString(); //set to inventory count
            crystalTotal++; //increment

            if(crystalTotal >= maxCollectibles) //if max is reached
            {
                SceneManager.LoadScene("End Menu"); //go to scene
            }
        }
    }
}
