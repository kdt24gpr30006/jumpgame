using UnityEngine;

public class Player :  MonoBehaviour
{
    [SerializeField]
    private float jumpForce;   // �W�����v��
    private bool isGrounded;        // �n�ʂƓ������Ă��邩
    [SerializeField]
    private Transform groundCheck;  // �m�F����������(�v���C���[)
    [SerializeField]
    private LayerMask groundLayer;  // �n�ʂ̃��C���[

    private Rigidbody2D rb;         // ���̃I�u�W�F�N�g

    [SerializeField]
    gameOver m_gameOver;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // �n�ʂƓ������Ă��邩�m�F
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.5f, groundLayer);

        // �n�ʂɂ��邩�X�y�[�X�L�[�������ꂽ��W�����v
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �ǂ̓����蔻��
        if (collision.gameObject.layer == LayerMask.NameToLayer("Cactus"))
        {
            // ��������̏���
            Debug.Log($"�ǂɂ���������[");

            m_gameOver.GameOver();
        }
    }
}



//public class TestPlayer
//{
//    [SerializeField]
//    private float jumpForce;   // �W�����v��
//    private bool isGrounded;        // �n�ʂƓ������Ă��邩
//    [SerializeField]
//    private Transform groundCheck;  // �m�F����������(�v���C���[)
//    [SerializeField]
//    private LayerMask groundLayer;  // �n�ʂ̃��C���[

//    private Rigidbody2D rb;         // ���̃I�u�W�F�N�g


//    // �Q�[���I�[�o�[�t���O
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
//        // �n�ʂƓ������Ă��邩�m�F
//        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.5f, groundLayer);

//        // �n�ʂɂ��邩�X�y�[�X�L�[�������ꂽ��W�����v
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
//        // �ǂ̓����蔻��
//        if (collision.gameObject.layer == LayerMask.NameToLayer("Cactus"))
//        {
//            // ��������̏���
//            Debug.Log($"�ǂɂ���������[");

//            isGameOver = true;
//        }

//    }
//}// class