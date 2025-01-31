using InputSystem;
using UnityEngine;
using Zenject;

namespace Gameplay.Controllers
{
    public class CameraMotionComponent : ICameraMotion
    {
        [Inject]
        private ICustomInputSystem customInputSystem;

        [Inject]
        private PlayerConfiguration playerConfiguration;

        private readonly Vector3 forward = Vector3.forward;
        private readonly Vector3 right = Vector3.right;

        public Quaternion CameraLocalOrientation(Quaternion sourceOrientation)
        {
            var axis = customInputSystem.MoveAxis();

            return sourceOrientation;
        }

        public Vector3 CameraLocalPosition(Vector3 sourcePosition)
        {
            var axis = customInputSystem.MoveAxis();

            var position = sourcePosition
                           + (forward * (axis.y * playerConfiguration.MoveSpeed) 
                              + right * (axis.x * playerConfiguration.MoveSpeed) )* Time.deltaTime;

            return position;
        }
    }
}