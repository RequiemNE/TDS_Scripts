using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEnd : MonoBehaviour
{

    [SerializeField] private Image black;
    [SerializeField] private GameObject levelManager;
    [SerializeField] private GameObject UI;
    [SerializeField] private GameObject[] toDisable;

    private AudioSource audioS;
    private AudioSource levelManagerAudio;
    private bool trigger = false;

    private void Start()
    {
        audioS = GetComponent<AudioSource>();
        levelManagerAudio = levelManager.GetComponent<AudioSource>();
        black.enabled = true;
        black.GetComponent<CanvasRenderer>().SetAlpha(0f);
    }

    private void Update()
    {
        if (trigger == true)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                audioS.Play();
                levelManagerAudio.Stop();
                black.CrossFadeAlpha(1f, 3f, false);
                StartCoroutine("EndLevel");

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

    IEnumerator EndLevel()
    {
        yield return new WaitForSeconds(15f);

        UIManager loadMenu = UI.GetComponent<UIManager>();
        loadMenu.GoToMainMenu();
    }
}
