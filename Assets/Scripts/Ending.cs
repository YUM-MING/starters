using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{

    [SerializeField]
    private DialogSystem dialogSystem;
    [SerializeField]
    private Image bug;
    public GameObject go;
    // Start is called before the first frame update
    private IEnumerator Start()
    {
        bug.gameObject.SetActive(false);
        go.SetActive(true);

        yield return new WaitForSeconds(28);
        bug.gameObject.SetActive(true);

        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => dialogSystem.UpdateDialog());
        yield return new WaitForSeconds(1);
        Application.Quit();
    }

}
