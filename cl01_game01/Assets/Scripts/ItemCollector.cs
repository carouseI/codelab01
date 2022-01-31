using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private int melons = 0; //counter

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Melon")) //melon collision
        {
            Destroy(collision.gameObject); //remove from game
            melons++; //increment value
            Debug.Log("Melons: " + melons); //add number to string, show numbre behind
        }
    }
}
