using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupSystem : MonoBehaviour
{
    public GameObject popup;
    Animator anim;

  

    public static PopupSystem instance{get;private set;}
    Action onClickCancel;

    private void Start()
    {
        popup.SetActive(false);
    }

    private void Awake()
    {
        instance = this;
        anim = popup.GetComponent<Animator>();
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
    }

    public void OpenPopUp(
        Action onClickCancel)
    {
        this.onClickCancel = onClickCancel; 
        popup.SetActive(true);
    }


    public void OnClickCancel()
    {
        if (onClickCancel != null)
        {
            onClickCancel();
        }
        ClosePopup();
    }

    void ClosePopup()
    {
        anim.SetTrigger("Close");
    }
}
