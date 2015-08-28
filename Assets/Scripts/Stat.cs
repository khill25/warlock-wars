using UnityEngine;
using UnityEditor;
using System.Collections;

namespace Warlock {
	[System.Serializable]
	public class Stat : UnityEngine.Object {

		public enum Type {
			None = 0,
			Attack,
			Defence,
			Absorb,
			Block,
			CardCapacity,
		}

	public string Name;// {get;set;}
	public int Value;// {get;set;}
	public Type StatType;// {get;set;}
	}
}