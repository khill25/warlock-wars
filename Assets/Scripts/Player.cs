using UnityEngine;
using System.Collections.Generic;
using Warlock;

public class Player : MonoBehaviour, ITarget {

	public int HP;
	public int TotalActionPoints;
	public int RemainingActionPoints;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool CanPlayCard(Card card) {
		return false;
	}

	public bool IsCasting() {
		return false;
	}

	public bool isDead() {
		return HP <= 0;
	}

	public void PlayCard(Card card, Player target) {

		// Do card effects on target

	}

	public void ApplyStats(List<Stat> appliedStats) {

	}

	public void ApplyDamage(int damage) {
		HP = HP - damage;
	}


}
