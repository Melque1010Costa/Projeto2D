using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver2 : MonoBehaviour
{
    public void ReiniciarJogo()
    {
        // Este método será chamado quando o jogador clicar no botão de reiniciar
        Debug.Log("Reiniciando o jogo..."); // Adiciona um log para verificar se a função é chamada
        SceneManager.LoadScene("Fase2"); // Troque "NomeDaSuaCenaDoJogo" pelo nome da sua cena principal do jogo
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
