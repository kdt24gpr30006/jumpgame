using UnityEngine;

public class gameOver : MonoBehaviour
{
    [SerializeField]
    GameObject gameOverPanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void Retry()
    {
        gameOverPanel.SetActive(false); 
        Time.timeScale = 1.0f;
    }
}
