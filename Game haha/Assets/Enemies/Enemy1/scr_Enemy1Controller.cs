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

    float attackCooldown = 2f; // IDK USELESS JUST HERE FOR VIBES
    float attackCooldownTimer;

    int maxHP = 300;
    int currentHP;
    
    void Start()
    {
        playerController = GameObject.Find("obj_Player").GetComponent<scr_PlayerController>();
        attackCooldownTimer = Random.Range(attackCooldown - 0.5f, attackCooldown + 0.5f);
        currentHP = maxHP;
    }

    void FixedUpdate()
    {
        if (attackCooldownTimer <= 0)
        {
            attackCooldownTimer = Random.Range(attackCooldown - 0.5f, attackCooldown + 0.5f);
            Debug.Log("Enemy1 Attacks");

            Vector2 playerDirection = (playerController.transform.position - transform.position ).normalized;
            float shootAngle = Mathf.Atan2(playerDirection.y, playerDirection.x);
            shootAngle = shootAngle + Random.Range(-0.4f, 0.4f);
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



        if (currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void TakeDamage(int damage, bool crit)
    {
        // DAMAGE TEXT
        GameObject _damageText = Instantiate(damageText, new Vector3(transform.position.x, transform.position.y + 2f, damageSortingOrder), Quaternion.identity);
        _damageText.GetComponent<scr_DamageNumber>().SetNumber(damage, damageSortingOrder);
        damageSortingOrder++;
        if (crit) { _damageText.GetComponent<scr_DamageNumber>().Crit(); }

        // ACTUAL DAMAGE EVENT
        currentHP -= damage;
        if (currentHP < 0) { currentHP = 0; }
        Debug.Log(currentHP);
    }


}
