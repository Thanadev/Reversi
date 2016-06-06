using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameSettings settings;
	public Player[] players;

	private static GameManager instance;
	
	private PawnColor playingColor;
	private Grid grid;
	private GuiManager gui;
	private SoundManager sm;
	

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
		grid = Grid.GetInstance();
		gui = GuiManager.GetInstance();
		sm = SoundManager.GetInstance();
		playingColor = PawnColor.BLACK;
		
		foreach (Player player in players) {
			if (player.color == playingColor) {
				player.IsTurn = true;
			}
		}

		gui.OnTurnEnded(playingColor, grid.GetScore());
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public void OnPlayerPassed () {
		gui.TogglePassTurnButton();
		if (FindPlayerWithColor(playingColor) != null) {
			onPlayerPlayed(FindPlayerWithColor(playingColor));
		} else {
			Debug.Log("Could not find player with this color");
		}
	}

	public void onPlayerPlayed (Player hasPlayed) {
		Debug.Log("Player " + hasPlayed.color.ToString() + " has played !");
		
		if (playingColor == PawnColor.WHITE) {
			playingColor = PawnColor.BLACK;
		} else {
			playingColor = PawnColor.WHITE;
		}
		
		if (grid.PlayerPossibilities(PawnColor.BLACK).Count == 0 && grid.PlayerPossibilities(PawnColor.WHITE).Count == 0) {
			ResolveScore();
		} else if (grid.PlayerPossibilities(playingColor).Count == 0) {
			gui.TogglePassTurnButton();
			if (FindPlayerWithColor(playingColor) != null) {
				Debug.Log("Passing turn");
			} else {
				Debug.Log("Could not find player with this color");
			}
		}
		
		foreach (Player player in players) {
			if (player.color != hasPlayed.color) {
				player.enabled = true;
				player.IsTurn = true;
				Debug.Log(player.color);
			} else {
				player.IsTurn = false;
				player.enabled = false;
			}
		}

		sm.PlayPawnPlacementSound();
		gui.OnTurnEnded(playingColor, grid.GetScore());
	}
	
	private Player FindPlayerWithColor (PawnColor color) {
		Player retPlayer = null;
		
		foreach (Player player in players) {
			if (player.color == color) {
				retPlayer = player;
			}
		}
		
		return retPlayer;
	}
	
	private void ResolveScore () {
		Grid.Score score = grid.GetScore();
		
		if (score.blackAlive > score.whiteAlive) {
			gui.DisplayWin("PLAYER BLACK WINS !!");
		} else {
			gui.DisplayWin("PLAYER WHITE WINS !!");
		}
		
	}
}
