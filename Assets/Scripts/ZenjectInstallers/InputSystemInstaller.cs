using System;
using UnityEngine;
using Zenject;

public class InputSystemInstaller : MonoInstaller<InputSystemInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind(typeof(ITickable), typeof(IInitializable), typeof(IDisposable), typeof(ICustomInputSystem)).To<IOSInputSystem>().AsSingle();
    }
}