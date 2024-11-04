using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WordsTray : MonoBehaviour, IDropHandler
{
    [SerializeField] private GameObject restartBtn;

    private void Start()
    {
        CardsGameManager.Instance.OnCardSelected += OnCardSelected;
    }

    private void OnCardSelected(List<string> _)
    {
        restartBtn.SetActive(false);
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.name.Contains("_display"))
        {
            AddWord(eventData.pointerDrag);
        }
    }

    public void AddWord(GameObject word)
    {
        StartCoroutine(AddNewWord(word));
    }

    private IEnumerator AddNewWord(GameObject word)
    {
        yield return new WaitForEndOfFrame();

        CardWord draggedCardWord = word.GetComponent<CardWord>();
        draggedCardWord.Hide();

        CardWord newWord = Instantiate(draggedCardWord, Vector3.zero, Quaternion.identity, transform);
        newWord.name = word.name.Replace("_display", "_tray");
        newWord.Show();
    }

    public void CheckAnswer()
    {
        List<string> words = new();

        foreach (Transform child in transform)
        {
           words.Add(child.name.Replace("_tray", ""));
        }

        List<int> incorrect = CardsGameManager.Instance.CheckAnswer(words);

        foreach (int index in incorrect)
        {
            transform.GetChild(index).GetComponent<CardWord>().SetCorrect(false);
            
        }

        restartBtn.SetActive(true);
    }
}
