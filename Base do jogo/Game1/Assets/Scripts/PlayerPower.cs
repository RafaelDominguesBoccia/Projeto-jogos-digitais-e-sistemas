using UnityEngine;
using System.Collections;

public class PlayerPower : MonoBehaviour
{
    // Verifica se o power-up está ativo
    public bool powerActive = false;

    // Objeto visual do escudo
    public GameObject shieldObject;

    // Renderer do shield
    private Renderer[] shieldRenderers;

    // Guarda a coroutine atual
    private Coroutine currentRoutine;

    void Start()
    {
        // pega o SpriteRenderer
        if (shieldObject != null)
        {
            shieldRenderers = shieldObject.GetComponentsInChildren<Renderer>();
        }
    }

    // Ativa o power-up
    public void ActivatePowerUp(float duration)
    {
        if (currentRoutine != null)
        {
            StopCoroutine(currentRoutine);
        }

        currentRoutine = StartCoroutine(PowerRoutine(duration));
    }

    IEnumerator PowerRoutine(float duration)
    {
        powerActive = true;

        Debug.Log("POWER UP ATIVO");

        // ativa shield
        if (shieldObject != null)
            shieldObject.SetActive(true);

        // espera até faltar 2 segundos
        yield return new WaitForSeconds(duration - 2f);

        // pisca durante 2 segundos
        yield return StartCoroutine(BlinkWarning(2f));

        // desativa power
        powerActive = false;

        if (shieldObject != null)
            shieldObject.SetActive(false);

        currentRoutine = null;

        Debug.Log("POWER UP ACABOU");
    }

    // Pisca vermelho/branco
    IEnumerator BlinkWarning(float blinkTime)
    {
        float timer = 0f;

        while (timer < blinkTime)
        {
            // vermelho
            foreach (Renderer rend in shieldRenderers)
            {
                rend.material.color = Color.red;
            }

            yield return new WaitForSeconds(0.2f);

            // branco
            foreach (Renderer rend in shieldRenderers)
            {
                rend.material.color = Color.white;
            }

            yield return new WaitForSeconds(0.2f);

            timer += 0.4f;
        }
    }
}