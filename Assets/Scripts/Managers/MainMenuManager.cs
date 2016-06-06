using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuManager : MonoBehaviour {

	public Button playButton;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void OnPlayPressed () {
		SoundManager.GetInstance().PlaySmashSound();
		StartCoroutine("LaunchGame");
		playButton.interactable = false;
	}

	public void OnQuitPressed () {
		Application.Quit();
	}
	
	public IEnumerator LaunchGame () {
		yield return new WaitForSeconds(1f);
		SceneManager.LoadSceneAsync(1);
	}
}
