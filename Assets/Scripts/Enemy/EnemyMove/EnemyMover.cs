using UnityEngine;

namespace Arena.EnemyMove
{
    public class EnemyMover : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 1f;

        private Transform _target;

        protected Rigidbody rb;

        private void Awake()
        {
            _target = FindObjectOfType<Arena.PlayerController.PlayerMovement>().transform;
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if(Vector3.Distance(_target.position, transform.position) > 2f)
            {
                MoveEnemy();
            }
        }

        protected void MoveEnemy()
        {
            rb.MovePosition(transform.position + transform.forward * _moveSpeed * Time.deltaTime);
            transform.LookAt(_target);
        }
    }
}