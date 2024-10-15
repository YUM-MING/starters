using UnityEngine;

public class LogoController : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // AudioSource ������Ʈ�� �����ɴϴ�.
        audioSource = GetComponent<AudioSource>();

        // �ΰ� ��Ÿ���� �ڵ� (��: Ȱ��ȭ)
        ShowLogo();
    }

    void ShowLogo()
    {
        // �ΰ� ��Ÿ���� ����
        gameObject.SetActive(true); // �ΰ� Ȱ��ȭ

        // �Ҹ� ���
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}

