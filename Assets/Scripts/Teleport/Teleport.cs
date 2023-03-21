using UnityEngine;
using Arena.PlayerAttack;
using Arena.EnemyAttack;
using Arena.EnemyHealth;
using Arena.Core;

namespace Arena.Teleport
{
    public class Teleport : MonoBehaviour
    {
        [SerializeField] private Transform[] _enemyPools;
        [SerializeField] private Transform _teleportPoints;
        [SerializeField] private Transform _enemyBulletPool;

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                TeleportPlayer(other.transform);
                ResetEnemyBullets();
            }

            if (other.CompareTag("Bullet"))
            {
                Bullet bullet = other.GetComponent<Bullet>();
                if (bullet != null)
                {
                    if (bullet is PlayerBullet || bullet is EnemyBullet)
                    {
                        bullet.TakeCollision();
                    }
                }
            }
        }

        private void TeleportPlayer(Transform player)
        {
            Vector3 farthestPoint = FindFarthestPoint();
            player.position = farthestPoint;
            player.LookAt(Vector3.zero);
        }

        private void ResetEnemyBullets()
        {
            foreach (Transform bullet in _enemyBulletPool)
            {
                bullet.GetComponent<EnemyBullet>().ResetTarget();
            }
        }

        private Vector3 FindFarthestPoint()
        {
            float maxDistance = Mathf.NegativeInfinity;
            Transform farthestPoint = null;

            foreach (Transform point in _teleportPoints)
            {
                foreach (Transform enemyPool in _enemyPools)
                {
                    foreach (Transform enemy in enemyPool)
                    {
                        EnemyStats enemyHealth = enemy.GetComponent<EnemyStats>();
                        if (enemyHealth != null)
                        {
                            float distance = Vector3.Distance(point.position, enemy.position);
                            if (distance > maxDistance)
                            {
                                maxDistance = distance;
                                farthestPoint = point;
                            }
                        }
                    }
                }
            }

            return farthestPoint.position;
        }
    }
}
