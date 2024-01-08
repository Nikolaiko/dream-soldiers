using UnityEngine;
using Zenject;

public class MainScreenMonoInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<MainScreenUI>().FromComponentInHierarchy().AsSingle();
        Container.Bind<SaveSlotsUI>().FromComponentInHierarchy().AsSingle();
    }
}