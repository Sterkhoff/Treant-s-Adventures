using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameHost : MonoBehaviour
{
    public Minigame game;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (game.IsComplete)
            anim.SetTrigger("GameComplete");
    }
}
