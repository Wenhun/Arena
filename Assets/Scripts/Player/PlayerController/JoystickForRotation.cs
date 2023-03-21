using UnityEngine;

namespace Arena.PlayerController
{
    public class JoystickForRotation : JoystickHandler
    {
        [SerializeField] private PlayerRotation playerRotation;

        private void Update()
        {
            if (_inputVector.x != 0 || _inputVector.y != 0)
            {
                playerRotation.Rotation(new Vector3(_inputVector.x, _inputVector.y, 0));
            }
        }
    }
}
