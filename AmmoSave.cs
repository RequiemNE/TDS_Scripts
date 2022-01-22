using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSave : MonoBehaviour
{

    private static GameObject ammoCounter;

    public int magAmmo = 0;
    public int reserveAmmo = 0;

    private void Awake()
    {
        if (!ammoCounter)
        {
            ammoCounter = this.gameObject;
        }

        else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        // assign players mag and total ammo to what has carried over.
        var player = GameObject.Find("Character");
        Shooting playerAmmo = player.GetComponent<Shooting>();
        playerAmmo.bullets = magAmmo;
        playerAmmo.totalAmmo = reserveAmmo;
        magAmmo = 0;
        reserveAmmo = 0;

    }

    public void GetAmmo(int bullets, int totalAmmo)
    {
        magAmmo = bullets;
        reserveAmmo = totalAmmo;
    }
}
