using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_SwordController : MonoBehaviour, Weapon
{
    scr_PlayerController playerController;
    public GameObject attackObject;
    
    float attackCooldownTimer;
    float attackCooldown;

    Vector2 mousePos;
    float SPRITE_ROTATION;


    void Start()
    {
        playerController = transform.parent.gameObject.GetComponent<scr_PlayerController>();
        
        attackCooldown = 0.5f;
        attackCooldownTimer = 0f;
    }
    public void Attack()
    {
        // IF ATTACK IS OFF COOLDOWN THEN DO ATTACK
        if (attackCooldownTimer <= 0)
        {
            
            // PUT ATTACK ON COOLDOWN
            attackCooldownTimer = attackCooldown;

            mousePos = playerController.GetMousePositionFromPlayer();
            GameObject newProjectile = Instantiate(attackObject,
                new Vector2(
                    playerController.transform.position.x + mousePos.normalized.x * 10f,
                    playerController.transform.position.y + mousePos.normalized.y * 10f),
                    Quaternion.identity,transform);

            newProjectile.GetComponent<scr_SwordProjectileController>().OnCreate(mousePos.normalized, 10);
            newProjectile.GetComponent<Transform>().Rotate(0, 0, Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg - SPRITE_ROTATION - 90F, Space.Self);
        }
        
    }
    public void FixedUpdate()
    {
        if (attackCooldownTimer > 0)
        {
            attackCooldownTimer -= Time.fixedDeltaTime;
        }

    }

}
