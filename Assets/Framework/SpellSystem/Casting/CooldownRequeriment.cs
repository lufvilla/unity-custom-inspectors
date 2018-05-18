using Entites;
using UnityEngine;

namespace Framework.SpellSystem
{
	[CreateAssetMenu(menuName = "Game/Spell/Requeriment/Cooldown")]
	public class CooldownRequeriment : CastingRequeriment
	{
		public float CooldownTime = 1;
		
		[HideInInspector]
		public float CooldownLeft;

		public override bool IsMet(Entity entity)
		{
			return CooldownLeft <= 0;
		}

		public override void Casted(Entity entity)
		{
			CooldownLeft = CooldownTime;
			
			EventsManager.SubscribeToEvent(GameEvents.UPDATE, OnUpdate);
		}

		private void OnUpdate(object[] parametercontainer)
		{
			CooldownLeft = Mathf.Clamp(CooldownLeft - Time.deltaTime, 0, CooldownTime);
			
			if (CooldownLeft <= 0)
			{
				EventsManager.UnsubscribeToEvent(GameEvents.UPDATE, OnUpdate);
			}
		}

		private void OnEnable()
		{
			CooldownLeft = 0;
		}
	}
}
