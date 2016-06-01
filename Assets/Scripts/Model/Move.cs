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
		bool legal = false;
		
		if (cell.ContainedPawn == null && IsLethal()) {
			legal = true;
		}
		
		return legal;
	}

	public bool IsLethal () {
		bool lethal = true;
		
		return lethal;
	}

	public void Execute () {
	}
}
