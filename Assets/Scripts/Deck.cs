using UnityEngine;
using System.Collections.Generic;
using Warlock;

public class Deck : MonoBehaviour {

	public List<Card> AllCards = new List<Card>();
	public Stack<Card> CurrentDeck = new Stack<Card>();
	public Stack<Card> Discarded = new Stack<Card>();

	public Player Owner;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Shuffle() {

		Debug.Log ("Shuffling " + Owner.name + "'s deck");
		List<Card> shuffled = new List<Card>();
		Card[] shuffleMe = new Card[AllCards.Count];
		AllCards.CopyTo(shuffleMe);
		List<Card> toShuffle = new List<Card>(shuffleMe);

		while (toShuffle.Count > 0) {
			int randomIndex = Random.Range(0, toShuffle.Count-1);
			CurrentDeck.Push (toShuffle[randomIndex]);
			toShuffle.RemoveAt (randomIndex);
		}

	}

	public Card Draw() {

		Debug.Log ("Drawing card for " + Owner.name);

		if (CurrentDeck.Peek() == null){
			Debug.Log ("No more cards in the deck");
			return null;
		}

		return CurrentDeck.Pop();
	}
}
