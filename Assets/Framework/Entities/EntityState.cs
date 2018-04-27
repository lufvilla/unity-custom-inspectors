using System.Collections.Generic;
using SpellSystem;
using UnityEngine;

namespace Entities
{
    [CreateAssetMenu(menuName = "Game/Entities/State")]
    public class EntityState : ScriptableObject
    {
        public int MaxHealth; 
        public int CurrentHealth;
        public int MaxSpirit;
        public int CurrentSpirit;
        public List<SpellDefinition> CurrentSpells;
    }
}
