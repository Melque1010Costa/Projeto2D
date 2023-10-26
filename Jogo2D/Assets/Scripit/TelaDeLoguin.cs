using UnityEngine;
using UnityEngine.SceneManagement;

public class TelaD : MonoBehaviour
{
    public void IniciarJogo()
    {
        Debug.Log("Iniciar Jogo clicado!"); // Adicione esta linha
        SceneManager.LoadScene("CenaPrincipal");
    }
    
}
