using Arena.ObjectPoolingSystem;
using UnityEngine;
using UnityEngine.Pool;

namespace Arena.Core
{
    public abstract class Bullet : MonoBehaviour, IPoolSetup
    {
        [SerializeField] protected float speed = 1f;
        [SerializeField] protected int damage = 15;

        protected Rigidbody rb;

        protected Vector3 direction;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        private IObjectPool<GameObject> bulletPool;

        public void SetPool(IObjectPool<GameObject> pool)
        {
            bulletPool = pool;
        }

        public void TakeCollision()
        {
            if (gameObject.activeSelf) bulletPool.Release(this.gameObject);
        }
    }
}
