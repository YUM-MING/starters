using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Secne4Talk : MonoBehaviour
{
	[SerializeField]
	private	DialogSystem	dialogSystem01;
    [SerializeField]
	private	DialogSystem	dialogSystem02;
 

    private IEnumerator Start()
	{
        yield return new WaitUntil(()=>dialogSystem01.UpdateDialog());

        
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => dialogSystem02.UpdateDialog());

    }
}
