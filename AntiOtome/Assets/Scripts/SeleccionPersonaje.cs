using UnityEngine;

public class SeleccionPersonaje : MonoBehaviour
{
    public GameObject canvasSeleccion;  // pantalla donde se elige
    public GameObject canvasJuego;      // pantalla donde empiezan las decisiones

    // Botón Hombre -> ElegirPersonaje(1)
    // Botón Mujer  -> ElegirPersonaje(2)
    public void ElegirPersonaje(int numero)
    {
        GameManager.Instance.ElegirPersonaje(numero);

        canvasSeleccion.SetActive(false);
        canvasJuego.SetActive(true);
    }
}