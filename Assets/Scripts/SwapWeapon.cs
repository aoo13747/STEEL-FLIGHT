using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SwapWeapon : MonoBehaviour
{
    public int[] weaponID;
    public PlayerShooting playerShooting;
    public TextMeshProUGUI currentWeaponText;
    
    void Update()
    {
        

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            playerShooting.currentWeapon = weaponID[0];
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            playerShooting.currentWeapon = weaponID[1];
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            playerShooting.currentWeapon = weaponID[2];
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            playerShooting.currentWeapon = weaponID[3];
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            playerShooting.currentWeapon = weaponID[4];
        }
    }
}
