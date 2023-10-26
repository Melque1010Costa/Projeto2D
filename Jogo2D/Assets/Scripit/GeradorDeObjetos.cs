using UnityEngine;

public class GeradorDeObjetos : MonoBehaviour
{
    public GameObject objetoPrefab;
    public Transform player;
    public float taxaDeGeracao = 1f; // Taxa de geração em objetos por segundo
    public float intervaloDeGeracao = 1f; // Intervalo de tempo entre gerações em segundos
    public float velocidadeDeQueda = 20f;

    private float proximoTempoDeGeracao;

    private void Update()
    {
        // Lógica para gerar objetos aqui
        if (Time.time >= proximoTempoDeGeracao)
        {
            GerarObjeto();
            proximoTempoDeGeracao = Time.time + intervaloDeGeracao;
        }
    }

    void GerarObjeto()
    {
        // Obtém a escala do quad no eixo Y
        float alturaDoQuad = transform.localScale.y;

        // Calcula uma posição X aleatória dentro da largura do quad
        float metadeDaLargura = transform.localScale.x / 2f;
        float posicaoX = Random.Range(-metadeDaLargura, metadeDaLargura);

        // Calcula uma posição Y acima do topo do quad para que os objetos caiam de cima para baixo
        float posicaoY = transform.position.y + alturaDoQuad / 2f + 1f; // Adiciona 1 unidade extra para garantir que os objetos estejam fora do quad

        // Instancia o objeto e define sua posição inicial
        GameObject novoObjeto = Instantiate(objetoPrefab, new Vector2(posicaoX, posicaoY), Quaternion.identity);

        // Obtém a referência ao script de movimento do objeto
        MovimentoObjeto movimentoObjeto = novoObjeto.GetComponent<MovimentoObjeto>();

        // Define a velocidade de queda do objeto
        movimentoObjeto.VelocidadeDeQueda = velocidadeDeQueda;

        // Define o jogador como alvo do objeto
        movimentoObjeto.Player = player;
    }
}
