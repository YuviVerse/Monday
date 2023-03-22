using TMPro;

namespace Gameplay.UiLayout
{
    public class UiSummaryScreen : IUiElement
    {
        private TextMeshProUGUI _topScoreText;
        private TextMeshProUGUI _correctScoreText;
        private int _topScore;
        private int _correctScore;

        public UiSummaryScreen(TextMeshProUGUI topScoreText, TextMeshProUGUI correctScoreText)
        {
            _topScore = 0;
            _correctScore = 0;
            _topScoreText = topScoreText;
            _correctScoreText = correctScoreText;
        }

        public void UpdateUiComponent()
        {
            _topScoreText.text = $"Top Score: {_topScore}";
            _correctScoreText.text = $"Your Score: {_correctScore}";
        }

        public void SetScore(int topScore, int correctScore)
        {
            _topScore = topScore;
            _correctScore = correctScore;
            UpdateUiComponent();
        }
    }
}