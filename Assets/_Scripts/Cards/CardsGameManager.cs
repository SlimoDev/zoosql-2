using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardsGameManager : MonoBehaviour
{
    [SerializeField] private int maxQuestions = 10;
    public List<Cards> m_cards;
    public GameObject texto_cards;
    [SerializeField] private List<Cards> m_cardsAlgebraLinear;
    [SerializeField] private List<Cards> m_cardsDmliql;
    [SerializeField] private List<Cards> m_cardsPlsql;
    [SerializeField] private List<string> currentCardWords;

    public static int difficulty;

    public event System.Action<List<string>> OnCardSelected;

    public static CardsGameManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private IEnumerator Start()
    {
        difficulty = 0;
        yield return new WaitForEndOfFrame();
        SetTemaYDificultad(DataManager.Instance.Tema, DataManager.Instance.Dificultad);
        
        StartGame();
    }

    public Cards GetCurrentCards() => m_cards[difficulty];

    public void StartGame()
    {
        int randomCardNum = Random.Range(0, m_cards[difficulty].CardsList.Count);
        string randomCard = m_cards[difficulty].CardsList[randomCardNum];
        texto_cards.GetComponent<Text>().text = m_cards[difficulty].TextoCards[randomCardNum].ToString();

        currentCardWords = new List<string>(randomCard.Split(' '));
        OnCardSelected?.Invoke(currentCardWords);
    }

    public List<int> CheckAnswer(List<string> answer)
    {
        List<int> incorrect = new();

        for (int i = 0; i < answer.Count; i++)
        {
            if (i >= currentCardWords.Count)
                incorrect.Add(i);
            else if (answer[i] != currentCardWords[i])
                incorrect.Add(i);
        }

        return incorrect;
    }
    public void SetTemaYDificultad(Tema tema, Dificultad dificultad)
    {
        m_cards = tema switch
        {
            Tema.Algebra => m_cardsAlgebraLinear,
            Tema.Plsql => m_cardsPlsql,
            Tema.DMLDQL => m_cardsDmliql,
            _ => new List<Cards>()  // En caso de que no haya coincidencia, devuelve una lista vacía.
        };

        difficulty = dificultad switch
        {
            Dificultad.Facil => 0,
            Dificultad.Intermedio => 1,
            Dificultad.Dificil => 2,
            _ => 0  // En caso de que no haya coincidencia, devuelve la dificultad fácil.
        };
    }

}
