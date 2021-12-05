using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform ray;
    public float pistolDamage = 10f;
    public int bullets = 7;

    public AudioClip fire;
    public AudioClip empty;
    public AudioClip reloadSound;
    public AudioClip reloadCockSound;
    public AudioClip enemyHitSound;
    public AudioClip pickupAmmo;


    public bool canFire = true;

    private AudioSource audioSource;

    public int totalAmmo = 21;

    private Rigidbody2D rb;
    private RaycastHit hit;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        canFire = true;

    }

    void Update()
    {
        Shoot();
        reload();
    }
    
    private void Shoot()
    {
         if (Input.GetMouseButtonDown(0) && canFire == true)
         {

            if (bullets > 0 && totalAmmo > 0)
            {

                // ADD Sprite muzzle flash

                bullets--;

                audioSource.PlayOneShot(fire);
                

                // TransformDirection FIXED THE PROBLEM!!!!!!! -- Vector2.Up means Forwards from sprite. 
                RaycastHit2D hit = Physics2D.Raycast(ray.transform.position, ray.transform.TransformDirection(Vector2.up));

                EnemyDamage target = hit.transform.GetComponent<EnemyDamage>();

                if (target != null)
                {
                    target.TakeDamage(pistolDamage);
                    audioSource.PlayOneShot(enemyHitSound);
                }

                if (hit.collider != null)
                {
                    Debug.Log(hit.collider.name);
                }

                Debug.DrawRay(ray.transform.position, ray.transform.TransformDirection(Vector2.up) * 10, Color.blue, 5f);

            }

            else
            {
                audioSource.PlayOneShot(empty);
            }

         }
    }


    private void reload ()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            canFire = false;
            animator.SetTrigger("Reload");

            if (bullets > 0)
            {
                audioSource.PlayOneShot(reloadSound);
                StartCoroutine("ReloadCoroutine");
            }

            else
            {
                audioSource.PlayOneShot(reloadCockSound);
                StartCoroutine("FullReloadCoroutine");
            }
        }
    }

    IEnumerator ReloadCoroutine()
    {
        yield return new WaitForSeconds(4f);
        bullets = 8;
        canFire = true;
        yield return null;
    }

    IEnumerator FullReloadCoroutine()
    {
        yield return new WaitForSeconds(5f);
        bullets = 7;
        canFire = true;
        yield return null;
    }
    
    public void PickupAmmo(int ammo)
    {
        totalAmmo += ammo;
        Debug.Log(totalAmmo);
        audioSource.PlayOneShot(pickupAmmo);
    }

}
