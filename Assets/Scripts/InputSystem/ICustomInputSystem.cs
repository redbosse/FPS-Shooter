using System;
using UnityEngine;
using Zenject;

namespace InputSystem
{
    public interface ICustomInputSystem : IDisposable, IInitializable, ITickable
    {
        public Vector2 MoveAxis();
    }
}