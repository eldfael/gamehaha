using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float FIXEDPLAYERSPEED = 5.0f;

    Vector2 inputDirection;
    Rigidbody2D playerRigidbody;


    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        inputDirection = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) ;
    }
    private void FixedUpdate()
    {
        playerRigidbody.velocity = inputDirection.normalized * FIXEDPLAYERSPEED;
    }
}
