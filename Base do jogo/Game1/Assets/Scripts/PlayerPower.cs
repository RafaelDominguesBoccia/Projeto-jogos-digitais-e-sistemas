using UnityEngine;
using System.Collections;

public class PlayerPower : MonoBehaviour
{
    public bool powerActive = false;
    public GameObject shieldObject;
    private Coroutine currentRoutine;
    private Collider shieldCollider;
    private Renderer shieldRenderer;

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

        
        if (shieldObject != null)
            shieldObject.SetActive(true); // liga o shield

        yield return new WaitForSeconds(duration);

        powerActive = false;

        if (shieldObject != null)
            shieldObject.SetActive(false); // desliga o shield

        currentRoutine = null;


        Debug.Log("POWER UP ACABOU");
    }
}