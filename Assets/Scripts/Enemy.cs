using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D anotherObject)
    {
        if (anotherObject.CompareTag("Bullet"))
        {
            Destroy(anotherObject.gameObject);

            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.color = Color.red;

        Invoke("ResetDamage", 0.25f);
    }

    private void ResetDamage()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.color = Color.white;
    }
}
