using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public int health = 30;
    public GameObject UI;


    private SpriteRenderer sprite;
    private bool canTakeDamage = true;
    private AudioSource audioSource;

    [SerializeField] private AudioClip[] hitNoises;
    [SerializeField] private AudioClip deathNoise;
    

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canTakeDamage == true)
        {
            var enemyType = collision.gameObject.tag;
            switch (enemyType)
            {
                case "Enemy":
                    NormalEnemyHit();
                    break;
                case "FastEnemy":
                    FastEnemyHit();
                    break;
                default:
                    break;

            }


            //if (collision.gameObject.tag == "Enemy")
               // NormalEnemyHit();

            // SPLIT ifs for seperate enemy tags when they are added in.
            // Use SWITCH?
            // Normal zombie -10. Fast zombie -50. Heavy Zombie -15
        }

        else
        {

        }

    }

    private void NormalEnemyHit()
    {
        canTakeDamage = false;

        if (health > 10)
        {
            health -= 10;
            StartCoroutine("PlayerTakesDamage");
            var rnd = new System.Random();
            int hitRnd = rnd.Next(0, hitNoises.Length);
            audioSource.PlayOneShot(hitNoises[hitRnd]);

        }

        else if (health == 10)
        {
            health -= 10;
            IfDies();
        }
    }

    private void FastEnemyHit()
    {
        health = 0;
        IfDies();
    }


    private void Update()
    {        
        ShowHealth();
    }

    private void ShowHealth()
    {
        UIManager showHealth = UI.GetComponent<UIManager>();
        showHealth.UI_health(health);
    }

    private void IfDies()
    {
        
        
          if (health == 0)
          {
              UIManager deadScript = UI.GetComponent<UIManager>();
              deadScript.isDead(true);
              audioSource.PlayOneShot(deathNoise);
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

