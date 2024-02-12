using Zenject;

namespace _Project.Logic.Infrastructure
{
    public class MainSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<EntryPoint>().AsSingle().NonLazy();
        }
    }
}