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
    [SerializeField]
    private DialogSystem dialogSystem10;

    private IEnumerator Start()
	{

        // 첫 번째 대사 분기 시작
        yield return new WaitUntil(()=>dialogSystem01.UpdateDialog());

        // 대사 분기 사이에 원하는 행동을 추가할 수 있다.
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => dialogSystem02.UpdateDialog());
        yield return new WaitForSeconds(1);

        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => dialogSystem03.UpdateDialog());
        yield return new WaitForSeconds(1);

        yield return new WaitForSeconds(1);

        yield return new WaitUntil(() => dialogSystem04.UpdateDialog());
        yield return new WaitForSeconds(1);



        yield return new WaitForSeconds(1);


        yield return new WaitForSeconds(1);

        yield return new WaitUntil(() => dialogSystem05.UpdateDialog());
        yield return new WaitForSeconds(1);


        yield return new WaitForSeconds(1);
        // 벽돌깨기 직전
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
        yield return new WaitUntil(() => dialogSystem10.UpdateDialog());
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Secen5");
    }
}
