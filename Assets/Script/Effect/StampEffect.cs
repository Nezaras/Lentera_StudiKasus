using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StampEffect : MonoBehaviour
{
    public Image stampImage;

    public void PlayStamp()
    {
        StopAllCoroutines();
        StartCoroutine(StampAnimation());
    }

    private IEnumerator StampAnimation()
    {
        stampImage.gameObject.SetActive(true);

        stampImage.color = new Color(1, 1, 1, 0);
        stampImage.rectTransform.localScale = Vector3.one * 2f;
        stampImage.rectTransform.localRotation = Quaternion.Euler(0, 0, Random.Range(-10f, 10f));

        float duration = 0.15f;
        for (float t = 0; t < 1; t += Time.deltaTime / duration)
        {
            float scale = Mathf.Lerp(2f, 0.9f, t);
            stampImage.rectTransform.localScale = Vector3.one * scale;
            stampImage.color = new Color(1, 1, 1, Mathf.Lerp(0, 1, t));
            yield return null;
        }

        duration = 0.1f;
        for (float t = 0; t < 1; t += Time.deltaTime / duration)
        {
            float scale = Mathf.Lerp(0.9f, 1f, t);
            stampImage.rectTransform.localScale = Vector3.one * scale;
            yield return null;
        }
    }

    public void HideStamp()
    {
        if (stampImage != null)
            stampImage.gameObject.SetActive(false);
    }

}
