using UnityEngine;
using UnityEngine.UI;

public class BackGroundMove : MonoBehaviour
{
    private const float MAXLENGTH = 1f;
    private const string PROP_NAME = "_MainTex";

    [SerializeField]
    private Vector2 m_offsetSpeed;

    private Material material;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        if(GetComponent<Image>() is Image i)
        {
            material = i.material;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if(material)
        {
            var x = Mathf.Repeat(Time.time * m_offsetSpeed.x, MAXLENGTH);
            var y = Mathf.Repeat(Time.time * m_offsetSpeed.y, MAXLENGTH);
            var offset = new Vector2(x, y);
            material.SetTextureOffset(PROP_NAME, offset);
        }
    }

    private void OnDestroy()
    {
        if(material)
        {
            material.SetTextureOffset(PROP_NAME, Vector2.zero);
        }
    }
}
