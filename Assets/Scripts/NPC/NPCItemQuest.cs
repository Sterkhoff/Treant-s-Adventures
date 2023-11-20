using Unity.VisualScripting;
using UnityEngine;

public class NPCItemQuest : IInteractive
{
    public GameObject DialogueWindow;
    public string NeededObjectName;
    public string[] DialogueTextIfQuestNotComplete;
    public string[] DialogueTextIfQuestComplete;
    
    private Dialogue NPCDialogue;
    private Inventory playerInventory;

    private void Start()
    {
        playerInventory = GameObject.Find("Player").GetComponent<Inventory>();
        NPCDialogue = DialogueWindow.GetComponent<Dialogue>();
        NPCDialogue.ChangeDialogLines(DialogueTextIfQuestNotComplete);
        gameObject.tag = "Interactive";
    }

    public override void Interact()
    {
        if (playerInventory.ChoosenSlotNumber != null
            && playerInventory.Items[(int)playerInventory.ChoosenSlotNumber] == NeededObjectName)
        {
            playerInventory.DeleteFromInventory((int)playerInventory.ChoosenSlotNumber);
            NPCDialogue.ChangeDialogLines(DialogueTextIfQuestComplete);
            GameObject.FindWithTag("InvisibleWall").SetActive(false);
        }

        if (!DialogueWindow.activeSelf)
        {
            DialogueWindow.SetActive(true);
            NPCDialogue.StartDialogue();
        }

        else
            NPCDialogue.ContinueDialogue();
    }

    private void OnTriggerExit2D(Collider2D other) => DialogueWindow.SetActive(false);
}
