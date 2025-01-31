using UnityEngine;

namespace Gameplay.Controllers
{
    public interface ICameraMotion
    {
        public Quaternion CameraLocalOrientation(Quaternion sourceOrientation);

        public Vector3 CameraLocalPosition(Vector3 sourcePosition);
    }
}