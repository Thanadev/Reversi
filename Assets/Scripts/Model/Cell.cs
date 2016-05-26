using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour {

	protected Vector2 coordinates;
	protected Pawn containedPawn;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Vector2 Coordinates {
		get {
			return this.coordinates;
		}
		set {
			coordinates = value;
		}
	}

	public Pawn ContainedPawn {
		get {
			return this.containedPawn;
		}
		set {
			containedPawn = value;
		}
	}
}
