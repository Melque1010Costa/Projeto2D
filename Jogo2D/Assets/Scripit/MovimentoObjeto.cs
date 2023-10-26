using UnityEngine;
using UnityEngine.SceneManagement;


public class MovimentoObjeto : MonoBehaviour
{
    public float VelocidadeDeQueda { get; set; }
    public Transform Player { get; set; }
    private ControleJogador2 controleJogador;

    private void Start()
    {
        controleJogador = FindObjectOfType<ControleJogador2>(); // Não é necessário usar o namespace aqui
    }

    private void Update()
    {
        // Move o objeto para baixo com base na velocidade de queda
        transform.Translate(Vector2.down * VelocidadeDeQueda * Time.deltaTime);

        // Verifica se o objeto saiu da tela e o destrói
        if (transform.position.y < -18f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o objeto colidiu com o jogador
        if (other.CompareTag("Player"))
        {
            // Chama o método de morte do jogador
            controleJogador.Morte();

            // Muda para a cena de Game Over
            UnityEngine.SceneManagement.SceneManager.LoadScene("TelaDeFim2");
        }
    }
}
