using UnityEngine;

public class PerseguirJugador : MonoBehaviour
{
    public Transform jugador; // Arrastra el objeto First Person Controller al Inspector
    public float velocidadPersecucion = 5.0f;

    void Update()
    {
        if (jugador != null)
        {
            // Calcula la dirección desde la pelota hacia el jugador.
            Vector3 direccion = jugador.position - transform.position;

            // Normaliza la dirección para obtener una velocidad constante.
            direccion.Normalize();

            // Mueve la pelota en la dirección del jugador con la velocidad de persecución.
            transform.Translate(direccion * velocidadPersecucion * Time.deltaTime);
        }
    }
}
