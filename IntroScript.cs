using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("LoadMenu");
    }

    IEnumerator LoadMenu()
    {
        yield return new WaitForSeconds(16f);

        int scene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = scene + 1;
        SceneManager.LoadScene(nextScene);
    }

}