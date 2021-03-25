using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scr_DamageNumber : MonoBehaviour
{
    public GameObject damageNumber;
    Rigidbody2D damageRigidbody2D;
    float duration = 0.3f;
    float durationtimer = 0f;

    private void Awake()
    {
        damageRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        damageRigidbody2D.velocity = new Vector2(0, 10f);
    }
    private void FixedUpdate()
    {
        if (durationtimer >= duration) { Destroy(gameObject); } else { durationtimer += Time.fixedDeltaTime; }
    }

    public void SetNumber(float number)
    {
        GetComponent<TextMeshPro>().SetText(number.ToString());
    }

    public void Crit()
    {
        GetComponent<TextMeshPro>().color = Color.red;
    }
}
