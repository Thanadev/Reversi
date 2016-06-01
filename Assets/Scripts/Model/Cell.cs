using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour {

	protected Vector2 coordinates;
	protected Pawn containedPawn;
	protected GameObject pawnReference;

	// Use this for initialization
	void Start () {
		pawnReference = Resources.Load<GameObject>("Prefabs/Pawn");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool SpawnPawn (PawnColor color) {
		Move move = new Move (this, color);
		bool isValid = false;

		if (move.IsLegal()) {
			GameObject pawn = Instantiate(pawnReference, transform.TransformPoint(Vector3.zero), pawnReference.transform.rotation) as GameObject;
			pawn.GetComponent<Pawn>().ToCell(this);
			if (color != GameManager.GetInstance().settings.pawnDefaultColor) {
				containedPawn.Flip();
			}
			if (containedPawn == pawn.GetComponent<Pawn>()) {
				isValid = true;			
			}
		}

		return isValid;
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
