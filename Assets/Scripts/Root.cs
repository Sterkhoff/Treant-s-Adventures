using UnityEngine;

public class Root : MonoBehaviour
{
    public int Number;
    private Animator anim;

    public void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Close()
    {
        anim.SetBool("IsActive", false);
    }

    public void Back()
    {
        anim.SetBool("IsActive", true);
    }

    public void Shake()
    {
        anim.SetTrigger("Shake");
    }
}
