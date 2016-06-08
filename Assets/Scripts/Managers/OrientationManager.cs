using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OrientationManager : MonoBehaviour {

	public GameSettings settings;
	public RectTransform[] guiObjects;
	
	private GuiOrientation orientation;

	// Use this for initialization
	void Start () {
		ActualizeOrientation();
	}
	
	public void NextOrientation () {
		orientation = settings.orientation;
		if ((int) orientation == ((int) GuiOrientation.NB_ORIENTATION) - 1) {
			settings.orientation = 0;
		} else {
			settings.orientation++;
		}
		
		ActualizeOrientation();
	}
	
	private void ActualizeOrientation () {
		orientation = settings.orientation;
		foreach (RectTransform element in guiObjects) {
			if (orientation == GuiOrientation.BOT) {
				element.rotation = Quaternion.Euler(0, 0, 0);
			} else if (orientation == GuiOrientation.RIGHT) {
				element.rotation = Quaternion.Euler(0, 0, 270);
			} else {
				element.rotation = Quaternion.Euler(0, 0, 90);
			}
		}
	}
}
