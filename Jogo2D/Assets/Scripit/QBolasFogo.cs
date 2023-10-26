using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Importe o namespace TMPro
using UnityEngine.UI;

public class QBolasFogo : MonoBehaviour
{
    private int bolasFogo = 30; // Campo privado para armazenar a quantidade de bolas de fogo
    [SerializeField] private TMP_Text QFogoText;


    public int BolasFogo // Propriedade para acessar a quantidade de bolas de fogo
    {
        get { return bolasFogo; }
        set { bolasFogo = value; }
    }

   public void AtualizarTexto()
    {
        if (QFogoText != null)
        {
            QFogoText.text = BolasFogo.ToString(); // Apenas exibe o número de bolas de fogo
        }
    }

    public void AdicionarBolaDeFogo()
    {
        Debug.Log("Bolas de Fogo: " + BolasFogo);
        BolasFogo++;
    }
}
