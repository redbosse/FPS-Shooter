using System;
using UnityEngine;

public class AndroidInputSystem : ICustomInputSystem
{
    private Vector2 moveAxis;

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