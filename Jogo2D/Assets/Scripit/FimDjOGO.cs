using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FimDjOGO : MonoBehaviour
{
     private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.CompareTag("Chegada"))
        {
            
           
            Debug.Log("Você Ganhou: ");
            SceneManager.LoadScene("TelaWin");
            
            
        }
      
    }
}
