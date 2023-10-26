using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ControleJogador : MonoBehaviour
{
    private Rigidbody2D rd;
    private BoxCollider2D chao;
    private Animator anime;
    private SpriteRenderer sprite;
    
    private bool jogadorMorto = false;
    


    [SerializeField] private LayerMask jumpableGround;
    public PiscinaBolasDeFogo piscinaBolasDeFogo;
    private QBolasFogo qBolasFogo;
    


    private float direcX = 0f;
    public GameObject qBolasFogoPrefab;
    private enum MovementState { Idle, Running, Jumping, Falling, Attacking }
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private float radiusAttack;
    [SerializeField] private LayerMask layerEnemy;
    [SerializeField] private float timeNextAttack;
    [SerializeField] private GameObject bolaDeFogoPrefab;

    private void Awake()
    {
        
        // Obtém a referência ao componente PiscinaBolasDeFogo no mesmo GameObject
        piscinaBolasDeFogo = GetComponent<PiscinaBolasDeFogo>();
        qBolasFogo = FindObjectOfType<QBolasFogo>(); 
        GameObject qbolasObj = Instantiate(qBolasFogoPrefab);
        DontDestroyOnLoad(qbolasObj);
        

        // Verifica se piscinaBolasDeFogo é null (não encontrado)
        if (piscinaBolasDeFogo == null)
        {
            Debug.LogError("Componente PiscinaBolasDeFogo não encontrado no mesmo GameObject!");
        }
    }
    private void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        chao = GetComponent<BoxCollider2D>();
        anime = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        
        
    }

    private void Update()
    {
        
        direcX = Input.GetAxisRaw("Horizontal");
        rd.velocity = new Vector2(direcX * moveSpeed, rd.velocity.y);
        if (Ehchao())
        {
            if (Input.GetButtonDown("Jump")||Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                rd.velocity = new Vector2(rd.velocity.x, jumpForce);
            }
        }
      

        UpdateAnimation();
    }
    


    private void UpdateAnimation()
    {
        MovementState estado = MovementState.Idle;

        if (direcX > 0f)
        {
            estado = MovementState.Running;
            sprite.flipX = false;
        }
        else if (direcX < 0f)
        {
            estado = MovementState.Running;
            sprite.flipX = true;
        }
        else{
            estado = MovementState.Idle;
        }
        if (rd.velocity.y > .1f)
        {
            estado = MovementState.Jumping;
        }
        else if (rd.velocity.y < -.1f)
        {
            estado = MovementState.Falling;
        }
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.K) && timeNextAttack <= 0)
            {
                anime.SetBool("Ataque", true);
                Atacar();
                timeNextAttack = 0.2f;
            }
        else
        {
            timeNextAttack -= Time.deltaTime;
                anime.SetBool("Ataque", false);
        }
        

        anime.SetInteger("estado", (int)estado);
    }
    private void Atacar()
    {
        if (qBolasFogo.BolasFogo > 0)
        {
            qBolasFogo.BolasFogo--; // Subtrai uma bola de fogo
            qBolasFogo.AtualizarTexto(); // Atualiza o texto na interface do usuário

            // Obtém uma bola de fogo da piscina e lança
            GameObject bolaDeFogo = piscinaBolasDeFogo.ObterBolaDeFogo();
            Rigidbody2D rbBolaDeFogo = bolaDeFogo.GetComponent<Rigidbody2D>();

            // Inverte o sprite da bola de fogo se o jogador estiver virado para a esquerda
            SpriteRenderer spriteBolaDeFogo = bolaDeFogo.GetComponent<SpriteRenderer>();
            spriteBolaDeFogo.flipX = sprite.flipX;

            // Calcula a direção da bola de fogo com base na orientação do jogador
            Vector2 direcaoDaBola = (sprite.flipX ? Vector2.left : Vector2.right);

            // Define a posição da bola de fogo para estar um pouco acima do centro do jogador
            Vector3 posicaoBolaDeFogo = transform.position;
            posicaoBolaDeFogo.y += -0.7f; // Ajuste o valor conforme necessário para a altura desejada
            bolaDeFogo.transform.position = posicaoBolaDeFogo;

            // Define a velocidade da bola de fogo na direção calculada
            rbBolaDeFogo.velocity = direcaoDaBola * moveSpeed;
        }
        else
        {
            // Se não houver bolas de fogo disponíveis, você pode mostrar uma mensagem ou executar outra lógica aqui
            Debug.Log("Sem bolas de fogo disponíveis!");
        }
    }

    
    


    
    public void Morte()
    {
        if (!jogadorMorto)
        {
            
            SceneManager.LoadScene("TelaDeFim");
        }
    }

   





    private bool Ehchao()
    {
        return Physics2D.BoxCast(chao.bounds.center, chao.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }
}
