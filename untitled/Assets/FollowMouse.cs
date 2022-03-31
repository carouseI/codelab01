using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public Camera mainCamera;

    // Update is called once per frame
    void Update()
    {
        //Position of the mouse on screen
        Vector2 mousePositionOnScreen = Input.mousePosition;

        //Clamped the mouse position on screen to within the screensize
        mousePositionOnScreen.x = Mathf.Clamp(mousePositionOnScreen.x, 0f, Camera.main.pixelWidth);
        mousePositionOnScreen.y = Mathf.Clamp(mousePositionOnScreen.y, 0f, Camera.main.pixelHeight);

        //Translate this new vector to a world position
        Vector3 mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePositionOnScreen);
    
        //Move self to mouse position in world
        transform.position = new Vector3(mousePositionInWorld.x, mousePositionInWorld.y, 0);
    }
}
