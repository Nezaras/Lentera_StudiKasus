using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestDetails : MonoBehaviour
{
    public TextMeshProUGUI questNameText;
    public TextMeshProUGUI descriptionText;
    public Button claimButton;
    public Button closeButton;
    public PlayerTitleUI playerTitleUI;

    private QuestData currentQuest;
    private int currentClicks;

    private void Start()
    {
        closeButton.onClick.AddListener(() => GetComponent<PanelEffect>().Hide());
        claimButton.interactable = false;
    }

    public void ShowDetails(QuestData data)
    {
        currentQuest = data;
        questNameText.text = data.questName;
        descriptionText.text = data.description;
        UpdateClicks(currentClicks);
        UpdateButton();
        GetComponent<PanelEffect>().Show();
    }

    public void UpdateClicks(int clicks)
    {
        currentClicks = clicks;
        UpdateButton();
    }

    private void UpdateButton()
    {
        if (currentQuest == null) return;

        if (currentQuest.isClaimed)
        {
            claimButton.interactable = false;
            claimButton.GetComponentInChildren<TextMeshProUGUI>().text = "Claimed";
        }
        else if (currentClicks >= currentQuest.targetClicks)
        {
            claimButton.interactable = true;
            claimButton.GetComponentInChildren<TextMeshProUGUI>().text = "Claim";
        }
        else
        {
            claimButton.interactable = false;
            claimButton.GetComponentInChildren<TextMeshProUGUI>().text = "In Progress";
        }
    }

    public void OnClaimButton()
    {
        if (currentQuest == null) return;

        if (currentClicks >= currentQuest.targetClicks && !currentQuest.isClaimed)
        {
            currentQuest.isClaimed = true;

            if (playerTitleUI != null)
            {
                playerTitleUI.ChangeTitleWithTransition(currentQuest.rewardTitle);
            }

            GetComponent<PanelEffect>().Hide();

            if (currentQuest.questItemUI != null)
            {
                currentQuest.questItemUI.PlayStamp();
            }

            UpdateButton();
        }
    }

}
