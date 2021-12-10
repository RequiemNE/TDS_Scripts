using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject zombie;
    public GameObject zSpawn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(zombie, zSpawn.transform.position, zSpawn.transform.rotation);
        }
    }
}
