using UnityEngine;

public class OpcionesBoton : MonoBehaviour
{
    // Start is called before the first frame update
    public Dificultad EleccionDificultad;
    public Tema tema;

    public void SetDificultad()
    {
        DataManager.Instance.Dificultad = EleccionDificultad;
    }

    public void SetTema()
    {
        DataManager.Instance.Tema = tema;
        if (tema == Tema.Algebra)
            PlayerPrefs.SetString("currentGameType", GameType.QuizGame.ToString());
        else if (tema == Tema.Plsql)
            PlayerPrefs.SetString("currentGameType", GameType.CardsGame.ToString());
    }
}
