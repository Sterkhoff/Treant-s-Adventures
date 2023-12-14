using UnityEngine.Events;

public class GameButton : IInteractive
{
    public UnityEvent Event;

    public void Start()
    {
        gameObject.tag = "Interactive";
    }

    public override void Interact()
    {
        Event.Invoke();
    }
}
