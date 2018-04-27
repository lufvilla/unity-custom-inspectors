using BattleSystem;
using UnityEngine;

namespace Entites
{
    public abstract class Entity : MonoBehaviour, IDamageable
    {
        public virtual void TakeDamage(int damage, DamageType type = DamageType.Unknown, Transform origin = null)
        {
            
        }
    }
}

