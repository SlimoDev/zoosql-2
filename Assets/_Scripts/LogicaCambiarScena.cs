using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicaCambiarScena : MonoBehaviour
{
    public bool pasarEscenas;
    public int indiceEscenas;


    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // 1 representa el botón derecho del mouse
        {
            CambiarNivel(indiceEscenas);
            Debug.Log("Cambiando a la escena con índice: " + indiceEscenas);
        }

        if (pasarEscenas)
        {
            CambiarNivel(indiceEscenas);
            Debug.Log("Cambiando a la escena con índice: " + indiceEscenas);
            pasarEscenas = false; // Resetear para evitar múltiples cambios
        }
    }

    public void CambiarNivel(int indice)
    {
        if (indice >= 0 && indice < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(indice);
        }
        else
        {
            Debug.LogError("Índice de escena fuera de rango: " + indice);
        }
    }
}


