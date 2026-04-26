using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour
{
    // Tempo que o power-up ficará ativo
    public float duration = 10f;

    // Detecta quando algo entra no trigger do power-up
    private void OnTriggerEnter(Collider other)
    {
        // Verifica se quem encostou foi o player
        if (other.CompareTag("Player"))
        {
            // Pega o script PlayerPower do player
            PlayerPower player = other.GetComponent<PlayerPower>();

            // Se o script existir
            if (player != null)
            {
                // Ativa o power-up pelo tempo definido
                player.ActivatePowerUp(duration);
            }

            // Destrói o power-up após ser coletado
            Destroy(gameObject);
        }
    }
}