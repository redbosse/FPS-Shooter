using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

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
            var x = Mathf.Clamp(Input.mousePosition.x, 0, Screen.width);
            var y = Mathf.Clamp(Input.mousePosition.y, 0, Screen.height);
            
            Vector2 mousePos = new Vector2(x, y);
            Vector2 screenSize = new Vector2(Screen.width, Screen.height);
            
            Vector2 direction  = (mousePos - screenSize * 0.5f) / (screenSize * 0.5f);
            
            direction.y = Mathf.Pow(direction.y, 6) * Mathf.Sign(direction.y);
            direction.x = Mathf.Pow(direction.x, 6) * Mathf.Sign(direction.x);

            if (Mathf.Abs(direction.x) < 0.7) direction.x = 0;
            if (Mathf.Abs(direction.y) < 0.7) direction.y = 0;

            
            return direction;
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