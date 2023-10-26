using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Vitoria : MonoBehaviour
{
    public GameObject geradorDeObjetos; // Referência ao objeto do gerador de objetos

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Chegada"))
        {
            Debug.Log("Você Ganhou: ");
            SceneManager.LoadScene("Fase2");

            // Ativa o gerador de objetos quando o jogador chega à Fase 2
            if (geradorDeObjetos != null)
            {
                geradorDeObjetos.SetActive(true);
            }
        }
    }
}
