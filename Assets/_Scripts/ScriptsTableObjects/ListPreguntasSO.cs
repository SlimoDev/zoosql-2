using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevaListaPregunta", menuName = "ListaTipoPregunta")]
public class ListPreguntasSO : ScriptableObject
{

    public List<PreguntaSO> BancoPreguntas;
    public Dificultad dificultad;
}
