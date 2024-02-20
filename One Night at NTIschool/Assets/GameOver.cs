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
        else if (other.CompareTag("Finish"))
        {
            WinGame();
        }

    }

    private void WinGame()
    {
        Debug.Log("Game is won.");
    }
    private void GameOverr()
    {
        Invoke("RestartGame", 0.1f);
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
