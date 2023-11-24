using UnityEngine;

public class Root : MonoBehaviour
{
    public int Number;
    private Animator anim;

    public void Start()
    {
        anim = GameObject.Find("RootsMiniGameLocation").GetComponent<Animator>();
    }

    public void Shake()
    {
        anim.SetTrigger($"Root{Number}");
    }
}
