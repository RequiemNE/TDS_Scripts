using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieNoise : MonoBehaviour
{

    [SerializeField] private AudioClip[] zNoise;

    private float[] noiseTimer = { 10f, 5f, 15f, 20f, 8f, 12f };
    private AudioSource audioS;
    private bool trigger = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (trigger == false)
        {

            if (collision.gameObject.tag == "Player")
            {
                StartCoroutine("MakeNoise");
                trigger = true;
            }
        }
    }

    void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    IEnumerator MakeNoise()
    {
        var rnd = new System.Random();
        var timeRnd = rnd.Next(0, noiseTimer.Length);
        var noiseRnd = rnd.Next(0, zNoise.Length);

        yield return new WaitForSeconds(10f);

        audioS.PlayOneShot(zNoise[noiseRnd]);

        StartCoroutine("MakeNoise");
    }

}
