using System;
using System.Collections.Generic;
using System.Linq;
using RH_Modules.Utilities.Extensions;
using UniRx;

namespace EcsFramework
{
    public class EcsWorld : IDisposable
    {
        internal readonly List<Entity> Entities = new();
        
        private readonly List<ISystem> _systems = new();
        private readonly List<IUpdateSystem> _updateSystems = new();
        private readonly CompositeDisposable _compositeDisposable = new();

        public void AddSystem(ISystem system)
        {
            _systems.Add(system);
            
            if (system is IUpdateSystem updateSystem)
                _updateSystems.Add(updateSystem);
            
            if (system is IDisposeSystem disposeSystem)
                _compositeDisposable.Add(disposeSystem);
        }

        public void Initialize() =>
            _systems
                .OfType<IInitializeSystem>()
                .ForEach(x => x.Initialize(this));

        public void Update() =>
            _updateSystems
                .ForEach(x => x.Update());

        public void Dispose() => 
            _compositeDisposable.Dispose();

        public Entity CreateNewEntity()
        {
            Entity instance = new();
            Entities.Add(instance);
            return instance;
        }
    }
}