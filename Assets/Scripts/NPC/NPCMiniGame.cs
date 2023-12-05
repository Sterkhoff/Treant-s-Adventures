using TMPro;
using UnityEngine;

public class NPCMiniGame : IInteractive
{
    public GameObject DialogueWindow;
    public string[] DialogueTextIfGameNotComplete;
    public string[] DialogueTextIfGameComplete;
    public string TextForChoicePanelIfGameNotComplete;
    public string TextForChoicePanelIfGameComplete;
    public GameObject FairyFollower;

    public LocationChangerProvider locChanger;
    public Minigame Game;
    private ChoicePanel choicePanel;
    private Dialogue NPCDialogue;

    private void Start()
    {
        choicePanel = GameObject.Find("ChoicePanel").GetComponent<ChoicePanel>();
        NPCDialogue = DialogueWindow.GetComponent<Dialogue>();
        NPCDialogue.ChangeDialogLines(DialogueTextIfGameNotComplete);
        gameObject.tag = "Interactive";
        locChanger = GetComponent<LocationChangerProvider>();
    }

    public override void Interact()
    {
        if (NPCDialogue.lines.Equals(DialogueTextIfGameNotComplete) && Game.IsComplete)
        {
            choicePanel.FirstButton.onClick.RemoveAllListeners();
            choicePanel.FirstButton.onClick.AddListener(() => FairyFollower.SetActive(true));
            choicePanel.FirstButton.onClick.AddListener(() => Destroy(gameObject));
            NPCDialogue.ChangeDialogLines(DialogueTextIfGameComplete);
        }

        if (!DialogueWindow.activeSelf)
        {
            DialogueWindow.SetActive(true);
            NPCDialogue.StartDialogue();
        }

        else
            NPCDialogue.ContinueDialogue();

        if (NPCDialogue.lineIndex == NPCDialogue.lines.Length - 1 && !Game.IsComplete)
        {
            choicePanel.FirstButton.onClick.AddListener(() => locChanger.ChangeLocation());
            choicePanel.Show(TextForChoicePanelIfGameNotComplete);
        }

        if (NPCDialogue.lineIndex == NPCDialogue.lines.Length - 1 && Game.IsComplete)
        {
            choicePanel.Show(TextForChoicePanelIfGameComplete);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        choicePanel.FirstButton.onClick.RemoveAllListeners();
        DialogueWindow.SetActive(false);
        choicePanel.Hide();
    }
}
