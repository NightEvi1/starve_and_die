using UnityEngine;

public class LightController : MonoBehaviour
{

    [Tooltip("ћинимальна€ интенсивность света")]
    public float minIntensity = 4f;

    [Tooltip("ћаксимальна€ интенсивность света")]
    public float maxIntensity = 6f;

    [Tooltip("—корость изменени€ интенсивности света")]
    public float speed = 1f;

    private float currentIntensity = 0f;
    private bool increasing = true;

    private void Start()
    {
        // ”станавливаем начальную интенсивность света
        currentIntensity = minIntensity;
        GetComponent<Light>().intensity = currentIntensity;
    }

    private void Update()
    {
        // »змен€ем интенсивность света с заданной скоростью
        if (increasing)
        {
            currentIntensity += Time.deltaTime * speed;
            if (currentIntensity >= maxIntensity)
            {
                currentIntensity = maxIntensity;
                increasing = false;
            }
        }
        else
        {
            currentIntensity -= Time.deltaTime * speed;
            if (currentIntensity <= minIntensity)
            {
                currentIntensity = minIntensity;
                increasing = true;
            }
        }
        // ”станавливаем текущую интенсивность света
        GetComponent<Light>().intensity = currentIntensity;
    }
}