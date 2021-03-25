using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_CameraController : MonoBehaviour
{
    
    Camera mainCamera;
    Transform playerTransform;
    bool playerActive;

    void Start()
    {
        playerActive = true; // TEMP LINE

        mainCamera = GetComponent<Camera>();
        playerTransform = GameObject.Find("obj_Player").GetComponent<Transform>();
    }


    void Update()
    {
        // If the player is active move the camera to follow the player
        if (true)
        {
            transform.position = new Vector3(
                // Follow the player's X and Y co-ordinate
                playerTransform.position.x,
                playerTransform.position.y,
                // Keep the Z co-ordinate to -10 so you can see objects in the scene 
                -10);  

            
        }
    }
}
