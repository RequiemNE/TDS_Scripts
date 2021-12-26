using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private Image pauseBG;

    public static bool isPaused = false;

    private AudioSource audioS;

    // Start is called before the first frame update
    void Start()
    {
        audioS = GetComponent<AudioSource>();
        audioS.ignoreListenerPause = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    private void PauseGame()
    {
        if (!isPaused)
        {
            Time.timeScale = 0;
            AudioListener.pause = true;
            isPaused = true;
        }

        else if (isPaused)
        {
            Time.timeScale = 1;
            AudioListener.pause = false;
            isPaused = false;
        }
    }
}
