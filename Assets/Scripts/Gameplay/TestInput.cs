using InputSystem;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class TestInput : MonoBehaviour
    {
        [Inject]
        private ICustomInputSystem customInputSystem;

        private void Start()
        {
        }
    }
}