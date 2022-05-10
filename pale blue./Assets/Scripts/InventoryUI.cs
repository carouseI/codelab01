using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace PaleBlue
{
    public class InventoryUI : MonoBehaviour
    {
        private TextMeshProUGUI crystalText;

        // Start is called before the first frame update
        void Start()
        {
            crystalText = GetComponent<TextMeshProUGUI>(); //get tmp comp
        }

        public void UpdateCrystalText(PlayerInventory playerInventory) //use playerInvetory as parameter
        {
            crystalText.text = playerInventory.CrystalCount.ToString(); //set to inventory count
        }
    }
}
