using UnityEngine;

public class cactus : MonoBehaviour
{

    //  �ړ����x
    [SerializeField]
    float speed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        //  �ړ�������
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        //  ��ʊO�ɏo���Ƃ��폜����
        if(transform.position.x < -10.0f)
        {
            //  ���g�̍폜
            Destroy(gameObject);
        }
    }
}
