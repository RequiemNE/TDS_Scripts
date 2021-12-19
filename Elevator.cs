using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Elevator : MonoBehaviour
{

    [SerializeField] private bool canMove = true;
    [SerializeField] private bool trigger = false;
    [SerializeField] private bool outsideLift = false;
    [SerializeField] private bool insideLift = false;

    [SerializeField] GameObject liftDoor;
    [SerializeField] GameObject liftOpen;
    [SerializeField] GameObject liftClosed;

    [SerializeField] GameObject secondLiftDoor;
    [SerializeField] GameObject secondLiftOpen;
    [SerializeField] GameObject playerTeleport;
    [SerializeField] GameObject character;

    [SerializeField] GameObject firstFloor;

    public Image fader;

    private AudioSource audioS;
    

    // Start is called before the first frame update
    void Start()
    {
        audioS = GetComponent<AudioSource>();
        fader.GetComponent<CanvasRenderer>().SetAlpha(0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true && trigger == true)
        {
            if (outsideLift == true)
            {
                OutsideLift();
            }

            if (insideLift == true)
            {
                InsideLift();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            trigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            trigger = false;
        }
    }

    private void OutsideLift()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            liftDoor.transform.localPosition = Vector2.Lerp(liftDoor.transform.position, liftOpen.transform.localPosition, 1);
            outsideLift = false;
            audioS.Play();
        }
    }

    private void InsideLift()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            liftDoor.transform.localPosition = Vector2.Lerp(liftDoor.transform.position, liftClosed.transform.localPosition, 1);
            fader.enabled = true;
            fader.CrossFadeAlpha(1f, 2f, false);
            insideLift = false;
            audioS.Play();


            StartCoroutine("FadeBack");
            StartCoroutine("OpenDoor");
            StartCoroutine("TransportPlayer");
        }
    }

    IEnumerator FadeBack()
    {
        yield return new WaitForSeconds(5f);
        fader.CrossFadeAlpha(0f, 5f, false);
    }

    IEnumerator OpenDoor()
    {
        yield return new WaitForSeconds(8f);
        secondLiftDoor.transform.localPosition = Vector2.Lerp(secondLiftDoor.transform.position, secondLiftOpen.transform.localPosition, 1);
        firstFloor.SetActive(false);
    }

    IEnumerator TransportPlayer()
    {
        yield return new WaitForSeconds(3);
        character.transform.position = playerTeleport.transform.position;
        canMove = false;

    }
}
