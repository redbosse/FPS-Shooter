using UnityEngine;
using System;
using Zenject;

public class PlayerBehavaviourInstaller : MonoInstaller<PlayerBehavaviourInstaller>
{
    [SerializeField]
    private PlayerConfiguration configuration;

    public override void InstallBindings()
    {
        Container.Bind<ICameraMotion>().To<CameraMotionComponent>().AsSingle();

        Container.BindInstances(configuration);
    }
}