using UnityEngine;

public class BolaDeFogo : MonoBehaviour
{
    public float speed = 30f;
    public float delayBeforeDestroy = 2f;

    private Vector2 moveDirection;

    private void Start()
    {   
        Destroy(gameObject, delayBeforeDestroy);
        // Determina a direção inicial com base na orientação do sprite
        moveDirection = transform.right; // Inicialmente, a bola de fogo se move para a direita
        if (GetComponent<SpriteRenderer>().flipX)
        {
            // Se o sprite estiver virado para a esquerda, inverte a direção
            moveDirection = -transform.right;
        }
    }

    private void Update()
    {
        // Move a bola de fogo na direção determinada
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Inimigo"))
        {
            DestruirBolaDeFogo();
            DestruirInimigo(collision.gameObject);
        }
    }

    private void DestruirBolaDeFogo()
    {
        Destroy(gameObject);
    }

    private void DestruirInimigo(GameObject inimigo)
    {
        Destroy(inimigo);
    }
}

