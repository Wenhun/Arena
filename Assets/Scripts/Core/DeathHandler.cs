using UnityEngine;
using Arena.PlayerHealth;
using Arena.Core;
using TMPro;

public class DeathHandler : MonoBehaviour
{
    [Header("Scorer")]
    [SerializeField] private Scorer _scorer;
    [Header("Enemy Death")]
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] int amountRedAddedStrength = 15;
    [SerializeField] int amountBlueAddedStrength = 50;
    [Header("Player Death")]
    [SerializeField] private GameObject _deadCanvas;
    [SerializeField] private GameObject _gameplayCanvas;
    [SerializeField] private TMP_Text _scoreText;


    public void EnemyHandleDeath(EnemyColor color)
    {
        switch (color)
        {
            case EnemyColor.Red:
                _playerStats.IncreaseStrength(amountRedAddedStrength);
                break;
            case EnemyColor.Blue:
                _playerStats.IncreaseStrength(amountBlueAddedStrength);
                break;
        }
    }

    public void EnemyHandleDeath(bool isBouncedBullet)
    {
        _playerStats.IncreaseStats(amountRedAddedStrength);
    }

    public void EnemyHandleDeath()
    {
        _scorer.IncreaceScore();
    }

    public void PlayerHandleDeath()
    {
        Time.timeScale = 0;
        _gameplayCanvas.SetActive(false);
        _deadCanvas.SetActive(true);
        _scoreText.text = _scorer.GetScore.ToString();
    }
}
