using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathUtil; //direct access to public static content in util script without references

public class NPCController : MonoBehaviour
{
    GameObject player;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Util.CanSeeObj(player, gameObject, 0.9f))
        {
            //Debug.Log("player in sight");
        }
        Util.ObjSide(player, gameObject);
    }
}
