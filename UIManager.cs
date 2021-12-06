using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image gameOver;
    public GameObject player;


    [SerializeField] private Text ammoDisplay;
    [SerializeField] private Text healthDisplay;



    // Start is called before the first frame update
    void Start()
    {
        gameOver.enabled = true;
        gameOver.GetComponent<CanvasRenderer>().SetAlpha(0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void isDead(bool dead)
    {
        // Used when Character dies

        if (dead == true)
        {
            gameOver.CrossFadeAlpha(1f, 0.5f, false);

            character character = player.GetComponent<character>();
            character.enabled = false;
            Shooting shoot = player.GetComponent<Shooting>();
            shoot.enabled = false;

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

}


