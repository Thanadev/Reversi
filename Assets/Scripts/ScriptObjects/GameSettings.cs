using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Game/Settings", fileName = "Settings")]
public class GameSettings : ScriptableObject {
	public float pawnHeight = 0.2f;
	public PawnColor pawnDefaultColor = PawnColor.WHITE;
}
