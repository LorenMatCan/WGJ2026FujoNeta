using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public string escenaTutorial = "Tutorial";

     void Start()
    {
        int? temp = GameManager.Instance?.getContaNo();
        if (temp != null)
        {
            GameManager.Instance.restartContaNo();
        }
    }

    public void Jugar()
    {
        if (FadeManager.Instance != null)
            FadeManager.Instance.IrAEscena(escenaTutorial);
        else
            SceneManager.LoadScene(escenaTutorial); 
    }

    public void Salir()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}