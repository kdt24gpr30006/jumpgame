using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Reset : MonoBehaviour
{
    Score m_score;

    [SerializeField]
    gameOver m_gameOver;

    [SerializeField]
    Text m_textTitle;
    [SerializeField]
    Text m_textGame;

    const string nextSceneGame = "Game";
    const string nextSceneTitle = "Title";

    private string nextSceneName = "";
    enum ResetType
    {
        TITLE = 1,
        GAME = 2,
    }


    int selectReset = (int)ResetType.GAME;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_textGame.color = Color.yellow;
        m_score = this.GetComponent<Score>();
        nextSceneName = nextSceneGame;
    }

    // Update is called once per frame
    void Update()
    {
        // �Q�[���I�[�o�[�t���O���I���̎�
        if (m_gameOver.isGameOver)
        {
            // ���L�[�Ŗ߂�ꏊ��ς���
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (selectReset == (int)ResetType.TITLE)
                {
                    // �F��ς���
                    m_textTitle.color= Color.white;
                    m_textGame.color = Color.yellow;

                    selectReset = (int)ResetType.GAME;
                }
                else
                {
                    // �F��ς���
                    m_textTitle.color = Color.yellow;
                    m_textGame.color = Color.white;

                    selectReset = (int)ResetType.TITLE;
                }
            }

            // �X�y�[�X�L�[�������ꂽ��
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var highScore = m_score.highScore;

                nextSceneName = (selectReset == (int)ResetType.TITLE) ? nextSceneTitle: nextSceneGame;
                // �n�C�X�R�A�ۑ�
                PlayerPrefs.SetInt("HighScore", highScore);
                SceneManager.LoadScene(nextSceneName);

                m_gameOver.Retry();
            }
        }
    }
}
