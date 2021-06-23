using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_ScarecrowController : MonoBehaviour, Enemy
{

    public GameObject damageText;
    SpriteRenderer sprRenderer;
    int damageSortingOrder = 0;
    float hitTimerDuration;
    float hitTimer;

    private void Start()
    {
        hitTimer = 0;
        hitTimerDuration = 0.1f;
        sprRenderer = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(int damage, Vector2 direction)
    {

        /*
        GameObject _damageText = Instantiate(damageText, new Vector3(transform.position.x,transform.position.y+2f,damageSortingOrder),Quaternion.identity);
        _damageText.GetComponent<scr_DamageNumber>().SetNumber(damage,damageSortingOrder);
        damageSortingOrder++;
        if(crit) { _damageText.GetComponent<scr_DamageNumber>().Crit(); }
        */
        hitTimer = hitTimerDuration;
        sprRenderer.color = Color.red;

    }

    private void FixedUpdate()
    {
        if (hitTimer > 0)
        {
            hitTimer -= Time.fixedDeltaTime;
        }
        else if (hitTimer <= 0)
        {
            sprRenderer.color = new Color(1f, 0.68f, 0.35f, 1f);
        }
    }
}
