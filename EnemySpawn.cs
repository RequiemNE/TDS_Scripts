using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] zombie;
    public GameObject zSpawn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var rnd = new System.Random();
            var zomRnd = rnd.Next(0, zombie.Length);
            Instantiate(zombie[zomRnd], zSpawn.transform.position, zSpawn.transform.rotation);

            Destroy(gameObject); 
        }
    }
}
