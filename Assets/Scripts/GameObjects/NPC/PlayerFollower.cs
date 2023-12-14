using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    private PlayerController player;
    private bool isFaceRight;
    public SpriteRenderer sr;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (player.isFaceRight && !isFaceRight)
            isFaceRight = true;
        if (!player.isFaceRight && isFaceRight)
            isFaceRight = false;
        sr.flipX = isFaceRight;
    }
}
