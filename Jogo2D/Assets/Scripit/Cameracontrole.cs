using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontrole : MonoBehaviour
{
    [SerializeField] private Transform Player;
   
    private void Update()
    {
        transform.position = new Vector3(Player.position.x, Player.position.y + 5, transform.position.z);
    }
    
}
