using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Secne2Talk : MonoBehaviour
{
	[SerializeField]
	private	DialogSystem	dialogSystem01;
    [SerializeField]
    private Button ButtonEffect;
    [SerializeField]
    private Image ImageEffect1;
    [SerializeField]
    private Image ImageEffect2;
    [SerializeField]
    private Image ImageEffect3;
    [SerializeField]
    private Image ImageEffect4;
    [SerializeField]
    private Image ImageEffect5;
    [SerializeField]
    private Image ImageEffect6;
    [SerializeField]
    private Image ImageEffect7;
    [SerializeField]
    private Image ImageEffect8;
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

    private IEnumerator Start()
	{
        ButtonEffect.gameObject.SetActive(false);
        ImageEffect1.gameObject.SetActive(false);
        ImageEffect2.gameObject.SetActive(false);
        ImageEffect3.gameObject.SetActive(false);
        ImageEffect4.gameObject.SetActive(false);
        ImageEffect5.gameObject.SetActive(false);
        ImageEffect6.gameObject.SetActive(false);
        ImageEffect7.gameObject.SetActive(false);
        ImageEffect8.gameObject.SetActive(false);
        // 첫 번째 대사 분기 시작
        yield return new WaitUntil(()=>dialogSystem01.UpdateDialog());

        // 대사 분기 사이에 원하는 행동을 추가할 수 있다.
        ImageEffect1.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => dialogSystem02.UpdateDialog());
        yield return new WaitForSeconds(1);

        ImageEffect5.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => dialogSystem03.UpdateDialog());
        yield return new WaitForSeconds(1);

        ImageEffect2.gameObject.SetActive(true);
        ImageEffect6.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);

        yield return new WaitUntil(() => dialogSystem04.UpdateDialog());
        yield return new WaitForSeconds(1);

        ImageEffect3.gameObject.SetActive(true);
        ImageEffect7.gameObject.SetActive(true);

        yield return new WaitForSeconds(1);

        ImageEffect4.gameObject.SetActive(true);
        ImageEffect8.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);

        yield return new WaitUntil(() => dialogSystem05.UpdateDialog());
        yield return new WaitForSeconds(1);
        ImageEffect1.gameObject.SetActive(false);
        ImageEffect2.gameObject.SetActive(false);
        ImageEffect3.gameObject.SetActive(false);
        ImageEffect4.gameObject.SetActive(false);
        ImageEffect5.gameObject.SetActive(false);
        ImageEffect6.gameObject.SetActive(false);
        ImageEffect7.gameObject.SetActive(false);
        ImageEffect8.gameObject.SetActive(false);
        yield return new WaitForSeconds(1);
        // 벽돌깨기 직전
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => dialogSystem06.UpdateDialog());
        yield return new WaitForSeconds(1);
        ButtonEffect.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => dialogSystem07.UpdateDialog());
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => dialogSystem08.UpdateDialog());
        yield return new WaitForSeconds(1);

    }
}
