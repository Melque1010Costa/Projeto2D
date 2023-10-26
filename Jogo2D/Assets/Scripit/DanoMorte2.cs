using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DanoMorte2 : MonoBehaviour
{
    private ControleJogador2 controleJogador2;
    private Animator anime;
    private bool jogadorMorto = false;

    private void Start()
    {
        controleJogador2 = GetComponentInParent<ControleJogador2>();
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

        ControleJogador2 controleJogador2 = GetComponentInParent<ControleJogador2>();
        if (controleJogador2 != null)
        {
            controleJogador2.Morte(); // Chame o método Morte() do script ControleJogador2
        }
        else
        {
            Debug.LogError("ControleJogador2 script not found!");
        }

        BolasDeFogoGerenciado.instance.RecriarBolasDeFogo(); // Chame o método para recriar as bolas de fogo

        SceneManager.LoadScene("TelaDeFim2");
    }

}
