using UnityEngine;

namespace Assets.Scripts.GameObjects.Objects
{
    public class Door : LocationEnter
    {
        public string[] Message;
        public GameObject PlayerDialogueWindow;
        public Dialogue PlayerDialogue;
        private Animator anim;
        public bool IsOpen;

        private void Start()
        {
            anim = GetComponent<Animator>();
        }

        public override void Interact()
        {
            if (IsOpen)
                base.Interact();
            else
            {
                StartPlayerDialogue();
            }
        }

        public void Open()
        {
            IsOpen = true;
            anim.SetBool("IsOpen", true);
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
