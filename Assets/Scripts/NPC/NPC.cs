
using UnityEngine;

public class NPC : IInteractive
{
    public GameObject DialogueWindow;
    public string[] DialogueStrings;
    protected Dialogue NPCDialogue;

    protected virtual void Start()
    {
        NPCDialogue = DialogueWindow.GetComponent<Dialogue>();
        NPCDialogue.ChangeDialogLines(DialogueStrings);
        gameObject.tag = "Interactive";
    }


    public override void Interact()
    {
        StartDialogue();
    }

    protected void StartDialogue()
    {
        if (!DialogueWindow.activeSelf)
        {
            NPCDialogue.StartDialogue();
        }

        else
            NPCDialogue.ContinueDialogue();
    }
}
