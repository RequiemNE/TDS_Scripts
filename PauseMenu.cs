using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private Image pauseBG;
    [SerializeField] private GameObject pauseMenuStuff;
    [SerializeField] private AudioClip pauseNoise;
    [SerializeField] private GameObject UI;
    [SerializeField] private Button quitB, infoB, infoBack, AYS_yes, AYS_no;
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
            Time.timeScale = 0;
            Cursor.visible = true;
            pauseMenuStuff.SetActive(true);
            infoDetails.SetActive(false);
            AudioListener.pause = true;
            isPaused = true;
            pauseBG.enabled = true;
        }

        else if (isPaused)
        {
            Time.timeScale = 1;
            Cursor.visible = false;
            pauseMenuStuff.SetActive(false);
            AudioListener.pause = false;
            isPaused = false;
            pauseBG.enabled = false;
        }
    }

    public void GetInfo()
    {
        quitB.gameObject.SetActive(false);
        infoB.gameObject.SetActive(false);
        infoDetails.SetActive(true);
        infoBack.onClick.AddListener(GoToPause);
    }

    public void GoToPause()
    {
        Debug.Log("oi");
        infoDetails.SetActive(false);
        infoB.gameObject.SetActive(true);
        quitB.gameObject.SetActive(true);
    }

    private void QuitGame()
    {
        UIManager loadMenu = UI.GetComponent<UIManager>();
        loadMenu.GoToMainMenu();        
    }
}
