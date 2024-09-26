using UnityEngine;

public class LogoSoundEffect : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        // AudioSource ������Ʈ ��������
        audioSource = GetComponent<AudioSource>();

        // �ΰ� ��Ÿ���� �Լ� ȣ��
        ShowLogo();
    }

    private void ShowLogo()
    {
        // ���⼭ �ΰ� ȭ�鿡 ǥ���ϴ� ������ �߰��ϼ���.
        // ���� ���, �ΰ� Ȱ��ȭ�ϴ� �ڵ�:

        // �ΰ� ��Ÿ���� �ִϸ��̼��̳� ȿ���� ���⿡ �߰��� �� �ֽ��ϴ�.

        // ȿ���� ���
        audioSource.Play();
    }
}
