using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
    public string restrictMovementObjectName; // имя объекта, с которым игрок не должен сталкиваться    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == restrictMovementObjectName)
        {
            // Игрок не может проходить сквозь определенный объект
        }
    }
}