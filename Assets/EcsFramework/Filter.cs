using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EcsFramework
{
    //todo добавить валидацию условий
    public class Filter : IEnumerable<Entity>
    {
        private readonly List<Func<Entity, bool>> _conditions = new();
        private readonly EcsWorld _ecsWorld;

        public Filter(EcsWorld world) => 
            _ecsWorld = world;

        public IEnumerator<Entity> GetEnumerator() =>
            _ecsWorld
                .Entities
                .Where(x => _conditions.All(y => y(x)))
                .GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => 
            GetEnumerator();

        public Filter With<T>() where T : IComponent
        {
            _conditions.Add(x => x.HasComponent<T>());
            return this;
        }

        public Filter Without<T>() where T : struct, IComponent
        {
            _conditions.Add(x => !x.HasComponent<T>());
            return this;
        }
    }
}