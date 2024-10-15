using UnityEngine;

public class ContinuousSound : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play(); // 시작하자마자 소리 재생
    }

    void Update()
    {
        // 예를 들어 특정 조건에서 소리를 멈추고 싶을 때
        if (Input.GetKeyDown(KeyCode.Escape)) // ESC 키를 누르면 소리 중지
        {
            audioSource.Stop();
        }
    }
}
