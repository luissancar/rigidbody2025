using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Blood : MonoBehaviour
{
    public float fadeDuration = 2f;
    public Image bloodImage;


    void Start()
    {
        if (bloodImage != null)
        {
            Color tempColor = bloodImage.color;
            tempColor.a = 0f;
            bloodImage.color = tempColor;
            bloodImage.gameObject.SetActive(false);
        }
    }

    public void ShowBlood()
    {
        if (bloodImage != null)
        {
            bloodImage.gameObject.SetActive(true);
            Color tempColor = bloodImage.color;
            tempColor.a = 1f;
            bloodImage.color = tempColor;
            StartCoroutine(FadeOut());
        }
    }

    private IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        Color tempColor = bloodImage.color;
        while (elapsedTime < fadeDuration)
        {
            tempColor.a = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            bloodImage.color = tempColor;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        tempColor.a = 0f;
        bloodImage.color = tempColor;
        bloodImage.gameObject.SetActive(false);
    }
    
    
}