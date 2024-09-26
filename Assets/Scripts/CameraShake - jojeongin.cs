using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeDuration = 5f; // 흔들리는 시간
    public float shakeMagnitude = 0.2f; // 흔들리는 강도
    private bool hasShaken = false; // 이미 흔들린 여부

    private void Update()
    {
        // 마우스 왼쪽 버튼 클릭 확인
        if (Input.GetMouseButtonDown(0) && !hasShaken)
        {
            hasShaken = true; // 흔들림 상태를 true로 설정
            StartCoroutine(ShakeCamera()); // 흔들림 효과 시작
        }
    }

    private IEnumerator ShakeCamera()
    {
        Vector3 originalPosition = transform.localPosition; // 원래 위치 저장

        float elapsed = 0f;
        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeMagnitude; // X축 랜덤 흔들림
            float y = Random.Range(-1f, 1f) * shakeMagnitude; // Y축 랜덤 흔들림

            transform.localPosition = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z); // 위치 업데이트

            elapsed += Time.deltaTime; // 경과 시간 업데이트
            yield return null; // 다음 프레임까지 대기
        }

        transform.localPosition = originalPosition; // 원래 위치로 돌아가기
    }
}
