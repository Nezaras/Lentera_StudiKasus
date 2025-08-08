using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestItemUI : MonoBehaviour
{
    public Image iconImage;
    public TextMeshProUGUI nameText;
    public Button detailsButton;
    public StampEffect stampEffect;

    private QuestData questData;
    private QuestDetails detailsPanel;

    public void Setup(QuestData data, QuestDetails panel)
    {
        questData = data;
        detailsPanel = panel;
        iconImage.sprite = data.icon;
        nameText.text = data.questName;

        questData.questItemUI = this;

        detailsButton.onClick.AddListener(() => detailsPanel.ShowDetails(questData));

        if (questData.isClaimed)
            stampEffect.PlayStamp();
        else
            stampEffect.HideStamp();
    }

    public void PlayStamp()
    {
        if (stampEffect != null)
        {
            stampEffect.PlayStamp();
        }
    }
}
