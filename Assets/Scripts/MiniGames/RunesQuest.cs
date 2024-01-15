using UnityEngine.Events;
using UnityEngine;

public class RunesQuest : MonoBehaviour
{
    public bool IsComplete;
    public Rune[] Runes;
    public UnityEvent OnComplete;
    public void Update()
    {
        if (!IsComplete  && Runes[0].color == "Blue" && Runes[1].color == "Red" && Runes[2].color == "Green")
            IsComplete = true;
        if (IsComplete)
        {
            OnComplete.Invoke();
        }
    }
}
