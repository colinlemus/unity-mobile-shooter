using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;  // Singleton instance
    private int score = 0; // Current score
    private int totalDestroyed = 0; // Total number of destroyed enemies
    public TextMeshProUGUI scoreText;  // Reference to the score display text object

    private void Awake()
    {
        // Ensure only one UIManager instance exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persist UIManager across scenes
        }
        else if (instance != this)
        {
            Destroy(gameObject); // Remove extra instances
            return;
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateScoreTextComponent();
        UpdateScoreDisplay(GetScore());
    }


    // Update Score Text Component method
    public void UpdateScoreTextComponent()
    {
        scoreText = GameObject.FindWithTag("Score").GetComponent<TextMeshProUGUI>();
    }

    // Update the displayed score
    public void UpdateScoreDisplay(int scoreToDisplay)
    {
        if (scoreText != null)
            scoreText.text = "Score: " + scoreToDisplay + " Killed: " + totalDestroyed;
    }

    // Increase the score by a specified amount
    public void IncreaseScore(int amount)
    {
        score += amount;
        totalDestroyed++;
        UpdateScoreDisplay(score);
    }

    // Decrease the score by a specified amount
    public void DecreaseScore(int amount)
    {
        score -= amount;
        totalDestroyed--;
        UpdateScoreDisplay(score);
    }

    // Reset the score to 0
    public void ResetScore()
    {
        score = 0;
        totalDestroyed = 0;
        UpdateScoreDisplay(score);
    }

    // Get the current score
    public int GetScore()
    {
        return score;
    }
}