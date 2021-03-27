using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_SkillAbility1Controller : MonoBehaviour, Ability
{
    //RAY OF HEAVEN

    scr_PlayerController playerController;
    public GameObject area;

    float cooldown = 4f;
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
            Vector2 newPos;
            if (playerController.GetMousePositionFromPlayer().magnitude>24)
            {
                newPos = playerController.GetMousePositionFromPlayer().normalized;
                newPos.x = Mathf.Sqrt(newPos.x * newPos.x * 576) * Mathf.Sign(newPos.x) + playerController.transform.position.x;
                newPos.y = Mathf.Sqrt(newPos.y * newPos.y * 576) * Mathf.Sign(newPos.y) + playerController.transform.position.y;
            }
            else
            {
                newPos = playerController.GetMousePosition();
            }
            GameObject newArea = Instantiate(area,newPos,Quaternion.identity);
            newArea.GetComponent<scr_SkillAbility1Area>().OnCreate(15f,playerController.GetCritChance());

        }
    }
}
