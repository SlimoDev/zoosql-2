using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizUI : MonoBehaviour
{
    
    [SerializeField] private Text m_question;
    [SerializeField] private Image m_image;
    [SerializeField] private List<Button> m_buttonList;

    
    private void Awake()
    {
    }
    
    public void Start()
    {
        Init();
    }
    
    public void Init()
    {
        m_question = GameObject.Find("TextQuestion").GetComponent<Text>();
    }

    public void MostrarPregunta(PreguntaSO pregunta)
    {
        m_question.text = pregunta.text_pregunta;

        if (pregunta.spr_pregunta != null)
        {
            m_image.sprite = pregunta.spr_pregunta;
            m_image.gameObject.SetActive(true); // Muestra la imagen si existe
        }
        else
        {
            m_image.gameObject.SetActive(false); // Oculta el componente de imagen si no hay imagen
        }

        for (int i = 0; i < m_buttonList.Capacity; i++)
        {
            m_buttonList[i].GetComponentInChildren<Text>().text = pregunta.text_alternativas[i].text_alternativa;
        }
    }



}
