using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Painel da tela de derrota
    public GameObject gameOverPanel;

    // Função chamada quando o jogador perde
    public void GameOver()
    {
        // Ativa a tela de Game Over
        gameOverPanel.SetActive(true);

        // Pausa o jogo
        Time.timeScale = 0f;
    }

    // Reinicia a cena atual
    public void Retry()
    {
        // Volta o tempo ao normal
        Time.timeScale = 1f;

        // Recarrega a cena atual
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Volta para o menu principal
    public void BackToMenu()
    {
        // Volta o tempo ao normal
        Time.timeScale = 1f;

        // Carrega a cena chamada "Menu"
        SceneManager.LoadScene("Menu");
    }
}
