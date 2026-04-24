using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;


// --- Modificadores de acesso para classes e variáveis ---
public class SceneLoader1 : MonoBehaviour
{
    public void CarregarJogo()
    {
        Invoke("Load", 1f);
    }


    // --- Carrega a cena "velocidade enemy" ---
    void Load()
    {
        SceneManager.LoadScene("velocidade enemy");
    }
}
