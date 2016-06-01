using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameSettings settings;
	public Player[] players;

	private static GameManager instance;

	

	public static GameManager GetInstance () {
		return instance;
	}

	void Awake () {
		if (instance != null) {
			Debug.LogError("Duplicate GameManager !");
			this.enabled = false;
		} else {
			instance = this;
		}
		Debug.Log("instance");
	}

	// Use this for initialization
	void Start () {
		foreach (Player player in players) {
			if (player.color == PawnColor.BLACK) {
				player.IsTurn = true;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void onPlayerPlayed (Player hasPlayed) {
		Debug.Log("Player " + hasPlayed.color.ToString() + " has played !");
		foreach (Player player in players) {
			if (player.color != hasPlayed.color) {
				player.enabled = true;
				player.IsTurn = true;
			} else {
				player.IsTurn = false;
				player.enabled = false;
			}
		}
	}
}
