using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject powerUpPrefab;

    [Header("Limites do mapa")]
    public float minX;
    public float maxX;

    public float minZ;
    public float maxZ;

    public float groundY = 4.2f;

    [Header("Tempo")]
    public float spawnDelay = 15f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnPowerUp), 5f, spawnDelay);
    }

 
    void SpawnPowerUp()
    {
        Vector3 spawnPos = new Vector3(
            Random.Range(minX, maxX),
            4.2f,
            Random.Range(minZ, maxZ)
        );

        Instantiate(
            powerUpPrefab,
            spawnPos,
            Quaternion.Euler(90f, 0f, 0f)
        );
    }
}
