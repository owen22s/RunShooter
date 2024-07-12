using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public GameObject finishUI;

    // Called when the player enters the finish trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            finishUI.SetActive(true);
            Debug.Log(other);

            // Get the current level
            int currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);

            // Increment the level
            currentLevel++;

            // Save the new level
            PlayerPrefs.SetInt("CurrentLevel", currentLevel);

            // Load the next level
            SceneManager.LoadScene("Level" + currentLevel);
        }
    }
}
