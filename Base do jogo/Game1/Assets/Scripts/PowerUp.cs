using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour
{
    public float duration = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPower player = other.GetComponent<PlayerPower>();

            if (player != null)
            {
                player.ActivatePowerUp(duration);
            }

            Destroy(gameObject);
        }
    }
}