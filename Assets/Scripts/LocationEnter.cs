using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationEnter : IInteractive
{
    public string Message;
    public GameObject PlayerDialogueWindow;
    public Dialogue PlayerDialogue;
    public override void Interact()
    {
        PlayerDialogue.lines = new string[] { "Я не могу зайти, слишком темно" };
        if (!PlayerDialogueWindow.activeSelf)
        {
            PlayerDialogueWindow.SetActive(true);
            PlayerDialogue.StartDialogue();
        }
        else
            PlayerDialogue.ContinueDialogue();
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        PlayerDialogueWindow.SetActive(false);
    }
}
