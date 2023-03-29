using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDamage : MonoBehaviour
{
    public float swordDamage = 1f;
    [SerializeField] float damageCooldown = 1f;

    private float nextDamage = 0f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            HeavyBanditHealth hbh = other.gameObject.GetComponent<HeavyBanditHealth>();
            if(hbh != null && Time.time > nextDamage)
            {
                hbh.TakeDamage(swordDamage);
                nextDamage = Time.time + damageCooldown;
            }
        }

        if (other.gameObject.CompareTag("Player"))
        {
            Health health = other.gameObject.GetComponent<Health>();
            if (health != null && Time.time > nextDamage)
            {
                health.TakeDamage(swordDamage);
                nextDamage = Time.time + damageCooldown;
            }
        }
    }
}
