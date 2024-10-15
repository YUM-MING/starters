using UnityEngine;

public class ContinuousSound : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play(); // �������ڸ��� �Ҹ� ���
    }

    void Update()
    {
        // ���� ��� Ư�� ���ǿ��� �Ҹ��� ���߰� ���� ��
        if (Input.GetKeyDown(KeyCode.Escape)) // ESC Ű�� ������ �Ҹ� ����
        {
            audioSource.Stop();
        }
    }
}
