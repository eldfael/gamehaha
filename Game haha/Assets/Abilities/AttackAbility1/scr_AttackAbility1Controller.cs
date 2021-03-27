using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_AttackAbility1Controller : MonoBehaviour, Ability
{
    scr_PlayerController playerController;
    public GameObject projectile;
    Vector2 mousePos;
    
    float cooldown = 0.3f;
    float cooldownTimer = 0f;

    void Start()
    {
        playerController = transform.parent.GetComponent<scr_PlayerController>();
    }

    void FixedUpdate()
    {
        if (cooldownTimer >= 0)
        {
            cooldownTimer -= Time.fixedDeltaTime;
            if (cooldownTimer < 0) { cooldownTimer = 0; }
        }
    }

    public void UseAbility()
    {
        if (cooldownTimer <= 0)
        {
            cooldownTimer = cooldown / playerController.GetAttackSpeed();
            mousePos = playerController.GetMousePositionFromPlayer();
            GameObject newProjectile = Instantiate(projectile,
                new Vector2(
                    playerController.transform.position.x + mousePos.normalized.x*0.5f,
                    playerController.transform.position.y + mousePos.normalized.y*0.5f),
                    Quaternion.identity);

            newProjectile.GetComponent<scr_AttackAbility1Projectile>().OnCreate(mousePos.normalized, 10f, playerController.GetCritChance());
            newProjectile.GetComponent<Transform>().Rotate(0, 0, Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg - 90f, Space.Self);
        }
    }
}
