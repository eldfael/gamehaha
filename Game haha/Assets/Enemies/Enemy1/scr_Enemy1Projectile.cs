using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Enemy1Projectile : MonoBehaviour
{
    Vector2 direction;
    int damage;
    bool created = false;

    float speed = 50f;
    float duration = 1.5f;
    float durationTimer = 0f;

    ContactFilter2D filter;
    List<Collider2D> collisions = new List<Collider2D>();
    Rigidbody2D projectileRigidbody;

    void Start()
    {
        // speed = Random.Range(speed - 5f, speed + 5f);
        filter.useTriggers = true;
        projectileRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
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
                    if (c.CompareTag("Player"))
                    {
                        //DAMAGE PLAYER FOR NOW JUST DESTROY
                        Destroy(gameObject);
                        
                    }
                    if (c.CompareTag("Wall"))
                    {
                        Destroy(gameObject);
                    }

                });


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
