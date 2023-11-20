using TMPro;
using UnityEngine;

public class NPCMiniGame : IInteractive
{
    public GameObject DialogueWindow;
    public string[] DialogueTextIfQuestNotComplete;
    public string[] DialogueTextIfQuestComplete;
    public string TextForChoicePanel;

    public LocationChangerProvider locChanger;
    private ChoicePanel choicePanel;
    private Dialogue NPCDialogue;

    private void Start()
    {
        choicePanel = GameObject.Find("ChoicePanel").GetComponent<ChoicePanel>();
        NPCDialogue = DialogueWindow.GetComponent<Dialogue>();
        NPCDialogue.ChangeDialogLines(DialogueTextIfQuestNotComplete);
        gameObject.tag = "Interactive";
        locChanger = GetComponent<LocationChangerProvider>();
    }

    public override void Interact()
    {
        if (!DialogueWindow.activeSelf)
        {
            DialogueWindow.SetActive(true);
            NPCDialogue.StartDialogue();
        }

        else
            NPCDialogue.ContinueDialogue();

        if (NPCDialogue.lineIndex == NPCDialogue.lines.Length - 1)
        {
            choicePanel.FirstButton.onClick.AddListener(() => locChanger.ChangeLocation());
            choicePanel.Show(TextForChoicePanel);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        choicePanel.FirstButton.onClick.RemoveListener(() => locChanger.ChangeLocation());
        DialogueWindow.SetActive(false);
        choicePanel.Hide();
    }
}
