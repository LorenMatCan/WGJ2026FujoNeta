using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour 
{
    public static MusicManager Instance { get; private set; }
    public MusicManager musicManager;
    public AudioSource  audSource;
    public AudioClip[] ost;
    public float volumen; 


     private void Awake()
    {
         if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayMusic(int id)
    {
        audSource.clip = ost[id];
        audSource.Play();
    }

     private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Menu inicial")
        {
            PlayMusic(0); 
        }
        if (scene.name == "NIvel2")
        {
            PlayMusic(1); 
        }
        if (scene.name == "Nivel3")
        {
            PlayMusic(2); 
        }
        if (scene.name == "Final")
        {
            PlayMusic(3); 
        }

    }

}
