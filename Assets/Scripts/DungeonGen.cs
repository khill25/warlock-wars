using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DungeonGen : MonoBehaviour {

	public int MaxX = 5;
	public int MaxZ = 5;
	public float ScaleMultiplier = 13.0f;
	public int MaxRooms = 15;
	public int MinRooms = 1;
	protected int[,] cells;
	public int MaxAttempts = 30;
	public List<Room> rooms = new List<Room>();
	
	// TODO
	/*
	 * Assertions/parameters around placement of rooms,
	 * cooridor structures, and junctions
	 */

	public Room roomPrefab;

	void init() {

		cells = new int[MaxX,MaxZ];

		for(int x = 0; x < MaxX; x++) {
			for(int z = 0; z < MaxZ; z++) {
				cells[x,z] = -1;
			}
		}

	}

	void Awake() {
		GenerateDungeon();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GenerateDungeon() {

		init ();
		PlaceRooms();

	}

	protected void PlaceRooms() {

		Room currentRoom = Instantiate<Room>(roomPrefab); // make a room
		int currentAttempts = 0;

		while (currentAttempts < MaxAttempts) {

			int rand = (int)(Random.value * 100);
			int xCell = rand % MaxX;
			rand = (int)(Random.value * 100);
			int yCell = rand % MaxZ;

			if (attemptRoomPlacement(currentRoom, xCell, yCell)) {
				currentAttempts = 0;

				currentRoom.transform.position = new Vector3(xCell*ScaleMultiplier, 0, yCell*ScaleMultiplier);

				rand = (int)(Random.value * 100) % 4;
				// 0 = 0
				// 1 = 90
				// 2 = 180
				// 3 = 270
				currentRoom.transform.Rotate(0,rand * 90,0);

				this.rooms.Add (currentRoom);
				currentRoom = Instantiate<Room>(roomPrefab);
			} else {
				currentAttempts++;
			}

			if (this.rooms.Count >= MaxRooms) {
				break; // We don't want to create any more
			}
		}

		if (this.rooms.Count < MinRooms) {
			Debug.Log ("Create more rooms. Didn't create enough rooms to meet the minimum number.");
		}

		// We don't want this one since we might have run out of attempts
		Destroy(currentRoom.gameObject);

		// Rooms should all be placed
		Debug.Log("Created " + this.rooms.Count + " rooms");

	}

	protected bool attemptRoomPlacement(Room room, int x, int y) {

		// If there is nothing here, we have found a place!
		if(cells[x,y] == -1) {
			cells[x,y] = 1;
			return true;
		}

		// Nope this cell is occupied.
		return false;

	}

	public void SaveDungeon() {
		// x,y,rotation, any other room info
	}

}
