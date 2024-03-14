using System;
using System.Collections.Generic;

namespace EcsFramework
{
    public class Entity
    {
        public readonly Guid Id;

        private readonly Dictionary<Type, IComponent> _components = new();

        public Entity() => 
            Id = Guid.NewGuid();

        public T Get<T>() where T : IComponent => 
            (T)_components[typeof(T)];

        public void Set<T>(T component) where T : struct, IComponent => 
            _components[typeof(T)] = component;

        public void Remove<T>() where T : struct, IComponent
        {
            Type type = typeof(T);
            
            if (!_components.ContainsKey(type))
                throw new InvalidOperationException($"Component of type {type} doesn't exist.");
            
            _components.Remove(type);
        }

        public bool HasComponent<T>() where T : struct, IComponent => 
            _components.ContainsKey(typeof(T));
    }
}
