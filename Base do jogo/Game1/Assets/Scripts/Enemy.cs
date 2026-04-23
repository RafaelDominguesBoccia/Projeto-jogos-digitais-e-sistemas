using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1f;

    private Transform player;

    void Start()
    {
        // encontra o player pela tag
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        // segue o player
        Vector3 direction = (player.position - transform.position).normalized;

        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        // mata o player
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);

            Debug.Log("Player morreu");
        }

        // destrói o inimigo
        if (other.CompareTag("Weapon"))
        {
            Destroy(gameObject);
        }
    }
}