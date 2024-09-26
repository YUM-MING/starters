using UnityEngine;
using UnityEngine.UI;

public class FadeAndExpandAndMove : MonoBehaviour
{
    public Image image;              // 사각형 Image (UI Image)
    public float fadeDuration = 1f;  // 불투명해지는 데 걸리는 시간
    public float expandDuration = 2f; // 사각형이 커지는 데 걸리는 시간
    public float moveDuration = 2f;   // 사각형이 이동하는 데 걸리는 시간
    public Vector2 startSize = new Vector2(100, 100); // 시작 크기
    public Vector2 endSize = new Vector2(2000, 2000); // 화면을 덮을 크기
    public Vector3 startPosition;    // 시작 위치
    public Vector3 endPosition;      // 마무리 위치

    private float elapsedTime = 0f;  // 경과 시간

    void Start()
    {
        // Image 컴포넌트가 null이면 자동으로 가져옴
        if (image == null)
        {
            image = GetComponent<Image>();
        }

        // 불투명도를 0으로 설정 (완전 투명)
        Color color = image.color;
        color.a = 0f;
        image.color = color;

        // 시작 크기와 위치 설정
        image.rectTransform.sizeDelta = startSize;
        transform.localPosition = startPosition;
    }

    void Update()
    {
        // 시간이 흐름에 따라 경과 시간 업데이트
        elapsedTime += Time.deltaTime;

        // 불투명도 처리 (서서히 불투명해짐)
        if (elapsedTime < fadeDuration)
        {
            float alpha = elapsedTime / fadeDuration;
            Color color = image.color;
            color.a = Mathf.Lerp(0f, 1f, alpha);  // Alpha 값을 0에서 1로 변경
            image.color = color;
        }

        // 크기 처리 (사각형이 커짐)
        if (elapsedTime < expandDuration)
        {
            float sizeFactor = elapsedTime / expandDuration;
            image.rectTransform.sizeDelta = Vector2.Lerp(startSize, endSize, sizeFactor);
        }

        // 위치 처리 (사각형이 이동함)
        if (elapsedTime < moveDuration)
        {
            float moveFactor = elapsedTime / moveDuration;
            transform.localPosition = Vector3.Lerp(startPosition, endPosition, moveFactor);
        }
    }
}
