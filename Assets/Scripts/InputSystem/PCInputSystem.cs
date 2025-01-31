using System;
using UnityEngine;

public class PCInputSystem : ICustomInputSystem
{
    private Vector2 moveAxis = Vector2.zero;

    public void Dispose()
    {
    }

    public void Initialize()
    {
        Debug.Log(this.GetType().Name);
    }

    public Vector2 MoveAxis()
    {
        return moveAxis;
    }

    public void Tick()
    {
    }
}