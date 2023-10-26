using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolasDeFogoGerenciado : MonoBehaviour
{
    public GameObject bolaDeFogoPrefab;
    public int quantidadeInicial = 30;
    public static BolasDeFogoGerenciado instance;

    private List<GameObject> bolasDeFogo;

    private void Start()
    {
        bolasDeFogo = new List<GameObject>();
        instance = this;

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

    public void DestruirTodasBolasDeFogo()
    {
        foreach (var bolaDeFogo in bolasDeFogo)
        {
            if (bolaDeFogo != null && bolaDeFogo.activeInHierarchy)
            {
                bolaDeFogo.SetActive(false);
                Destroy(bolaDeFogo);
            }
        }
    }

    public void RecriarBolasDeFogo()
    {
        DestruirTodasBolasDeFogo(); // Primeiro, destruímos todas as bolas existentes

        // Em seguida, recriamos a quantidade inicial de bolas de fogo
        for (int i = 0; i < quantidadeInicial; i++)
        {
            CriarNovaBolaDeFogo();
        }
    }
}