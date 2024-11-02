using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragCard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI word;
    public static DragCard Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }

    public void OnBeginDrag(Vector3 position, string text)
    {
        transform.position = position;
        word.text = text;
        gameObject.SetActive(true);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag()
    {
        gameObject.SetActive(false);
    }
}
