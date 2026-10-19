using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicioController : MonoBehaviour
{
    public GameObject[] Textos; 
    private int index; 
    public GameObject canvaJuego;


    void Start()
    {
        index = 0; 
        PasarTexto(); 
    }


    void PasarTexto()
    {
        foreach (GameObject c in Textos)
        {
            c.SetActive(false); 
        }
        Textos[index].SetActive(true);
    }

    public void Avanzar()
    {
        index++; 
        if(index <  Textos.Length)
        {
            PasarTexto(); 
        }
        else{
            canvaJuego.SetActive(true); 
            Destroy(gameObject); 
        }
    }

    public void AvanzarFinal()
    {
        index++; 
        if(index <  Textos.Length)
        {
            PasarTexto(); 
        }
        else{
            canvaJuego.SetActive(true); 
        }
    }


}
