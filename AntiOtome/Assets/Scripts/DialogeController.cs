using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using System; 



public class DialogeController : MonoBehaviour 
{
    public TextMeshProUGUI textComponent; 
    public string[] lines; 
    public float textSpeed;
    private int index;

    public LevelController lc; 
    public event EventHandler TerminoMensaje; 

    // Start is called before the first frame update
    void Start()
    {
        lc.ReiniciarMensaje += NextLine; 
        textComponent.text = string.Empty; 
        StartDialogue(); 
        index = 0;
    }


    public void NextLine(object sender, EventArgs e)
    {
        textComponent.text = string.Empty; 
        index++; 
        textComponent.text = string.Empty; 
        StartDialogue(); 
    }

    public void StartDialogue()
    {
        StartCoroutine(TypeLine()); 
    }


    
    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text +=c; 
            yield return new WaitForSeconds(textSpeed); 
        }
        yield return new WaitForSeconds(0.2f);  
        TerminoMensaje?.Invoke(this, EventArgs.Empty);
    }

}
