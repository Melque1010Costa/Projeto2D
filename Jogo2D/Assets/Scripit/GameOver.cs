using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorGameOver : MonoBehaviour
{
    public void ReiniciarJogo()
    {
        // Este método será chamado quando o jogador clicar no botão de reiniciar
        Debug.Log("Reiniciando o jogo..."); // Adiciona um log para verificar se a função é chamada
        SceneManager.LoadScene("CenaPrincipal"); // Troque "NomeDaSuaCenaDoJogo" pelo nome da sua cena principal do jogo
    }

    public void SairDoJogo()
    {
        // Este método será chamado quando o jogador clicar no botão de sair do jogo
        Debug.Log("Saindo do jogo..."); // Adiciona um log para verificar se a função é chamada
        
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
            System.Diagnostics.Process.GetCurrentProcess().Kill(); // Fecha a aplicação usando Process
        #endif
    }
}
