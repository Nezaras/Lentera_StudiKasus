using UnityEngine;
using TMPro;

public class ClickCounter : MonoBehaviour
{
    public TextMeshProUGUI clickText;
    public QuestManager questManager;

    public GameObject floatingTextPrefab;
    public Transform spawnParent;
    public RectTransform buttonRect;

    private int clickCount = 0;

    public void AddClick()
    {
        clickCount++;
        UpdateUI();
        questManager.UpdateAllQuestClicks(clickCount);
        ShowFloatingText("+1");
    }

    private void UpdateUI()
    {
        clickText.text = "" + clickCount;
    }

    void ShowFloatingText(string text)
    {
        Vector3 spawnPos = buttonRect.position;

        GameObject obj = Instantiate(floatingTextPrefab, spawnPos, Quaternion.identity, spawnParent);
        obj.GetComponent<FloatingText>().Setup(text);
    }
}
