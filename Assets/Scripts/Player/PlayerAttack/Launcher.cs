using System.Collections;
using UnityEngine;
using Arena.ObjectPoolingSystem;

namespace Arena.PlayerAttack
{
    public class Launcher : ObjectPoolBase
    {
        [SerializeField] private float _range = 100f;
        [SerializeField] private Camera _camera;
        [SerializeField] private float _timeBetweenShots = 0.5f;

        private bool _canShoot = true;

        //button event
        public void TakeShoot()
        {
            if (_canShoot) StartCoroutine(ShootDelay());
        }

        private IEnumerator ShootDelay()
        {
            _canShoot = false;
            RaycastToTarget();
            yield return new WaitForSeconds(_timeBetweenShots);
            _canShoot = true;
        }

        private void RaycastToTarget()
        {
            RaycastHit hit;
            Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, _range);
            pool.Get();
        }
    }
}
