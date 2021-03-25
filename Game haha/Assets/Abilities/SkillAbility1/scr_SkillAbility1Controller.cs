using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_SkillAbility1Controller : MonoBehaviour, Ability
{
    //RAY OF HEAVEN

    scr_PlayerController playerController;
    public GameObject area;

    float cooldown = 5f;
    float cooldowntimer = 0f;

    private void Start()
    {
        playerController = transform.parent.GetComponent<scr_PlayerController>();
    }

    private void FixedUpdate()
    {
        if (cooldowntimer > 0) 
        { 
            cooldowntimer -= Time.fixedDeltaTime; 
            if (cooldowntimer < 0) { cooldowntimer = 0; }
        }
    }
    public void UseAbility()
    { 
        if (cooldowntimer <= 0)
        {
            cooldowntimer = cooldown;
            GameObject newArea = Instantiate(area,playerController.GetMousePosition(),Quaternion.identity);
            newArea.GetComponent<scr_SkillAbility1Area>().OnCreate(20f);

        }
    }
}
