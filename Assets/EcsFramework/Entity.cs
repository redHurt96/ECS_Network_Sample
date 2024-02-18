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

        public T Add<T>() where T : IComponent, new()
        {
            Type type = typeof(T);
            T component = new();
            
            if (_components.ContainsKey(type))
                throw new InvalidOperationException($"Component of type {type} already exists.");

            _components[type] = component;
            return component;
        }

        public T Get<T>() where T : IComponent => 
            (T)_components[typeof(T)];

        public void Remove<T>() where T : struct, IComponent
        {
            Type type = typeof(T);
            
            if (!_components.ContainsKey(type))
                throw new InvalidOperationException($"Component of type {type} doesn't exist.");
            
            _components.Remove(type);
        }

        public bool HasComponent<T>() where T : IComponent => 
            _components.ContainsKey(typeof(T));
    }
}
