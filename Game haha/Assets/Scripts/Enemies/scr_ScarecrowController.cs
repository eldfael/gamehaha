using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_ScarecrowController : MonoBehaviour, Enemy
{

    public GameObject damageText;

    public void TakeDamage(float damage, bool crit)
    {
        
        GameObject _damageText = Instantiate(damageText, new Vector2(transform.position.x,transform.position.y+2f),Quaternion.identity);
        _damageText.GetComponent<scr_DamageNumber>().SetNumber(damage);
        if(crit) { _damageText.GetComponent<scr_DamageNumber>().Crit(); }

    }
}
