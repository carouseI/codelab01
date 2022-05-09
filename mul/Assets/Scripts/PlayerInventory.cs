using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mul
{
    public class PlayerInventory : MonoBehaviour
    {
        public int CrystalCount { get; private set; } //can be read by other scripts, can only be set in this one

        public void CrystalsCollected()
        {
            CrystalCount++; //increment

        }
    }
}