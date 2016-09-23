using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HexUI : MonoBehaviour {
	[SerializeField]private InputField _gridSizeX;
	[SerializeField]private InputField _gridSizeY;
	[SerializeField]private InputField _hexSize;
	private HexGrid _grid;
	private float _max = 50f;


	private void Start( ){
		_grid = GetComponent<HexGrid> ();
	}

	public void InitGrid() {
		_grid.GridSizeX = MaxValue(float.Parse (_gridSizeX.text));
		_grid.GridSizeY = MaxValue(float.Parse (_gridSizeY.text));
		_grid.Radius = MaxValue(float.Parse (_hexSize.text));
	}

	private float MaxValue(float value) {
		if (value > _max) {
			return _max;
		} else {
			return value;
		}
	}
}
