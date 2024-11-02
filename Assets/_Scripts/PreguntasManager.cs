using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PreguntasManager : MonoBehaviour
{

    public List<ListPreguntasSO> ListaPreguntasPlSQL;
    public List<ListPreguntasSO> ListaPreguntasAlgebra;
    public int PreguntasRonda = 10;
    public static PreguntasManager Instance { private set; get; }

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

    private List<PreguntaSO> GetPreguntaAleatoria(Dificultad dificultad, List<ListPreguntasSO> ListarPreguntas) 
    {
  
        List<PreguntaSO> PreguntasDificultad = new List<PreguntaSO>();

        foreach (ListPreguntasSO ListaPregunta in ListarPreguntas) {

            foreach (PreguntaSO Pregunta in ListaPregunta.BancoPreguntas)
            {
                if(Pregunta.dificultad == dificultad)
                {
                    PreguntasDificultad.Add(Pregunta);
                }
            }
        }

        return PreguntasDificultad;
    }


    //Tipo Variable // Nombre Variable
    public List<PreguntaSO> ElegirTema(Dificultad dificultad,Tema tema)
    {
        List<ListPreguntasSO> ListaPreguntas = tema == Tema.Algebra ? ListaPreguntasAlgebra : ListaPreguntasPlSQL;

        List<PreguntaSO> PreguntaSO = GetPreguntaAleatoria(dificultad, ListaPreguntas);


        List<PreguntaSO> preguntas = new List<PreguntaSO>();


        for (int i = 0; i<PreguntasRonda; i++)
        {
            int random = Random.Range(0, PreguntaSO.Count);
            preguntas.Add(PreguntaSO[random]);

            
            PreguntaSO.RemoveAt(random);
         

        }
        
        return preguntas;
    }

}

