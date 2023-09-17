using UnityEngine;

public class BonusScript : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject mainPlayer;
    public float fireRateBoost = 0.1f;
    private static int fireRateUpgrades = 0;
    private static bool hasCloned = false;

    void Start()
    {
        mainPlayer = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))  // Ensure it's the main player
        {
            int randomBonus = Random.Range(0, 1);

            if ((randomBonus == 0 && !hasCloned) || (fireRateUpgrades == 3 && !hasCloned))
            {
                SpawnClones(mainPlayer);
                hasCloned = true;
            }
            else if (randomBonus == 1 && fireRateUpgrades < 3)
            {
                PlayerShooting playerShooting = other.GetComponent<PlayerShooting>();
                if (playerShooting != null)
                {
                    playerShooting.UpdateFireRate(Mathf.Max(0.1f, playerShooting.fireRate - fireRateBoost));
                    fireRateUpgrades++;
                }
            }
            Destroy(gameObject);
        }
    }

    private void SpawnClones(GameObject player)
    {
        // Left clone
        GameObject leftClone = Instantiate(playerPrefab, player.transform.position, Quaternion.identity);
        AttachCloneController(leftClone, player, -1.0f);

        // Right clone
        GameObject rightClone = Instantiate(playerPrefab, player.transform.position, Quaternion.identity);
        AttachCloneController(rightClone, player, 1.0f);
    }

    private void AttachCloneController(GameObject clone, GameObject player, float offset)
    {
        CloneController cloneController = clone.AddComponent<CloneController>();
        cloneController.mainPlayer = player;
        cloneController.horizontalOffset = offset;
    }
}