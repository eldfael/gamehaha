using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_PlayerController : MonoBehaviour
{
    //CONSTANTS
    float FIXEDPLAYERSPEED = 28.0f;

    //INPUT VARIABLES
    Vector2 moveDirection;
    bool attackAbility1Input;
    bool skillAbility1Input;

    //SKILLS ARRAY
    Ability[] playerAbilities;

    Rigidbody2D playerRigidbody;


    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        
        //TEMP
        playerAbilities = new Ability[2];
        playerAbilities[0] = transform.Find("obj_AttackAbility1").GetComponent<Ability>();
        playerAbilities[1] = transform.Find("obj_SkillAbility1").GetComponent<Ability>();
    }
    void Update()
    {
        //GETTING INPUT FROM THE USER
        moveDirection = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) ;
        attackAbility1Input = Input.GetMouseButton(0);
        skillAbility1Input = Input.GetKey(KeyCode.Q);
    }
    private void FixedUpdate()
    {
        //PLAYER MOVEMENT
        playerRigidbody.velocity = moveDirection.normalized * FIXEDPLAYERSPEED;

        //PLAYER ATTACKING
        if (attackAbility1Input)
        {
            //RUN A METHOD BASE ON THE CURRENT ATTACK SKILL
            //SKILLS CAN BE SEPERATE OBJECTS WITH COOLDOWNS / METHODS WITHIN THEM THAT ARE CONNECTED TO THE PLAYER (wow that's actually pretty smart good job me)
            //SKILLS CAN THEN HAVE BUTTONS RELATED TO THEM
            playerAbilities[0].UseAbility();

        }

        //PLAYER USING AN ABILITY
        if (skillAbility1Input)
        {
            playerAbilities[1].UseAbility();
        }
    }

    public Vector2 GetMousePositionFromPlayer()
    {
        return Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y)) - transform.position;
    }

    public Vector2 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
    }
}
