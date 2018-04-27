using System.Collections.Generic;
using SpellSystem;
using UnityEngine;

namespace Entities
{
    [CreateAssetMenu(menuName = "Game/Entities/Entity")]
    public sealed class EntityDefinition : ScriptableObject
    {
        public string Name = string.Empty;
        public int MaxHealth = 100;
        public int StartingHealth = 100;
        public float MovementSpeed = 10;
        public float RotationSpeed = 10;
        public int MaxSpirit = 100;
        public int StartingSpirit = 0;
        public bool IgnoreDifficult = false;
        public List<SpellDefinition> StartingSpells;
        public EntityState State;
    }
}

