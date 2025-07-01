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
    private void Awake()
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
        GetReady.SetActive(false);
        gameOver.SetActive(true);
        Pause1();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();

        if (score % 10 == 0)
        {
            // Increase pipe speed significantly
            Pipes[] pipes = FindObjectsOfType<Pipes>();
            foreach (Pipes pipe in pipes)
            {
                pipe.speed += 1.5f; // Strong increase
            }

            // Make sure future pipes also spawn faster
            Spawner spawner = FindObjectOfType<Spawner>();
            if (spawner != null)
            {
                GameObject pipePrefab = spawner.prefab;
                if (pipePrefab != null && pipePrefab.GetComponent<Pipes>() != null)
                {
                    pipePrefab.GetComponent<Pipes>().speed += 1.5f;
                }
            }
            if (score >= 50) // You can change 50 to any final score
            {
                Win();
            }

            // Increase gravity and jump strength to keep pace
            player.gravity -= 1.2f;     // Fall faster
            player.strenght += 0.8f;    // Jump harder
        }
    }
    public void Win()
    {
        Pause();
        gameOver.SetActive(true);
        gameOver.GetComponentInChildren<Text>().text = "YOU WIN!";
        playButton.SetActive(true);
    }

}