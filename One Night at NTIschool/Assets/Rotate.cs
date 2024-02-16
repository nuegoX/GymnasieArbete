using System.Collections;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed = 30f; // Adjust the speed as needed
    public bool AlarmsActivated = false;

    [SerializeField]
    private Light[] pointLights;

    public void Update()
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
                    light.intensity = Mathf.Lerp(0f, 2f, Mathf.PingPong(Time.time, 1f));
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
