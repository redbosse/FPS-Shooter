using System;
using UnityEngine;

public class PCInputSystem : ICustomInputSystem
{
    public void Dispose()
    {
    }

    public void Initialize()
    {
    }

    public Vector2 MoveAxis()
    {
        return new Vector2(1f, 0f);
    }

    public void Tick()
    {
    }
}