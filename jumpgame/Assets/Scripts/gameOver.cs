using UnityEngine;

public class gameOver : MonoBehaviour
{
    [SerializeField]
    GameObject gameOverPanel;

    public bool isGameOver = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        isGameOver = true;
        Time.timeScale = 0.0f;
    }

    public void Retry()
    {
        gameOverPanel.SetActive(false);
        isGameOver = false;
        Time.timeScale = 1.0f;
    }
}
