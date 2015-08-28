using UnityEngine;
using System.Collections.Generic;
using Warlock;

namespace Warlock {
	[System.Serializable]
	public class Card : MonoBehaviour, IAction{

		public enum Type {
			None = 0,
			Instant,
			Spell,
			Equipment,
			Consumable
		}

		public enum RangeKind {
			None,
			Self,
			LineOfSight,
			AOE,
			Global
		}

		public string Name;
		public int Cost;
		public string CostFormula;
		public Type CardType = Card.Type.None;
		public RangeKind RangeKindType = Card.RangeKind.None;
		public int EffectRadius = 0;
		public string FlavorText;
		public List<Warlock.Stat> Stats;

		public Player CastOrigin;
		public ITarget CastTarget;

		void Awake() {
		}

		// Use this for initialization
		void Start () {
			DontDestroyOnLoad(this);
		}
		
		// Update is called once per frame
		void Update () {
		
		}

	}
}
