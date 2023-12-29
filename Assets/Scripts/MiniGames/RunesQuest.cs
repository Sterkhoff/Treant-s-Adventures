using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunesQuest : MonoBehaviour
{
    public bool IsComplete;
    public Rune[] Runes;

    public void Update()
    {
        if (!IsComplete  && Runes[0].color == "Blue" && Runes[1].color == "Red" && Runes[2].color == "Green")
            IsComplete = true;
    }
}
