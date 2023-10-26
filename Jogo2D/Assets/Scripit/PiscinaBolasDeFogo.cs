using System.Collections.Generic;
using UnityEngine;

public class PiscinaBolasDeFogo : MonoBehaviour
{
    public GameObject bolaDeFogoPrefab;
    public int quantidadeInicial = 30;
    public static PiscinaBolasDeFogo instance;

    private List<GameObject> bolasDeFogo;

    private void Awake()
    {
        instance = this;
        InicializarPiscina();
    }

    private void InicializarPiscina()
    {
        bolasDeFogo = new List<GameObject>();

        for (int i = 0; i < quantidadeInicial; i++)
        {
            CriarNovaBolaDeFogo();
        }
    }

    private GameObject CriarNovaBolaDeFogo()
    {
        GameObject bolaDeFogo = Instantiate(bolaDeFogoPrefab, transform);
        bolaDeFogo.SetActive(false);
        bolasDeFogo.Add(bolaDeFogo);
        return bolaDeFogo;
    }

    public GameObject ObterBolaDeFogo()
    {
        foreach (var bolaDeFogo in bolasDeFogo)
        {
            if (bolaDeFogo != null && !bolaDeFogo.activeInHierarchy)
            {
                bolaDeFogo.SetActive(true);
                return bolaDeFogo;
            }
        }

        // Se todas as bolas de fogo estiverem em uso, crie uma nova
        GameObject novaBolaDeFogo = CriarNovaBolaDeFogo();
        novaBolaDeFogo.SetActive(true);
        bolasDeFogo.Add(novaBolaDeFogo); // Adiciona a nova bola de fogo à lista
        return novaBolaDeFogo;
    }

   
    }

