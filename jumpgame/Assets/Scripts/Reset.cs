using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    Score m_score;

    [SerializeField]
    gameOver m_gameOver;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_score = this.GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("r"))
        {

            var highScore = m_score.highScore;
            // ハイスコア保存
            PlayerPrefs.SetInt("HighScore", highScore);
            SceneManager.LoadScene(1);

            m_gameOver.Retry();
        }
    }
}
