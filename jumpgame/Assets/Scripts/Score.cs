using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    // �X�R�A
    [SerializeField]
    Text scoreText;

    // �n�C�X�R�A
    [SerializeField]
    Text highScoreText;

    // �X�R�A�𑝂₷����
    [SerializeField]
    float addScoreTime;

    // ���₷�X�R�A�̐��l
    [SerializeField]
    int addScore;       

    float timer = 0;    // ����
    int score = 0;      // �X�R�A
    // �n�C�X�R�A
    int m_highScore;
    public int highScore
    {
        get { return m_highScore;  }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // �󂯎�������Ԃ��t���[���ɕς���
        addScoreTime /= 60;

        // �n�C�X�R�A�����[�h���`��
        m_highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "" + m_highScore.ToString("d4");
    }

    // Update is called once per frame
    void Update()
    {
        AddScore();
    }

    // ���Ԃɂ���ăX�R�A�𑝂₷�֐�
    void AddScore()
    {
        // �����ݒ�
        if (score >= 9999)
        {
            score = 9999;
            return;
        }

        // ���Ԃ��v��
        timer += Time.deltaTime;
        if (timer >= addScoreTime)
        {
            timer -= addScoreTime;
            score += addScore;
            scoreText.text = "" + score.ToString("d4");
        }

        // �n�C�X�R�A�X�V
        if (m_highScore < score)
        {
            m_highScore = score;
            highScoreText.text = "" + m_highScore.ToString("d4");
        }
    }
}
