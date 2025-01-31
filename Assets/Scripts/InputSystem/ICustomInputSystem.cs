using System;
using UnityEngine;
using Zenject;

public interface ICustomInputSystem : IDisposable, IInitializable, ITickable

{
    public Vector2 MoveAxis();
}
