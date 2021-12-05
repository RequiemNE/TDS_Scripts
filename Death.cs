using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Death : MonoBehaviour
{
    public int health = 30;
    public Image image;


    private SpriteRenderer sprite;
    private bool canTakeDamage = true;

    private void Start()
    {
        image.enabled = true;
        image.GetComponent<CanvasRenderer>().SetAlpha(0f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canTakeDamage == true)
        {
                  
            if (collision.gameObject.tag == "Enemy")
            {

                canTakeDamage = false;

                if (health > 0)
                {
                    health -= 10;
                    Debug.Log(health);
                    StartCoroutine("PlayerTakesDamage");
                    //Add player hit noise
                }

                else
                {
                   
                }
            }
            // SPLIT ifs for seperate enemy tags when they are added in.
            // Use SWITCH?
            // Normal zombie -10. Fast zombie -50. Heavy Zombie -15
        }

        else
        {

        }

    }

    private void Update()
    {
        if (health == 0)
        {

            image.CrossFadeAlpha(1f, 2f, false);

        }
    }

    IEnumerator PlayerTakesDamage()
    {
        sprite = GetComponent<SpriteRenderer>();

        for (int i = 0; i <= 6; i++)
        {
            if (sprite.enabled == false)
            {
                sprite.enabled = true;
            }

            else if (sprite.enabled == true)
            {
                sprite.enabled = false;
            }

            yield return new WaitForSeconds(0.3f);
        }

        sprite.enabled = true;
        canTakeDamage = true;
        yield return null;
    }

}

