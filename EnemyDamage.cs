using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float health = 30f;

    public GameObject body;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // get body sprite.
        //Create with same transform. 

        Instantiate(body, transform.position, transform.rotation);

       Destroy(gameObject);
    }
}
