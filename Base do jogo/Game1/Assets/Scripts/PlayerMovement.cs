using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 8f;

    private Rigidbody rb;

    private Vector3 direcao;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        direcao = Vector3.zero;

        if (Keyboard.current != null)
        {
            if (Keyboard.current.wKey.isPressed) direcao.z += 1;
            if (Keyboard.current.sKey.isPressed) direcao.z -= 1;
            if (Keyboard.current.aKey.isPressed) direcao.x -= 1;
            if (Keyboard.current.dKey.isPressed) direcao.x += 1;
        }

        // rotação
        if (direcao != Vector3.zero)
        {
            transform.rotation =
                Quaternion.LookRotation(direcao)
                * Quaternion.Euler(0, -90, 0);
        }
    }

    void FixedUpdate()
    {
        Vector3 movimento =
            direcao.normalized * speed * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + movimento);
    }
}