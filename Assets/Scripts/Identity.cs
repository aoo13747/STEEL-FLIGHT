using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Identity : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public HealthBar healthBar;
    public GameObject deathEffect;
    
    public virtual void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;       
        
        if(currentHealth <= 0)
        {
            Die();
        }
    }
    public virtual void Die()
    {
        GameObject effect = Instantiate(deathEffect, transform.position, transform.rotation);
        effect.transform.localScale = transform.localScale;
        Destroy(effect, 5f);
        Destroy(gameObject);
    }
}
