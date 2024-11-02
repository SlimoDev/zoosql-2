using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelMenu : MonoBehaviour
{
    public void Start()
    {
        this.gameObject.SetActive(false);

        //string levelName = "Scene" + levelId;
        //SceneManager.LoadScene(levelName);
    } 

    public void ActivarPantalla()
    {
        this.gameObject.SetActive(true);

    }

}
