using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
    public string restrictMovementObjectName; // ��� �������, � ������� ����� �� ������ ������������    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == restrictMovementObjectName)
        {
            // ����� �� ����� ��������� ������ ������������ ������
        }
    }
}