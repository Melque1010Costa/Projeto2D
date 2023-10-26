using UnityEngine;

public class Habilidades : MonoBehaviour
{
    private bool isAttacking = false;
    private bool isBlocking = false;
    private Animator anime;
    public float raioDeAtaque = 1.5f; // Raio da área de ataque, ajuste conforme necessário

    private void Start()
    {
        anime = GetComponent<Animator>();
    }

    void Update()
    {
        // Inicia o ataque ao clicar no mouse
        if (Input.GetMouseButtonDown(0) && !isAttacking)
        {
            isAttacking = true;
            anime.SetBool("Ataque", true);
            Invoke("StopAttack", 0.1f); // Desativa o ataque após 0.1 segundos (ajuste conforme necessário)
            
        }

        // Defende ao pressionar 'q'
        if (Input.GetKeyDown(KeyCode.Q) && !isBlocking)
        {
            isBlocking = true;
            anime.SetBool("Def", true);
            Invoke("StopDefend", 0.3f); // Desativa a defesa após 0.3 segundos (ajuste conforme necessário)
        }
    }

    void StopAttack()
    {
        isAttacking = false;
        anime.SetBool("Ataque", false);
    }

    void StopDefend()
    {
        isBlocking = false;
        anime.SetBool("Def", false);
    }

    
        }
