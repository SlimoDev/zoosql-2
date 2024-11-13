using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cards", menuName = "ScriptableObjects/Cards", order = 1)]
public class Cards : ScriptableObject
{
    [SerializeField] private int minRandomWords;
    [SerializeField] private int maxRandomWords;
    [SerializeField] private TipoPregunta quizType;
    [TextArea]
    [SerializeField] private List<string> cards;
    [SerializeField] private List<string> texto_cards;
    [SerializeField] private List<string> randomWords;

    public int MinRandomWords => minRandomWords;
    public int MaxRandomWords => maxRandomWords;
    public TipoPregunta QuizType => quizType;
    public List<string> CardsList => cards;

    public List<string> TextoCards => texto_cards;
    public List<string> RandomWords => randomWords;
}
