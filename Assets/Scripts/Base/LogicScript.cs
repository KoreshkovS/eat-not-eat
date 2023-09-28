using System.Collections;
using System.Collections.Generic;
using Game.Fruits;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Game.NonEatables;
using Game.PlayerScripts;

namespace Game.Base
{
    public class LogicScript : MonoBehaviour
    {
        [SerializeField] private int _playerScore;
        [SerializeField] private Text _scoreText;
        [SerializeField] private Text _highScoreText;
        [SerializeField] private Text _healthText;
        [SerializeField] private int _maxHealth;
        [SerializeField] private GameObject _gameOverScreen;
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private List<Spawner> _spawner;


        private void Start()
        {
            _healthText.text = _maxHealth.ToString();
        }

        private void OnEnable()
        {
            Fruit.OnAddScore += AddScore;
            NonEatable.OnDeath += EndGame;
        }
        private void OnDisable()
        {
            Fruit.OnAddScore -= AddScore;
            NonEatable.OnDeath -= EndGame;
        }

        [ContextMenu("Increase Score")]
        private void AddScore(int score)
        {
            _playerScore = _playerScore + score;
            _scoreText.text = _playerScore.ToString();
            _highScoreText.text = _scoreText.text;
        }

       
        private void EndGame()
        {
            _maxHealth -= 1;
            _healthText.text = _maxHealth.ToString();
            if (_maxHealth ==0)
            {
                GameOver();
                _spawner.ForEach(i => i.StopSpawn());
                _playerController.StopMove();
            }
            
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }


        public void GameOver()
        {
            _gameOverScreen.SetActive(true);
        }
    }
}