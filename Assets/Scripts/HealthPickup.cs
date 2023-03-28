using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] float restorePoints;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Animator animator = GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetTrigger("PickedUp");
            }

            Health health = collision.gameObject.GetComponent<Health>();
            if (health != null)
            {
                health.Heal(restorePoints);
            }
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
