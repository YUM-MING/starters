using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeDuration = 5f; // ��鸮�� �ð�
    public float shakeMagnitude = 0.2f; // ��鸮�� ����
    private bool hasShaken = false; // �̹� ��鸰 ����

    private void Update()
    {
        // ���콺 ���� ��ư Ŭ�� Ȯ��
        if (Input.GetMouseButtonDown(0) && !hasShaken)
        {
            hasShaken = true; // ��鸲 ���¸� true�� ����
            StartCoroutine(ShakeCamera()); // ��鸲 ȿ�� ����
        }
    }

    private IEnumerator ShakeCamera()
    {
        Vector3 originalPosition = transform.localPosition; // ���� ��ġ ����

        float elapsed = 0f;
        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeMagnitude; // X�� ���� ��鸲
            float y = Random.Range(-1f, 1f) * shakeMagnitude; // Y�� ���� ��鸲

            transform.localPosition = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z); // ��ġ ������Ʈ

            elapsed += Time.deltaTime; // ��� �ð� ������Ʈ
            yield return null; // ���� �����ӱ��� ���
        }

        transform.localPosition = originalPosition; // ���� ��ġ�� ���ư���
    }
}
