using Arena.Core;
using UnityEngine;

namespace Arena.PlayerHealth
{
    public class PlayerStats : Health
    {
        [SerializeField] private int _strength = 50;
        [SerializeField] private int _maxStrength = 100;
        [SerializeField] private DeathHandler _deathHandler;

        public int GetHealth { get => health; }
        public int Strength { get => _strength; set => _strength = value; }
        public int GetMaxStrength { get => _maxStrength; }
        public float GetHealthPercentage { get => health / maxHealth; }

        public void DecreaseStrength(int damage)
        {
            _strength = Mathf.Max(_strength - damage, 0);
        }

        public override void Death()
        {
            _deathHandler.PlayerHandleDeath();
        }

        public void IncreaseStats(int strenght)
        {
            if(health < maxHealth / 2)
            {
                health = maxHealth / 2;
            }
            else
            {
                _strength += strenght;
            }

            _strength = Mathf.Min(_strength, _maxStrength);
        }

        public void IncreaseStrength(int strenght)
        {
            _strength += strenght;
            _strength = Mathf.Min(_strength, _maxStrength);
        }
    }
}
