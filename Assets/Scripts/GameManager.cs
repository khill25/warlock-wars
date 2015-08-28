using UnityEngine;
using System.Collections.Generic;
using Warlock;

public class GameManager : MonoBehaviour {

	public Stack<Card> CardStack = new Stack<Card>();
	public List<Player> Players = new List<Player>();

	public int turnCount = 0;
	public Player CurrentTurn;
	public List<Player> TurnOrder = new List<Player>();
	public List<Player> TurnsEntered = new List<Player>();

	/*
	 * Game State
	 * Idle
	 * -(1)Players entering turn
	 *   Resolve entered turn actions in order
	 *   Prompt target's for response
	 *   Resolve card stack
	 *   All Players pass, back to (1)
	 * 
	 */ 

	protected enum GameState {
		Idle = 0,
		PlayersEnteringTurns,
		ResolvingTurns,
		AwaitingPlayerResponse,
		ResolvingCardStack,
		RoundOver,
		PlayerDeath,
		PlayerWin
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	protected void StartNewTurn() {

	}

	public void FinishTurnForPlayer(Player player) {

	}

	protected void PromptNextPlayer() {
	}
	
	// When the player has entered the action they are using this turn
	public void SubmitActionRound(IAction action, Player player, ITarget target) {

		if (action is Card) {
			CastCard(action as Card, player, target);
		}

		PromptNextPlayer();
	}

	protected void CastCard(Card card, Player origin, ITarget target) {
		card.CastOrigin = origin;
		card.CastTarget = target;
		CardStack.Push (card);
		if (target is Player) {
			AlertPlayerForResponse(target as Player, origin, card);
		}
	}

	protected void AlertPlayerForResponse(Player target, Player origin, Card card) {
		
	}

	// Returns true if finished
	// False if there is more work to be done
	protected bool ResolveCardStack() {
		return true;
	}
}
