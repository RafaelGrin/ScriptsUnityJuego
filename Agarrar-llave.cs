using UnityEngine;
using UnityEngine.UI; // Importa el espacio de nombres para UI

public class Player : MonoBehaviour
{
    public delegate void LlaveRecogidaEventHandler(string nombreLlave);
    public static event LlaveRecogidaEventHandler OnLlaveRecogida;

    public Text mensajeText; // Asigna el objeto de texto en el Inspector

    private void Start()
    {
        // Asegúrate de que el mensaje de texto esté desactivado al principio
        mensajeText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 2.0f))
            {
                if (hit.collider.CompareTag("Llave"))
                {
                    hit.collider.gameObject.SetActive(false);
                    OnLlaveRecogida?.Invoke(hit.collider.gameObject.name);

                    // Muestra el mensaje en el objeto de texto
                    mensajeText.text = "Muy bien, has agarrado una llave";
                    mensajeText.gameObject.SetActive(true);

                    // Luego, puedes ocultar el mensaje después de un tiempo si lo deseas
                    StartCoroutine(OcultarMensaje(3.0f)); // Oculta el mensaje después de 3 segundos
                }
            }
        }
    }

    // Método para ocultar el mensaje después de un tiempo
    private IEnumerator OcultarMensaje(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        mensajeText.gameObject.SetActive(false);
    }
}
