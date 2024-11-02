using TMPro;
using UnityEngine;

public class DifficultyDisplayUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI difficultyLabel;
    [SerializeField] private TextMeshProUGUI topicLabel;

    private void Start()
    {
        difficultyLabel.text =  DataManager.Instance.Dificultad.ToString();
        topicLabel.text = DataManager.Instance.Tema.ToString();
    }
}
