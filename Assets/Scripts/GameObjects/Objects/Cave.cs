using UnityEngine;

namespace Assets.Scripts.GameObjects.Objects
{
    public class Cave : LocationEnter
    {
        public string[] Message;
        public GameObject PlayerDialogueWindow;
        public Dialogue PlayerDialogue;
        public GameObject Fairy;

        public override void Interact()
        {
            if (!Fairy.activeSelf)
                StartPlayerDialogue();
            else
                base.Interact();
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

        private void OnTriggerExit2D(Collider2D collision)
        {
            PlayerDialogueWindow.SetActive(false);
        }
    }
}
