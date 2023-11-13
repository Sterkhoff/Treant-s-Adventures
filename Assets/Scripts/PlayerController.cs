using System;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float Speed;
    public Rigidbody2D rb;
    public Animator animator;
    public bool isFaceRight;
    public SpriteRenderer sr;
    public GameObject InteractiveButton;
    public event Action ActionButtonPressed ;


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
