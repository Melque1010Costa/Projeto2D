using UnityEngine;

public class MovimentoHorizontal : MonoBehaviour
{
    public float velocidadeHorizontal = 5f;

    void Update()
    {
        // Move o objeto na direção horizontal
        transform.Translate(Vector2.right * velocidadeHorizontal * Time.deltaTime);

        // Obtém a largura da tela em unidades do mundo (coordenadas)
        float larguraTela = Camera.main.orthographicSize * 2f * Camera.main.aspect;

        // Verifica se o objeto saiu da tela pelo lado direito e o destrói
        if (transform.position.x > larguraTela / 2f)
        {
            Destroy(gameObject);
        }
    }
}
