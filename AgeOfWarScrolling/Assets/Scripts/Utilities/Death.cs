using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public static int endScendeIndex = 1;  // Index of the end game scene

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject); // Destroy the player
            ShowGameOver();
        }
        else if (collision.gameObject.CompareTag("Clone"))
        {
            Destroy(collision.gameObject); // Destroy the clone
        }
    }

    void ShowGameOver()
    {
        // Load the "DeathMenu" scene
        SceneManager.LoadScene(endScendeIndex);
    }
}