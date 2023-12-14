using UnityEngine;

public class NPCMiniGame : NPC
{
    public string[] DialogueStringsIfGameComplete;
    public string TextForChoicePanelIfGameNotComplete;
    public string TextForChoicePanelIfGameComplete;
    public LocationChangerProvider locChanger;
    public Minigame Game;
    protected ChoicePanel choicePanel;

    protected override void Start()
    {
        base.Start();
        choicePanel = GameObject.Find("ChoicePanel").GetComponent<ChoicePanel>();
        locChanger = GetComponent<LocationChangerProvider>();
    }

    public override void Interact()
    {

        CheckIfMiniGameComplete();
        base.Interact();
        if (NPCDialogue.lineIndex == NPCDialogue.lines.Length - 1)
        {
            ShowChoicePanel();
        }
        if (NPCDialogue.lineIndex == NPCDialogue.lines.Length - 1)
            ShowChoicePanel();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        DialogueWindow.SetActive(false);
        choicePanel.Hide();
    }

    protected virtual void CheckIfMiniGameComplete()
    {
        if (NPCDialogue.lines.Equals(DialogueStrings) && Game.IsComplete)
        {
            NPCDialogue.ChangeDialogLines(DialogueStringsIfGameComplete);
        }
    }

    protected virtual void ShowChoicePanel()
    {
        if (Game.IsComplete)
            choicePanel.Show(TextForChoicePanelIfGameComplete, () => { });
        else
        {
            choicePanel.Show(TextForChoicePanelIfGameNotComplete, () => { });
        }
    }
}
