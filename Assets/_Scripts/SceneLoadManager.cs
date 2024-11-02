
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    //set privado get publico
    public static SceneLoadManager Instance { private set; get; }
    //public bool pasarEscenas;
    //public string indiceEscenas;

    //Se llama cuando un objeto es cargado en memoria, se ejecuta cuando esta cargando el juego
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }

    }


    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }



}
