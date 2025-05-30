using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour
{

    public void OnClickStartBtn()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void OnClickStart2Btn()
    {
        SceneManager.LoadScene("Scene2");
    }

    public void OnClickSettingBtn()
    {
        SceneManager.LoadScene("Setting");
    }

    public void OnClickExitBtn()
    {
        Application.Quit();
    }

    public void OnClickblockBtn()
    {
        SceneManager.LoadScene("Scene3");
    }

    public void OnClickblockdoorBtn()
    {
        SceneManager.LoadScene("Scene4");
    }

    public void OnClickKeyBtn()
    {
        SceneManager.LoadScene("Window");
    }
    public void OnClickMemoBtn()
    {
        PopupSystem.instance.OpenPopUp(() => { });
    }

    public void OnClickKeypadBtn()
    {
        PopupSystem.instance.OpenKeypad(() => { });
    }

    public void OnClickPillBtn()
    {
        SceneManager.LoadScene("Credit");
    }
}

