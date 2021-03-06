﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid : MonoBehaviour {

	public GameObject[] mapRows;
	protected Cell[,] map;
	protected static Grid instance;

	public static Grid GetInstance () {
		return instance;
	}

	void Awake () {
		if (instance != null) {
			this.enabled = false;
		} else {
			instance = this;
			map = new Cell[8,8];
			for (int i = 0; i < mapRows.Length; i++) {
				Cell[] cells = mapRows[i].GetComponentsInChildren<Cell>();
				cells = OrderCellsByPosition(cells);
				for (int j = 0; j < cells.Length; j++) {
					map[i, j] = cells[j];
					map[i, j].Coordinates = new Vector2(i, j);
					if ((i == 3 && j == 3) || (i == 4 && j == 4)) {
						Debug.Log(map[i, j].SpawnPawn(PawnColor.WHITE, true));
					} else if ((i == 3 && j == 4) || (i == 4 && j == 3)) {
						map[i, j].SpawnPawn(PawnColor.BLACK, true);
					}
				}
			}
		}
	}

	public Pawn GetPawnAt (uint x, uint y) {
		Pawn pawn = null;
		if (x < map.GetLength(0) && y < map.GetLength(1)) {
			pawn = map[x, y].ContainedPawn;
		}

		return pawn;
	}

	Cell[] OrderCellsByPosition (Cell[] cells) {
		bool ordered = true;
		do {
			ordered = true;
			for (int i = 1; i < cells.Length; i++) {
				if (cells[i-1].transform.position.x > cells[i].transform.position.x) {
					Cell tmpCell = cells[i];
					cells[i] = cells[i-1];
					cells[i-1] = tmpCell;
					ordered = false;
				}
			}
		} while (!ordered);

		return cells;
	}
	
	public List<Cell> PlayerPossibilities (PawnColor color) {
		List<Cell> cells = new List<Cell>();
		
		for (int x = 0; x < 8; x++) {
			for (int y = 0; y < 8; y++) {
				Move move = new Move(map[x, y], color);
				if (move.IsLegal()) {
					cells.Add(map[x, y]);
				}
			}
		}
		
		return cells;
	}
	
	public Score GetScore () {
		Score retValue = new Score(0,0);
		for (int x = 0; x < 8; x++) {
			for (int y = 0; y < 8; y++) {
				if (map[x, y].ContainedPawn != null) {
					if (map[x, y].ContainedPawn.color == PawnColor.WHITE) {
						retValue.whiteAlive++;
					} else {
						retValue.blackAlive++;
					}
					
				}
			}
		}
		
		return retValue;
	}
	
	public struct Score {
		public int whiteAlive;
		public int blackAlive;
		
		public Score (int whiteAlive, int blackAlive) {
			this.whiteAlive = whiteAlive;
			this.blackAlive = blackAlive;
		}
	}
}
