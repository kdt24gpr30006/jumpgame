using NUnit.Framework;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float jumpForce;         // �W�����v��
    private bool isGrounded;         // �n�ʂƓ������Ă��邩
    [SerializeField]
    private Transform groundCheck;   // �m�F����������(�v���C���[)
    [SerializeField]
    private LayerMask groundLayer;   // �n�ʂ̃��C���[

    // �v���C���[�̃R���|�[�l���g
    private Rigidbody2D rb;                 
    private Animator animator;              
    private CircleCollider2D circleCollider;

    string state;                   �@// �v���C���[�̏�ԊǗ�
    string prevState;               �@// �ЂƂO�̏��

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

    // �I�u�W�F�N�g�Ƃ̓����蔻��
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

    // �W�����v
    void Jump()
    {
        // �n�ʂƓ������Ă��邩�m�F
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, circleCollider.radius, groundLayer);

        // �n�ʂɂ��邩�X�y�[�X�L�[�������ꂽ��W�����v
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void ChangeState()
    {
        // �ڒn���Ă���ꍇ
        if (isGrounded)
        {
            state = "RUN";
        }
        // �󒆂ɂ���ꍇ
        else
        {
            // �����x�����ăX�e�[�g��ς���
            // �㏸��
            if (rb.linearVelocity.y > 0)
            {
                state = "JUMP_UP";
            }
            // ���~��
            else
            {
                state = "JUMP_DOWN";
            }
        }
    }

    void ChangeAnim()
    {
        // ��Ԃ��ς�����Ƃ��A�j���[�V������ύX
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