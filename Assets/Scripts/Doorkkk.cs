using UnityEngine;

public class Door : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // AudioSource 컴포넌트를 가져옵니다.
        audioSource = GetComponent<AudioSource>();
    }

    void OnMouseDown()
    {
        // 문이 클릭되었을 때 소리 재생
        audioSource.Play();

        // 문 열리는 애니메이션이나 로직 추가 (여기서는 단순히 회전 예시)
        StartCoroutine(OpenDoor());
    }

    private System.Collections.IEnumerator OpenDoor()
    {
        // 문 열리는 동작을 여기에 추가 (예: 문을 회전시키기)
        float duration = 1.0f; // 열리는 시간
        float elapsed = 0f;

        Quaternion startingRotation = transform.rotation;
        Quaternion targetRotation = startingRotation * Quaternion.Euler(0f, 90f, 0f); // 90도 회전

        while (elapsed < duration)
        {
            transform.rotation = Quaternion.Slerp(startingRotation, targetRotation, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.rotation = targetRotation; // 최종 회전 값 설정
    }
}
