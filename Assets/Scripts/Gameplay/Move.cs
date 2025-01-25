using DG.Tweening;
using JetBrains.Annotations;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1;

    [SerializeField]
    private float rotationSpeed = 15;

    [SerializeField]
    private Vector2 rotationSensivity = Vector2.one;

    [SerializeField]
    private float MaxYAngle = 70;

    [SerializeField]
    private float MinYAngle = -70;

    [SerializeField]
    private bool Rotate_X = true, Rotate_Y = true;

    [SerializeField]
    private bool Move_X = true, Move_Z = true;

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

        transform.position += (Move_X ? (rigthDirection * deltaSpeed) : zero) + (Move_Z ? (forwardDirection * deltaSpeed) : zero);

        float deltaRotation = rotationSpeed * Time.deltaTime;

        transform.Rotate((Rotate_X ? -rigthStick.y * deltaRotation * rotationSensivity.y : 0.0f), (Rotate_Y ? rigthStick.x * deltaRotation * rotationSensivity.x : 0.0f), 0);

        var quat = transform.localRotation;

        float degresConverter = Mathf.PI / 360;

        transform.localRotation = new Quaternion(Mathf.Clamp(quat.x, -MaxYAngle * degresConverter, -MinYAngle * degresConverter), quat.y, quat.z, quat.w);
    }

    private void Update()
    {
        CalculateTransformation();
    }
}