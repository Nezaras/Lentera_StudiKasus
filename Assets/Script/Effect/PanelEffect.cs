using UnityEngine;
using System.Collections;

public class PanelEffect : MonoBehaviour
{
    public float fadeDuration = 0.3f;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(FadeCanvas(0, 1, true));
    }

    public void Hide()
    {
        StopAllCoroutines();
        StartCoroutine(FadeCanvas(1, 0, false));
    }

    private IEnumerator FadeCanvas(float startAlpha, float endAlpha, bool setActiveOnEnd)
    {
        if (startAlpha < endAlpha)
        {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }

        float t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float normalizedTime = Mathf.Clamp01(t / fadeDuration);
            canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, normalizedTime);
            yield return null;
        }

        canvasGroup.alpha = endAlpha;

        if (endAlpha == 1)
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
        else
        {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            gameObject.SetActive(setActiveOnEnd);
        }
    }
}
