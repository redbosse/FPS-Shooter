using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfiguration", menuName = "RED/PlayerConfiguration")]
public class PlayerConfiguration : ScriptableObject
{
    [SerializeField]
    private float moveSpeed = 1f;

    [SerializeField]
    private float rotationSpeed = 1f;

    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public float RotationSpeed { get => rotationSpeed; set => rotationSpeed = value; }
}