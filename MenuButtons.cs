using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    public Button startB, infoB, quitB;

    private void Start()
    {
        startB.onClick.AddListener(StartButton);
        infoB.onClick.AddListener(InfoButton);
        quitB.onClick.AddListener(QuitButton);
    }

    public void StartButton()
    {
       StartCoroutine("StartGame");
    }

    private void InfoButton()
    {
        Debug.Log("info");   
    }

    private void QuitButton()
    {
        Application.Quit();
        
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(3f);
        int scene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = scene + 1;
        SceneManager.LoadScene(nextScene);
    }

}
