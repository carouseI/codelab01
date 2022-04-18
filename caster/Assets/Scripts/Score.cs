using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public GameObject player;
    public GameObject score;

    public RaycastHit hit; //Assign hit here so it doesn't get assigned every frame.

    public bool hitOnce = false;    //Bool to update score once.

    void Update()
    {

        Debug.DrawRay(transform.position, Vector3.down * 0.6f, Color.red);
        //detect if player has hit the top of the platform
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.6f))
        {
            //i check if i hit the specific Cube and it has not been hit yet.
            if (hit.collider.name == "Platform" && !hitOnce)
            {
                print("HIT!!!!!!!!!");
                //Change 'hitOnce' to 'true' so that 'if' statement is not executed every frame while player is sitting on the Cube.'
                hitOnce = true;
                //isAir = false;
                //PlatformMovement.platformMovement.shouldMove = false;
                //player.score += 1; // i increase my score here
            }
        }
        //Change 'hitOnce' back to false when player moves away from Cube. That is 'RayCast' return false.
        else hitOnce = false;
    }
}
