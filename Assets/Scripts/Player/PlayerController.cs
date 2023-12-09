using System;
using TMPro;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float Speed;
    public Rigidbody2D rb;
    public Animator animator;
    public bool isFaceRight;
    public SpriteRenderer sr;
    private GameObject InteractionButton;
    private event Action OnInteractionButtonPressed;
    public TextMeshProUGUI InteractionButtonText;
    private bool IsRises;
    private bool IsGoesDown;
    private Inventory playerInventory;
    private BoxCollider2D boxCollider;
    private string currentColliderActionName;

    private void Start()
    {
        InteractionButton = transform.Find("InteractionButton").gameObject;
        boxCollider = GetComponent<BoxCollider2D>();
        OnInteractionButtonPressed += () => InteractionButton.SetActive(false);
        playerInventory = GetComponent<Inventory>();
    }


    private void Update()
    {
        UpdateInteractionButton();
    }

    private void FixedUpdate()
    {
        UpdateAnimator();
        if (!IsRises && !IsGoesDown)
        {
            UpdateHorizontalMovement();
        }
        else
            UpdateMovesOnLadder();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CheckInteractiveTriggerEnter(other);
        CheckLadderTriggerEnter(other);
        CheckGroundTriggerEnter(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        CheckInteractiveTriggerExit(other);
        CheckLaddereTriggerExit(other);
    }

    private void IsRisesSetTrue()
    {
        boxCollider.isTrigger = true;
        IsRises = true;
    }

    private void IsGoesDownSetTrue()
    {
        boxCollider.isTrigger = true;
        IsGoesDown = true;
    }

    private void CheckLadderTriggerEnter(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            if (other.transform.position.y > transform.position.y)
            {
                currentColliderActionName = "Забраться";
                InteractionButton.SetActive(true);
                OnInteractionButtonPressed += IsRisesSetTrue;
            }

            else
            {
                currentColliderActionName = "Спуститься";
                InteractionButton.SetActive(true);
                OnInteractionButtonPressed += IsGoesDownSetTrue;
            }
        }
    }

    private void CheckLaddereTriggerExit(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            IsRises = false;
            boxCollider.isTrigger = false;
            InteractionButton.SetActive(false);
            OnInteractionButtonPressed -= IsRisesSetTrue;
            OnInteractionButtonPressed -= IsGoesDownSetTrue;
            rb.velocity = new Vector2(0, 0);
        }
    }

    private void CheckInteractiveTriggerEnter(Collider2D other)
    {
        if (other.CompareTag("Interactive"))
        {
            currentColliderActionName = other.GetComponent<IInteractive>().InteractionName;
            InteractionButton.SetActive(true);
            OnInteractionButtonPressed += other.GetComponent<IInteractive>().Interact;
        }
    }

    private void CheckInteractiveTriggerExit(Collider2D other)
    {
        if (other.CompareTag("Interactive"))
        {
            InteractionButton.SetActive(false);
            OnInteractionButtonPressed -= other.GetComponent<IInteractive>().Interact;
        }
    }

    private void CheckGroundTriggerEnter(Collider2D other)
    {
        if (other.CompareTag("Ground") && IsGoesDown)
        {
            IsGoesDown = false;
            boxCollider.isTrigger = false;
            OnInteractionButtonPressed -= IsGoesDownSetTrue;
            currentColliderActionName = "Забраться";
            InteractionButton.SetActive(true);
            OnInteractionButtonPressed += IsRisesSetTrue;
        }
    }

    private void UpdateMovesOnLadder()
    {
        if (IsRises)
        {
            rb.velocity = new Vector2(0, 4);
        }
        else if (IsGoesDown)
        {
            rb.velocity = new Vector2(0, -4);
        }
    }

    private void UpdateHorizontalMovement()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * Speed, rb.velocity.y);
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

    private void UpdateAnimator()
    {
        animator.SetBool("player_is_walk", rb.velocity.x != 0);
    }

    private void UpdateInteractionButton()
    {
        if (Input.GetKeyDown(KeyCode.F))
            OnInteractionButtonPressed.Invoke();
        if (InteractionButton.activeSelf)
        {
            if (playerInventory.ChoosenItem != String.Empty)
                InteractionButtonText.text = "Использовать";
            else
                InteractionButtonText.text = currentColliderActionName;
        }
    }
}
