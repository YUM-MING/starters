using UnityEngine;

public class SquareClick : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        // AudioSource ������Ʈ ��������
        audioSource = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        // �׸� Ŭ�� �� �Ҹ� ���
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play(); // �Ҹ� ���
        }
    }
}

