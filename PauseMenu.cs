using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private Image pauseBG;
    [SerializeField] private GameObject pauseMenuStuff;
    [SerializeField] private AudioClip pauseNoise;
    [SerializeField] private AudioClip menuClick;
    [SerializeField] private GameObject UI;
    [SerializeField] private Button quitB, infoB, infoBack, AYS_yes, AYS_no;
    [SerializeField] private GameObject AYS;
    [SerializeField] private GameObject infoDetails;

    public static bool isPaused = false;

    private AudioSource audioS;

    // Start is called before the first frame update
    void Start()
    {
        audioS = GetComponent<AudioSource>();
        audioS.ignoreListenerPause = true;
        pauseMenuStuff.SetActive(false);
        quitB.onClick.AddListener(QuitGame);
        infoB.onClick.AddListener(GetInfo);
        infoBack.onClick.AddListener(GoToPause);
        AYS_no.onClick.AddListener(AYS_No);
        AYS_yes.onClick.AddListener(AYS_Yes);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            audioS.PlayOneShot(pauseNoise);
            PauseGame();
        }
    }

    private void PauseGame()
    {
        if (!isPaused)
        {
            isPaused = true;
            Time.timeScale = 0;
            Cursor.visible = true;
            pauseMenuStuff.SetActive(true);
            infoDetails.SetActive(false);
            infoBack.gameObject.SetActive(false);
            AudioListener.pause = true;
            pauseBG.enabled = true;
            AYS_no.gameObject.SetActive(false);
            AYS_yes.gameObject.SetActive(false);
            AYS.SetActive(false);
        }

        else if (isPaused)
        {
            isPaused = false;
            Time.timeScale = 1;
            pauseMenuStuff.SetActive(false);
            AudioListener.pause = false;
            pauseBG.enabled = false;
            Cursor.visible = false;
        }
    }

    public void GetInfo()
    {
        quitB.gameObject.SetActive(false);
        infoB.gameObject.SetActive(false);
        infoDetails.SetActive(true);
        infoBack.gameObject.SetActive(true);
        PlayMenuclick();
    }

    public void GoToPause()
    {
        PlayMenuclick();
        infoDetails.SetActive(false);
        infoB.gameObject.SetActive(true);
        quitB.gameObject.SetActive(true);
        infoBack.gameObject.SetActive(false);
    }

    private void QuitGame()
    {
        PlayMenuclick();
        AYS.SetActive(true);
        AYS_no.gameObject.SetActive(true);
        AYS_yes.gameObject.SetActive(true);
        quitB.gameObject.SetActive(false);
        infoB.gameObject.SetActive(false);
       
    }

    private void AYS_Yes()
    {
        UIManager loadMenu = UI.GetComponent<UIManager>();
        loadMenu.GoToMainMenu();
    }

    private void AYS_No()
    {
        isPaused = false;
        PlayMenuclick();
        infoB.gameObject.SetActive(true);
        quitB.gameObject.SetActive(true);
        PauseGame();
    }

    private void PlayMenuclick()
    {
        audioS.PlayOneShot(menuClick);
    }
}
