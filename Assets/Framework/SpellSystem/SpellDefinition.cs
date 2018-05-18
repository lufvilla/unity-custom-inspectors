﻿using UnityEngine;

namespace SpellSystem
{
    sealed public class SpellDefinition : ScriptableObject
    {
        [Header("UI")]
        public string Name = string.Empty;
        public string Description = string.Empty;
        public Texture2D Icon;
        
        [Header("Cast")]
        public GameObject Prefab;
        public GameObject HitEffect;
        public GameObject DeathEffect;
        public float Cooldown = 1f;
        public int SpiritCost;
        
        [Header("Damage")]
        public int Damage;
        public int DamageMultiplier;
        
        [Header("Sounds")]
        public AudioClip CastSound;
        public AudioClip DeathSound;
        
        [Header("Projectile")]
        public float Speed = 0f;
        public float DestroyAfterTime = 1f;
        public bool DestroyOnCollision = true;

        [Header("AoE")]
        public float EffectRadius = 1f;
        public LayerMask EffectLayer;
        
        
        public static void Cast(SpellDefinition definition, Transform origin, Quaternion rotation)
        {
            //var newSpell = Instantiate(definition.Prefab, origin.position, rotation);

            /*var spellComponent = newSpell.GetComponent<SpellBehaviour>();
            
            if (spellComponent != null)
            {
                spellComponent.Definition = definition;
            }*/
        }
        
        public static void Cast(SpellDefinition definition, Transform origin)
        {
            Cast(definition, origin, origin.rotation);
        }
    }
}