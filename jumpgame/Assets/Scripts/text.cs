using UnityEngine;
using UnityEngine.UI;


public class text : MonoBehaviour
{
    public RectTransform uiTextTransform; // Text��RectTransform
    void Update()
    {
        // RectTransform�̃A���J�[�𒆉��ɐݒ�
        uiTextTransform.anchorMin = new Vector2(0.5f, 0.5f);  // �A���J�[�𒆉���
        uiTextTransform.anchorMax = new Vector2(0.5f, 0.5f);  // �A���J�[�𒆉���
        uiTextTransform.anchoredPosition = Vector2.zero; // �ʒu�𒆉��ɐݒ�
    }
}
