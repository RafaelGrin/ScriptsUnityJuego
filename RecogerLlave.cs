using UnityEngine;

public class RecogerLlave : MonoBehaviour
{
    public float distanciaInteraccion = 3.0f; // Distancia máxima para interactuar con la llave.
    private GameObject llaveRecogida;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Raycast para detectar objetos en frente del jugador.
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, distanciaInteraccion))
            {
                if (hit.collider.CompareTag("Llave"))
                {
                    // El objeto que hemos alcanzado es la llave.
                    RecogerLlave(hit.collider.gameObject);
                }
            }
        }
    }

    void RecogerLlave(GameObject llave)
    {
        // Realizar acciones para recoger la llave, por ejemplo, desactivarla.
        llaveRecogida = llave;
        llaveRecogida.SetActive(false);
        Debug.Log("¡Felicitaciones por recoger la llave");
    }
}
