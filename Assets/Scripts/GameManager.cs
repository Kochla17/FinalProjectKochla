using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public GameObject GetReady;
    public Player player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    private int score;
    private void Awake ()
    {
        Application.targetFrameRate = 60;
        Pause();
    }

    public void Play()
    {
        score = 0;

        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);
        GetReady.SetActive(false);
        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
        gameOver.SetActive(false);  

    }
    public void Pause1()
    {
        Time.timeScale = 0f;
        player.enabled = false;
        gameOver.SetActive(true);

    }

    public void GameOver()
    {
        
        playButton.SetActive(true);
        GetReady.SetActive(false );
        gameOver.SetActive(true);
        Pause1();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString(); 
    }
}
