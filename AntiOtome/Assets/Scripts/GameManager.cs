using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    // -1 = aún no elegido, 1 = Personaje 1, 2 = Personaje 2
    public int PersonajeElegido { get; private set; } = -1;

    [Header("Sprites del protagonista")]
    public Sprite spritePersonaje1;
    public Sprite spritePersonaje2;
    private int contaNo; 

    void Awake()
    {
        contaNo=6; 
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject); // sobrevive al cambio de escena
    }

    public void ElegirPersonaje(int numero)
    {
        PersonajeElegido = numero;
    }

    public Sprite GetSpriteElegido()
    {
        return PersonajeElegido == 1 ? spritePersonaje1 : spritePersonaje2;
    }

    public int getContaNo()
    {
        return contaNo; 
    }

    public void setContaNO()
    {
        contaNo--; 
    }

    public void restartContaNo()
    {
        contaNo = 6; 
    }
}