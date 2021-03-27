using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_ScarecrowController : MonoBehaviour, Enemy
{

    public GameObject damageText;
    int damageSortingOrder = 0;

    public void TakeDamage(float damage, bool crit)
    {
        
        GameObject _damageText = Instantiate(damageText, new Vector3(transform.position.x,transform.position.y+2f,damageSortingOrder),Quaternion.identity);
        _damageText.GetComponent<scr_DamageNumber>().SetNumber(damage,damageSortingOrder);
        damageSortingOrder++;
        if(crit) { _damageText.GetComponent<scr_DamageNumber>().Crit(); }

    }
}
