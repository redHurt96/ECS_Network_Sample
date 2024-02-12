namespace EcsFramework
{
    public interface IInitializeSystem : ISystem
    {
        void Initialize(EcsWorld world);
    }
}