using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    // スコア
    [SerializeField]
    Text scoreText;

    // 最大スコア
    [SerializeField]
    Text maxScoreText;

    // スコアを増やす時間
    [SerializeField]
    float addScoreTime;

    // 増やすスコアの数値
    [SerializeField]
    int addScore;       

    float timer = 1;    // 時間
    int score = 0;      // スコア
    int maxScore = 0;   // 最大スコア


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 受け取った時間をフレームに変える
        addScoreTime /= 60;
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

        // 最大スコア更新
        if (maxScore < score)
        {
            maxScore = score;
            maxScoreText.text = "" + maxScore.ToString("d4");
        }
    }
}
