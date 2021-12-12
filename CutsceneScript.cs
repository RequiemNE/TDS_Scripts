using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutsceneScript : MonoBehaviour
{
    public float cutsceneLength = 10f;
    public Button skip;

    private void Start()
    {
        StartCoroutine("NextLevel");
        skip.onClick.AddListener(Next);
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(cutsceneLength);
        Next();
    }

    private void Next()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = scene + 1;
        SceneManager.LoadScene(nextScene);
    }
}
