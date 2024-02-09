using UnityEngine;

public class ProximitySound : MonoBehaviour
{
    public AudioClip continuousSound;
    public Transform player; // Reference to the player's transform
    public float maxVolumeDistance = 10f;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = continuousSound;
        audioSource.loop = true;
        audioSource.Play(); // Start playing the sound when the script starts
    }

    void Update()
    {
        if (player == null)
        {
            Debug.LogError("Player transform not assigned!");
            return;
        }

        // Calculate the distance between the object and the player
        float distance = Vector3.Distance(transform.position, player.position);

        // Adjust the volume based on the distance
        audioSource.volume = Mathf.Clamp01(1f - distance / maxVolumeDistance);
    }
}
