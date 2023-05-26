using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    private int maxHealth = 100;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthSlider.value = currentHealth;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // handle player death
    }
}