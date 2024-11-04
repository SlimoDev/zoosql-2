using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultUI : MonoBehaviour
{
    public GameObject resultPanel;
    
    public List<TextMeshProUGUI> typeTexts;
    public List<TextMeshProUGUI> valueTexts;

    public GameObject gridGameObject;
    
    public GameObject prefabTMP_Type;
    public GameObject prefabTMP_Value;

    private Dictionary<string, int> totalQuestionTypeDictionary;
    private Dictionary<string, int> correctQuestionTypeDictionary;

    private void Awake()
    {
        totalQuestionTypeDictionary = new Dictionary<string, int>();
        correctQuestionTypeDictionary = new Dictionary<string, int>();
        
    }

    private void Start()
    {
        
    }
    
    public void OpenPanel()
    {
        resultPanel.SetActive(true);
        gridGameObject = GameObject.Find("Grid");
        ShowResults();
    }
    
    public void ClosePanel()
    {
        resultPanel.SetActive(false);
    }
    
    public void OnClickClose()
    {
        ClosePanel();
        if (GameManager2.Instance.isGameOver)
        {
            SceneManager.LoadScene("GameOverScene");
        }
        else
        {
            SceneManager.LoadScene("AlgebraGame");
            GameManager2.Instance.Awake();
            GameManager2.Instance.IniciarJuego();
        }
    }
    
    //Funcion que recorra por todo el enum TipoPregunta y muestre el tipo de pregunta y el valor de la pregunta en el UI
    public void ShowResults()
    {
        //
        // foreach (var question in GameManager2.Instance.questions)
        // {
        //     if (totalQuestionTypeDictionary.ContainsKey(question.tipoPregunta.ToString()))
        //     {
        //         totalQuestionTypeDictionary[question.tipoPregunta.ToString()]++;
        //     }
        //     else
        //     {
        //         totalQuestionTypeDictionary.Add(question.tipoPregunta.ToString(), 1);
        //     }
        // }


        for (int i = 0; i < 10; i++)
        {
            var question = GameManager2.Instance.correctQuestions[i];
            Debug.Log($"Indice de pregunta: {i}");
            Debug.Log($"Cantidad de preguntas: {GameManager2.Instance.questions.Count}");
            Debug.Log($"Pregunta {i + 1}: {question.text_pregunta}");
            
            
            if (totalQuestionTypeDictionary.ContainsKey(question.tipoPregunta.ToString()))
            {
                totalQuestionTypeDictionary[question.tipoPregunta.ToString()]++;
            }
            else
            {
                totalQuestionTypeDictionary.Add(question.tipoPregunta.ToString(), 1);
                
                var typeTMP = Instantiate(prefabTMP_Type, gridGameObject.transform);
                var valueTMP = Instantiate(prefabTMP_Value, gridGameObject.transform);
                
                typeTexts.Add(typeTMP.GetComponent<TextMeshProUGUI>());
                valueTexts.Add(valueTMP.GetComponent<TextMeshProUGUI>());
            }

            if (GameManager2.Instance.m_IsCorrectAnswer[i])
            {
                if (correctQuestionTypeDictionary.ContainsKey(question.tipoPregunta.ToString()))
                {
                    correctQuestionTypeDictionary[question.tipoPregunta.ToString()]++;
                }
                else
                {
                    correctQuestionTypeDictionary.Add(question.tipoPregunta.ToString(), 1);
                }
            }
        }
        
        for (var i = 0; i < typeTexts.Count; i++)
        {
            var currentTypeQuestionKey = totalQuestionTypeDictionary.ElementAt(i).Key;
            typeTexts[i].text = $"Tópico: {currentTypeQuestionKey}";
            // typeTexts[i].text = $"{currentTypeQuestionKey}";
            var totalAnswersByQuestionType = "";
            totalAnswersByQuestionType = totalQuestionTypeDictionary.ContainsKey(currentTypeQuestionKey) ? totalQuestionTypeDictionary[currentTypeQuestionKey].ToString() : "1";

            var correctAnswersByQuestionType = "";
            correctAnswersByQuestionType = correctQuestionTypeDictionary.ContainsKey(currentTypeQuestionKey) ? correctQuestionTypeDictionary[currentTypeQuestionKey].ToString() : "0";
            
            valueTexts[i].text = $"{correctAnswersByQuestionType}/{totalAnswersByQuestionType}";
        }
    }
}
