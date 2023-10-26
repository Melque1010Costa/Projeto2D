using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{   
    private int Baus = 0;
    
    [SerializeField] private TMP_Text QbauText;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bau"))
        {
            Destroy(collision.gameObject);
            Baus++;
            Debug.Log("Baus: " + Baus);
            
            // Verifique se QcoinsText não é nulo antes de acessá-lo
            if(QbauText != null)
            {
                QbauText.text = "Baus: " + Baus; // Adicione um espaço após "Baus" para separar o número
            }
            else
            {
                Debug.LogError("QbauText is not assigned in the Inspector!");
            }
        }
    }
}
