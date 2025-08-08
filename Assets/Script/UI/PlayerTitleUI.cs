using UnityEngine;
using TMPro;
using System.Collections;

public class PlayerTitleUI : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public float fadeDuration = 0.3f;
    public float bounceScale = 1.2f;
    public float bounceDuration = 0.2f;

    public void ChangeTitleWithTransition(string newTitle)
    {
        StopAllCoroutines();
        StartCoroutine(TitleTransition(newTitle));
    }

    private IEnumerator TitleTransition(string newTitle)
    {
        for (float t = 0; t < 1; t += Time.deltaTime / fadeDuration)
        {
            Color c = titleText.color;
            c.a = Mathf.Lerp(1, 0, t);
            titleText.color = c;
            yield return null;
        }

        titleText.text = newTitle;

        Vector3 originalScale = titleText.rectTransform.localScale;
        Vector3 targetScale = originalScale * bounceScale;

        for (float t = 0; t < 1; t += Time.deltaTime / bounceDuration)
        {
            titleText.rectTransform.localScale = Vector3.Lerp(originalScale, targetScale, t);
            yield return null;
        }

        for (float t = 0; t < 1; t += Time.deltaTime / fadeDuration)
        {
            Color c = titleText.color;
            c.a = Mathf.Lerp(0, 1, t);
            titleText.color = c;

            titleText.rectTransform.localScale = Vector3.Lerp(targetScale, originalScale, t);
            yield return null;
        }

        titleText.rectTransform.localScale = originalScale;
    }
}
