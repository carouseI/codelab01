using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Run
{
    public class EnemyAnimatorManager : AnimatorManager
    {
        private void Awake()
        {
            anim.GetComponent<Animator>(); //find animator comp
        }
    }
}