using Arena.Core;
using Arena.PlayerHealth;
using UnityEngine;

namespace Arena.EnemyAttack
{
    public class MeleeDamage : Bullet
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<PlayerStats>().TakeDamage(damage);
                TakeCollision();
            }
        }
    }
}
