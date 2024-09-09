using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Paddle : MonoBehaviour
{

    [Multiline(12)]
    public string[] StageStr;
    public GameObject WinPanel;
    public AudioSource S_Break;
    public AudioSource S_Paddle;
    public AudioSource S_Victory;
    public Transform BlocksTr;
    public BoxCollider2D[] BlockCol;
    public GameObject[] Ball;
    public Animator[] BallAni;
    public Transform[] BallTr;
    public SpriteRenderer[] BallSr;
    public Rigidbody2D[] BallRg;
    public SpriteRenderer PaddleSr;
    public BoxCollider2D PaddleCol;

    bool isStart;
    public float paddleX;
    public float ballSpeed;
    float oldBallSpeed = 300;
    float paddleBorder = 6.5f;
    float paddleSize = 1.58f;
    int stage;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            WinPanel.gameObject.SetActive(false);
            StartCoroutine("InfinityLoop");
        }
    }


    // 블럭 생성
    void BlockGenerator()
    {
        string currentStr = StageStr[stage].Replace("\n", "");
        currentStr = currentStr.Replace(" ", "");
        for (int i = 0; i < currentStr.Length; i++)
        {
            BlockCol[i].gameObject.SetActive(false);
            char A = currentStr[i]; string currentName = "Block"; int currentB = 0;

            if (A == '*') continue;
            else if (A == '8') { currentB = 8; currentName = "HardBlock0"; }
            else if (A == '9') currentB = Random.Range(0, 8);
            else currentB = int.Parse(A.ToString());

            BlockCol[i].gameObject.name = currentName;
            //BlockCol[i].gameObject.GetComponent<SpriteRenderer>().sprite = B[currentB];
            BlockCol[i].gameObject.SetActive(true);
        }
    }

    // 볼 위치 초기화하고 0.7초간 깜빡이는 애니메이션 재생
    IEnumerator BallReset()
    {
        isStart = false;
        Ball[0].SetActive(true);
        BallAni[0].SetTrigger("Blink");
        BallTr[0].position = new Vector2(paddleX, -3.55f);

        StopCoroutine("InfinityLoop");
        yield return new WaitForSeconds(0.7f);
        StartCoroutine("InfinityLoop");
    }

    // 무한 루프
    IEnumerator InfinityLoop()
    {
        while (true)
        {
            // 마우스 누를 때 공이 붙어있음
            if (Input.GetMouseButton(0) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved))
            {
                paddleX = Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.GetMouseButton(0) ? Input.mousePosition : (Vector3)Input.GetTouch(0).position).x, -paddleBorder, paddleBorder);
                transform.position = new Vector2(paddleX, transform.position.y);
                if (!isStart) BallTr[0].position = new Vector2(paddleX, BallTr[0].position.y);
            }

            // 마우스 떼면 공이 떨어져나감
            if (!isStart && (Input.GetMouseButtonUp(0) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)))
            {
                isStart = true;
                ballSpeed = oldBallSpeed;
                BallRg[0].AddForce(new Vector2(0.1f, 0.9f).normalized * ballSpeed);
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
 
    // 볼이 충돌할 때
    public IEnumerator BallCollisionEnter2D(Transform ThisBallTr, Rigidbody2D ThisBallRg, Ball ThisBallCs, GameObject Col, Transform ColTr, SpriteRenderer ColSr, Animator ColAni)
    {
        // 같은 볼끼리 충돌 무시
        Physics2D.IgnoreLayerCollision(2, 2);
        if (!isStart) yield break;

        switch (Col.name)
        {
            // 패들에 부딪히면 차이값만큼 힘 줌
            case "Paddle":
                ThisBallRg.velocity = Vector2.zero;
                ThisBallRg.AddForce((ThisBallTr.position - transform.position).normalized * ballSpeed);
                S_Paddle.Play();
                break;

          
            // 데스존에 부딪히면 비활성화, 볼 체크
            case "DeathZone":
                ThisBallTr.gameObject.SetActive(false);
                BallReset();
                break;

         
            // 블럭이나 돌에 부딪히면 부숴짐
            case "Block":
                BlockBreak(Col, ColTr, ColAni);
                break;
        }
    }


    // 블럭이 부숴질 때
    public void BlockBreak(GameObject Col, Transform ColTr, Animator ColAni)
    {
        // 벽돌 부서지는 애니메이션
        ColAni.SetTrigger("Break");
        S_Break.Play();
        StartCoroutine(ActiveFalse(Col));

        StopCoroutine("BlockCheck");
        StartCoroutine("BlockCheck");
    }



    // 0.2초 후 비활성화
    IEnumerator ActiveFalse(GameObject Col)
    {
        yield return new WaitForSeconds(0.2f);
        Col.SetActive(false);
    }




    // 볼에 힘을 줌
    public void BallAddForce(Rigidbody2D ThisBallRg)
    {
        Vector2 dir = ThisBallRg.velocity.normalized;
        ThisBallRg.velocity = Vector2.zero;
        ThisBallRg.AddForce(dir * ballSpeed);
    }

    // 블럭 체크
    IEnumerator BlockCheck()
    {
        yield return new WaitForSeconds(0.5f);
        int blockCount = 0;
        for (int i = 0; i < BlocksTr.childCount; i++)
            if (BlocksTr.GetChild(i).gameObject.activeSelf) blockCount++;

        // 승리
        if (blockCount == 0)
        {
            WinPanel.SetActive(true);
            S_Victory.Play();
            Clear();
        }

    }

    // 승리 또는 게임오버시 호출
    void Clear()
    {
        StopAllCoroutines();
        PaddleSr.enabled = false;
        SceneManager.LoadScene("Scene4");
    }
}

