using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardsWordDisplayUI : MonoBehaviour, IDropHandler
{
    [SerializeField] private CardWord wordPrefab;

    private void Start()
    {
        CardsGameManager.Instance.OnCardSelected += OnCardSelected;
    }

    private List<string> GetRandomWords()
    {
        Cards cards = CardsGameManager.Instance.GetCurrentCards();

        int maxRandomWords = cards.MaxRandomWords < cards.MinRandomWords ? cards.MinRandomWords : cards.MaxRandomWords;

        int randomWordsCount = Random.Range(cards.MinRandomWords, maxRandomWords + 1);
        if (randomWordsCount > cards.RandomWords.Count)
            randomWordsCount = cards.RandomWords.Count;

        List<string> randomWordsOptions = new(cards.RandomWords);
        List<string> randomWordsSelection = new();
        
        for (int i = 0; i < randomWordsCount; i++)
        {
            int randomIndex = Random.Range(0, randomWordsOptions.Count);
            randomWordsSelection.Add(randomWordsOptions[randomIndex]);
            randomWordsOptions.RemoveAt(randomIndex);
        }

        return randomWordsSelection;
    }

    private void OnCardSelected(List<string> words)
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        List<string> copy = new(words);

        copy.AddRange(GetRandomWords());

        System.Random rng = new();
        int n = copy.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            (copy[n], copy[k]) = (copy[k], copy[n]);
        }
        int i = 1;
        foreach (string word in copy)
        {
            
            CardWord wordObj = Instantiate(wordPrefab, Vector3.zero, Quaternion.identity, transform);
            wordObj.SetWord(word);
            wordObj.name = $"{word}{i}_display";
            i++;
        }
    }

    public void ReturnWord(GameObject returnedWord)
    {
        Debug.Log("Tray to display");
        string word = returnedWord.name.Replace("_tray", "");

        foreach (Transform child in transform)
        {
            if (child.name.Contains(word))
            {
                child.GetComponent<CardWord>().Show();
                Destroy(returnedWord);
                DragCard.Instance.OnEndDrag();
                break;
            }
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.name.Contains("_tray"))
        {
           ReturnWord(eventData.pointerDrag);
        }
    }
}
