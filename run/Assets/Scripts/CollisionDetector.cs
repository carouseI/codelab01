using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Run
{
    public class CollisionDetector : MonoBehaviour
    {
        EnemyManager enemyManager;

        private void Awake()
        {
            enemyManager = GetComponent<EnemyManager>(); //find enemy manager comp
        }

        void OnCollisionEnter(Collision c)
        {
            if(c.collider.tag == "Death") //if collision with object tagged death
            {
                Debug.Log("player has died"); //show debug
                SceneManager.LoadScene(3); //load game over scene
                //Time.timeScale = 1;
            }
        }
    }
}