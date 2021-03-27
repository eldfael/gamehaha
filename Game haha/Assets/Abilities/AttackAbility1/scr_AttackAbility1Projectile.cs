using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_AttackAbility1Projectile : MonoBehaviour
{

    Rigidbody2D projectileRigidbody;
    bool created = false;
    
    Vector2 direction;
    int damage;
    float critChance;

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
                        if (Random.Range(0f, 1f) + critChance > 1)
                        {
                            c.gameObject.GetComponent<Enemy>().TakeDamage(damage + (int)(damage * 0.5f), true);
                        }
                        else
                        {
                            c.gameObject.GetComponent<Enemy>().TakeDamage(damage+Random.Range((int)(-damage*0.2f),(int)(1+damage*0.2f)), false);
                        }
                        
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


    public void OnCreate(Vector2 _direction, int _damage, float _critChance)
    {
        if(_direction != Vector2.zero) { direction = _direction; } else { direction = new Vector2(0, 1); }
        damage = _damage;
        critChance = _critChance;
        created = true;
    }


}
