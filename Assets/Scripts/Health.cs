using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth;
    [SerializeField] Slider sliderHealthBar;
    [SerializeField] bool showHealthBarWhenFull;
    private float currentHealth;
    private bool isDead = false;

    // Start is called before the first frame update
    protected void Start()
    {
        currentHealth = maxHealth;
        if(sliderHealthBar != null)
        {
            sliderHealthBar.maxValue = maxHealth;
        }
        UpdateHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Heal(float health)
    {
        currentHealth += health;
        UpdateHealthBar();
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void TakeDamage(float damage)
    {
        if (isDead) return;
        currentHealth -= damage;
        UpdateHealthBar();
        if (currentHealth <= 0)
        {
            if (sliderHealthBar != null)
            {
                sliderHealthBar.gameObject.SetActive(false);
            }
            Die();
        } else
        {
            Hurt();
        }
    }

    public virtual void Hurt()
    {
    }

    public virtual void Die()
    {
        isDead = true;
    }

    private void UpdateHealthBar()
    {
        if(sliderHealthBar != null)
        {
            if (currentHealth == maxHealth && !showHealthBarWhenFull)
            {
                sliderHealthBar.gameObject.SetActive(false);
            } else
            {
                sliderHealthBar.gameObject.SetActive(true);
            }
            sliderHealthBar.value = currentHealth;
        }
    }
    
    public bool IsDead()
    {
        return isDead;
    }
}
