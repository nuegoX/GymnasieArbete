using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimeHandling : MonoBehaviour
{
    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;
    public AudioClip sound4;
    public AudioClip sound5;
    public AudioClip sound6;
    public AudioClip winSound;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Start coroutines for each action at different time intervals
        StartCoroutine(PlaySoundAfterDelay(sound1, 0f));      // Play sound immediately
        StartCoroutine(PlaySoundAfterDelay(sound2, 120f));    // Play sound after 2 minutes (120 seconds)
        StartCoroutine(PlaySoundAfterDelay(sound3, 240f));    // Play sound after 4 minutes (240 seconds)
        StartCoroutine(PlaySoundAfterDelay(sound4, 240f));    // Play sound after 6 minutes (360 seconds)
        StartCoroutine(PlaySoundAfterDelay(sound5, 240f));    // Play sound after 6 minutes (360 seconds)
        StartCoroutine(PlaySoundAfterDelay(sound6, 240f));    // Play sound after 8 minutes (480 seconds)
        StartCoroutine(WinGameAfterDelay(480f));             // Only two minutes left. The teachers know where you are. QUICK! Escape!

        StartCoroutine(WinGameAfterDelay(600f));             // Win game after 10 minutes (600 seconds)
    }

    private IEnumerator PlaySoundAfterDelay(AudioClip sound, float delayInSeconds)
    {
        yield return new WaitForSeconds(delayInSeconds);

        // Play the specified sound
        if (audioSource != null && sound != null)
        {
            audioSource.PlayOneShot(sound);
        }
    }

    private IEnumerator WinGameAfterDelay(float delayInSeconds)
    {
        yield return new WaitForSeconds(delayInSeconds);

        // Call the function or perform the action to win the game
        WinGame();
    }

    private void WinGame()
    {
        Debug.Log("You win the game!");
        // Add your win game logic here
    }
    private void EndgameAction()
    {
        // Activate alarm.
        // Red alarm-lights activate.
        // Random escape route opens up.
    }
}
