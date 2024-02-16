using System.Collections;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed = 30f; // Adjust the speed as needed
    public bool AlarmsActivated = false;

    [SerializeField]
    private Light[] pointLights;

    [SerializeField]
    private AudioSource alarmSound;

    private void Update()
    {
        if (AlarmsActivated)
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

            // Update intensity of selected point lights
            foreach (Light light in pointLights)
            {
                if (light != null)
                {
                    // Interpolate intensity from 0 to 2 over time
                    light.intensity = Mathf.Lerp(0f, 1.5f, Mathf.PingPong(Time.time, 1f));
                }
            }

            // Adjust sound volume based on distance
            // Adjust sound volume based on distance
            if (alarmSound != null)
            {
                float distanceToPlayer = Vector3.Distance(transform.position, Camera.main.transform.position);
                float volume = Mathf.Clamp01(1f - distanceToPlayer / 35f); // Adjust the divisor for the desired volume falloff

                // Set the maximum volume to 75%
                volume *= 0.01f;

                alarmSound.volume = volume;

                if (!alarmSound.isPlaying)
                {
                    alarmSound.Play();
                }
            }

        }
    }

    private void Start()
    {
        StartCoroutine(ActivateAlarm(10f));
    }

    private IEnumerator ActivateAlarm(float delayInSeconds)
    {
        yield return new WaitForSeconds(delayInSeconds);
        AlarmsActivated = true;
    }
}
