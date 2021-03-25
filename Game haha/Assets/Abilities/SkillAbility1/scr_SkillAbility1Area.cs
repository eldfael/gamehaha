using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_SkillAbility1Area : MonoBehaviour
{
    bool created = false;
    float damage;
    float duration = 0.25f;
    float durationtimer = 0.25f;
    int maxticks = 4;
    int tickcounter = 0;

    ContactFilter2D filter;
    List<Collider2D> collisions = new List<Collider2D>();

    void FixedUpdate()
    {
        if (created) 
        {
            if (durationtimer >= duration)
            {
                if (tickcounter == maxticks)
                {
                    Destroy(gameObject);
                }
                durationtimer = 0;
                Physics2D.OverlapCollider(GetComponent<BoxCollider2D>(), filter, collisions);

                if (collisions.Count > 0)
                {

                    collisions.ForEach(delegate (Collider2D c)
                    {
                        if (c.CompareTag("Enemy"))
                        {
                            c.gameObject.GetComponent<Enemy>().TakeDamage(damage + Random.Range((int)(-damage * 0.2f), (int)(1 + damage * 0.2f)));

                        }

                    });


                }

                tickcounter++;
            }
            else
            {
                durationtimer += Time.fixedDeltaTime;
            }

        }
    }

    public void OnCreate(float _damage)
    {
        damage = _damage;
        created = true;
    }
}
