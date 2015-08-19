using UnityEngine;
using System;
using System.Collections.Generic;

public class PathFinding {

	public class Node : IComparable, IEquatable<Node> {
		public int x;
		public int y;
		public double cost = double.MaxValue;
		public double estimatedCost = double.MaxValue;
		public Node from;
		public Node() {}
		public Node(int x, int y) {
			this.x = x;
			this.y = y;
		}
		public Node(int x, int y, int cost) {
			this.x = x;
			this.y = y;
			this.cost = cost;
		}

		public int CompareTo (object obj) {
			if (!(obj is Node)) return -1;

			Node o = (Node)obj;
			if (this.Equals(o)) {
				return 0;
			} else return 1;

		}

		public bool Equals (Node other) {
			return (x == other.x && y == other.y);
		}

	}

	public PathFinding() {}

	public List<Node> findPath(int[,] map, Node start, Node goal) {

		Stack<Node> visited = new Stack<Node>();
		Stack<Node> evaulate = new Stack<Node>();

		start.cost = 0;
		start.estimatedCost = start.cost + distance(start, goal);
		evaulate.Push(start);

		int totalLoops = 0;

		while (evaulate.Count > 0) {

			if (totalLoops > 2000) {
				Debug.LogError("Total loops has exceeded 2000. Bailing out.");
				return null;
			}
			totalLoops++;

			Node current = evaulate.Pop();

			if (current == goal) {
				// create path with visited nodes and the goal
				Debug.Log ("Best path from X: " + start.x + " Y: " + start.y + " -- To X: " + goal.x + " Y: " + goal.y);
				return bestPath(goal);
			}

			visited.Push (current);
			foreach(Node neighbor in getNeighbors(map, current)) {

				if (visited.Contains(neighbor)) {
					continue;
				}

				double score = current.cost + distance(current, neighbor);

				if (!evaulate.Contains(neighbor) || score < neighbor.cost) {

					neighbor.from = current;
					neighbor.cost = score;
					neighbor.estimatedCost = score + distance(neighbor, goal);

					if (!evaulate.Contains(neighbor)) {
						evaulate.Push (neighbor);
					}
				}

			}

		}

		return null;
	}


	protected List<Node> bestPath(Node current) {

		List<Node> path = new List<Node>();
		path.Add(current);
		while (current.from != null) {
			current = current.from;
			Debug.Log("X: " + current.x + " Y: " + current.y);
			path.Add(current);
		}
		Debug.Log("\n\n\n");

		return path;
	}
	
	protected List<Node> getNeighbors(int [,] map, Node node) {

		List<Node> neighbors = new List<Node>();
		int x = node.x;
		int y = node.y;

		for(int i = -1; i <= 1; i++) {
			if (x+i < 0 || x+i >= map.GetLength(0)) continue;

			for(int j = -1; j <= 1; j++) {
				if (y+j < 0 || y+j >= map.GetLength(1)) continue;

				if (x+i == x && y+j == y) continue;

				int n = map[x+i,y+j];

				//if (n > 0) continue; // This is an obsticle

				Node neighbor = new Node(x+i, y+j);
				neighbors.Add (neighbor);
			}
		}

		return neighbors;

	}

	protected double distance(Node a, Node b) {

		// TODO check if b has a cost of infinity, IE not passable
		// in that case return infinity
		return Math.Sqrt( Math.Pow((b.x - a.x),2) + Math.Pow((b.y - a.y),2));

	}

	protected double costEstimator(int[,] map, Node a, Node b) {
		return distance(a,b);
	}

}
