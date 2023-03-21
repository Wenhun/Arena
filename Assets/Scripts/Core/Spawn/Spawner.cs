using UnityEngine;
using Arena.ObjectPoolingSystem;

namespace Arena.Spawn
{
    public class Spawner : ObjectPoolBase
    {
        [SerializeField] private Transform _arena;
        [SerializeField] private float _heightSpawn = 2f;

        private float _radius;
        private Vector3 _spawnPoint;

        private void Start()
        {
            _radius = Vector3.Distance(Vector3.zero, _arena.position);
        }

        public void Spawn(int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                GameObject enemy = pool.Get();
                RandomPoint();
                enemy.transform.position = _spawnPoint;
            }
        }

        private void RandomPoint()
        {
            float randomX = Random.Range(-_radius, _radius);
            float randomZ = Random.Range(-_radius, _radius);

            Vector3 randomPoint = new Vector3(randomX, _heightSpawn, randomZ);

            if (randomPoint.magnitude <= _radius)
            {
                _spawnPoint = randomPoint;
            }
            else
            {
                RandomPoint();
            }
        }
    }
}