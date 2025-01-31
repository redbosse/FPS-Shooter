using UnityEngine;

namespace InputSystem
{
    public class AndroidInputSystem : ICustomInputSystem
    {
        private Vector2 moveAxis;

        public void Initialize()
        {
           
        }

        public Vector2 MoveAxis()
        {
            return moveAxis;
        }

        public void Tick()
        {
        }

        public void Dispose()
        {
        }
    }
}