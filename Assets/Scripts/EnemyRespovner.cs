using UnityEngine;

public class EnemyRespovner : MonoBehaviour
{
    [SerializeField] private float cooldown;
    private float timer;

    private void Update()
    {
        timer -= Time.deltaTime;
    }
}
