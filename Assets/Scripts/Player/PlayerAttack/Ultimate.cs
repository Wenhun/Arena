using UnityEngine;
using UnityEngine.UI;
using Arena.PlayerHealth;
using Arena.EnemyHealth;

namespace Arena.PlayerAttack
{
    public class Ultimate : MonoBehaviour
    {
        [SerializeField] private PlayerStats _playerStats;

        private Button _button;

        private void Start()
        {
            _button = GetComponentInChildren<Button>();
        }

        private void Update()
        {
            if (_playerStats.Strength == _playerStats.GetMaxStrength)
            {
                _button.interactable = true;
            }
            else
            {
                _button.interactable = false;
            }
        }

        //button event
        public void UseUltimate()
        {
            foreach (EnemyStats enemy in FindObjectsOfType<EnemyStats>())
                enemy.Death();
            _playerStats.Strength = 0;
        }
    }
}
