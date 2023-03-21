using UnityEngine;
using Arena.ObjectPoolingSystem;
using System.Collections;

namespace Arena.EnemyAttack
{
    public class RangeAttack : ObjectPoolBase
    {
        [SerializeField] private float _shootInterval = 3f;

        private bool _canShoot;

        private void OnEnable()
        {
            _canShoot = false;
            StartCoroutine(Shooting());
        }

        private IEnumerator Shooting()
        {
            yield return new WaitForSeconds(_shootInterval);
            _canShoot = true;
        }

        private void Update()
        {
            if (gameObject.activeSelf && _canShoot)
            {
                _canShoot = false;
                GameObject bullet = pool.Get();
                bullet.GetComponent<EnemyBullet>().SetStartPoint(transform.position);
                StartCoroutine(Shooting());
            }
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }
    }
}
