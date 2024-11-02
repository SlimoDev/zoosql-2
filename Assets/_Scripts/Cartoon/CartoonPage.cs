using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Cartoon
{
    public enum CartoonPageState
    {
        Waiting,
        Writing,
        Finished
    }

    public class CartoonPage : MonoBehaviour
    {
        [TextArea(3, 10)]
        public List<string> _dialogues;
        [SerializeField] private TextMeshProUGUI _dialogueText;
        [SerializeField] private float _dialogueSpeed = 0.1f;

        public string currentDialogueText;
        
        public bool IsDialogueFinished { get; private set; }
        public bool IsPartialDialogueFinished { get; private set; }
        public int CurrentDialogueIndex { get; set; }

        private void Start()
        {
            IsDialogueFinished = false;
            IsPartialDialogueFinished = false;
            CurrentDialogueIndex = 0;
            _dialogueText.text = string.Empty;
            currentDialogueText = string.Empty;
            
            WritePartialDialogueWithAnimation();
        }

        public void CompleteWritePartialDialogue()
        {
            if (IsDialogueFinished)
            {
                return;
            }
            
            StopAllCoroutines();
            Debug.Log("StopAllCoroutines");
            
            if (CurrentDialogueIndex > 0)
            {
                currentDialogueText += "\n";
                Debug.Log("Salto de linea " + currentDialogueText);
            }
            currentDialogueText += _dialogues[CurrentDialogueIndex];
            _dialogueText.text = currentDialogueText;
            CurrentDialogueIndex++;
            IsPartialDialogueFinished = true;

            if (CurrentDialogueIndex >= _dialogues.Count)
            {
                IsDialogueFinished = true;
            }
        }
        
        public void WritePartialDialogueWithAnimation()
        {
            StartCoroutine(WritePartialDialogueAnimation());
        }
        
        private IEnumerator WritePartialDialogueAnimation()
        {
            Debug.Log("WritePartialDialogueAnimation");
            IsPartialDialogueFinished = false;
            if (IsDialogueFinished)
            {
                yield break;
            }
            
            if (CurrentDialogueIndex > 0)
            {
                _dialogueText.text += "\n";
            }
            
            foreach (var letter in _dialogues[CurrentDialogueIndex])
            {
                _dialogueText.text += letter;
                yield return new WaitForSeconds(_dialogueSpeed);
            }
            CurrentDialogueIndex++;
            IsPartialDialogueFinished = true;
            
            if (CurrentDialogueIndex >= _dialogues.Count)
            {
                IsDialogueFinished = true;
            }
        }
    }
}