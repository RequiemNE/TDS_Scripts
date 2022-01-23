using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastZombie : MonoBehaviour
{
    [SerializeField] private AudioClip[] zNoise;

    private AudioSource audioS;
    private bool trigger = false;


    void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (trigger == false)
        {

            if (collision.gameObject.tag == "Player")
            {
                var rnd = new System.Random();
                var noiseRnd = rnd.Next(0, zNoise.Length);
                audioS.PlayOneShot(zNoise[noiseRnd]);
            }
        }
    }
}
