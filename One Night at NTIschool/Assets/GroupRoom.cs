using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupRoom : MonoBehaviour
{
    // Start is called before the first frame update
    private bool soundPlayed = false;
    public AudioSource GrouproomSound;

    void Start()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        // Kolla om det är spelaren som har träffat triggern
        if (other.CompareTag("Player"))
        {
            // Kolla om ljudet inte har spelats upp tidigare
            if (!soundPlayed)
            {
                // Spela upp ljudet
                GrouproomSound.Play();

                // Markera att ljudet har spelats upp
                soundPlayed = true;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
