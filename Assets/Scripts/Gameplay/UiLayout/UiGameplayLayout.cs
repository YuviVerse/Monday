using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.UiLayout
{
    public class UiGameplayLayout : MonoBehaviour
    {
        [Header("Timer")] [SerializeField] private TextMeshProUGUI timerText;

        [Space] [Header("Hint")] [SerializeField]
        private Image hintPageImage;

        [SerializeField] private GameObject hintPageGameObject;

        [Space] [Header("SummaryScreen")]
        private UiSummaryScreen _uiSummaryScreen;
        [SerializeField] private GameObject summaryScreenObject;
        [SerializeField] private TextMeshProUGUI topScoreText;
        [SerializeField] private TextMeshProUGUI correctScoreText;

        private UiHint _uiHint;
        private UiTimer _timer;

        private void Awake()
        {
            _timer = new UiTimer(timerText);
            _uiHint = new UiHint(hintPageImage);
            _uiSummaryScreen = new UiSummaryScreen(topScoreText, correctScoreText);
            hintPageGameObject.SetActive(false);
            summaryScreenObject.SetActive(false);
        }

        public void TimerUpdate(float currentTime)
        {
            _timer.UpdateTimer(currentTime);
        }

        public void ToggleHintWindow(Sprite treasureTypeSprite)
        {
            if (hintPageGameObject.activeSelf)
            {
                Time.timeScale = 1f;
                hintPageGameObject.SetActive(false);
            }
            else
            {
                Time.timeScale = 0f;
                hintPageGameObject.SetActive(true);
                _uiHint.SetImage(treasureTypeSprite);
            }
        }

        public void GameOverSummaryScreen(int topScore, int correctScore )
        {
            summaryScreenObject.SetActive(true);
            _uiSummaryScreen.SetScore(topScore, correctScore);
            Time.timeScale = 0f;
        }
    }
}