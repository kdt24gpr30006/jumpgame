using UnityEngine;
using UnityEngine.UI;

public class SinCurve : MonoBehaviour
{

    [SerializeField] RectTransform rectTransform; // 矩形の座標
    Vector2 defaultPos; //  基準座標

    [SerializeField] float amplitude = 10f; // 揺れる幅（px）
    [SerializeField] float frequency = 2f; // 揺れる速さ（Hz）

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        defaultPos = rectTransform.anchoredPosition;
    }

    void Update()
    {
        float y = Mathf.Sin(Time.time * frequency) * amplitude;
        rectTransform.anchoredPosition = defaultPos + new Vector2(0, y);
    }
}
