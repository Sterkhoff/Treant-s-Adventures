using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChoicePanel : MonoBehaviour
{
    private Animator anim;
    public TextMeshProUGUI textBox;

    public void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Show(string text)
    {
        textBox.text = text;
        if (!anim.GetBool("IsActive"))
        {
            anim.SetTrigger("IsTriggered");
            anim.SetBool("IsActive", true);
        }
    }

    public void Hide()
    {
        if (anim.GetBool("IsActive"))
        {
            anim.SetTrigger("IsTriggered");
            anim.SetBool("IsActive", false);
        }
    }
}
