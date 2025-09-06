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
        // ゲームオーバーフラグがオンの時
        if (m_gameOver.isGameOver)
        {
            // 矢印キーで戻る場所を変える
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (selectReset == (int)ResetType.TITLE)
                {
                    // 色を変える
                    m_textTitle.color= Color.white;
                    m_textGame.color = Color.yellow;

                    selectReset = (int)ResetType.GAME;
                }
                else
                {
                    // 色を変える
                    m_textTitle.color = Color.yellow;
                    m_textGame.color = Color.white;

                    selectReset = (int)ResetType.TITLE;
                }
            }

            // スペースキーが押されたら
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var highScore = m_score.highScore;

                nextSceneName = (selectReset == (int)ResetType.TITLE) ? nextSceneTitle: nextSceneGame;
                // ハイスコア保存
                PlayerPrefs.SetInt("HighScore", highScore);
                SceneManager.LoadScene(nextSceneName);

                m_gameOver.Retry();
            }
        }
    }
}
