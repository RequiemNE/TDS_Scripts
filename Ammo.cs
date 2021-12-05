using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public int ammount = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Shooting giveAmmo = collision.transform.GetComponent<Shooting>();
            giveAmmo.PickupAmmo(ammount);

            Destroy(gameObject);
        }
    }
}
