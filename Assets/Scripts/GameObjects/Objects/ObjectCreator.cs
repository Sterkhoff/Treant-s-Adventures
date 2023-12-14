using Cinemachine;
using UnityEngine;

public class ObjectCreator : IInteractive
{
    public GameObject Prefab;
    public Vector2 Position;
    public CinemachineVirtualCamera CMCamera; 

    public override void Interact()
    {
        CMCamera.GetComponent<CinemachineShake>().ShakeCamera(3.85f, .1f);
        Instantiate(Prefab, Position, Quaternion.identity);
        Destroy(gameObject);
    }
}
