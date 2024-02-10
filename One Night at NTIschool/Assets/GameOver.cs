using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider is an NPC
        if (other.CompareTag("NPC"))
        {
            // Call the game over function
            GameOverr();
            Debug.Log("This is a NPC");
        }
        Debug.Log("This is a log meseeesage");

    }

    private void GameOverr()
    {
        // Pause the game (stop time)
        Time.timeScale = 0f;
        /*
        // Display the game over canvas
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true);
        }*/

        // Invoke the RestartGame function after 5 seconds
        Invoke("RestartGame", 5f);
    }

    private void RestartGame()
    {
        // Unpause the game
        Time.timeScale = 1f;

        // Reload the scene to restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
