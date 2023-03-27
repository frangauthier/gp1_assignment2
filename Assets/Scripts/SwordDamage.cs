using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDamage : MonoBehaviour
{
    public float swordDamage = 1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            HeavyBanditHealth hbh = other.gameObject.GetComponent<HeavyBanditHealth>();
            if(hbh != null)
            {
                hbh.TakeDamage(swordDamage);
            }
        }

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Spotted Player");

            Health health = other.gameObject.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(swordDamage);
            }
        }
    }
}
