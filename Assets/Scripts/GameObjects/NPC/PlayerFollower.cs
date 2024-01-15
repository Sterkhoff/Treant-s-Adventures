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
        isFaceRight = player.isFaceRight;
        sr.flipX = isFaceRight;
    }
}
