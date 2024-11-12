using System.Collections.Generic;
using Cartoon;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using DG.Tweening;

namespace Controllers
{
    public class StoryBoardController : MonoBehaviour, IPointerClickHandler
    {
        [Header("Animation")]
        [SerializeField] private float _animationDuration;
        [SerializeField] private AnimationInType _animationInType;
        [SerializeField] private AnimationOutType _animationOutType;
        [SerializeField] private CanvasGroup _canvasGroup;

        [Header("Pages")]
        [SerializeField] private int _currentPageIndex;
        [SerializeField] private List<CartoonPage> _cartoonPages;

        [Header("ConfigData")]
        [SerializeField] private ConfigData _configData;

        public string levelToLoad;
        
        private bool _isInTransition;
        
        private void Start()
        {
            DOTween.Init();
            _isInTransition = true;
            _configData = DataManager.Instance.LoadConfigData();
            SetupCartoonPages();
            _currentPageIndex = 0;
            
            _canvasGroup.alpha = 0;
            var sequence = DOTween.Sequence();
            sequence.Append(_canvasGroup.DOFade(1, _animationDuration)).AppendCallback(() =>
            {
                _isInTransition = false;
                Debug.Log("IsInTransition: " + _isInTransition);
            });
            sequence.Play();
        }

        private void SetupCartoonPages()
        {
            foreach (var cartoonPage in _cartoonPages)
            {
                cartoonPage.gameObject.SetActive(false);
            }
            _cartoonPages[0].gameObject.SetActive(true);
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            if (_isInTransition)
            {
                return;
            }
            
            var currentPage = GetCurrentCartoonPage();

            if (!currentPage.IsPartialDialogueFinished && !currentPage.IsDialogueFinished)
            {
                currentPage.CompleteWritePartialDialogue();
                return;
            }
            
            if (currentPage.IsDialogueFinished)
            {
                _isInTransition = true;
                
                var sequence = DOTween.Sequence();
                sequence.Append(_canvasGroup.DOFade(0, _animationDuration)).AppendCallback(() =>
                {
                    _cartoonPages[_currentPageIndex].gameObject.SetActive(false);
                    _currentPageIndex++;
                    if (_currentPageIndex >= _cartoonPages.Count)
                    {
                        DOTween.KillAll();
                        Debug.Log("All dialogues are finished");

                        var gameType = _configData.currentGameType;

                        Debug.Log("Game type: " + gameType);

                        SceneManager.LoadScene(levelToLoad);

                        //if (gameType == GameType.QuizGame.ToString())
                        //{
                        //    SceneManager.LoadScene("AlgebraGame");
                        //}
                        //else
                        //{
                        //    SceneManager.LoadScene("CardsGame");
                        //}
                    }
                });

                // _isInTransition = true;
                sequence.AppendCallback(() =>
                {
                    _canvasGroup.alpha = 0;
                    _cartoonPages[_currentPageIndex].gameObject.SetActive(true);
                });
                sequence.Append(_canvasGroup.DOFade(1, _animationDuration)).AppendCallback(() =>
                {
                    _isInTransition = false;
                });
                sequence.Play();
            }
            currentPage.WritePartialDialogueWithAnimation();
        }
        
        public CartoonPage GetCurrentCartoonPage()
        {
            return _cartoonPages[_currentPageIndex];
        }
    }

}