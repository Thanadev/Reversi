using UnityEngine;
using System.Collections;

public enum GuiOrientation {LEFT, RIGHT, BOT, NB_ORIENTATION};

[CreateAssetMenu(menuName = "Game/Settings", fileName = "Settings")]
public class GameSettings : ScriptableObject {
	public float pawnHeight = 0.2f;
	public PawnColor pawnDefaultColor = PawnColor.WHITE;
	public bool isTablet = true;
	public GuiOrientation orientation = GuiOrientation.BOT;
}
