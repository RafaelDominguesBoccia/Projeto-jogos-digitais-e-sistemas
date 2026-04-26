using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    // Prefab do power-up que será criado
    public GameObject powerUpPrefab;

    [Header("Limites do mapa")]

    // Limite mínimo do eixo X
    public float minX;

    // Limite máximo do eixo X
    public float maxX;

    // Limite mínimo do eixo Z
    public float minZ;

    // Limite máximo do eixo Z
    public float maxZ;

    // Altura fixa do chão onde o power-up irá aparecer
    public float groundY = 4.2f;

    [Header("Tempo")]

    // Tempo entre cada spawn de power-up
    public float spawnDelay = 15f;

    void Start()
    {
        // Executa o método SpawnPowerUp repetidamente
        // após 5 segundos e depois a cada spawnDelay
        InvokeRepeating(nameof(SpawnPowerUp), 5f, spawnDelay);
    }

    // Função responsável por criar o power-up
    void SpawnPowerUp()
    {
        // Gera uma posição aleatória dentro dos limites do mapa
        Vector3 spawnPos = new Vector3(
            Random.Range(minX, maxX),
            groundY,
            Random.Range(minZ, maxZ)
        );

        // Cria o power-up na posição gerada
        // com rotação ajustada para o chão
        Instantiate(
            powerUpPrefab,
            spawnPos,
            Quaternion.Euler(90f, 0f, 0f)
        );
    }
}