using Unity.VisualScripting;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractive
{
    public GameObject DialogueWindow;
    public string NeededObjectName;
    public string[] DialogueTextIfQuestNotComplete;
    public string[] DialogueTextIfQuestComplete;
    
    private Dialogue NPCDialogue;
    private Inventory playerInventory;

    private void Start()
    {
        playerInventory = GameObject.Find("UIInventory").GetComponent<Inventory>();
        NPCDialogue = DialogueWindow.GetComponent<Dialogue>();
        NPCDialogue.ChangeDialogLines(DialogueTextIfQuestNotComplete);
    }

    public void Interact()
    {
        if (playerInventory.ChoosenSlotNumber != null
            && !playerInventory.Items[(int)playerInventory.ChoosenSlotNumber].IsUnityNull()
            && playerInventory.Items[(int)playerInventory.ChoosenSlotNumber].Name == NeededObjectName)
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
