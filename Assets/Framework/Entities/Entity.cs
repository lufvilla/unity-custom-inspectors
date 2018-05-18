using System.Linq;
using Entities;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Entites
{
    public class Entity : MonoBehaviour
    {
        public EntityDefinition Definition;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var spell = Definition.StartingSpells.FirstOrDefault();

                if (spell != null)
                {
                    spell.Cast(this);
                }
            }

            EventsManager.TriggerEvent(GameEvents.UPDATE);
        }
    }
}