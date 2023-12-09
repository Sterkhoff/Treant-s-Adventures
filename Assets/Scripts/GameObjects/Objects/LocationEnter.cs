using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationEnter : IInteractive
{
    public string[] Message;
    public GameObject PlayerDialogueWindow;
    public Dialogue PlayerDialogue;
    public GameObject Fairy;
    public SceneChanger SceneChanger;
    public override void Interact()
    {
        if (!Fairy.activeSelf)
            StartPlayerDialogue();
        else
            SceneChanger.FadeToLevel();

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerDialogueWindow.SetActive(false);
    }

    private void StartPlayerDialogue()
    {
        PlayerDialogue.ChangeDialogLines(Message);
        if (!PlayerDialogueWindow.activeSelf)
        {
            PlayerDialogue.StartDialogue();
        }
        else
            PlayerDialogue.ContinueDialogue();
    }
}
