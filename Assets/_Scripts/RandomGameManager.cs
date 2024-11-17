using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGameManager : MonoBehaviour
{
    public GameObject algebraGM;
    public GameObject cardsGM;
    public static int rndGame;

    void Update()
    {
        GameSelector(rndGame);
    }
    public static void RandomMinigame()
    {
        if (DataManager.Instance.Tema == Tema.Plsql)
        {
            rndGame = 0;
        }
        else
        {
            rndGame = Random.Range(0, 2);
        }
        Debug.Log("JUEGO: " + rndGame);
    }
    public void GameSelector(int index)
    {
        if(index == 0) //Se muestra el juego de algebra y se esconde el cards
        {
            algebraGM.SetActive(true);
            cardsGM.SetActive(false);

        }
        else //Se muestra el juego de cards y se esconde el de algebra
        {
            algebraGM.SetActive(false);
            cardsGM.SetActive(true);
        }
    }
}
