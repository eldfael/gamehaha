using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_PlayerController : MonoBehaviour
{
    //CONSTANTS
    float FIXEDPLAYERSPEED = 36.0f;

    //INPUT VARIABLES
    Vector2 moveDirection;
    bool attackAbility1Input;
    bool skillAbility1Input;
    bool skillAbility2Input;

    //SKILLS ARRAY
    Ability[] playerAbilities;

    Rigidbody2D playerRigidbody;

    //STATS
    float critChance = 0.2f;
    float speedModifier = 1f;

    float cooldownReduction = 0f; // NOT YET IMPLEMENTED
    float attackSpeed = 1f; // 1 = BASE ATTACK SPEED ~ 1.2 = 20% INCREASED ATTACK SPEED


    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        
        //TEMP
        playerAbilities = new Ability[3];
        playerAbilities[0] = transform.Find("obj_AttackAbility1").GetComponent<Ability>();
        playerAbilities[1] = transform.Find("obj_SkillAbility1").GetComponent<Ability>();
        playerAbilities[2] = transform.Find("obj_SkillAbility2").GetComponent<Ability>();

    }
    void Update()
    {
        //GETTING INPUT FROM THE USER
        moveDirection = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) ;
        attackAbility1Input = Input.GetMouseButton(0);
        skillAbility1Input = Input.GetKey(KeyCode.Q);
        skillAbility2Input = Input.GetKey(KeyCode.Space);
    }
    private void FixedUpdate()
    {
        //PLAYER MOVEMENT
        playerRigidbody.velocity = moveDirection.normalized * FIXEDPLAYERSPEED * speedModifier;

        //PLAYER ATTACKING
        if (attackAbility1Input)
        {
            //RUN A METHOD BASE ON THE CURRENT ATTACK SKILL
            //SKILLS CAN BE SEPERATE OBJECTS WITH COOLDOWNS / METHODS WITHIN THEM THAT ARE CONNECTED TO THE PLAYER (wow that's actually pretty smart good job me)
            //SKILLS CAN THEN HAVE BUTTONS RELATED TO THEM
            playerAbilities[0].UseAbility();

        }

        //PLAYER USING AN ABILITY (1)
        if (skillAbility1Input)
        {
            playerAbilities[1].UseAbility();
        }

        //PLAYER USING AN ABILITY (2)
        if (skillAbility2Input)
        {
            playerAbilities[2].UseAbility();
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

    public float GetCritChance()
    {
        return critChance;
    }

    public void AddMovementSpeed(float movementSpeedChange)
    {
        speedModifier += movementSpeedChange;
    }

    public void AddAttackSpeed(float attackSpeedChange)
    {
        attackSpeed += attackSpeedChange;
    }

    public float GetAttackSpeed()
    {
        return attackSpeed;
    }

    public void AddCritChance(float critChanceChange)
    {
        critChance += critChanceChange;
    }
}
