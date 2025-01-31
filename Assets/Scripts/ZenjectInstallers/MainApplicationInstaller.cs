using UnityEngine;
using Zenject;

public class MainApplicationInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ICustomInputSystem>().To<IOSInputSystem>().AsSingle();
        Container.Bind<IOSInputSystem>().AsTransient().OnInstantiated<IOSInputSystem>((_context, _object) =>
        {
            _context.Container.Resolve<TickableManager>().Add(_object);
        });
    }
}