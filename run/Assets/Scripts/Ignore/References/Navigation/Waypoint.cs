using System.Collections;
using UnityEngine;
using System.Collections;
using Assets.Code;

public class Waypoint : MonoBehaviour
{
    [SerializeField]
    protected float debugDrawRadius = 1.0F; //set radius to 1 float

    public virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.red; //set gizmo colour
        Gizmos.DrawWireSphere(transform.position, debugDrawRadius); //has transform cos it inherits from monobehaviour; draw sphere from current position of object
    }
}