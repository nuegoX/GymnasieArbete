using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTimeHandling : MonoBehaviour
{
    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;
    public AudioClip sound4;
    public AudioClip sound5;
    public AudioClip winSound;
    private AudioSource audioSource;
    public GameObject gameOverCanvas;

    [SerializeField]
    private GameObject exitGate1;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Start coroutines for each action at different time intervals
        StartCoroutine(PlaySoundAfterDelay(sound1, 0f));      // Play sound immediately
        
        StartCoroutine(PlaySoundAfterDelay(sound2, 120f));    // Play sound after 2 minutes (120 seconds)
        StartCoroutine(PlaySoundAfterDelay(sound3, 240f));    // Play sound after 4 minutes (240 seconds)
        StartCoroutine(PlaySoundAfterDelay(sound4, 240f));    // Play sound after 6 minutes (360 seconds)        
        
        StartCoroutine(PlaySoundAfterDelay(sound5, 240f));    // Play sound after 8 minutes (480 seconds)
        StartCoroutine(OpenExitGate(240f));

        // 10 Minutes passed - You lose
        StartCoroutine(TimeRanOut(300f));             // Lose game after 10 minutes (600 seconds)
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

    private IEnumerator TimeRanOut(float delayInSeconds)
    {
        yield return new WaitForSeconds(delayInSeconds);
        TimeIsUp();
    }
    
    private IEnumerator OpenExitGate(float delayInSeconds)
    {
        yield return new WaitForSeconds(delayInSeconds);

        EndgameAction();
    }

    private void TimeIsUp()
    {
        //Restart game.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void EndgameAction()
    {
        if (exitGate1 != null)
        {
            Destroy(exitGate1);
        } else
        {
            Debug.Log("Something went wrong");
        }


    }
}
