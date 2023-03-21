using UnityEngine;
using UnityEngine.Pool;

namespace Arena.ObjectPoolingSystem
{
    public abstract class ObjectPoolBase : MonoBehaviour
    {
        [SerializeField] private GameObject _objectPrefab;
        [SerializeField] private Transform _poolParent;

        protected IObjectPool<GameObject> pool;

        private void Awake()
        {
            pool = new ObjectPool<GameObject>(
                CreateObject,
                OnGet,
                OnRelease
            );
        }

        private GameObject CreateObject()
        {
            GameObject newObject = Instantiate(_objectPrefab);

            if (_poolParent != null) newObject.transform.SetParent(_poolParent); 

            IPoolSetup[] poolSetups = newObject.GetComponents<IPoolSetup>();
            foreach (IPoolSetup poolSetup in poolSetups)
            {
                poolSetup.SetPool(pool);
            }

            return newObject;
        }

        private void OnGet(GameObject obj)
        {
            obj.SetActive(true);
        }

        private void OnRelease(GameObject obj)
        {
            obj.SetActive(false);
        }

        private void OnDestroy()
        {
            pool.Clear();
        }
    }
}
