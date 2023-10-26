using UnityEngine;

public class DestruirObjeto : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collider)
    {
        // Verifica se o objeto está em contato contínuo com o objeto de água
        if (collider.CompareTag("Agua"))
        {
            // Verifica se o objeto tem a tag "ObjetoCaindoClone"
            if (gameObject.CompareTag("ObjetoCaindoClone"))
            {
                // Destroi o objeto
                Destroy(gameObject);
            }
        }
    }
}
