using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ChoicePanel : MonoBehaviour
{
    private Animator anim;
    public TextMeshProUGUI textBox;
    public Button FirstButton;
    public Button SecondButoon;

    public void Start()
    {
        anim = GetComponent<Animator>();       
    }
    public void Show(string text, params UnityAction[] firstButtonListeners)
    {
        textBox.text = text;
        if (!anim.GetBool("IsActive"))
        {
            anim.SetTrigger("IsTriggered");
            anim.SetBool("IsActive", true);
        }
        foreach(var action in firstButtonListeners)
        {
            FirstButton.onClick.AddListener(action);
        }
    }

    public void Hide()
    {
        if (anim.GetBool("IsActive"))
        {
            anim.SetTrigger("IsTriggered");
            anim.SetBool("IsActive", false);
            FirstButton.onClick.RemoveAllListeners();
        }
    }
}
