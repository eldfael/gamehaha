using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_AttackSkill1Controller : MonoBehaviour, Skill
{
    scr_PlayerController playerController;
    public GameObject projectile;
    Vector2 mousePos;
    float cooldown;
    float cooldownTimer;

    void Start()
    {
        playerController = transform.parent.GetComponent<scr_PlayerController>();
        cooldown = 0.4f;
        cooldownTimer = 0.5f;
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (cooldownTimer <= cooldown)
        {
            cooldownTimer += Time.fixedDeltaTime;
        }
    }

    public void UseSkill()
    {
        if (cooldownTimer >= cooldown)
        {
            cooldownTimer = 0;
            mousePos = playerController.GetMousePosition();
            GameObject newProjectile = Instantiate(projectile,
                new Vector2(
                    playerController.transform.position.x + mousePos.normalized.x*0.5f,
                    playerController.transform.position.y + mousePos.normalized.y*0.5f),
                    Quaternion.identity);

            newProjectile.GetComponent<scr_AttackSkill1Projectile>().OnCreate(mousePos.normalized, 10f);
            newProjectile.GetComponent<Transform>().Rotate(0, 0, Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg - 90f, Space.Self);
        }
    }
}
