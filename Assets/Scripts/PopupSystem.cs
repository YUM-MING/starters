using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class PopupSystem : MonoBehaviour
{
    public GameObject popup;
    public GameObject keypad;
    Animator anim;
    Animator anim2;

  

    public static PopupSystem instance{get;private set;}
    Action onClickCancel;

    private void Start()
    {
        popup.SetActive(false);
        keypad.SetActive(false);
    }

    private void Awake()
    {
        instance = this;
        anim = popup.GetComponent<Animator>();
        anim2 = keypad.GetComponent<Animator>();
    }

    private void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Close"))
        {
            if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime >=1)
            {
                popup.SetActive(false);
            }
        }

        if (anim2.GetCurrentAnimatorStateInfo(0).IsName("Close"))
        {
            if (anim2.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                keypad.SetActive(false);
            }
        }
    }

    public void OpenPopUp(
        Action onClickCancel)
    {
        this.onClickCancel = onClickCancel; 
        popup.SetActive(true);
    }

    public void OpenKeypad(
        Action onClickCancel)
    {
        this.onClickCancel = onClickCancel;
        keypad.SetActive(true);
    }


    public void OnClickCancel()
    {
        if (onClickCancel != null)
        {
            onClickCancel();
        }
        ClosePopup();
        CloseKeypad();
    }

    void ClosePopup()
    {
        anim.SetTrigger("Close");
    }

    void CloseKeypad()
    {
        anim2.SetTrigger("Close");
    }
}
