using System.Collections;
using UnityEngine;

namespace Arena.EnemyMove
{
    public class FlyingEnemy : EnemyMover
    {
        [SerializeField] private float _flyingTime = 1f;
        [SerializeField] private float _flyingSpeed = 1f;

        private bool _startAttack = false;
        private bool _wait = false;

        private void OnEnable()
        {
            _startAttack = false;
            rb.useGravity = false;
            StartCoroutine(StartFly());
        }

        private void Update()
        {
            if (this.enabled && !_wait)
            {
                transform.Translate(Vector3.up * _flyingSpeed * Time.deltaTime);
            }

            if (_startAttack)
            {
                MoveEnemy();
            }
        }

        private IEnumerator StartFly()
        {
            yield return new WaitForSeconds(_flyingTime);
            _wait = true;
            yield return new WaitForSeconds(_flyingTime);
            _startAttack = true;
            rb.useGravity = true;
        }
    }
}
