using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_SkillAbility1Area : MonoBehaviour
{
    bool created = false;
    int damage;
    float duration = 0.15f;
    float durationtimer = -0.2f;
    int maxticks = 4;
    int tickcounter = 0;
    bool active = false;
    float critChance;

    ContactFilter2D filter;
    List<Collider2D> collisions = new List<Collider2D>();

    private void Start()
    {
        filter.useTriggers = true;
    }
    void FixedUpdate()
    {
        if (created) 
        {
            if (durationtimer >= duration)
            {
                durationtimer = 0;

                if (tickcounter == maxticks)
                {
                    Destroy(gameObject);
                }
                
                if (!active)
                {
                    active = true;
                    Debug.Log("Active");
                    GetComponent<SpriteRenderer>().color = new Color(1f,92f/255f,90f/255f,1f);
                }

                Physics2D.OverlapCollider(GetComponent<CircleCollider2D>(), filter, collisions);
                if (collisions.Count > 0)
                {

                    collisions.ForEach(delegate (Collider2D c)
                    {
                        if (c.CompareTag("Enemy"))
                        {
                            if (Random.Range(0f,1f)+critChance > 1)
                            {
                                c.gameObject.GetComponent<Enemy>().TakeDamage(damage + (int)(damage * 0.5f), true);

                            }
                            else
                            {
                                c.gameObject.GetComponent<Enemy>().TakeDamage(damage + Random.Range((int)(-damage * 0.1f), (int)(1 + damage * 0.1f)), false);
                            }
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

    public void OnCreate(int _damage, float _critChance)
    {
        damage = _damage;
        critChance = _critChance;
        created = true;
    }
}
