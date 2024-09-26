using UnityEngine;
using UnityEngine.UI;

public class BlinkEffect : MonoBehaviour
{
    public float blinkSpeed = 1.0f; // �����̴� �ӵ�
    private Image image;
    private Color originalColor;

    void Start()
    {
        image = GetComponent<Image>();
        originalColor = image.color;
    }

    void Update()
    {
        // ���� ���� ���� �Լ��� �̿��� ��ȭ��Ŵ
        float alpha = Mathf.Abs(Mathf.Sin(Time.time * blinkSpeed));
        image.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
    }
}
