using UnityEngine;
using System.Collections.Generic;

public class Corridor : MonoBehaviour {

	public List<DoorMarker> Doors = new List<DoorMarker>();
	public List<Room> ConnectedRooms;
	public List<Corridor> ConnectedCorridors;
	public List<Junction> ConnectedJunctions;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
