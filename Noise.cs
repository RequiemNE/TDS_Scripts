using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noise : MonoBehaviour
{

    private AudioSource audioS;
    public float timeToDestroy = 2f;

    void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audioS.Play();
            StartCoroutine("Destroy");
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
    }
}
