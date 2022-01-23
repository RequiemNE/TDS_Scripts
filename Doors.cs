using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    [SerializeField] private bool canOpen = false;
    [SerializeField] private GameObject door;
    private bool trigger = false;
    private AudioSource audioS;

    [SerializeField] private GameObject bg;

    private void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);

        if (canOpen == true && collision.gameObject.tag == "Player")
        {
            trigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (canOpen == true && collision.gameObject.tag == "Player")
        {
            trigger = false;
        }
    }

    private void Update()
    {
        if (trigger == true && Input.GetKeyDown(KeyCode.E) && !PauseMenu.isPaused)
        {        
            Vector3 rotationToAdd = new Vector3(0, 0, 102);
            door.transform.Rotate(rotationToAdd);
            audioS.Play();
            trigger = false;
            canOpen = false;

            Destroy(bg);
        }
    }
}
