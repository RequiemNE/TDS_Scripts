using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    public Button startB, infoB, quitB, backB;

    public GameObject infoScreen;

    [SerializeField] private AudioClip select, startSelect;

    private AudioSource audioSrc;

    private void Start()
    {
        
        startB.onClick.AddListener(StartButton);
        infoB.onClick.AddListener(InfoButton);
        quitB.onClick.AddListener(QuitButton);
        backB.onClick.AddListener(BackButton);
        infoScreen.gameObject.SetActive(false);

        audioSrc = GetComponent<AudioSource>();

    }

    public void StartButton()
    {
        audioSrc.PlayOneShot(startSelect);
       StartCoroutine("StartGame");
    }

    public void InfoButton()
    {
        startB.gameObject.SetActive(false);
        infoB.gameObject.SetActive(false);
        quitB.gameObject.SetActive(false);
        infoScreen.gameObject.SetActive(true);
        PlaySelect();

    }

    public void QuitButton()
    {
        startB.gameObject.SetActive(true);
        Application.Quit();
        
    }

    public void BackButton() {
        Debug.Log("oioi");
        startB.gameObject.SetActive(true);
        infoB.gameObject.SetActive(true);
        quitB.gameObject.SetActive(true);
        infoScreen.gameObject.SetActive(false);
        PlaySelect();
    }

    private void PlaySelect()
    {
        audioSrc.PlayOneShot(select);
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(3f);
        int scene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = scene + 1;
        SceneManager.LoadScene(nextScene);
    }


}
