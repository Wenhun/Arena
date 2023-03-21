using Arena.Core;
using Arena.PlayerHealth;
using UnityEngine;

namespace Arena.EnemyAttack
{
    public class EnemyBullet : Bullet
    {
        private PlayerStats _playerStats;
        private Transform _player;
        private Transform _target;

        private void Awake()
        {
            transform.SetParent(GameObject.FindWithTag("EnemyBulletPool").transform);
            _playerStats = FindObjectOfType<PlayerStats>();
            _player = _playerStats.GetComponent<Transform>();
        }

        private void OnEnable()
        {
            _target = _player;
        }

        public void SetStartPoint(Vector3 point)
        {
            transform.position = point;
        }

        private void Update()
        {
            if (_target != null)
            {
                MoveToTarget();
            }
            else
            {
                rb.velocity = direction * speed;
            }
        }

        private void MoveToTarget()
        {
            Vector3 targetDirection = _target.position - transform.position;
            targetDirection.y = 0;

            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            rb.MoveRotation(targetRotation);

            Vector3 targetVelocity = targetDirection.normalized * speed;
            rb.velocity = targetVelocity;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player") && gameObject.activeSelf)
            {
                _playerStats.DecreaseStrength(damage);
                TakeCollision();
            }
        }

        public void ResetTarget()
        {
            _target = null;
            direction = transform.forward;
        }
    }
}
