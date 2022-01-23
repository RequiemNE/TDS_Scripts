using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
                CarryOverAmmo();
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

    private void CarryOverAmmo()
    {

        int magAmmo = 0;
        int reserveAmmo = 0;

        // Get bullets from player.
        var player = GameObject.Find("Character");
        Shooting playerAmmo = player.GetComponent<Shooting>();
        magAmmo = playerAmmo.bullets;
        reserveAmmo = playerAmmo.totalAmmo;

        // Pass bullets to be carried over.
        var ammoSaveObject = GameObject.Find("AmmoSave");
        AmmoSave ammoSaveScript = ammoSaveObject.GetComponent<AmmoSave>();
        ammoSaveScript.GetAmmo(magAmmo, reserveAmmo);

        magAmmo = 0;
        reserveAmmo = 0;
    }


    IEnumerator EndLevel()
    {
        yield return new WaitForSeconds(15f);

        int scene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = scene + 1;
        SceneManager.LoadScene(nextScene);
    }
}
