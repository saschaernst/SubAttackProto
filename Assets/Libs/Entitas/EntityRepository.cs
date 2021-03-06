﻿using ToolKit;
using System.Collections.Generic;
using System;

namespace Entitas {
    public partial class EntityRepository {
        readonly HashSet<Entity> _entities = new HashSet<Entity>(EntityEqualityComparer.comparer);
        readonly Dictionary<IEntityMatcher, EntityCollection> _collections = new Dictionary<IEntityMatcher, EntityCollection>();
        readonly List<EntityCollection>[] _collectionsForIndex;
        readonly ObjectPool<Entity> _entityPool;
        readonly int _totalComponents;
        int _creationIndex;
        Entity[] _entitiesCache;

        public EntityRepository(int totalComponents) : this(totalComponents, 0) {
        }

        public EntityRepository(int totalComponents, int startCreationIndex) {
            _totalComponents = totalComponents;
            _creationIndex = startCreationIndex;
            _collectionsForIndex = new List<EntityCollection>[totalComponents];
            _entityPool = new ObjectPool<Entity>(() => new Entity(_totalComponents));
        }

        public Entity CreateEntity() {
            var entity = _entityPool.Get();
            entity.creationIndex = _creationIndex++;
            _entities.Add(entity);
            _entitiesCache = null;
            entity.OnComponentAdded += onComponentAdded;
            entity.OnComponentReplaced += onComponentReplaced;
            entity.OnComponentWillBeRemoved += onComponentWillBeRemoved;
            entity.OnComponentRemoved += onComponentRemoved;
            return entity;
        }

        public void DestroyEntity(Entity entity) {
            entity.RemoveAllComponents();
            entity.OnComponentAdded -= onComponentAdded;
            entity.OnComponentReplaced -= onComponentReplaced;
            entity.OnComponentWillBeRemoved -= onComponentWillBeRemoved;
            entity.OnComponentRemoved -= onComponentRemoved;
            _entities.Remove(entity);
            _entitiesCache = null;
            _entityPool.Push(entity);
        }

        public void DestroyAllEntities() {
            var entities = GetEntities();
            foreach (var entity in entities) {
                DestroyEntity(entity);
            }
        }

        public bool HasEntity(Entity entity) {
            return _entities.Contains(entity);
        }

        public Entity[] GetEntities() {
            if (_entitiesCache == null) {
                _entitiesCache = new Entity[_entities.Count];
                _entities.CopyTo(_entitiesCache);
            }

            return _entitiesCache;
        }

        public EntityCollection GetCollection(IEntityMatcher matcher) {
            EntityCollection collection;
            if (!_collections.TryGetValue(matcher, out collection)) {
                collection = new EntityCollection(matcher);
                foreach (var entity in _entities) {
                    collection.AddEntityIfMatching(entity);
                }
                _collections.Add(matcher, collection);

                for (int i = 0, indicesLength = matcher.indices.Length; i < indicesLength; i++) {
                    var index = matcher.indices[i];
                    if (_collectionsForIndex[index] == null) {
                        _collectionsForIndex[index] = new List<EntityCollection>();
                    }
                    _collectionsForIndex[index].Add(collection);
                }
            }

            return collection;
        }

        void onComponentAdded(Entity entity, int index, IComponent component) {
            var collections = _collectionsForIndex[index];
            if (collections != null) {
                for (int i = 0, collectionsCount = collections.Count; i < collectionsCount; i++) {
                    collections[i].AddEntityIfMatching(entity);
                }
            }
        }

        void onComponentReplaced(Entity entity, int index, IComponent component) {
            var collections = _collectionsForIndex[index];
            if (collections != null) {
                for (int i = 0, collectionsCount = collections.Count; i < collectionsCount; i++) {
                    collections[i].UpdateEntity(entity);
                }
            }
        }

        void onComponentWillBeRemoved(Entity entity, int index, IComponent component) {
            var collections = _collectionsForIndex[index];
            if (collections != null) {
                for (int i = 0, collectionsCount = collections.Count; i < collectionsCount; i++) {
                    collections[i].WillRemoveEntity(entity);
                }
            }
        }

        void onComponentRemoved(Entity entity, int index, IComponent component) {
            var collections = _collectionsForIndex[index];
            if (collections != null) {
                for (int i = 0, collectionsCount = collections.Count; i < collectionsCount; i++) {
                    collections[i].RemoveEntity(entity);
                }
            }
        }
    }
}

