using UnityEngine;

public class LogoSoundEffect : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        // AudioSource 컴포넌트 가져오기
        audioSource = GetComponent<AudioSource>();

        // 로고가 나타나는 함수 호출
        ShowLogo();
    }

    private void ShowLogo()
    {
        // 여기서 로고를 화면에 표시하는 로직을 추가하세요.
        // 예를 들어, 로고를 활성화하는 코드:

        // 로고가 나타나는 애니메이션이나 효과를 여기에 추가할 수 있습니다.

        // 효과음 재생
        audioSource.Play();
    }
}
