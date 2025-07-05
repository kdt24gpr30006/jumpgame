using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float jumpForce = 5f;   // ジャンプ力
    private bool isGrounded;        // 地面と当たっているか
    [SerializeField]
    private Transform groundCheck;  // 確認したいもの(プレイヤー)
    [SerializeField]
    private LayerMask groundLayer;  // 地面のレイヤー

    private Rigidbody2D rb;         // このオブジェクト

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // 地面と当たっているか確認
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.5f, groundLayer);

        // 地面にいるかつスペースキーが押されたらジャンプ
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 壁の当たり判定
        if (collision.gameObject.layer == LayerMask.NameToLayer("Cactus"))
        {
            // 何かしらの処理
            Debug.Log($"壁にあたったよー");
        }

    }


    // 自身の設定しているColliderが「Trigger」になっていたらここに来る
    private void OnTriggerEnter2D(Collider2D collision)
    {
    }
}
