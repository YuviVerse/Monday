using TMPro;
using UnityEngine;

namespace Gameplay.UiLayout
{
    public class UiTimer : IUiElement
    {
        private TextMeshProUGUI timerText;
        private float _timer;

        public UiTimer(TextMeshProUGUI timerText)
        {
            this.timerText = timerText;
        }

        public void UpdateUiComponent()
        {
            _timer -= Time.deltaTime;

            int minutes = Mathf.FloorToInt(_timer / 60);
            int seconds = Mathf.FloorToInt(_timer % 60);

            string minutesString = minutes.ToString("00");
            string secondsString = seconds.ToString("00");

            timerText.text = minutesString + ":" + secondsString;
        }
        
        public void UpdateTimer(float timer)
        {
            _timer = timer;
            UpdateUiComponent();
        }
    }
}