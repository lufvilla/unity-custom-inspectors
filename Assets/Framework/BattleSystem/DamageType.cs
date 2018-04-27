

using System;

namespace BattleSystem
{
    [Flags]
    public enum DamageType
    {
        // Base
        Unknown = 0,
        Environment = 1 << 0,
        
        // Normal
        Melee = 1 << 10,
        Range = 1 << 11,
        Special = 1 << 12,
        Block = 1 << 13,
        Knock = 1 << 14,
        
        // Spells
        Spell = 1 << 20,
        Stun = 1 << 21
    }
}

