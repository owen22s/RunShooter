using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadLevel(int level)
    {
        // Save the current level
        PlayerPrefs.SetInt("CurrentLevel", level);

        // Load the specified level
        SceneManager.LoadScene("Level" + level);
    }

    public void ResetProgress()
    {
        // Reset the player's progress
        PlayerPrefs.SetInt("CurrentLevel", 1);
    }

    public void IncreaseLevel()
    {
        // Get the current level
        int currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);

        // Increment the level
        currentLevel++;

        // Save the new level
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);

        // Load the new level
        SceneManager.LoadScene("Level" + currentLevel);
    }
}