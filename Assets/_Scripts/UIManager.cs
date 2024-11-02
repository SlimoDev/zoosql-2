using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //set privado get publico


    public QuizUI QuizUI;



    //Se llama cuando un objeto es cargado en memoria, se ejecuta cuando esta cargando el juego
    private void Awake()
    {
        QuizUI = FindObjectOfType<QuizUI>();
    }

    public void MostrarPregunta(PreguntaSO pregunta)
    {
        QuizUI.Init();
        QuizUI.MostrarPregunta(pregunta);
    }



}
