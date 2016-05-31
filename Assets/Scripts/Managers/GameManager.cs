using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameSettings settings;

	private static GameManager instance;

	Player[] players;

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
		players = GameObject.FindObjectsOfType<Player>();
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
				player.IsTurn = true;
			}
		}
	}
}
