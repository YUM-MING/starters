using UnityEngine;

public class LogoController : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // AudioSource 컴포넌트를 가져옵니다.
        audioSource = GetComponent<AudioSource>();

        // 로고를 나타내는 코드 (예: 활성화)
        ShowLogo();
    }

    void ShowLogo()
    {
        // 로고를 나타내는 로직
        gameObject.SetActive(true); // 로고 활성화

        // 소리 재생
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}

