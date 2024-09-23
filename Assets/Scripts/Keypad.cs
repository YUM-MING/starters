using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private TextMeshProUGUI Ans;
    public GameObject pill;

    private string Answer = "0710";



    // Update is called once per frame
    private void Awake()
    {
        pill.gameObject.SetActive(false);
    }
    public void Number(int number)
    {
        Ans.text += number.ToString();
    }

    public void Check()
    {
        if (Ans.text == Answer)
        {
            Ans.text = "CORRECT";
            OpenPill();
        }
        else
        {
            Ans.text = "";
        }
    }

    public void OpenPill()
    {
        pill.gameObject.SetActive(true);
    }
}
