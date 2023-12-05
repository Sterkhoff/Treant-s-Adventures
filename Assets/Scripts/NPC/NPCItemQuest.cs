using Unity.VisualScripting;
using UnityEngine;

public class NPCItemQuest : NPC
{
    public string NeededObjectName;
    public string[] DialogueTextIfQuestComplete;
    private Inventory playerInventory;

    protected override void Start()
    {
        base.Start();
        playerInventory = GameObject.Find("Player").GetComponent<Inventory>();
    }

    public override void Interact()
    {
        if (playerInventory.ChoosenItem == NeededObjectName && !NPCDialogue.gameObject.activeSelf)
        {
            playerInventory.DeleteChoosenFromInventory();
            NPCDialogue.ChangeDialogLines(DialogueTextIfQuestComplete);
            GameObject.FindWithTag("InvisibleWall").SetActive(false);
        }
        base.Interact();
    }

    private void OnTriggerExit2D(Collider2D other) => DialogueWindow.SetActive(false);
}
