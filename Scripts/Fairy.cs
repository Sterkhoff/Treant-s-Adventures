using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy : MonoBehaviour
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
