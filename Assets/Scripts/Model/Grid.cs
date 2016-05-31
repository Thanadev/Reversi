using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

	public GameObject[] mapRows;
	protected Cell[,] map;

	void Awake () {
		map = new Cell[8,8];
		for (int i = 0; i < mapRows.Length; i++) {
			Cell[] cells = mapRows[i].GetComponentsInChildren<Cell>();
			cells = OrderCellsByPosition(cells);
			for (int j = 0; j < cells.Length; j++) {
				map[i, j] = cells[j];
			}
		}
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
}
