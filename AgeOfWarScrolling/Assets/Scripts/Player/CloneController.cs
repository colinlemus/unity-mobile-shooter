using UnityEngine;

public class CloneController : MonoBehaviour
{
    public GameObject mainPlayer;
    public float horizontalOffset = 1.0f;
    public float maxHorizontalRange = 2.0f;
    private PlayerShooting mainPlayerShooting;
    private PlayerShooting cloneShooting;
    private float lastFireRate;
    private float lastGlobalFireRate;

    void Start()
    {
        mainPlayer = GameObject.FindWithTag("Player");
        mainPlayerShooting = mainPlayer.GetComponent<PlayerShooting>();
        cloneShooting = GetComponent<PlayerShooting>();
        UpdateFireRate();
        lastFireRate = cloneShooting.fireRate;
        lastGlobalFireRate = PlayerShooting.GlobalFireRate;
    }

    void Update()
    {
        Vector3 newPosition = mainPlayer.transform.position;
        newPosition.x += horizontalOffset;
        transform.position = newPosition;

        if (lastGlobalFireRate != PlayerShooting.GlobalFireRate)
        {
            UpdateFireRate();
            lastGlobalFireRate = PlayerShooting.GlobalFireRate;
        }
    }

    private void UpdateFireRate()
    {
        cloneShooting.fireRate = mainPlayerShooting.fireRate;
        cloneShooting.CancelInvoke("Shoot");
        cloneShooting.InvokeRepeating("Shoot", 0f, cloneShooting.fireRate);
    }
}