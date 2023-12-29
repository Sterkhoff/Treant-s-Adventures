using UnityEngine;

public class Rune : MonoBehaviour
{
    public string color;
    private Animator anim;

    public void SwitchColor()
    {
        anim.SetTrigger("SwitchColor");
        switch (color)
        {
            case "Red":
                color = "Green";
                break;
            case "Green":
                color = "Blue";
                break;
            case "Blue":
                color = "Red";
                break;
        }
    }

    void Start()
    {
        color = "Red";
        anim = GetComponent<Animator>();
    }
}
