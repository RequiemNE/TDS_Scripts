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

    [SerializeField] private GameObject UI;

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
        DisplayAmmo();
    }

    private void Shoot()
    {
         if (Input.GetMouseButtonDown(0) && canFire == true && !PauseMenu.isPaused)
         {

            if (bullets > 0)
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
        if (Input.GetKeyDown(KeyCode.R) && canFire == true && !PauseMenu.isPaused)
        {
            canFire = false;            

            if (bullets > 0 && totalAmmo > 0)
            {
                animator.SetTrigger("Reload");
                audioSource.PlayOneShot(reloadSound);
                StartCoroutine("ReloadCoroutine");
            }

            else if (bullets == 0 && totalAmmo > 0)
            {
                animator.SetTrigger("Reload");
                audioSource.PlayOneShot(reloadCockSound);
                StartCoroutine("FullReloadCoroutine");
            }

            else
            {
                canFire = true;
            }
        }
    }

    IEnumerator ReloadCoroutine()
    {
        yield return new WaitForSeconds(4f);
        BulletPool(8);
        canFire = true;
        yield return null;
    }

    IEnumerator FullReloadCoroutine()
    {
        yield return new WaitForSeconds(5f);
        BulletPool(7);
        canFire = true;
        yield return null;
    }
    
    public void PickupAmmo(int ammo)
    {
        totalAmmo += ammo;
        audioSource.PlayOneShot(pickupAmmo);
    }

    private void DisplayAmmo()
    {
        UIManager ammo = UI.GetComponent<UIManager>();
        ammo.UI_Ammo(bullets, totalAmmo);
    }

    private void BulletPool(int bul)
    {

        int pool = 0;
        int bulletCopy = bullets;

        if (totalAmmo > bul)
        {
            while (bulletCopy < bul)
            {
                pool++;
                bulletCopy++;
            }

            bullets += pool;
            totalAmmo -= pool;

        }
        
        else if (totalAmmo <= bul)
        {

            while (totalAmmo > 0 && bullets < bul)
            {
                bullets++;
                totalAmmo--;
            }
        }
        



        if (totalAmmo < 0)
        {
            totalAmmo = 0;
        }
            Debug.Log("total ammo: " + totalAmmo);
        


    }

}
