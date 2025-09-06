using NUnit.Framework;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float jumpForce;         // ジャンプ力
    private bool isGrounded;         // 地面と当たっているか
    [SerializeField]
    private Transform groundCheck;   // 確認したいもの(プレイヤー)
    [SerializeField]
    private LayerMask groundLayer;   // 地面のレイヤー

    // プレイヤーのコンポーネント
    private Rigidbody2D rb;                 
    private Animator animator;              
    private CircleCollider2D circleCollider;

    string state;                   　// プレイヤーの状態管理
    string prevState;               　// ひとつ前の状態

    [SerializeField]
    gameOver m_gameOver;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        ChangeState();
        ChangeAnim();
    }

    // オブジェクトとの当たり判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 壁の当たり判定
        if (collision.gameObject.layer == LayerMask.NameToLayer("Cactus"))
        {
            // 何かしらの処理
            Debug.Log($"壁にあたったよー");

            m_gameOver.GameOver();
        }
    }

    // ジャンプ
    void Jump()
    {
        // 地面と当たっているか確認
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, circleCollider.radius, groundLayer);

        // 地面にいるかつスペースキーが押されたらジャンプ
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void ChangeState()
    {
        // 接地している場合
        if (isGrounded)
        {
            state = "RUN";
        }
        // 空中にいる場合
        else
        {
            // 加速度を見てステートを変える
            // 上昇中
            if (rb.linearVelocity.y > 0)
            {
                state = "JUMP_UP";
            }
            // 下降中
            else
            {
                state = "JUMP_DOWN";
            }
        }
    }

    void ChangeAnim()
    {
        // 状態が変わったときアニメーションを変更
        if (prevState != state)
        {
            switch (state)
            {
                case "RUN":
                    animator.SetBool("Run", true);
                    animator.SetBool("JumpUp", false);
                    animator.SetBool("JumpDown", false);
                    break;
                case "JUMP_UP":
                    animator.SetBool("Run", false);
                    animator.SetBool("JumpUp", true);
                    animator.SetBool("JumpDown", false);
                    break;
                case "JUMP_DOWN":
                    animator.SetBool("Run", false);
                    animator.SetBool("JumpUp", false);
                    animator.SetBool("JumpDown", true);
                    break;
            }

            prevState = state;
        }
    }
}

//public class TestPlayer
//{
//    [SerializeField]
//    private float jumpForce;   // ジャンプ力
//    private bool isGrounded;        // 地面と当たっているか
//    [SerializeField]
//    private Transform groundCheck;  // 確認したいもの(プレイヤー)
//    [SerializeField]
//    private LayerMask groundLayer;  // 地面のレイヤー

//    private Rigidbody2D rb;         // このオブジェクト


//    // ゲームオーバーフラグ
//    public bool isGameOver;


//    PlayerCollision m_playerCollision;

//    GameObject m_objPlayer;

//    // Start is called once before the first execution of Update after the MonoBehaviour is created
//    public TestPlayer(GameObject objPlayer)
//    {
//        m_objPlayer = objPlayer;
//        m_playerCollision = m_objPlayer.GetComponent<PlayerCollision>();
//        rb = m_objPlayer.GetComponent<Rigidbody2D>();
//    }

//    // Update is called once per frame
//    public void Update()
//    {
//        // 地面と当たっているか確認
//        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.5f, groundLayer);

//        // 地面にいるかつスペースキーが押されたらジャンプ
//        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
//        {
//            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
//        }
//    }

//}// class

//public class PlayerCollision : MonoBehaviour
//{
//    public bool isGameOver;

//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        // 壁の当たり判定
//        if (collision.gameObject.layer == LayerMask.NameToLayer("Cactus"))
//        {
//            // 何かしらの処理
//            Debug.Log($"壁にあたったよー");

//            isGameOver = true;
//        }

//    }
//}// class