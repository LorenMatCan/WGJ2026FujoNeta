using UnityEngine;

public class BotonContinuar : MonoBehaviour
{
    public string escenaDestino;   // ej. "Level1", "Final1", "FinalMalo"

    public void Continuar()
    {
        FadeManager.Instance.IrAEscena(escenaDestino);
    }
}