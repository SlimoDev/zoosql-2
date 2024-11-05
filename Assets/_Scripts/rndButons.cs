using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rndButons : MonoBehaviour
{
    public void ChangeScene2(string name)
    {
        Debug.Log("Cargando escena " + name);
        SceneManager.LoadScene(name);
    }
}
