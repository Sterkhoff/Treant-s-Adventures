using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersPhysicsIgnoreObject : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool IsOnGround;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!IsOnGround)
            rb.MovePosition(rb.position + new Vector2(0, -1) * 10f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
            IsOnGround = true;
    }
}
