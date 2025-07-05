using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    // �X�R�A
    [SerializeField]
    Text scoreText;

    // �ő�X�R�A
    [SerializeField]
    Text maxScoreText;

    // �X�R�A�𑝂₷����
    [SerializeField]
    float addScoreTime;

    // ���₷�X�R�A�̐��l
    [SerializeField]
    int addScore;       

    float timer = 1;    // ����
    int score = 0;      // �X�R�A
    int maxScore = 0;   // �ő�X�R�A


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // �󂯎�������Ԃ��t���[���ɕς���
        addScoreTime /= 60;
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

        // �ő�X�R�A�X�V
        if (maxScore < score)
        {
            maxScore = score;
            maxScoreText.text = "" + maxScore.ToString("d4");
        }
    }
}
