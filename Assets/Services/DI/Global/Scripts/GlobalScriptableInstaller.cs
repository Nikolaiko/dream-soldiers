using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GlobalScriptableInstaller", menuName = "Installers/GlobalScriptableInstaller")]
public class GlobalScriptableInstaller : ScriptableObjectInstaller<GlobalScriptableInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<UserDataService>().To<PlayerPrefsStorage>().AsSingle();
    }
}