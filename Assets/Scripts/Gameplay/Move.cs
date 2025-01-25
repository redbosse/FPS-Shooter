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

        Vector3 eyler = transform.localEulerAngles;

        eyler.x += (Rotate_X ? -rigthStick.y * Time.deltaTime * rotationSpeed * rotationSensivity.y : 0.0f);
        eyler.y += (Rotate_Y ? rigthStick.x * Time.deltaTime * rotationSpeed * rotationSensivity.x : 0.0f);

        transform.localEulerAngles = eyler;
    }
}