using UnityEngine;

[RequireComponent(typeof(Light))] // “ребуетс€ компонент Light
public class Worldtime : MonoBehaviour
{
    [Tooltip("ћинимальное значение интенсивности света")]
    public float minIntensity = 0f;

    [Tooltip("ћаксимальное значение интенсивности света")]
    public float maxIntensity = 1.5f;

    [Tooltip("¬рем€, в течение которого свет не измен€ет интенсивность при значени€х 0 и 1.5 соответственно")]
    public float holdTimeNight = 300f;
    public float holdTimeDay = 600f;

    [Tooltip("—корость изменени€ интенсивности света")]
    public float changeSpeed = 0.01f;

    // ѕеременна€, отвечающа€ за направление изменени€ интенсивности
    private float direction = 1f;

    // “екущее значение интенсивности света
    private float currentIntensity = 0f;

    // ‘лаг, определ€ющий, готов ли свет к изменению интенсивности
    private bool readyToChange = true;

    // “аймер дл€ контрол€ времени "остановки" интенсивности
    private float holdTimer = 0f;

    private bool isDay = false;

    private void Start()
    {
        // «адаем начальное значение интенсивности света
        currentIntensity = minIntensity;
        GetComponent<Light>().intensity = currentIntensity;
        isDay = (currentIntensity == maxIntensity);
    }

    private void Update()
    {
        // ќпредел€ем, день сейчас или ночь, и соответственно выбираем
        // текущее значение holdTime
        float currentHoldTime = (isDay ? holdTimeDay : holdTimeNight);

        // ≈сли свет должен "остановитьс€", увеличиваем таймер и возвращаемс€
        // дл€ ожидани€, пока таймер не достигнет заданного значени€.
        if (!readyToChange)
        {
            holdTimer += Time.deltaTime;
            if (holdTimer >= currentHoldTime)
            {
                holdTimer = 0f;
                readyToChange = true;
                isDay = !isDay;
            }
            return;
        }

        // »змен€ем интенсивность света с заданной скоростью
        currentIntensity += changeSpeed * direction;
        if (currentIntensity <= minIntensity)
        {
            // —вет достиг минимальной интенсивности, начинаем "остановку"
            currentIntensity = minIntensity;
            readyToChange = false;
        }
        else if (currentIntensity >= maxIntensity)
        {
            // —вет достиг максимальной интенсивности, начинаем "остановку"
            currentIntensity = maxIntensity;
            readyToChange = false;
        }

        // ”станавливаем текущую интенсивность света
        GetComponent<Light>().intensity = currentIntensity;

        // »змен€ем направление изменени€ интенсивности света при достижении границ
        if (currentIntensity <= minIntensity || currentIntensity >= maxIntensity)
        {
            direction = -direction;
        }
    }
}