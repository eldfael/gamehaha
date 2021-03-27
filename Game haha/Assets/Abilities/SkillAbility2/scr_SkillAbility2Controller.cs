using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_SkillAbility2Controller : MonoBehaviour, Ability
{
    scr_PlayerController playerController;
    float cooldown = 20f;
    float cooldowntimer = 0f;

    float duration = 7f;
    float durationtimer = 0f;

    void Start()
    {
        playerController = transform.parent.GetComponent<scr_PlayerController>();
    }
  
    void FixedUpdate()
    {
        if (cooldowntimer > 0)
        {
            cooldowntimer -= Time.fixedDeltaTime;
            if (cooldowntimer < 0) { cooldowntimer = 0; }
        }

        if (durationtimer > 0)
        {
            durationtimer -= Time.fixedDeltaTime;
            if (durationtimer <= 0)
            { 
                durationtimer = 0; 
                //playerController.AddMovementSpeed(-0.5f); 
                playerController.AddAttackSpeed(-0.5f);
                playerController.AddCritChance(-2f); 
            }
        }
    }
    public void UseAbility()
    {
        if (cooldowntimer <= 0)
        {
            cooldowntimer = cooldown;
            durationtimer = duration;
            //playerController.AddMovementSpeed(0.5f);
            playerController.AddAttackSpeed(0.5f);
            playerController.AddCritChance(2f);
        }
    }
    public float GetCooldown()
    {
        return cooldowntimer;
    }

}
