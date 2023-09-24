using UnityEngine;

public class Health : MonoBehaviour
{
    public int initialHealth = 10; // Initial health for all instances
    public int health; // Instance-specific health
    public int maxHealth = 100;  // Maximum possible health

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            UIManager.instance.IncreaseScore(initialHealth);
            Destroy(gameObject);
        }
    }

    public void InitializeHealth(int updatedHealth)
    {
        initialHealth += updatedHealth;
        health = initialHealth;
    }
}