using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{

    Rigidbody2D projectileRigidbody;
    bool created = false;
    Vector2 direction;
    float speed = 20f;
    float maxduration = 0.25f;
    float duration = 0;
    void Start()
    {
        projectileRigidbody = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        if (created)
        {
            projectileRigidbody.velocity = direction * speed;
            if (duration <= maxduration)
            {
                duration += Time.fixedDeltaTime;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    public void OnCreate(Vector2 _direction)
    {
        if(_direction != Vector2.zero) { direction = _direction; } else { direction = new Vector2(0, 1); }

        created = true;
        Debug.Log("Created");
    }


}
