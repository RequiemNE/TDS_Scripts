using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public GameObject rayCaster;
    public float pistolDamage = 10f;

    private Rigidbody2D rb;
    private RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }
    
    private void Shoot()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, rayCaster.transform.position);

            EnemyDamage target = hit.transform.GetComponent<EnemyDamage>();

            if (target != null)
            {
                target.TakeDamage(pistolDamage);
            }

            if (hit.collider != null)
            {
                Debug.Log(hit.collider.name);
            }

            Debug.DrawRay(transform.position, rayCaster.transform.position * 10, Color.blue, 5f);
            
        }
    }
    
}
