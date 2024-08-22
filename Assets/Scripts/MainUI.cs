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
}
