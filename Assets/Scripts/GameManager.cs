using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject obstacleSpawner;
    int score = 0;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
  public void GameOver()
    {
        StopScrolling();
        stopObstacles();
        obstacleSpawner.SetActive(false);
        gameOverPanel.SetActive(true);
    }
    void StopScrolling()
    {
        TextureScroll[] scrollingObjects = FindObjectsByType<TextureScroll>(FindObjectsSortMode.None);
        foreach(TextureScroll t in scrollingObjects)
        {
            t.scroll = false;
        }

    }
    void stopObstacles()
    {
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach(GameObject o in obstacles)
        {
            o.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
    public void IncrementScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
    
}
