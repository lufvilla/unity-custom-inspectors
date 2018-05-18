using Entites;
using UnityEngine;

namespace Framework.SpellSystem
{
    [CreateAssetMenu(menuName = "Game/Spell/Requeriment/Spirit")]
    public class SpiritRequeriment : CastingRequeriment
    {
        public int RequiredAmount = 10;

        public override bool IsMet(Entity entity)
        {
            return entity.Definition.State.CurrentSpirit >= RequiredAmount;
        }

        public override void Casted(Entity entity)
        {
            entity.Definition.State.CurrentSpirit -= RequiredAmount;
        }
    }
}
