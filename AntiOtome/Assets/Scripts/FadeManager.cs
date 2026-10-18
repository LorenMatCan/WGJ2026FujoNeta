using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    public static FadeManager Instance { get; private set; }

    public float duracion = 0.8f;

    CanvasGroup grupo;
    bool cambiando;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        CrearPantallaNegra();
    }

    void CrearPantallaNegra()
    {
        // Canvas que cubre toda la pantalla, por encima de todo
        Canvas canvas = gameObject.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.sortingOrder = 999;

        grupo = gameObject.AddComponent<CanvasGroup>();
        grupo.alpha = 0f;
        grupo.blocksRaycasts = false;

        GameObject fondo = new GameObject("PantallaNegra");
        fondo.transform.SetParent(transform, false);

        Image img = fondo.AddComponent<Image>();
        img.color = Color.black;

        RectTransform rt = img.rectTransform;
        rt.anchorMin = Vector2.zero;
        rt.anchorMax = Vector2.one;
        rt.offsetMin = Vector2.zero;
        rt.offsetMax = Vector2.zero;
    }

    // Úsalo para ir a otro nivel o a un final (por nombre de escena)
    public void IrAEscena(string nombreEscena)
    {
        if (!cambiando)
            StartCoroutine(Transicion(nombreEscena));
    }

    IEnumerator Transicion(string nombreEscena)
    {
        cambiando = true;
        grupo.blocksRaycasts = true; // evita clics mientras se oscurece

        yield return Fade(0f, 1f);                 // fade out (a negro)

        AsyncOperation carga = SceneManager.LoadSceneAsync(nombreEscena);
        while (!carga.isDone)
            yield return null;

        yield return Fade(1f, 0f);                 // fade in (aparece la nueva escena)

        grupo.blocksRaycasts = false;
        cambiando = false;
    }

    IEnumerator Fade(float desde, float hasta)
    {
        float t = 0f;
        while (t < duracion)
        {
            t += Time.unscaledDeltaTime;
            grupo.alpha = Mathf.Lerp(desde, hasta, t / duracion);
            yield return null;
        }
        grupo.alpha = hasta;
    }
}