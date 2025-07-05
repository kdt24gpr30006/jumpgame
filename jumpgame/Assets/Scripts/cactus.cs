using UnityEngine;

public class cactus : MonoBehaviour
{

    //  移動速度
    [SerializeField]
    float speed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        //  移動させる
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        //  画面外に出たとき削除する
        if(transform.position.x < -10.0f)
        {
            //  自身の削除
            Destroy(gameObject);
        }
    }
}
