using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Identity 
{    
    public static int money;
    bool isRegen;

    private Coroutine coroutine;    
    public AudioSource playerSorce;
    public AudioClip alarmSound;
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);    
              
    }
    public override void TakeDamage(int damageAmount)
    {
        base.TakeDamage(damageAmount);        
        if(isRegen)
        {
            IEnumerator courantine = Regen();
            StopCoroutine(courantine);
            isRegen = !isRegen;
        }
    }
    public override void Die()
    {
        GameManager.instance.PlayerDied();
        base.Die();
    }
    private void FixedUpdate()
    {
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 30)
        {
            playerSorce.PlayOneShot(alarmSound);
        }
    }

    private void Update()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if (currentHealth != maxHealth && !isRegen)
        {            
            StartCoroutine(Regen());
        }
    }
    IEnumerator Regen()
    {
        isRegen = true;
        yield return new WaitForSeconds(5f);
        while (currentHealth < maxHealth)
        {
            currentHealth += 2;
            yield return new WaitForSeconds(2f);
        }
        isRegen = false;
    }
    


    public static void AddMoney(int amount)
    {
        money += amount;
    }
    public static void ReduceMoney(int amount)
    {
        money -= amount;
    }
    


}
