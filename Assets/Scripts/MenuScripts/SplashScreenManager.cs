using UnityEngine;
using System.Collections;

public class SplashScreenManager : MonoBehaviour
{
    public GameObject objectToDisable; // The GameObject to be disabled
    public AudioSource audioSource; // The AudioSource to play the music

    private void Start()
    {
        // Start the coroutine
        StartCoroutine(PauseAndDisableCoroutine());
    }

    private IEnumerator PauseAndDisableCoroutine()
    {
        // Pause the game
        Time.timeScale = 0f;

        // Wait for 2 seconds (unscaled time)
        yield return new WaitForSecondsRealtime(2f);

        // Disable the specified GameObject
        objectToDisable.SetActive(false);

        // Play the music
        if (audioSource != null)
        {
            audioSource.Play();
        }

        // Resume the game
        Time.timeScale = 1f;
    }
}
