using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest System/Quest Data")]
public class QuestData : ScriptableObject
{
    public Sprite icon;
    public string questName;
    [TextArea] public string description;
    public int targetClicks;
    public string rewardTitle;
    public bool isClaimed = false;

    [HideInInspector] public QuestItemUI questItemUI;
}
