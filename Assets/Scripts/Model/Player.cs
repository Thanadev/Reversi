using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public PawnColor color;
	protected bool isTurn;


	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (isTurn == true) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Input.GetMouseButtonUp(0) && Physics.Raycast(ray, out hit, 8)) {
				if (hit.collider.GetComponent<Cell>().SpawnPawn(this.color)) {
					GameManager.GetInstance().onPlayerPlayed(this);
				}
			}
		}
	}

	public bool IsTurn {
		get {
			return this.isTurn;
		}
		set {
			isTurn = value;
		}
	}
}
