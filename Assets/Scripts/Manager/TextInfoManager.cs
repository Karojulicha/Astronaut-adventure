using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextInfoManager : MonoBehaviour
{
    public static TextInfoManager Instance { get; private set; }

    public TextMeshProUGUI textInfo;
    public Canvas canvas;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator InactiveText(float number)
    {
        yield return new WaitForSeconds(number);

        if (textInfo != null)
        {
            textInfo.gameObject.SetActive(false);
            canvas.gameObject.SetActive(false);
        }
    }

    public void ShowInfoForSeconds(string message, float number)
    {
        if (textInfo != null)
        {
            textInfo.gameObject.SetActive(true);
            canvas.gameObject.SetActive(true);
            textInfo.text = message;
            StartCoroutine(InactiveText(number));
        }
    }

}
