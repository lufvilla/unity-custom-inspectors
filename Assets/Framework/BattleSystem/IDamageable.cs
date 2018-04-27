using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    public interface IDamageable
    {
        void TakeDamage(int damage, DamageType type = DamageType.Unknown, Transform origin = null);
    }
}

