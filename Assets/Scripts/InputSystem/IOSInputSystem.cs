using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

using Random = UnityEngine.Random;

public class IOSInputSystem : ICustomInputSystem, IDisposable, IInitializable, ITickable
{
    private Vector2 vector = Vector2.one;

    public void Initialize()
    {
    }

    public Vector2 MoveAxis()
    {
        return vector;
    }

    public void Tick()
    {
    }

    public void Dispose()
    {
    }
}