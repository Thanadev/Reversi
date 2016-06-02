using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GuiManager : MonoBehaviour {
	
	public Button passTurn;
	public Text winSentence;
	
	private GameManager gm;
	
	private static GuiManager instance;

	// Use this for initialization
	void Awake () {
		if (instance != null) {
			this.enabled = false;
		} else {
			instance = this;
		}
	}
	
	void Start () {
		gm = GameManager.GetInstance();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public static GuiManager GetInstance () {
		return instance;
	}
	
	public void DisplayWin (string text) {
		winSentence.text = text;
	}
	
	public void TogglePassTurnButton () {
		passTurn.interactable = !passTurn.interactable;
	}
	
	public void OnPassTurn () {
		Debug.Log("Pass");
		gm.OnPlayerPassed();
	}
}
