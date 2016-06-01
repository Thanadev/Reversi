using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Move {

	protected Cell cell;
	protected PawnColor actorColor;
	protected List<Pawn> toFlip;
	

	public Move (Cell cell, PawnColor actorColor) {
		this.cell = cell;
		this.actorColor = actorColor;
		toFlip = new List<Pawn>();
	}

	public bool IsLegal () {
		Grid grid = Grid.GetInstance();
		bool legal = false;
		bool isAdjacent = false;

		for (int x = -1; x <= 1; x++) {
			for (int y = -1; y <= 1; y++) {
				Pawn sidePawn = grid.GetPawnAt((uint) (cell.Coordinates.x + x), (uint) cell.Coordinates.y);
				Pawn topOrBotPawn = grid.GetPawnAt((uint) cell.Coordinates.x, (uint) (cell.Coordinates.y + y));

				if ((sidePawn != null && sidePawn.color != actorColor) || (topOrBotPawn != null && topOrBotPawn.color != actorColor)) {
					Debug.Log("Adj");
					isAdjacent = true;
				}
			}
		}

		if (cell.ContainedPawn == null && isAdjacent) {
			if (IsLethal()) {
				legal = true;
			}
		}
		
		return legal;
	}

	public bool IsLethal () {
		bool lethal = false;
		Grid grid = Grid.GetInstance();

		for (int x = -1; x <= 1; x++) {
			for (int y = -1; y <= 1; y++) {
				bool isComplete = true;
				Vector2 direction = new Vector2(x, y);
				Vector2 coord = cell.Coordinates + direction;
				List<Pawn> alignedPawns = new List<Pawn>();

				do {
					isComplete = true;
					Pawn pawn = grid.GetPawnAt((uint)coord.x, (uint)coord.y);


					if (pawn != null) {
						if (pawn.color != actorColor) {
							alignedPawns.Add(pawn);
							isComplete = false;
						} else {
							foreach (Pawn p in alignedPawns) {
								toFlip.Add(p);
							}
						}
					}

					coord.x += direction.x;
					coord.y += direction.y;
				} while (!isComplete);
			}
		}

		if (toFlip.Count > 0) {
			lethal = true;
		}

		return lethal;
	}

	public void Execute () {
		foreach (Pawn pawn in toFlip) {
			pawn.Flip();
		}
	}
}
