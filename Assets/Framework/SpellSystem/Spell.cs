using System.Linq;
using Entites;
using UnityEngine;

namespace Framework.SpellSystem
{
    [System.Serializable]
    [CreateAssetMenu(menuName = "Game/Spell/New Spell")]
    public class Spell : ScriptableObject
    {
        public string Name;
        public string Description;

        public CastingRequeriment[] Requeriments;
        
        public void Cast(Entity entity)
        {
            if (CanCast(entity))
            {
                Debug.Log("Casting: " + Name);
                CallCast(entity);
            }
            else
            {
                Debug.Log("Can't cast: " + Name);
            }
        }
        
        public bool CanCast(Entity entity)
        {
            return Requeriments.All(requirement => requirement.IsMet(entity));
        }

        private void CallCast(Entity entity)
        {
            foreach (var requeriment in Requeriments)
            {
                requeriment.Casted(entity);
            }
        }
    }
}
