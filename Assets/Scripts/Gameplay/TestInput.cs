using UnityEngine;
using Zenject;

public class TestInput : MonoBehaviour
{
    [Inject]
    private ICustomInputSystem customInputSystem;

    private void Start()
    {
        Debug.Log(customInputSystem.MoveAxis());
    }

    private void Update()
    {
        Debug.Log(customInputSystem.MoveAxis());
    }
}