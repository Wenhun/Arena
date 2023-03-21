using UnityEngine;
using UnityEngine.Pool;
using Arena.ObjectPoolingSystem;
using Arena.Core;

namespace Arena.Core
{
    public enum EnemyColor
    {
        Red, Blue
    }
}

namespace Arena.EnemyHealth
{
    public class EnemyStats : Health, IPoolSetup
    {
        [SerializeField] private EnemyColor _color;

        private DeathHandler _deathHandler;

        private void OnEnable()
        {
            if (maxHealth != 0) health = maxHealth;
        }

        private void Start()
        {
            _deathHandler = FindObjectOfType<DeathHandler>();
        }

        public IObjectPool<GameObject> _pool;
        public void SetPool(IObjectPool<GameObject> pool)
        {
            _pool = pool;
        }

        public void TakeDamage(int damage, bool isBouncedBullet)
        {
            health = Mathf.Max(health - damage, 0);

            if (health == 0)
            {
                if(isBouncedBullet)
                {
                    _deathHandler.EnemyHandleDeath(isBouncedBullet);
                }
                else
                {
                    _deathHandler.EnemyHandleDeath(this._color);
                }
                Death();
            }
        }

        public override void Death()
        {
            _deathHandler.EnemyHandleDeath();
            ReleaseThis();
        }

        public void ReleaseThis()
        {
            if (gameObject.activeSelf)
            {
                _pool.Release(this.gameObject);
            }   
        }
    }
}
