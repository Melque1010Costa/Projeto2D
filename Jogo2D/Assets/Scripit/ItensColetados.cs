using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Importe o namespace TMPro
using UnityEngine.UI;

public class ItensColetados : MonoBehaviour
{   

    private int coin = 0;
    
    [SerializeField] private TMP_Text QcoinsText;
    
    
    private void OnTriggerEnter2D(Collider2D collision)
{
    Debug.Log("Collision detected with: " + collision.gameObject.tag);

    if (collision.gameObject.CompareTag("Bau"))
    {
        Destroy(collision.gameObject);
        coin += 3;
        Debug.Log("Coin: " + coin);
        if(QcoinsText != null)
        {
            QcoinsText.text = "" + coin;
        }
    }

    if (collision.gameObject.CompareTag("Coin"))
    {
        Destroy(collision.gameObject);
        coin++;
        Debug.Log("Coin: " + coin);

        if(QcoinsText != null)
        {
            QcoinsText.text = "" + coin;
        }
        else
        {
            Debug.LogError("QcoinsText is not assigned in the Inspector!");
        }
    }
}

    }

   
