using UnityEngine;
using Arena.PlayerHealth;
using Arena.EnemyHealth;

namespace Arena.PlayerAttack
{
    public class BulletBounce : MonoBehaviour
    {
        [SerializeField] [Range(0, 1)] private float _baseChanceBounce;
        [SerializeField] private float _bounceDistance = 5f;
        private PlayerStats _playerStats;

        private void Start()
        {
            _playerStats = FindObjectOfType<PlayerStats>();
        }

        public Vector3 TakeNewDirection(EnemyStats crossfireEnemy, Vector3 currentDirection, bool isBounce)
        {
            if (isBounce) return Vector3.zero;

            if (IsBounceActivated(_playerStats.GetHealthPercentage))
            {
                return FindClosesTarget(crossfireEnemy, currentDirection);
            }
            else
            {
                return Vector3.zero;
            }
        }

        private bool IsBounceActivated(float healthPercentage)
        {
            if (healthPercentage < 0.2f) return true;               

            return Random.value < _baseChanceBounce;
        }

        private Vector3 FindClosesTarget(EnemyStats crossfireEnemy, Vector3 currentDirection)
        {
            float minDistance = Mathf.Infinity;
            Transform bounceTarget = null;

            foreach (EnemyStats enemy in FindObjectsOfType<EnemyStats>())
            {
                if (!enemy.gameObject.activeSelf) continue;

                if (enemy == crossfireEnemy) continue;

                float distance = Vector3.Distance(transform.position, enemy.transform.position);
                if (distance <= minDistance)
                {
                    minDistance = distance;
                    bounceTarget = enemy.transform;
                }
            }

            if (minDistance <= _bounceDistance)
            {
                return (bounceTarget.transform.position - transform.position).normalized;
            }
            else
            { 
                return currentDirection;
            }
        }
    }
}
