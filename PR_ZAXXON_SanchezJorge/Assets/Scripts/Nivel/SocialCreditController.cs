using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SocialCreditController : MonoBehaviour
{
    public Text thisText, socialCreditText;
    public static int lastLevel = 1;
    // Start is called before the first frame update
    void Start()
    {
        thisText.CrossFadeAlpha(0, 0, true);
        socialCreditText.CrossFadeAlpha(0, 0, true);
    }

    void Update()
    {
        if (lastLevel != GameManager.level)
        {
            lastLevel = GameManager.level;
            StartCoroutine(Animate());
        }
    }


    public IEnumerator Animate()
    {
        thisText.CrossFadeAlpha(1, 1, true);
        yield return new WaitForSeconds(1f);
        socialCreditText.CrossFadeAlpha(1, 1, true);
        yield return new WaitForSeconds(1f);
        thisText.CrossFadeAlpha(0, 1, true);
        socialCreditText.CrossFadeAlpha(0, 1, true);
    }
}
