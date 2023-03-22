using Gameplay.Dispatchers;
using Gameplay.UiLayout;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gameplay
{
    public class GameManager : MonoBehaviour
    {
        [Header("Data Collections")] [SerializeField]
        private TreasureCollection treasureCollection;

        [SerializeField] private SeasonData seasonData;

        [Space] [Header("Dispatchers")] [SerializeField]
        private Dispatcher treasureDispatcher;

        [Space] [Header("Scripts")] [SerializeField]
        private Player player;

        [Space] [Header("Interface")] [SerializeField]
        private UiGameplayLayout uiGameplayLayout;

        [Space] [Header("Timer")] [SerializeField]
        private float initialTime = 120f;

        [SerializeField] private float timeToAddEachCoinsCollection = 40f;
        private float _timer;


        private TreasureType _currentTypeByDifficulty = TreasureType.CopperCoins;
        private int _treasureCollected;
        private int _currentScore;
        private bool _isGameOver;

        private void Awake()
        {
            player.onTreasureCollect += SpawnANewTreasure;
            player.onTreasureCollect += AddTimeBonusForCollectedCoins;
        }

        private void Start()
        {
            SpawnANewTreasure();
            uiGameplayLayout.TimerUpdate(initialTime);

            _timer = initialTime;
            _currentScore = 0;
            _treasureCollected = 0;
        }

        private void Update()
        {
            RunTimer();

            if (_timer <= 0 && !_isGameOver)
                GameOver();
        }

        private void RunTimer()
        {
            _timer -= Time.deltaTime;
            if (_timer > 0)
                uiGameplayLayout.TimerUpdate(_timer);
            else
                uiGameplayLayout.TimerUpdate(0);
        }

        private void GameOver()
        {
            _isGameOver = true;
            if (seasonData.topScore < _currentScore)
                seasonData.topScore = _currentScore;

            seasonData.currentSeasonScore = _currentScore;
            uiGameplayLayout.GameOverSummaryScreen(seasonData.topScore, seasonData.currentSeasonScore);
        }

        private void SpawnANewTreasure()
        {
            if (_treasureCollected > 10)
            {
                _currentTypeByDifficulty = TreasureType.SilverCoins;
            }
            else if (_treasureCollected > 20)
            {
                _currentTypeByDifficulty = TreasureType.GoldCoins;
            }
            else
            {
                _currentTypeByDifficulty = TreasureType.CopperCoins;
            }

            Treasure newTreasure =
                treasureCollection.treasures.Find(treasure => treasure.type == _currentTypeByDifficulty);
            treasureDispatcher.Spawn(newTreasure.prefab);

            _currentScore += newTreasure.scoreAmount;
            _treasureCollected++;
            HintButtonWasPressed();
        }

        private void AddTimeBonusForCollectedCoins()
        {
            if (timeToAddEachCoinsCollection > 10)
                timeToAddEachCoinsCollection--;

            _timer += timeToAddEachCoinsCollection;
            uiGameplayLayout.TimerUpdate(_timer);
        }

        public void HintButtonWasPressed()
        {
            Treasure treasure =
                treasureCollection.treasures.Find(treasure => treasure.type == _currentTypeByDifficulty);
            uiGameplayLayout.ToggleHintWindow(treasure.image);
        }

        public void OnButtonMainMenuPress()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}