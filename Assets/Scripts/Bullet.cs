using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed = 10f;
	public int damage = 10;	

	private Rigidbody2D rb;

	public GameObject impactEffect;

	public bool explodeOnImpact = false;
	public bool explodeAfterTime = false;
	public float explosionRange = 4f;
	public float explosionDelayTime = 2f;
	private float explodeTime;

	public bool enemyBullet = false;
	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = transform.up * speed;

		if (enemyBullet)
			rb.AddTorque(10f, ForceMode2D.Impulse);

		explodeTime = Time.time + explosionDelayTime;
	}

	private void Update()
	{
		if (!explodeAfterTime)
			return;
		if(Time.time >= explodeTime)
        {
			Explode(null);
			return;
        }
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (explodeAfterTime)
			return;

		if (!enemyBullet)
		{
			Enemy enemy = collider.GetComponent<Enemy>();
			if (enemy != null)
			{
				Explode(enemy);
				//Debug.Log("Enemy Take Damage");
				//enemy.TakeDamage(damage);
				//Destroy(gameObject);
			}
			//Destroy(gameObject, 5f);
		}
		else
		{
			Player player = collider.GetComponent<Player>();
			if (player != null)
			{
				Explode(player);
				//Debug.Log("Player Take Damage");
				//player.TakeDamage(damage);
				//Destroy(gameObject);
			}
			//Destroy(gameObject, 5f);
		}
		
	}
	private void Explode(Identity target)
    {
		if(target != null)
        {
			target.TakeDamage(damage);
        }
		if(explodeOnImpact && !enemyBullet)
        {
			Collider2D[] targets = Physics2D.OverlapCircleAll(rb.position, explosionRange);
			foreach(Collider2D t in targets)
            {
				Enemy enemy = t.GetComponent<Enemy>();
				if(enemy != null)
                {
					enemy.TakeDamage(damage);
                }
				Bullet bullet = t.GetComponent<Bullet>();
				if(bullet != null && bullet != this)
                {
					bullet.Remove();
                }
            }
        }
		Remove();
    }
	public void Remove()
    {
		GameObject effect = Instantiate(impactEffect, transform.position, transform.rotation);
		effect.transform.localScale = transform.localScale;
		Destroy(effect, 2f);

		Destroy(gameObject);
	}

    private void OnDrawGizmosSelected()
    {
		Gizmos.color = Color.blue;
		Gizmos.DrawSphere(transform.position, explosionRange);
    }
}

