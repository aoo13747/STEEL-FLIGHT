using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Identity {

	public int damage = 10;
	public int moneyReward;
	public int score;

	public AudioClip impactSound;
	public AudioSource audioSource;

	private void Start()
	{
		currentHealth = maxHealth;		
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		Player player = collision.collider.GetComponent<Player>();
		if (player != null)
		{			
			player.TakeDamage(damage);
			//audioSource.PlayOneShot(impactSound);
			base.Die();
		}
	}

	public override void Die()
	{
		GameProgression.instance.AddScore(score);
		Player.AddMoney(moneyReward);
		base.Die();
	}

	public void Remove ()
	{
		base.Die();
	}

}
