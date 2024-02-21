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
    public AudioSource audioSource;
    public GameObject gameOverCanvas;

    [SerializeField]
    private GameObject exitGate1;

    [SerializeField]
    private GameObject exitGate2;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Start coroutines for each action at different time intervals
        StartCoroutine(PlaySoundAfterDelay(sound1, 0f));      // Play sound immediately
        
        StartCoroutine(PlaySoundAfterDelay(sound2, 120f));    // Play sound: Three minutes and the alarm will go off. You got this!
        
        StartCoroutine(PlaySoundAfterDelay(sound3, 240f));    // Play sound: The alarm will go off in one minute. Hang in there.
        
        
        StartCoroutine(PlaySoundAfterDelay(sound4, 300f));    // Play sound after 5 minutes (360 seconds)
        StartCoroutine(OpenExitGate(300f));

        StartCoroutine(PlaySoundAfterDelay(sound5, 380f));    // Play sound: You have 10 seconds. QUICK!
        
        StartCoroutine(TimeRanOut(390f));             // Lose game


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
        SceneManager.LoadScene("MainMenuScene");
    }

    private void EndgameAction()
    {

        // Generate a random number between 1 and 2
        int randomNumber = Random.Range(1, 3);

        // Perform actions based on the random number
        if (randomNumber == 1)
        {
            Destroy(exitGate1);
        }
        else if (randomNumber == 2)
        {
            Destroy(exitGate2);
        }

    }
}
