using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public QuestData[] quests;
    public QuestItemUI questItemPrefab;
    public Transform questListParent;
    public QuestDetails questPanel;

    public void Start()
    {
        foreach (var quest in quests)
        {
            var questUI = Instantiate(questItemPrefab, questListParent);
            questUI.Setup(quest, questPanel);
        }
    }

    public void UpdateAllQuestClicks(int clicks)
    {
        questPanel.UpdateClicks(clicks);
    }

}
