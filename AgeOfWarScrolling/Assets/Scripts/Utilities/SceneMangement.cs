using UnityEngine;
using UnityEngine.SceneManagement; // Importing the necessary namespace

public class SceneMangement : MonoBehaviour
{
    // Function to reload the current scene
    public static void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene(); // Get the current scene
        SceneManager.LoadScene(currentScene.name); // Load the scene using its name
    }

    public static void initScenes()
    {
        // Clear all loaded assets
        Resources.UnloadUnusedAssets();

        // Clear Unity's internal asset cache
        Caching.ClearCache();

        // Reset the score
        UIManager.instance.ResetScore();

        // Load the initial scene by index
        SceneManager.LoadScene(0);

    }
}