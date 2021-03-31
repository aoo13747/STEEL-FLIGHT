using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ItemHolder : MonoBehaviour
{
    public PlayerShooting playerShooting;
    public int weaponID;

    public TextMeshProUGUI weaponName;
    public TextMeshProUGUI weaponPrice;
    public TextMeshProUGUI weaponFirerate;
    
    void Start()
    {
        SetInfo();
    }
    void SetInfo()
    {
        weaponName.text = playerShooting.weapons[weaponID].name;
        weaponPrice.text = "Cost : " + playerShooting.weapons[weaponID].weaponCost.ToString();
        weaponFirerate.text = "Firerate : " + playerShooting.weapons[weaponID].fireRate.ToString();        
    }
    
}
