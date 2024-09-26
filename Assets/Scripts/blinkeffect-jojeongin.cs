using UnityEngine;
using UnityEngine.UI;

public class BlinkEffect : MonoBehaviour
{
    public float blinkSpeed = 1.0f; // 깜박이는 속도
    private Image image;
    private Color originalColor;

    void Start()
    {
        image = GetComponent<Image>();
        originalColor = image.color;
    }

    void Update()
    {
        // 알파 값을 사인 함수를 이용해 변화시킴
        float alpha = Mathf.Abs(Mathf.Sin(Time.time * blinkSpeed));
        image.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
    }
}
