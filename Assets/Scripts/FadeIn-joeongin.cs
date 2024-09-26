using UnityEngine;
using UnityEngine.UI;

public class FadeAndExpandAndMove : MonoBehaviour
{
    public Image image;              // �簢�� Image (UI Image)
    public float fadeDuration = 1f;  // ������������ �� �ɸ��� �ð�
    public float expandDuration = 2f; // �簢���� Ŀ���� �� �ɸ��� �ð�
    public float moveDuration = 2f;   // �簢���� �̵��ϴ� �� �ɸ��� �ð�
    public Vector2 startSize = new Vector2(100, 100); // ���� ũ��
    public Vector2 endSize = new Vector2(2000, 2000); // ȭ���� ���� ũ��
    public Vector3 startPosition;    // ���� ��ġ
    public Vector3 endPosition;      // ������ ��ġ

    private float elapsedTime = 0f;  // ��� �ð�

    void Start()
    {
        // Image ������Ʈ�� null�̸� �ڵ����� ������
        if (image == null)
        {
            image = GetComponent<Image>();
        }

        // �������� 0���� ���� (���� ����)
        Color color = image.color;
        color.a = 0f;
        image.color = color;

        // ���� ũ��� ��ġ ����
        image.rectTransform.sizeDelta = startSize;
        transform.localPosition = startPosition;
    }

    void Update()
    {
        // �ð��� �帧�� ���� ��� �ð� ������Ʈ
        elapsedTime += Time.deltaTime;

        // ������ ó�� (������ ����������)
        if (elapsedTime < fadeDuration)
        {
            float alpha = elapsedTime / fadeDuration;
            Color color = image.color;
            color.a = Mathf.Lerp(0f, 1f, alpha);  // Alpha ���� 0���� 1�� ����
            image.color = color;
        }

        // ũ�� ó�� (�簢���� Ŀ��)
        if (elapsedTime < expandDuration)
        {
            float sizeFactor = elapsedTime / expandDuration;
            image.rectTransform.sizeDelta = Vector2.Lerp(startSize, endSize, sizeFactor);
        }

        // ��ġ ó�� (�簢���� �̵���)
        if (elapsedTime < moveDuration)
        {
            float moveFactor = elapsedTime / moveDuration;
            transform.localPosition = Vector3.Lerp(startPosition, endPosition, moveFactor);
        }
    }
}
