using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public float minX = 12f;
    public float maxX = -12f;

    public float minZ = 5.2f;
    public float maxZ = -5.2f;

    public float groundY = 4.2f;

    public float spawnTime = 0.7f;

    [Header("Velocidade")]
    public float currentSpeed = 0.5f;

    public float maxSpeed = 5f;

    public float speedIncrease = 0.1f;


    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnTime);
    }

    void Update()
    {
        // aumenta velocidade global
        if (currentSpeed < maxSpeed)
        {
            currentSpeed += speedIncrease * Time.deltaTime;
        }
    }
    void SpawnEnemy()
    {
        int side = Random.Range(0, 4);

        float x = 0;
        float z = 0;

        switch (side)
        {
            case 0: // cima
                x = Random.Range(minX, maxX);
                z = maxZ;
                break;

            case 1: // baixo
                x = Random.Range(minX, maxX);
                z = minZ;
                break;

            case 2: // direita
                x = maxX;
                z = Random.Range(minZ, maxZ);
                break;

            case 3: // esquerda
                x = minX;
                z = Random.Range(minZ, maxZ);
                break;
        }

        Vector3 spawnPosition = new Vector3(x, groundY, z);

        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        Enemy enemyScript = enemy.GetComponent<Enemy>();

        enemyScript.speed = currentSpeed;
        Debug.Log("Velocidade atual: " + currentSpeed);
    }
}