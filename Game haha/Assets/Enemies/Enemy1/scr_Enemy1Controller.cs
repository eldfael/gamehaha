using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Enemy1Controller : MonoBehaviour, Enemy
{
    scr_PlayerController playerController;
    public GameObject projectile;

    // DAMAGE TEXT VARIABLES
    public GameObject damageText;
    int damageSortingOrder = 0;

    int attackbursts = 3;
    int attackcount = 0;

    float attackCooldown = 2f; // IDK USELESS JUST HERE FOR VIBES
    float attackCooldownTimer;

    float activeDuration = 0f;
    
    float moveDuration = 0f;
    Vector2 sentryPosition;
    Vector2 moveDirection;
    float moveAngle;
    bool playerClose;
    Rigidbody2D rigidbody2d;
    float enemySpeed = 3f;

    int maxHP = 300;
    int currentHP;
    
    void Start()
    {
        playerController = GameObject.Find("obj_Player").GetComponent<scr_PlayerController>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        attackCooldownTimer = Random.Range(attackCooldown - 0.25f, attackCooldown + 0.25f);
        currentHP = maxHP;
        sentryPosition = transform.position;
        playerClose = false;
    }

    void FixedUpdate()
    {
        // CHECK IF PLAYER IS IN ACTIVE RANGE

        if ((playerController.transform.position - transform.position).magnitude < 60)
        {
            activeDuration = 3f;
        }
        else
        {
            activeDuration -= Time.fixedDeltaTime;
        }

        // ATTACKING
        
        if (attackCooldownTimer <= 0 && activeDuration > 0)
        {
            if (attackcount < attackbursts-1)
            {
                attackcount++;
                attackCooldownTimer = 0.2f;

                activeDuration = Mathf.Clamp(activeDuration + 0.2f, 0, 3f);
            }
            else
            {
                attackcount = 0;
                attackCooldownTimer = Random.Range(attackCooldown - 0.25f, attackCooldown + 0.25f);
            }           

            Vector2 playerDirection = (playerController.transform.position - transform.position ).normalized;
            float shootAngle = Mathf.Atan2(playerDirection.y, playerDirection.x);
            shootAngle = shootAngle + Random.Range(-0.25f, 0.25f);
            Vector2 shootDirection = new Vector2(Mathf.Cos(shootAngle), Mathf.Sin(shootAngle));

            GameObject newProjectile = Instantiate(projectile,
                new Vector2(
                    transform.position.x + shootDirection.x * 0.8f,
                    transform.position.y + shootDirection.y * 0.8f),
                    Quaternion.identity);
            newProjectile.GetComponent<scr_Enemy1Projectile>().OnCreate(shootDirection, 5);
            newProjectile.GetComponent<Transform>().Rotate(0, 0, Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg - 90f, Space.Self);

        }
        else 
        { 
            attackCooldownTimer -= Time.fixedDeltaTime; 
        }

        // MOVING
        // CHECK IF PLAYER IS IN SENTRY RANGE
        if (moveDuration <= 0)
        {
            if ((playerController.transform.position - transform.position).magnitude > 16)
            {
                if (playerClose)
                {
                    sentryPosition = transform.position;
                    playerClose = false;
                }

                if (Random.Range(0,1f) > 0.2)
                {
                    do
                    {
                        moveAngle = (Random.Range(-Mathf.PI, Mathf.PI));
                        moveDirection = new Vector2(Mathf.Cos(moveAngle), Mathf.Sin(moveAngle));
                        moveDuration = Random.Range(0.4f, 0.6f);
                    } while (!((new Vector2(transform.position.x, transform.position.y) + (moveDirection * moveDuration * enemySpeed) - sentryPosition).magnitude < 8f));
                }
                else
                {
                    moveDirection = Vector2.zero;
                    moveDuration = Random.Range(0.2f, 0.3f);
                }
               
            }
            else
            {
                playerClose = true;
                moveDirection = (transform.position - playerController.transform.position).normalized;
                moveAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) + Random.Range(-0.2f, 0.2f);
                moveDirection = new Vector2(Mathf.Cos(moveAngle), Mathf.Sin(moveAngle));
                moveDuration = Random.Range(0.3f, 0.4f);
            }
        }
        else
        {
            if (playerClose)
            {
                rigidbody2d.velocity = moveDirection * enemySpeed * 2.5f;
            }
            else
            {
                rigidbody2d.velocity = moveDirection * enemySpeed;
            }
            moveDuration -= Time.fixedDeltaTime;
        }
        
        


        // DYING
        if (currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void TakeDamage(int damage, Vector2 direction)
    {
        // DAMAGE TEXT
        GameObject _damageText = Instantiate(damageText, new Vector3(transform.position.x, transform.position.y + 2f, damageSortingOrder), Quaternion.identity);
        _damageText.GetComponent<scr_DamageNumber>().SetNumber(damage, damageSortingOrder);
        damageSortingOrder++;

        // ACTUAL DAMAGE EVENT
        currentHP -= damage;
        if (currentHP < 0) { currentHP = 0; }
        Debug.Log(currentHP);
    }


}
