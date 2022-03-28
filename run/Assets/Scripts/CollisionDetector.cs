using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Run
{
    public class CollisionDetector : MonoBehaviour
    {
        EnemyManager enemyManager;
        //private void OnCollisionEnter(Collision collision)
        //{
        //    if(collision.gameObject.tag == "Death")
        //    {
        //        SceneManager.LoadScene("GameOver");
        //    }
        //}

        private void Awake()
        {
            enemyManager = GetComponent<EnemyManager>();
        }

        void OnCollisionEnter(Collision c)
        {
            if(c.collider.tag == "Death")
            {
                Debug.Log("player has died");
            }
        }
    }
}