using UnityEngine;

namespace Arena.Core
{
    public abstract class Health : MonoBehaviour
    {
        [SerializeField] protected int health = 100;

        protected int maxHealth;

        private void Start()
        {
            maxHealth = health;
        }

        public void TakeDamage(int damage)
        {
            health = Mathf.Max(health - damage, 0);
            if (health == 0) Death();
        }

        public abstract void Death();
    }
}
