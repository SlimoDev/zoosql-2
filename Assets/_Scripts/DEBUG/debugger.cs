using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class debugger : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            SceneManager.LoadScene("AlgebraGame");
        }
    }
}
