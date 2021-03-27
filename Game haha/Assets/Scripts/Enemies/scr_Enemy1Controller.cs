using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Enemy1Controller : MonoBehaviour, Enemy
{
    // DAMAGE TEXT VARIABLES
    public GameObject damageText;
    int damageSortingOrder = 0;

    int maxHP = 300;
    int currentHP;
    
    void Start()
    {
        currentHP = maxHP;
    }

    void FixedUpdate()
    {
        if (currentHP <= 0)
        {
            //DIE
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
