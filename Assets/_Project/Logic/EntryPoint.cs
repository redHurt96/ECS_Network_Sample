using System;
using System.Numerics;
using _Project.Logic.Core.Components;
using _Project.Logic.Core.Systems;
using EcsFramework;
using Zenject;

namespace _Project.Logic
{
    public class EntryPoint : IInitializable, ITickable, IDisposable
    {
        private EcsWorld _world;

        public void Initialize()
        {
            EcsWorld world = new();
            world.AddSystem(new ProvideInput());
            
            Entity player = world.CreateNewEntity();
            player.Set<Position>(new() { Value = Vector3.Zero });
            
            world.Initialize();
            _world = world;
        }

        public void Tick() => 
            _world.Update();

        public void Dispose() => 
            _world.Dispose();
    }
}
