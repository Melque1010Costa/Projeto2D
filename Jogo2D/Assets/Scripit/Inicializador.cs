using UnityEngine;

public class Inicializador : MonoBehaviour
{
    private void Awake()
    {
        BolasDeFogoGerenciado.instance = FindObjectOfType<BolasDeFogoGerenciado>();
    }
}
