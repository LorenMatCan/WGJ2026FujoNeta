using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using System; 


public class LevelController : MonoBehaviour
{
    public int contaNo;
    public Button botonSi, botonNo; 
    public Text textoContaNo; 
    public int[] puntos; 
    public int totalPreguntas; 
    [SerializeField]private int puntuacion; 
    private int id; 
    public DialogeController dc;
    public event EventHandler ReiniciarMensaje; 
    public GameObject img; 


    // Start is called before the first frame update
    void Start()
    {
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
        contaNo--; 
        textoContaNo.text =  "No:"+contaNo.ToString(); 
        PuedeSeguirJugando();  
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
        if(puntuacion <= 8)
        {
            Debug.Log("Nivel"); 
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
