using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Mul
{
    public class PlayerInventory : MonoBehaviour
    {
        public int CrystalCount { get; private set; } //can be read by other scripts, can only be set in this one

        public UnityEvent<PlayerInventory> OnCrystalCollected; //set event, will take argument of type playerInventory

        public void CrystalsCollected()
        {
            CrystalCount++; //increment
            OnCrystalCollected.Invoke(this); //invoke event, pass through playerInventory to subcribers
        }
    }
}