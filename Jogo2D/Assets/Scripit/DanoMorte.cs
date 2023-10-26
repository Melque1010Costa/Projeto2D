using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DanoMorte : MonoBehaviour
{
    private ControleJogador controleJogador;
    private Animator anime;
    private bool jogadorMorto = false;

    private void Start()
    {
        controleJogador = GetComponentInParent<ControleJogador>();
        anime = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (jogadorMorto) return; // Se o jogador já estiver morto, não faça nada

        if (collision.gameObject.CompareTag("Agua") || collision.gameObject.CompareTag("Serra") || collision.gameObject.CompareTag("Inimigo"))
        {
            Morte();
        }
    }

    public void Morte()
    {
        anime.SetTrigger("morte");

        ControleJogador controleJogador = GetComponentInParent<ControleJogador>();
        if (controleJogador != null)
        {
            controleJogador.Morte(); // Chame o método Morte() do script ControleJogador
        }
        else
        {
            Debug.LogError("ControleJogador script not found!");
        }

        BolasDeFogoGerenciado.instance.RecriarBolasDeFogo(); // Chame o método para recriar as bolas de fogo

        SceneManager.LoadScene("TelaDeFim");
    }

}

