using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    // スコア
    [SerializeField]
    Text scoreText;

    // ハイスコア
    [SerializeField]
    Text highScoreText;

    // スコアを増やす時間
    [SerializeField]
    float addScoreTime;

    // 増やすスコアの数値
    [SerializeField]
    int addScore;       

    float timer = 0;    // 時間
    int score = 0;      // スコア
    // ハイスコア
    int m_highScore;
    public int highScore
    {
        get { return m_highScore;  }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 受け取った時間をフレームに変える
        addScoreTime /= 60;

        // ハイスコアをロード＆描画
        m_highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "" + m_highScore.ToString("d4");
    }

    // Update is called once per frame
    void Update()
    {
        AddScore();
    }

    // 時間によってスコアを増やす関数
    void AddScore()
    {
        // 上限を設定
        if (score >= 9999)
        {
            score = 9999;
            return;
        }

        // 時間を計測
        timer += Time.deltaTime;
        if (timer >= addScoreTime)
        {
            timer -= addScoreTime;
            score += addScore;
            scoreText.text = "" + score.ToString("d4");
        }

        // ハイスコア更新
        if (m_highScore < score)
        {
            m_highScore = score;
            highScoreText.text = "" + m_highScore.ToString("d4");
        }
    }
}
