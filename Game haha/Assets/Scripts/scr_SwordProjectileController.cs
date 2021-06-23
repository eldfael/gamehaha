using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_SwordProjectileController : MonoBehaviour
{
    bool created = false;

    int damage;
    float critChance;
    Vector2 direction;

    float duration = 0.2666f;
    float durationTimer = 0;

    List<GameObject> hits = new List<GameObject>();
    ContactFilter2D filter;
    List<Collider2D> collisions = new List<Collider2D>();
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        filter.useTriggers = true;
    }


    void FixedUpdate()
    {
        if (created)
        {
            if (durationTimer <= duration)
            {
                durationTimer += Time.fixedDeltaTime;
            }
            else
            {
                Destroy(gameObject);
            }

            if (durationTimer < 0.1f)
            {
                Physics2D.OverlapCollider(GetComponent<BoxCollider2D>(), filter, collisions);

                if (collisions.Count > 0)
                {

                    collisions.ForEach(delegate (Collider2D c)
                    {
                        if (c.CompareTag("Enemy") && !hits.Contains(c.gameObject))
                        {
                            c.gameObject.GetComponent<Enemy>().TakeDamage(damage, direction) ;
                            hits.Add(c.gameObject);
                        }
                    });


                }
            }
        }


    }


    public void OnCreate(Vector2 _direction, int _damage)
    {
        direction = _direction;
        damage = _damage;
        created = true;
    }
}
