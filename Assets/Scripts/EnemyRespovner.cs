using UnityEngine;

public class EnemyRespovner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform[] respawnPoints;
    [SerializeField] private float cooldown = 2f;
    [SerializeField] private float cooldawnDecreaseRate = .05f;
    [SerializeField] private float cooldawnCap = .7f;

    private float timer;

    private Transform player;

    private void Awake()
    {
        player = FindFirstObjectByType<Player>().transform;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            timer = cooldown;
            CreateNewEnemy();

            cooldown = Mathf.Max(cooldawnCap, cooldown - cooldawnDecreaseRate);
        }
    }

    private void CreateNewEnemy()
    {
        int respawnPointIndex = Random.Range(0, respawnPoints.Length);
        Vector3 spawnPosition = respawnPoints[respawnPointIndex].position;
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        bool createdOnTheRight = newEnemy.transform.position.x > player.position.x;

        if (createdOnTheRight)
        {
            newEnemy.GetComponent<Enemy>().Flip();
        }
    }
}
