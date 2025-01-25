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

    private void Update()
    {
        transform.position += (Move_X ? (transform.right * moveSpeed * leftStick.x * Time.deltaTime) : Vector3.zero)
                            + (Move_Z ? (transform.forward * moveSpeed * leftStick.y * Time.deltaTime) : Vector3.zero);

        transform.Rotate(
            (Rotate_X ? -rigthStick.y * Time.deltaTime * rotationSpeed * rotationSensivity.y : 0.0f),
            (Rotate_Y ? rigthStick.x * Time.deltaTime * rotationSpeed * rotationSensivity.x : 0.0f),
            0);
        var quat = transform.localRotation;

        Debug.Log(quat.x * 360 / Mathf.PI);

        transform.localRotation = new Quaternion(Mathf.Clamp(quat.x, -MaxYAngle * Mathf.PI / 360, -MinYAngle * Mathf.PI / 360), quat.y, quat.z, quat.w);
    }
}