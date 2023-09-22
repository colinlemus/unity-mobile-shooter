using UnityEngine;

public class Health : MonoBehaviour
{
    public int initialHealth = 10; // Initial health for all instances
    public int health; // Instance-specific health
    public int maxHealth = 100;  // Maximum possible health
    public int healthGainOnSpawn = 5;  // Amount of health to gain on each spawn

    void Start()
    {
        health = initialHealth;  // Set the health to the initial value
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            UIManager.instance.IncreaseScore(initialHealth);
            Destroy(gameObject);
        }
    }

    public void GainHealth()
    {
        health += healthGainOnSpawn;
        health = Mathf.Clamp(health, 0, maxHealth);  // Clamp health between 0 and maxHealth
    }
}