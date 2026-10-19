using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using System; 
using UnityEngine.SceneManagement;


public class LevelController : MonoBehaviour
{
    private int contaNo = 1;
    private int contaNoTutorial = 1 ; 
    public Button botonSi, botonNo; 
    public Text textoContaNo; 
    public int[] puntos; 
    public int totalPreguntas; 
    private int puntuacion; 
    private int id; 
    public DialogeController dc;
    public event EventHandler ReiniciarMensaje; 
    public GameObject img; 
    [SerializeField] private String escenaDestino;    


    // Start is called before the first frame update
    void Start()
    {
        int? temp = GameManager.Instance?.getContaNo();
        if (temp == null || SceneManager.GetActiveScene().name == "Tutorial")
        {
            contaNo = 1;
        }
        else 
        {
            contaNo = temp.Value; 
        }
        textoContaNo.text =  "No:"+contaNo.ToString(); 
        id = 0; 
        DeshabilitarBotones(); 
        dc.TerminoMensaje+= HabilitarBotones;
    }



    public void HabilitarBotones(object sender, EventArgs e)
    {
        if(contaNo > 0){
            botonNo.interactable = true;
        }
        botonSi.interactable = true;
    }

    public void DeshabilitarBotones()
    {
        botonSi.interactable = false;
        botonNo.interactable = false;
    }

    public void PresionoSi(){

        DeshabilitarBotones(); 
        puntuacion+=puntos[id];
        PuedeSeguirJugando(); 
    }

    public void PresionoNo()
    {
        DeshabilitarBotones();
        GameManager.Instance.setContaNO(); 
        contaNo--; 
        textoContaNo.text =  "No:"+contaNo.ToString(); 
        PuedeSeguirJugando();  
    }

    public void PresionoSiTutorial(){

        DeshabilitarBotones(); 
        Ending(); 
    }

    public void PresionoNoTutorial()
    {
        DeshabilitarBotones(); 
        contaNoTutorial--; 
        textoContaNo.text =  "No:"+contaNoTutorial.ToString(); 
        FadeManager.Instance.IrAEscena(escenaDestino);
    }

    public void PuedeSeguirJugando()
    {
        
        if(id < totalPreguntas-1 )
        {
            id++;
            ReiniciarMensaje?.Invoke(this, EventArgs.Empty);
        }
        else{
            Proseguir(); 
        }
    }

    public void Proseguir()
    {
        if(puntuacion >= 8)
        {
            FadeManager.Instance.IrAEscena(escenaDestino);
        }
        else{
            
            Ending(); 
        }
    }

    private void Ending()
    {
        img.SetActive(true); 
    }
    void OnDestroy()
    {
        dc.TerminoMensaje-= HabilitarBotones; 
    }
}
