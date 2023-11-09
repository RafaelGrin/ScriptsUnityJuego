using UnityEngine;

public class Player : MonoBehaviour
{
    // Declaración de un evento para notificar cuando se recoge una llave
    public delegate void LlaveRecogidaEventHandler(string nombreLlave);
    public static event LlaveRecogidaEventHandler OnLlaveRecogida;

    private void Update()
    {
        // Detecta si el jugador presiona la tecla "E"
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Realiza un raycast hacia adelante desde la posición del jugador
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            // Determina si el rayo colisiona con un objeto
            if (Physics.Raycast(ray, out hit, 2.0f))
            {
                // Verifica si el objeto tiene una etiqueta de "Llave" y recoge la llave
                if (hit.collider.CompareTag("Llave"))
                {
                    // Desactiva el objeto de la llave
                    hit.collider.gameObject.SetActive(false);

                    // Notifica que se ha recogido la llave con su nombre
                    OnLlaveRecogida?.Invoke(hit.collider.gameObject.name);

                  if (coinGrabSound != null)
                    {
                        audioSource.PlayOneShot(coinGrabSound);
                    }



                }
            }
        }
    }
}
