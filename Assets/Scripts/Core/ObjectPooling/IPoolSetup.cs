using UnityEngine;
using UnityEngine.Pool;

namespace Arena.ObjectPoolingSystem
{
    public interface IPoolSetup
    {
        public void SetPool(IObjectPool<GameObject> pool);
    }
}
