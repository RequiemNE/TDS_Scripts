using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public Image fadeIn;

    // Start is called before the first frame update
    void Start()
    {
        fadeIn.enabled = true;
        fadeIn.GetComponent<CanvasRenderer>().SetAlpha(1f);
        fadeIn.CrossFadeAlpha(0f, 7f, false);
        StartCoroutine("DisableBlack");
    }

    // Update is called once per frame
    IEnumerator DisableBlack()
    {
        yield return new WaitForSeconds(6f);
        Destroy(fadeIn);
    }
}
