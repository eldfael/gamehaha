using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_PlayerController : MonoBehaviour
{
    //CONSTANTS
    float FIXEDPLAYERSPEED = 54.0f;

    //INPUT VARIABLES
    Vector2 moveDirection;
    Vector2 inputDirection;
    bool moveControl;
    bool attackInput;

    Rigidbody2D playerRigidbody;
    Weapon currentWeapon;

    //STATS
    float critChance = 0.05f; // BASE CRIT CHANCE 5% (TBD)
    float speedModifier = 1f; // BASE SPEED MOD 1

    float cooldownReduction = 0f; // NOT YET IMPLEMENTED ~
    float attackSpeed = 1f; // 1 = BASE ATTACK SPEED ~ 1.2 = 20% INCREASED ATTACK SPEED


    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        SetMoveControl(true);

        currentWeapon = transform.GetChild(0).gameObject.GetComponent<Weapon>();

        //TEMP
        /*
        playerAbilities = new Ability[3];
        playerAbilities[0] = transform.Find("obj_AttackAbility1").GetComponent<Ability>();
        playerAbilities[1] = transform.Find("obj_SkillAbility1").GetComponent<Ability>();
        playerAbilities[2] = transform.Find("obj_SkillAbility2").GetComponent<Ability>();
        */
    }
    void Update()
    {
        //GETTING INPUT FROM THE USER
        //IF moveControl IS TRUE -> GET MOVEMENT INPUT FROM THE USER
        inputDirection = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized ;
        if(moveControl)
        {
            moveDirection = inputDirection;
        }  

        attackInput = Input.GetMouseButton(0);
        

    }
    private void FixedUpdate()
    {
        //PLAYER MOVEMENT
        playerRigidbody.velocity = moveDirection * FIXEDPLAYERSPEED * speedModifier;

        //PLAYER ATTACKING
        if (attackInput)
        {
            //RUN A METHOD BASE ON THE CURRENT WEAPON
            currentWeapon.Attack();
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

    public void SetSpeedModifier(float movementSpeed)
    {
        speedModifier = movementSpeed;
    }

    public float GetSpeedModifier()
    {
        return speedModifier;
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

    public void SetMoveControl(bool b)
    {
        moveControl = b;
    }

    public void SetMoveDirection(Vector2 v)
    {
        moveDirection = v;
    }

    public Vector2 GetMoveDirection()
    {
        return moveDirection;
    }

    public Vector2 GetInputDirection()
    {
        return inputDirection;
    }
}
