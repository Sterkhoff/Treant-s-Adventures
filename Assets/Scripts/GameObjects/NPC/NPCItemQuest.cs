using UnityEngine;

public class NPCItemQuest : NPC
{
    public string NeededObjectName;
    public string[] DialogueTextIfQuestComplete;
    protected Inventory playerInventory;

    protected override void Start()
    {
        base.Start();
        playerInventory = GameObject.Find("Player").GetComponent<Inventory>();
    }

    public override void Interact()
    {
        TakeChoosenItem();
        base.Interact();
    }

    protected virtual void TakeChoosenItem()
    {
        if (playerInventory.ChoosenItem == NeededObjectName && !NPCDialogue.gameObject.activeSelf)
        {
            playerInventory.DeleteChoosenFromInventory();
            NPCDialogue.ChangeDialogLines(DialogueTextIfQuestComplete);
        }
    }

    private void OnTriggerExit2D(Collider2D other) => DialogueWindow.SetActive(false);
}
