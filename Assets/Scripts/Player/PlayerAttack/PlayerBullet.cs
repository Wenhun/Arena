using UnityEngine;
using Arena.EnemyHealth;
using Arena.Core;

namespace Arena.PlayerAttack
{
    public class PlayerBullet : Bullet
    {
        private BulletBounce _bulletBounce;
        private bool _isBounsed;

        private void Awake()
        {
            _bulletBounce = GetComponent<BulletBounce>();
        }

        private void OnEnable()
        {
            ResetPosition();
        }

        private void Update()
        {
            rb.velocity = direction * speed;
        }

        private void OnCollisionEnter(Collision collision)
        {
            switch (collision.gameObject.tag)
            {
                case "Player":
                    break;
                case "Bullet":
                    break;
                case "Enemy":
                    DamageEnemy(collision.gameObject.GetComponent<EnemyStats>());
                    break;
                default:
                    TakeCollision();
                    break;
            }
        }

        private void DamageEnemy(EnemyStats enemy)
        {
            direction = _bulletBounce.TakeNewDirection(enemy, direction, _isBounsed);

            if (direction == Vector3.zero)
            {
                _isBounsed = false;
                enemy.TakeDamage(damage, _isBounsed);
                TakeCollision();
            }
            else
            {
                _isBounsed = true;
                enemy.TakeDamage(damage, _isBounsed);
            }
        }

        private void ResetPosition()
        {
            transform.position = Camera.main.transform.position;
            direction = Camera.main.transform.forward;
        }
    }
}
