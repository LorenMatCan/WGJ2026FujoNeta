using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using System; 
using UnityEngine.UI; 

public class TextHandler : MonoBehaviour
{
    public TextMeshProUGUI textComponent; 
    public string line;
    public float textSpeed;

    void Start()
    {
        textComponent.text = string.Empty; 
        StartDialogue(); 
    }

     public void StartDialogue()
    {
        StartCoroutine(TypeLine()); 
    }
    
    IEnumerator TypeLine()
    {
        foreach (char c in line.ToCharArray())
        {
            textComponent.text +=c; 
            yield return new WaitForSeconds(textSpeed); 
        }
        yield return new WaitForSeconds(0.2f);  
    }
}
