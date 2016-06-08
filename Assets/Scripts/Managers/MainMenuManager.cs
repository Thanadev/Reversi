using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuManager : MonoBehaviour {

	public Button playButton;
	public Text tabletText;
	public GameSettings settings;

	// Use this for initialization
	void Start () {
		ActualizeTabletText();
	}
	
	public void OnPlayPressed () {
		SoundManager.GetInstance().PlaySmashSound();
		StartCoroutine("LaunchGame");
		playButton.interactable = false;
	}

	public void OnQuitPressed () {
		SoundManager.GetInstance().PlaySmashSound();
		Application.Quit();
	}
	
	public IEnumerator LaunchGame () {
		yield return new WaitForSeconds(0.4f);
		SceneManager.LoadSceneAsync(1);
	}
	
	public void ToggleTabletMode () {
		SoundManager.GetInstance().PlaySmashSound();
		settings.isTablet = !settings.isTablet;
		ActualizeTabletText();
	}
	
	private void ActualizeTabletText () {
		if (settings.isTablet) {
			tabletText.text = "Tablet mode enabled";
		} else {
			tabletText.text = "Tablet mode disabled";
		}
	}

}
