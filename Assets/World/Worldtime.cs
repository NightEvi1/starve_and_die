using UnityEngine;

[RequireComponent(typeof(Light))] // ��������� ��������� Light
public class Worldtime : MonoBehaviour
{
    [Tooltip("����������� �������� ������������� �����")]
    public float minIntensity = 0f;

    [Tooltip("������������ �������� ������������� �����")]
    public float maxIntensity = 1.5f;

    [Tooltip("�����, � ������� �������� ���� �� �������� ������������� ��� ��������� 0 � 1.5 ��������������")]
    public float holdTimeNight = 300f;
    public float holdTimeDay = 600f;

    [Tooltip("�������� ��������� ������������� �����")]
    public float changeSpeed = 0.01f;

    // ����������, ���������� �� ����������� ��������� �������������
    private float direction = 1f;

    // ������� �������� ������������� �����
    private float currentIntensity = 0f;

    // ����, ������������, ����� �� ���� � ��������� �������������
    private bool readyToChange = true;

    // ������ ��� �������� ������� "���������" �������������
    private float holdTimer = 0f;

    private bool isDay = false;

    private void Start()
    {
        // ������ ��������� �������� ������������� �����
        currentIntensity = minIntensity;
        GetComponent<Light>().intensity = currentIntensity;
        isDay = (currentIntensity == maxIntensity);
    }

    private void Update()
    {
        // ����������, ���� ������ ��� ����, � �������������� ��������
        // ������� �������� holdTime
        float currentHoldTime = (isDay ? holdTimeDay : holdTimeNight);

        // ���� ���� ������ "������������", ����������� ������ � ������������
        // ��� ��������, ���� ������ �� ��������� ��������� ��������.
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

        // �������� ������������� ����� � �������� ���������
        currentIntensity += changeSpeed * direction;
        if (currentIntensity <= minIntensity)
        {
            // ���� ������ ����������� �������������, �������� "���������"
            currentIntensity = minIntensity;
            readyToChange = false;
        }
        else if (currentIntensity >= maxIntensity)
        {
            // ���� ������ ������������ �������������, �������� "���������"
            currentIntensity = maxIntensity;
            readyToChange = false;
        }

        // ������������� ������� ������������� �����
        GetComponent<Light>().intensity = currentIntensity;

        // �������� ����������� ��������� ������������� ����� ��� ���������� ������
        if (currentIntensity <= minIntensity || currentIntensity >= maxIntensity)
        {
            direction = -direction;
        }
    }
}