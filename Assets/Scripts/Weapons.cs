using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
[System.Serializable]
public class Weapons : ScriptableObject
{
    public string weaponName;    
    public int weaponCost;
    public float fireRate;    

    public GameObject bulletPrefab;
    public bool shootRayCast = false;
    public int rayCastDamage;
    public void Shoot(Transform firePoint)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Destroy(bullet, 5f);
    }
}
