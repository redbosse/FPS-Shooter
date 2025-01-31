using UnityEngine;
using Zenject;

public class CameraMotionComponent : ICameraMotion
{
    [Inject]
    private ICustomInputSystem customInputSystem;

    [Inject]
    private PlayerConfiguration playerConfiguration;

    private Vector3 forward = Vector3.forward;
    private Vector3 right = Vector3.right;

    public Quaternion CameraLocalOrientation(Quaternion sourceOrientation)
    {
        Vector2 axis = customInputSystem.MoveAxis();

        return sourceOrientation;
    }

    public Vector3 CameraLocalPosition(Vector3 sourcePosition)
    {
        Vector2 axis = customInputSystem.MoveAxis();

        Vector3 position = sourcePosition
            + forward * axis.y * playerConfiguration.MoveSpeed * Time.deltaTime
            + right * axis.x * playerConfiguration.MoveSpeed * Time.deltaTime;

        return position;
    }
}