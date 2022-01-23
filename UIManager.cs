using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Image gameOver;
    public GameObject player;

    [SerializeField] private Text ammoDisplay;
    [SerializeField] private Text healthDisplay;

    void Start()
    {
        gameOver.enabled = true;
        gameOver.GetComponent<CanvasRenderer>().SetAlpha(0f);
    }


    public void isDead(bool dead)
    {

        if (dead == true)
        {
            gameOver.CrossFadeAlpha(1f, 0.5f, false);

            character character = player.GetComponent<character>();
            character.enabled = false;
            Shooting shoot = player.GetComponent<Shooting>();
            shoot.enabled = false;
            StartCoroutine("RestartLevel");
        }
    }

    public void UI_Ammo(int magAmmo, int totalAmmo)
    {
        ammoDisplay.text = magAmmo + " / " + totalAmmo;
    }

    public void UI_health(int health)
    {
        healthDisplay.text = health + "";
    }

    public void GoToMainMenu()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(1);
    }

    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(4f);
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene);
    }

}


