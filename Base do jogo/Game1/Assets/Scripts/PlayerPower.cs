using UnityEngine;
using System.Collections;

public class PlayerPower : MonoBehaviour
{
    public bool powerActive = false;

    public void ActivatePowerUp(float duration)
    {
        StartCoroutine(PowerRoutine(duration));
    }

    IEnumerator PowerRoutine(float duration)
    {
        powerActive = true;

        Debug.Log("POWER UP ATIVO");

        // aqui você coloca o efeito:
        // velocidade
        // arma
        // escudo
        // etc

        yield return new WaitForSeconds(duration);

        powerActive = false;

        Debug.Log("POWER UP ACABOU");
    }
}