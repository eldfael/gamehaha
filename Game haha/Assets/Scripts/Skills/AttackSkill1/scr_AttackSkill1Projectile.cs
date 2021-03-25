using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_AttackSkill1Projectile : MonoBehaviour
{

    Rigidbody2D projectileRigidbody;
    bool created = false;
    
    Vector2 direction;
    float damage;

    float speed = 80f;
    float duration = 0.25f;
    float durationTimer = 0;

    List<GameObject> hits = new List<GameObject>();
    ContactFilter2D filter;
    List<Collider2D> collisions = new List<Collider2D>();

    void Start()
    {
        projectileRigidbody = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        if (created)
        {
            projectileRigidbody.velocity = direction * speed;
            if (durationTimer <= duration)
            {
                durationTimer += Time.fixedDeltaTime;
            }
            else
            {
                Destroy(gameObject);
            }

            Physics2D.OverlapCollider(GetComponent<BoxCollider2D>(), filter, collisions);

            if (collisions.Count > 0)
            {

                collisions.ForEach(delegate (Collider2D c)
                {
                    if (c.CompareTag("Enemy") && !hits.Contains(c.gameObject))
                    {
                        c.gameObject.GetComponent<Enemy>().TakeDamage(damage);
                        hits.Add(c.gameObject);
                    }
                    if (c.CompareTag("Wall"))
                    {
                        Destroy(gameObject);
                    }

                });


            }
        }
    }


    public void OnCreate(Vector2 _direction, float _damage)
    {
        if(_direction != Vector2.zero) { direction = _direction; } else { direction = new Vector2(0, 1); }
        damage = _damage;

        created = true;
    }


}
