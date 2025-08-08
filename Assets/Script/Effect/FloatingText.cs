using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{
    public float moveSpeed = 50f;
    public float fadeDuration = 1f;

    private TextMeshProUGUI textMesh;
    private CanvasGroup canvasGroup;
    private float timer;

    void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Setup(string text)
    {
        textMesh.text = text;
        timer = 0f;
        canvasGroup.alpha = 1f;
    }

    void Update()
    {
        // Gerak ke atas
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

        // Fade out
        timer += Time.deltaTime;
        canvasGroup.alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);

        // Hapus object setelah selesai fade
        if (timer >= fadeDuration)
        {
            Destroy(gameObject);
        }
    }
}
