using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float health = 30f;

    public GameObject body;
    public float thrust = 5f;

    private Rigidbody2D rb2d;


    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        KnockBack();
        if (health <= 0)
        {
            Die();
        }
    }
    private void KnockBack()
    {
        rb2d.AddForce(-transform.up * thrust);
        Debug.Log("Force");
    }

    void Die()
    {

       Instantiate(body, transform.position, transform.rotation);
       

       Destroy(gameObject);
    }
}
