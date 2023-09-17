using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 100f;
    public float fireRate = 0.3f;
    public int maxBullets = 10;
    public static float GlobalFireRate = 0.3f;  // Shared fire rate

    private Queue<GameObject> bullets = new Queue<GameObject>();

    void Start()
    {
        UpdateFireRate(PlayerShooting.GlobalFireRate);
    }

    public void UpdateFireRate(float newRate)
    {
        fireRate = newRate;
        GlobalFireRate = newRate;  // Update the static GlobalFireRate
        CancelInvoke("Shoot");
        InvokeRepeating("Shoot", 0f, fireRate);
    }

    void Shoot()
    {
        // Instantiate the new bullet
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = firePoint.forward * projectileSpeed;
        rb.mass = 0.0001f;  // Ridiculously low mass

        // Add the new bullet to the queue
        bullets.Enqueue(projectile);

        // If we exceed max bullets, despawn the oldest onez
        if (bullets.Count > maxBullets)
        {
            GameObject oldestBullet = bullets.Dequeue();
            Destroy(oldestBullet);
        }
    }
}