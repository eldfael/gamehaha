using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_ScarecrowController : MonoBehaviour, Enemy
{

    public GameObject damageText;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        
        GameObject _damageText = Instantiate(damageText, new Vector2(transform.position.x,transform.position.y+1f),Quaternion.identity);
        _damageText.GetComponent<scr_DamageNumber>().SetNumber(damage);
        Debug.Log("Scarecrow took " + damage + " damage");
    }
}
