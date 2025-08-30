using UnityEngine;
using UnityEngine.UI;

public class SinCurve : MonoBehaviour
{

    [SerializeField] RectTransform rectTransform; // ��`�̍��W
    Vector2 defaultPos; //  ����W

    [SerializeField] float amplitude = 10f; // �h��镝�ipx�j
    [SerializeField] float frequency = 2f; // �h��鑬���iHz�j

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
