using UnityEngine;

public class PersonajeVisual : MonoBehaviour
{
    public GameObject assetMujer;  // el asset del personaje 1
    public GameObject assetHombre;   // el asset del personaje 2

    void OnEnable()
    {
        int elegido = GameManager.Instance.PersonajeElegido;

        assetMujer.SetActive(elegido == 1);
        assetHombre.SetActive(elegido == 2);
    }
}