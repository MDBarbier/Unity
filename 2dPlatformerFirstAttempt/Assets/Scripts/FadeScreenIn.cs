using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreenIn : MonoBehaviour
{
    public float fadeTime;
    private Image blackScreen;

    // Start is called before the first frame update
    public void Start()
    {
        blackScreen = GetComponent<Image>();
    }

    // Update is called once per frame
    public void Update()
    {
        blackScreen.CrossFadeAlpha(0f, fadeTime, false);

        if (blackScreen.color.a <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
