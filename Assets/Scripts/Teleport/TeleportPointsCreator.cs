using UnityEngine;

namespace Arena.Teleport
{
    public class TeleportPointsCreator : MonoBehaviour
    {
        [SerializeField] private int _numOfPoints = 30;
        [SerializeField] private Transform _radiusPoint;
        [SerializeField] private float _radiusCorrection = 1f;
        [SerializeField] [Range(0, 1f)] private float _minInterval = 0.2f;
        [SerializeField] [Range(0, 1f)] private float _maxInterval = 1f;

        private float _radius;

        private void Start()
        {
            _radius = Vector3.Distance(Vector3.zero, _radiusPoint.position);
            _radius -= _radiusCorrection;
            float interval = Mathf.Lerp(_maxInterval, _minInterval, (float)_numOfPoints);

            for (int i = 0; i < _numOfPoints; i++)
            {
                float angle = i * Mathf.PI * 2f / _numOfPoints;
                float x = Mathf.Cos(angle) * (_radius + interval);
                float y = Mathf.Sin(angle) * (_radius + interval);
                Vector3 pos = new Vector3(x, 0, y);
                GameObject point = new GameObject("Point " + i);
                point.transform.position = pos;
                point.transform.SetParent(transform);
            }
        }
    }
}
