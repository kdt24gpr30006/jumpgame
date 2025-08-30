using UnityEngine;
using UnityEngine.UI;


public class text : MonoBehaviour
{
    public RectTransform uiTextTransform; // TextのRectTransform
    void Update()
    {
        // RectTransformのアンカーを中央に設定
        uiTextTransform.anchorMin = new Vector2(0.5f, 0.5f);  // アンカーを中央に
        uiTextTransform.anchorMax = new Vector2(0.5f, 0.5f);  // アンカーを中央に
        uiTextTransform.anchoredPosition = Vector2.zero; // 位置を中央に設定
    }
}
