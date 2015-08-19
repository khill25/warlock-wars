using UnityEngine;
using System.Collections.Generic;

public class Room : MonoBehaviour {

	public int cellsWide = 3;
	public int cellsHigh = 3;
	public int X_Cell = -1;
	public int Y_Cell = -1;

	public int DoorX = -1;
	public int DoorY = -1;

	public List<DoorMarker> Doors = new List<DoorMarker>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
