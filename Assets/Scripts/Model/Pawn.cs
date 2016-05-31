using UnityEngine;
using System.Collections;

public enum PawnColor {BLACK, WHITE};

public class Pawn : MonoBehaviour {

	public PawnColor color;
	protected Vector2 coordinates;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Flip () {
		if (color == PawnColor.WHITE) {
			color = PawnColor.BLACK;
		} else {
			color = PawnColor.WHITE;
		}

		transform.Rotate(180, 0, 0);
	}

	public void ToCell (Cell cell) {
		cell.ContainedPawn = this;
		this.coordinates = cell.Coordinates;
	}
}
