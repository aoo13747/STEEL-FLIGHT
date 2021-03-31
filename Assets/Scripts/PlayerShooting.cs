using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

	public Transform firePoint;
	public Weapons[] weapons;
	public int currentWeapon;
	public LineRenderer lineRenderer;

	public AudioClip fireSound;
	public AudioSource playerSorce;

	private float nextTimeOfFire = 0f;

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButton("Fire1"))
		{
			if (Time.time >= nextTimeOfFire)
			{
				if(Time.time >= nextTimeOfFire)
                {
					if(weapons[currentWeapon].shootRayCast)
                    {
						ShootRayCast();
                    }
					else
                    {
						weapons[currentWeapon].Shoot(firePoint);
						playerSorce.PlayOneShot(fireSound);
                    }
					nextTimeOfFire = Time.time + 1 / weapons[currentWeapon].fireRate;
                }
			}
		}
	}	
	void ShootRayCast()
    {
		RaycastHit2D[] hits = Physics2D.CircleCastAll(firePoint.position, lineRenderer.startWidth, firePoint.up);
		foreach(RaycastHit2D hit in hits)
        {
			Enemy enemy = hit.collider.GetComponent<Enemy>();
			if(enemy != null)
            {
				enemy.TakeDamage(weapons[currentWeapon].rayCastDamage);
            }
			lineRenderer.SetPosition(0, firePoint.position);
			lineRenderer.SetPosition(1, firePoint.position + firePoint.up * 100);

			StartCoroutine(FlashLineRenderer());
        }
    }
	IEnumerator FlashLineRenderer()
    {
		lineRenderer.enabled = true;

		yield return new WaitForSeconds(0.02f);

		lineRenderer.enabled = false;
    }
	
}
