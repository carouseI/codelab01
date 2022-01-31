using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int melons = 0; //counter

    [SerializeField] private Text melonText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Melon")) //melon collision
        {
            Destroy(collision.gameObject); //remove from game
            melons++; //increment value
            //Debug.Log("Melons: " + melons); //add number to string, show numbre behind
            melonText.text = "Melons: " + melons;
        }
    }
}
