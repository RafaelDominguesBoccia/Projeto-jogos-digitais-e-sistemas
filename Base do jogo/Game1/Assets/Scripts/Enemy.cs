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

    private void OnCollisionEnter(Collision collision)
    {
        // mata o player
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);

            Debug.Log("Player morreu");
        }

        // destrói o inimigo
        if (collision.gameObject.CompareTag("Weapon"))
        {
            Destroy(gameObject);
        }
    }
}