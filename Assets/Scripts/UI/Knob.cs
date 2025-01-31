using UnityEngine;

namespace UI
{
    public class Knob : MonoBehaviour
    {
        public void MoveTo(Vector2 position)
        {
            transform.localPosition = position;
        }
    }
}