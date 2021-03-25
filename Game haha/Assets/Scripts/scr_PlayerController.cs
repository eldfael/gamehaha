using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_PlayerController : MonoBehaviour
{
    //CONSTANTS
    float FIXEDPLAYERSPEED = 28.0f;

    //INPUT VARIABLES
    Vector2 moveDirection;
    bool attackInput;

    //SKILLS ARRAY
    Skill[] playerSkills;

    Rigidbody2D playerRigidbody;


    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        
        //TEMP
        playerSkills = new Skill[1];
        playerSkills[0] = transform.Find("obj_AttackSkill1").GetComponent<Skill>();
    }
    void Update()
    {
        //GETTING INPUT FROM THE USER
        moveDirection = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) ;
        attackInput = Input.GetMouseButton(0);
    }
    private void FixedUpdate()
    {
        //PLAYER MOVEMENT
        playerRigidbody.velocity = moveDirection.normalized * FIXEDPLAYERSPEED;

        //PLAYER ATTACKING
        if (attackInput)
        {
            //RUN A METHOD BASE ON THE CURRENT ATTACK SKILL
            //SKILLS CAN BE SEPERATE OBJECTS WITH COOLDOWNS / METHODS WITHIN THEM THAT ARE CONNECTED TO THE PLAYER (wow that's actually pretty smart good job me)
            //SKILLS CAN THEN HAVE BUTTONS RELATED TO THEM
            playerSkills[0].UseSkill();

        }
    }

    public Vector2 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y)) - transform.position;
    }
}
