using UnityEngine;

public class SquareClick : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        // AudioSource 컴포넌트 가져오기
        audioSource = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        // 네모 클릭 시 소리 재생
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play(); // 소리 재생
        }
    }
}

