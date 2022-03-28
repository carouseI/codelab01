using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Run
{
    public class CollisionDetector : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag == "Death")
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}