using UI;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay.Controllers
{
    public class Move : MonoBehaviour
    {
        [SerializeField]
        private float moveSpeed = 1;

        [SerializeField]
        private float rotationSpeed = 15;

        [SerializeField]
        private Vector2 rotationSensivity = Vector2.one;

         [SerializeField]
        private float maxYAngle = 70;

         [SerializeField]
        private float minYAngle = -70;

         [SerializeField]
        private bool rotateX = true;

         [SerializeField]
        private bool rotateY = true;

        [SerializeField]
        private bool moveX = true;

        [SerializeField]
        private bool moveZ = true;

        private StickCommutator commutator;

        private Vector2 leftStick;
        private Vector2 rigthStick;

        private void OnEnable()
        {
            if (commutator == null)
                commutator = GetComponent<StickCommutator>();

            if (!commutator)
                throw new System.Exception("Commutator is null");

            commutator.LeftStick.OnStick.AddListener(LeftStick);
            commutator.RigthStick.OnStick.AddListener(RigthStick);
        }

        private void OnDisable()
        {
            if (!commutator)
                throw new System.Exception("Commutator is null");

            commutator.LeftStick.OnStick.RemoveListener(LeftStick);
            commutator.RigthStick.OnStick.RemoveListener(RigthStick);
        }

        private void LeftStick(Vector2 direction)
        {
            leftStick = direction;
        }

        private void RigthStick(Vector2 direction)
        {
            rigthStick = direction;
        }

        private void CalculateTransformation()
        {
            float deltaSpeed = moveSpeed * Time.deltaTime;

            Vector3 zero = Vector3.zero;
            Vector3 rigthDirection = transform.right * leftStick.x;
            Vector3 forwardDirection = transform.forward * leftStick.y;

            transform.position += (moveX ? (rigthDirection * deltaSpeed) : zero) + (moveZ ? (forwardDirection * deltaSpeed) : zero);

            float deltaRotation = rotationSpeed * Time.deltaTime;

            transform.Rotate((rotateX ? -rigthStick.y * deltaRotation * rotationSensivity.y : 0.0f), (rotateY ? rigthStick.x * deltaRotation * rotationSensivity.x : 0.0f), 0);

            var quat = transform.localRotation;

            float degresConverter = Mathf.PI / 360;

            transform.localRotation = new Quaternion(Mathf.Clamp(quat.x, -maxYAngle * degresConverter, -minYAngle * degresConverter), quat.y, quat.z, quat.w);
        }

        private void Update()
        {
            CalculateTransformation();
        }
    }
}