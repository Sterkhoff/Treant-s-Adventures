using UnityEngine;

public abstract class IInteractive : MonoBehaviour
{
    public string InteractionName;
    public abstract void Interact();
}
