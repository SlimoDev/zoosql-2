using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogos : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] lines;
    public float textSpeed = 0.05f;

    public Button clicDerechoButton; // Referencia al botón de clic derecho
    public Button clicIzquierdoButton; // Referencia al botón de clic izquierdo

    private int index;

    void Start()
    {
        dialogueText.text = string.Empty;
        clicIzquierdoButton.gameObject.SetActive(true);
        clicDerechoButton.gameObject.SetActive(false);
        StartDialogue();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (dialogueText.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = lines[index];
            }
        }
    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(WriteLine());
    }

    IEnumerator WriteLine()
    {
        foreach (char letter in lines[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine(WriteLine());
        }
        else
        {
            dialogueText.text = string.Empty;
            clicIzquierdoButton.gameObject.SetActive(false); // Ocultar el botón de clic derecho
            clicDerechoButton.gameObject.SetActive(true); // Mostrar el botón de clic izquierdo
        }
    }
}
