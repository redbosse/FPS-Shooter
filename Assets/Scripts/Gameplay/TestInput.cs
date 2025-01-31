using UnityEngine;
using Zenject;

public class TestInput : MonoBehaviour
{
    [Inject]
    private ICustomInputSystem customInputSystem;

    private void Start()
    {
    }
}