using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WindowTalk : MonoBehaviour
{
	[SerializeField]
	private	DialogSystem	dialogSystem01;
    [SerializeField]
    private Image ImageEffect1;
    [SerializeField]
	private	DialogSystem dialogSystem02;
    [SerializeField]
    private DialogSystem dialogSystem03;
    [SerializeField]
    private DialogSystem dialogSystem04;
    [SerializeField]
    private DialogSystem dialogSystem05;
    [SerializeField]
    private DialogSystem dialogSystem06;
    [SerializeField]
    private DialogSystem dialogSystem07;
    [SerializeField]
    private DialogSystem dialogSystem08;
    [SerializeField]
    private DialogSystem dialogSystem09;

    private IEnumerator Start()
	{
        
        ImageEffect1.gameObject.SetActive(false);
        // 첫 번째 대사 분기 시작
        yield return new WaitUntil(()=>dialogSystem01.UpdateDialog());

        ImageEffect1.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => dialogSystem02.UpdateDialog());
        yield return new WaitForSeconds(1);
;
        yield return new WaitUntil(() => dialogSystem03.UpdateDialog());
        yield return new WaitForSeconds(1);


        yield return new WaitUntil(() => dialogSystem04.UpdateDialog());
        yield return new WaitForSeconds(1);


        yield return new WaitUntil(() => dialogSystem05.UpdateDialog());

        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => dialogSystem06.UpdateDialog());
        yield return new WaitForSeconds(1);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => dialogSystem07.UpdateDialog());
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => dialogSystem08.UpdateDialog());
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => dialogSystem09.UpdateDialog());
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Window2");
    }
}
