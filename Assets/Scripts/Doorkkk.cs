using UnityEngine;

public class Door : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // AudioSource ������Ʈ�� �����ɴϴ�.
        audioSource = GetComponent<AudioSource>();
    }

    void OnMouseDown()
    {
        // ���� Ŭ���Ǿ��� �� �Ҹ� ���
        audioSource.Play();

        // �� ������ �ִϸ��̼��̳� ���� �߰� (���⼭�� �ܼ��� ȸ�� ����)
        StartCoroutine(OpenDoor());
    }

    private System.Collections.IEnumerator OpenDoor()
    {
        // �� ������ ������ ���⿡ �߰� (��: ���� ȸ����Ű��)
        float duration = 1.0f; // ������ �ð�
        float elapsed = 0f;

        Quaternion startingRotation = transform.rotation;
        Quaternion targetRotation = startingRotation * Quaternion.Euler(0f, 90f, 0f); // 90�� ȸ��

        while (elapsed < duration)
        {
            transform.rotation = Quaternion.Slerp(startingRotation, targetRotation, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.rotation = targetRotation; // ���� ȸ�� �� ����
    }
}
