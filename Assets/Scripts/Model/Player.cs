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
		if (isTurn) {
			Debug.Log(color.ToString() + " is playing");
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Input.GetMouseButtonUp(0) && Physics.Raycast(ray, out hit, 8)) {
				hit.collider.GetComponent<Cell>().SpawnPawn(this.color);
				isTurn = false;
				GameManager.GetInstance().onPlayerPlayed(this);
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
