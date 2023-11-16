using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float distanciaInteraccion = 0.5f;
    public KeyCode teclaInteraccion = KeyCode.E;

    void Update()
    {
        if (Input.GetKeyDown(teclaInteraccion))
        {
            InteractuarConObjeto();
        }
    }

    void InteractuarConObjeto()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, distanciaInteraccion);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Objeto1"))
            {
                EliminarObjeto1Y2();
                break; // Termina el bucle una vez que se eliminen los objetos
            }
        }
    }

    void EliminarObjeto1Y2()
    {
        GameObject objeto1 = GameObject.FindGameObjectWithTag("Objeto1");
        GameObject objeto2 = GameObject.FindGameObjectWithTag("Objeto2");

        if (objeto1 != null)
        {
            Destroy(objeto1);
        }

        if (objeto2 != null)
        {
            Destroy(objeto2);
        }
    }
}