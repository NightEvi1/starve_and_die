using UnityEngine;

public class LightController : MonoBehaviour
{

    [Tooltip("����������� ������������� �����")]
    public float minIntensity = 4f;

    [Tooltip("������������ ������������� �����")]
    public float maxIntensity = 6f;

    [Tooltip("�������� ��������� ������������� �����")]
    public float speed = 1f;

    private float currentIntensity = 0f;
    private bool increasing = true;

    private void Start()
    {
        // ������������� ��������� ������������� �����
        currentIntensity = minIntensity;
        GetComponent<Light>().intensity = currentIntensity;
    }

    private void Update()
    {
        // �������� ������������� ����� � �������� ���������
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
        // ������������� ������� ������������� �����
        GetComponent<Light>().intensity = currentIntensity;
    }
}