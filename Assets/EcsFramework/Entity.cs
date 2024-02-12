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

        public void Add<T>() where T : struct, IComponent
        {
            Type type = typeof(T);
            T component = new();
            
            if (_components.ContainsKey(type))
                throw new InvalidOperationException($"Component of type {type} already exists.");

            _components[type] = component;
        }

        public void Modify<T>(Action<T> modifyAction) where T : struct, IComponent
        {
            Type type = typeof(T);
            
            if (_components.TryGetValue(type, out IComponent component)) 
                modifyAction((T)component);
            else
                throw new InvalidOperationException($"Component of type {type} does not exist.");
        }

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
