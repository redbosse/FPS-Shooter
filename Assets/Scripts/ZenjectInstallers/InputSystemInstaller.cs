using System;
using UnityEngine;
using Zenject;

public class InputSystemInstaller : MonoInstaller<InputSystemInstaller>
{
    private enum BuildTarget
    {
        PC,
        IOS,
        Android
    }

    [SerializeField]
    private BuildTarget buildTarget;

    public override void InstallBindings()
    {
        switch (buildTarget)
        {
            case BuildTarget.PC:

                Container.Bind(
               typeof(ITickable),
               typeof(IDisposable),
               typeof(IInitializable),
               typeof(ICustomInputSystem)).To<PCInputSystem>().AsSingle();

                break;

            case BuildTarget.Android:

                Container.Bind(
               typeof(ITickable),
               typeof(IDisposable),
               typeof(IInitializable),
               typeof(ICustomInputSystem)).To<AndroidInputSystem>().AsSingle();

                break;

            case BuildTarget.IOS:

                Container.Bind(
               typeof(ITickable),
               typeof(IDisposable),
               typeof(IInitializable),
               typeof(ICustomInputSystem)).To<IOSInputSystem>().AsSingle();

                break;

            default:

                Container.Bind(
               typeof(ITickable),
               typeof(IDisposable),
               typeof(IInitializable),
               typeof(ICustomInputSystem)).To<PCInputSystem>().AsSingle();

                break;
        }
    }
}