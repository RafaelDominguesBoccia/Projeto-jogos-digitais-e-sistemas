using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Velocidade de movimentação do player
    public float speed = 8f;

    // Referência ao Rigidbody do player
    private Rigidbody rb;

    // Direção atual do movimento
    private Vector3 direcao;

    void Start()
    {
        // Pega o Rigidbody do objeto
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Reseta a direção a cada frame
        direcao = Vector3.zero;

        // Verifica se o teclado existe
        if (Keyboard.current != null)
        {
            // Movimento para frente
            if (Keyboard.current.wKey.isPressed) direcao.z += 1;

            // Movimento para trás
            if (Keyboard.current.sKey.isPressed) direcao.z -= 1;

            // Movimento para esquerda
            if (Keyboard.current.aKey.isPressed) direcao.x -= 1;

            // Movimento para direita
            if (Keyboard.current.dKey.isPressed) direcao.x += 1;
        }

        // Faz o player rotacionar na direção do movimento
        if (direcao != Vector3.zero)
        {
            transform.rotation =
                Quaternion.LookRotation(direcao)
                * Quaternion.Euler(0, -90, 0);
        }
    }

    void FixedUpdate()
    {
        // Calcula o movimento com física
        Vector3 movimento =
            direcao.normalized * speed * Time.fixedDeltaTime;

        // Move o player usando o Rigidbody
        rb.MovePosition(rb.position + movimento);
    }
}