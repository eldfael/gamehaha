using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSkill1 : MonoBehaviour, Skill
{
    PlayerController playerController;
    public GameObject projectile;
    Vector2 mousePos;

    void Start()
    {
        playerController = transform.parent.GetComponent<PlayerController>();

    }

    void Update()
    {
        
    }

    public void UseSkill() 
    {
        mousePos = playerController.GetMousePosition();
        GameObject newProjectile = Instantiate(projectile,
            new Vector2(
                playerController.transform.position.x + mousePos.normalized.x,
                playerController.transform.position.y + mousePos.normalized.y), 
                Quaternion.identity);

        newProjectile.GetComponent<ProjectileController>().OnCreate(mousePos.normalized);
        newProjectile.GetComponent<Transform>().Rotate(0,0,Mathf.Atan2(mousePos.y,mousePos.x) * Mathf.Rad2Deg - 90f, Space.Self);
    }
}
