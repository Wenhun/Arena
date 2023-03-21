using UnityEngine;

namespace Arena.PlayerController
{
    public class PlayerRotation : MonoBehaviour
    {
        [SerializeField] private float _sensitivity = 1;
        [SerializeField] private float _maxXAngle = 80f;
        [SerializeField] private float _minXAngle = -80f;

        private Camera _camera;

        private void Start()
        {
            _camera = GetComponentInChildren<Camera>();
        }

        public void Rotation(Vector3 direction)
        {
            if (Vector3.Angle(transform.forward, direction) > 0)
            {
                float yRotation = direction.x * _sensitivity;
                float xRotation = direction.y * _sensitivity;

                transform.localRotation = Quaternion.Euler(0, yRotation + transform.localEulerAngles.y, 0);

                _camera.transform.localRotation *= Quaternion.Euler(-xRotation, 0, 0);
                _camera.transform.localRotation = ClampCameraRotation(_camera.transform.localRotation);
            }
        }

        private Quaternion ClampCameraRotation(Quaternion rotation)
        {
            rotation.x /= rotation.w;
            rotation.w = 1.0f;

            float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(rotation.x);
            angleX = Mathf.Clamp(angleX, _minXAngle, _maxXAngle);
            rotation.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

            return rotation;
        }
    }
}
