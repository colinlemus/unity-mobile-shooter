using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;  // Singleton instance
    private int score = 0; // Current score
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
    }

    // Manual initialization method
    public void InitializeScoreText()
    {
        scoreText = GameObject.FindWithTag("score").GetComponent<TextMeshProUGUI>();
    }

    // Update the displayed score
    public void UpdateScoreDisplay(int scoreToDisplay)
    {
        if (scoreText != null)
            scoreText.text = "Score: " + scoreToDisplay;
    }

    // Increase the score by a specified amount
    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreDisplay(score);
    }

    // Decrease the score by a specified amount
    public void DecreaseScore(int amount)
    {
        score -= amount;
        UpdateScoreDisplay(score);
    }

    // Get the current score
    public int GetScore()
    {
        return score;
    }
}