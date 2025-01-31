using UnityEngine;

namespace InputSystem
{
    public class PCInputSystem : ICustomInputSystem
    {
        private Vector2 moveAxis = Vector2.zero;

        public void Initialize()
        {
        }

        public Vector2 MoveAxis()
        {
            return moveAxis;
        }

        public Vector2 MoveMouseAxis()
        {
            throw new System.NotImplementedException();
        }

        public void Tick()
        {
            moveAxis.x = Input.GetAxis("Horizontal");
            moveAxis.y = Input.GetAxis("Vertical");
        }

        public void Dispose()
        {
        }
    }
}