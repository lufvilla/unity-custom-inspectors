using System.Collections;
using System.Collections.Generic;
using Entites;
using UnityEngine;

namespace Framework.SpellSystem
{
    public abstract class CastingRequeriment : ScriptableObject
    {
        public abstract bool IsMet(Entity entity);

        public virtual void Casted(Entity entity) {}
    }
}

