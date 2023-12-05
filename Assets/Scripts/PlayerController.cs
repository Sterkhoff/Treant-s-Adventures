using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float Speed;
    public Rigidbody2D rb;
    public Animator animator;
    public bool isFaceRight;
    public SpriteRenderer sr;
    public GameObject InteractiveButton;
    private event Action ActionButtonPressed;
    public TextMeshProUGUI InteractionName;
    private Inventory playerInventory;

    private void Start()
    {
        ActionButtonPressed += () => InteractiveButton.SetActive(false);
        playerInventory = GetComponent<Inventory>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            ActionButtonPressed?.Invoke();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * Speed, rb.velocity.y);
        animator.SetBool("player_is_walk", rb.velocity.x != 0);
        if (isFaceRight && Input.GetAxis("Horizontal") < 0)
        {
            isFaceRight = false;
        }
        if (!isFaceRight && Input.GetAxis("Horizontal") > 0)
        {
            isFaceRight = true;
        }
        sr.flipX = !isFaceRight;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Interactive"))
        {
            if (playerInventory.ChoosenItem != String.Empty)
                InteractionName.text = "Использовать";
            else
                InteractionName.text = other.GetComponent<IInteractive>().InteractionName;
            InteractiveButton.SetActive(true);
            ActionButtonPressed += other.GetComponent<IInteractive>().Interact;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Interactive"))
        {
            InteractiveButton.SetActive(false);
            ActionButtonPressed -= other.GetComponent<IInteractive>().Interact;
        }
    }
}
