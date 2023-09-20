using UnityEngine;

public class BonusScript : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject mainPlayer;
    public float fireRateBoost = 0.1f;
    private static int fireRateUpgrades = 0;

    void Start()
    {
        mainPlayer = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))  // Ensure it's the main player
        {
            int randomBonus = Random.Range(0, 1);
            int cloneSize = GameObject.FindGameObjectsWithTag(tag).Length;

            if ((randomBonus == 0 && cloneSize < 2) || (fireRateUpgrades == 3 && cloneSize < 2))
            {
                SpawnClones(mainPlayer);
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
        // Check for existing clones
        GameObject existingLeftClone = GameObject.Find("LeftClone");
        GameObject existingRightClone = GameObject.Find("RightClone");

        // If no left clone exists, spawn it
        if (existingLeftClone == null)
        {
            GameObject leftClone = Instantiate(playerPrefab, player.transform.position, Quaternion.identity);
            AttachCloneController(leftClone, player, -1.0f);
            leftClone.name = "LeftClone";
        }

        // If no right clone exists, spawn it
        if (existingRightClone == null)
        {
            GameObject rightClone = Instantiate(playerPrefab, player.transform.position, Quaternion.identity);
            AttachCloneController(rightClone, player, 1.0f);
            rightClone.name = "RightClone";
        }
    }

    private void AttachCloneController(GameObject clone, GameObject player, float offset)
    {
        CloneController cloneController = clone.AddComponent<CloneController>();
        cloneController.mainPlayer = player;
        cloneController.horizontalOffset = offset;
    }
}