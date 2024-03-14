using _Project.Logic.Core.Components;
using _Project.Logic.Extensions;
using EcsFramework;
using UnityEngine;
using static UnityEngine.Random;

namespace _Project.Logic.Core.Systems
{
    public class ProvideInput : IInitializeSystem, IUpdateSystem
    {
        private Filter _filter;

        public void Initialize(EcsWorld world) =>
            _filter = new Filter(world)
                .With<Position>();

        public void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                foreach (Entity entity in _filter)
                {
                    Position position = entity.Get<Position>();
                    position.Value = insideUnitSphere.ToSystem();
                    entity.Set(position);
                }
            }
        }
    }
}
