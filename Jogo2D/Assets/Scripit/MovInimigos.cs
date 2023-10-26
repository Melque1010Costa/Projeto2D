using UnityEngine;

public class MovInimigos : MonoBehaviour
{
    private Vector3 posicaoInicial;
    private GameObject player;
    private Animator anime;
    private int direction;
    private int Life = 3;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        direction = 1;
        anime = GetComponent<Animator>();
        posicaoInicial = transform.position;
        Life = 3; // Inicialize a vida com 3
    }

    // Update is called once per frame
    void Update()
    {
        // Move o inimigo na direção atual independentemente da distância
        transform.Translate(0.01f * direction, 0.0f, 0.0f);

        // Vira o inimigo quando necessário
        if (Mathf.Abs(transform.position.x - posicaoInicial.x) > 2)
        {
            direction *= -1;
            transform.localScale = new Vector3(direction, 1f, 1f);
        }

        anime.SetInteger("Distance", 0); // Define a distância como 0, ou outra lógica conforme necessário
    }

    public void ReceberDano(int dano)
    {
        Life -= dano;

        // Se os pontos de vida chegarem a zero ou menos, o inimigo é destruído
        if (Life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
