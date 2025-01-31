using System;
using UnityEngine;

public class MobileInputSystem : ICustomInputSystem
{
    public void Dispose()
    {
    }

    public void Initialize()
    {
    }

    public Vector2 MoveAxis()
    {
        return new Vector2(0f, 0f);
    }

    public void Tick()
    {
    }
}