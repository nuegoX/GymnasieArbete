using System.Collections;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public float minFlickerInterval = 0.1f;
    public float maxFlickerInterval = 0.5f;
    public float flickerDuration = 0.2f;

    private Light lightComponent;

    void Start()
    {
        lightComponent = GetComponent<Light>();
        if (lightComponent == null)
        {
            Debug.LogError("LightFlicker script requires a Light component on the same GameObject.");
            enabled = false;
        }

        // Start the flickering coroutine
        StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        while (true)
        {
            // Wait for a random interval before flickering
            yield return new WaitForSeconds(Random.Range(minFlickerInterval, maxFlickerInterval));

            // Flicker the light
            StartCoroutine(FlickerLight());
        }
    }

    IEnumerator FlickerLight()
    {
        // Turn off the light
        lightComponent.enabled = false;

        // Wait for a short duration
        yield return new WaitForSeconds(flickerDuration);

        // Turn the light back on
        lightComponent.enabled = true;
    }
}
