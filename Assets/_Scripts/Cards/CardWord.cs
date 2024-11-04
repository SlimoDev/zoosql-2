using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class CardWord : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Image background;
    public static int incorrectCards;
    
    void Start()
    {
        incorrectCards = 0;
    }
    public void Show()
    {
        canvasGroup.alpha = 1;
    }

    public void SetCorrect(bool correct)
    {
        if (correct)
        { 
            background.color = Color.green;
        }
        else
        {
            background.color = Color.red;
            incorrectCards++;
        }
    }

    public void SetWord(string word)
    {
        text.text = word;
    }

    public string GetWord()
    {
        return text.text;
    }

    public void Hide()
    {
        canvasGroup.alpha = 0;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Hide();
        DragCard.Instance.OnBeginDrag(transform.position, text.text);
    }

    public void OnDrag(PointerEventData eventData)
    {
        DragCard.Instance.OnDrag(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Show();
        DragCard.Instance.OnEndDrag();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.name.Contains("_tray") && gameObject.name.Contains("_display"))
        {
            transform.parent.GetComponent<CardsWordDisplayUI>().ReturnWord(eventData.pointerDrag);
            return;
        }

        if (!gameObject.name.Contains("_tray")) return;

        if (eventData.pointerDrag.name.Contains("_tray"))
        {
            int thisIndex = transform.GetSiblingIndex();
            int dropIndex = eventData.pointerDrag.transform.GetSiblingIndex();
            transform.SetSiblingIndex(dropIndex);
            eventData.pointerDrag.transform.SetSiblingIndex(thisIndex);
        }
        else if (eventData.pointerDrag.name.Contains("_display"))
        {
            transform.parent.GetComponent<WordsTray>().AddWord(eventData.pointerDrag);
        }
    }
}
