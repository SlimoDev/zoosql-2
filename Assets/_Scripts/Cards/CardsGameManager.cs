using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsGameManager : MonoBehaviour
{
    [SerializeField] private int maxQuestions = 10;
    [SerializeField] private List<Cards> m_cards;
    [SerializeField] private List<string> currentCardWords;

    private int difficulty = 0;

    public event System.Action<List<string>> OnCardSelected;

    public static CardsGameManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        difficulty = 0;
        StartGame();
    }

    public Cards GetCurrentCards() => m_cards[difficulty];

    public void StartGame()
    {
        int randomCardNum = Random.Range(0, m_cards[difficulty].CardsList.Count);
        string randomCard = m_cards[difficulty].CardsList[randomCardNum];

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
}
