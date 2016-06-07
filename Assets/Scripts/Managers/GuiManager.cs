using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GuiManager : MonoBehaviour {
	
	public Button passTurn;
	public Text winSentence;
	public Text blackTurnText;
	public Text whiteTurnText;
	public RectTransform whiteScorePanel;
	public RectTransform blackScorePanel;
	public Text[] blackCounters;
	public Text[] whiteCounters;
	public GameObject menuDialogBox;
	
	private GameManager gm;
	private bool showMenuDialogBox;
	
	private static GuiManager instance;

	// Use this for initialization
	void Awake () {
		if (instance != null) {
			this.enabled = false;
		} else {
			instance = this;
		}

		showMenuDialogBox = false;

	}
	
	void Start () {
		gm = GameManager.GetInstance();
		if (gm.settings.isTablet) {
			blackScorePanel.rotation = Quaternion.Euler(0, 0, 270);
			whiteScorePanel.rotation = Quaternion.Euler(0, 0, 90);
		} else {
			blackScorePanel.rotation = Quaternion.Euler(0, 0, 0);
			whiteScorePanel.rotation = Quaternion.Euler(0, 0, 0);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.Escape)) {
			ToggleMenuDialogBox();
		}
	}
	
	public static GuiManager GetInstance () {
		return instance;
	}

	public void OnTurnEnded (PawnColor playingColor, Grid.Score score) {
		if (playingColor == PawnColor.BLACK) {
			blackTurnText.text = "It's your turn.";
			whiteTurnText.text = "It's your opponent's turn.";
		} else {
			blackTurnText.text = "It's your opponent's turn.";
			whiteTurnText.text = "It's your turn.";
		}

		foreach (Text displayText in blackCounters) {
			displayText.text = score.blackAlive.ToString();
		}

		foreach (Text displayText in whiteCounters) {
			displayText.text = score.whiteAlive.ToString();
		}
		
	}
	
	public void DisplayWin (string text) {
		winSentence.gameObject.SetActive(true);
		winSentence.text = text;
	}
	
	public void TogglePassTurnButton () {
		passTurn.interactable = !passTurn.interactable;
	}

	public void ToggleMenuDialogBox () {
		SoundManager.GetInstance().PlaySmashSound();
		showMenuDialogBox = !showMenuDialogBox;
		menuDialogBox.SetActive(showMenuDialogBox);
	}
	
	public void OnPassTurn () {
		Debug.Log("Pass");
		gm.OnPlayerPassed();
	}

	public void OnConfirmMenu () {
		SceneManager.LoadSceneAsync("menu");
	}
	
	private void RotateScoresPanels () {
		
	}
}
