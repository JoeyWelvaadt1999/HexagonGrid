using UnityEngine;
using System.Collections;

public class HexGrid : MonoBehaviour {
	[SerializeField]private GameObject _hexagon;
	private float _gridSizeX;
	public float GridSizeX {
		get { 
			return _gridSizeX;
		} set { 
			_gridSizeX = value;
		}
	}

	private float _gridSizeY;
	public float GridSizeY {
		get { 
			return _gridSizeY;
		} set { 
			_gridSizeY = value;
		}
	}

	private float _radius;
	public float Radius {
		get { 
			return _radius;
		} set { 
			_radius = value;
		}
	}

	private CalculateHex _hex;
	private Vector3 _position;

	public void Create() {
		Debug.Log (_gridSizeX);
		Debug.Log (_gridSizeY);
		DestroyGrid ();
		CreateGrid ();
	}

	private void CreateGrid () {
		for (int x = 0; x < _gridSizeX; x++) {
			for (int z = 0; z < _gridSizeY; z++) {
				
				GameObject newHex = Instantiate (_hexagon, Vector3.zero, Quaternion.identity) as GameObject;
				_hex = newHex.GetComponent<CalculateHex> ();
				_hex.Radius = _radius;
				_position = new Vector3 ((x + z * 0.5f - z / 2) * _hex.Width - _gridSizeX / 2, 0, z * _hex.Height * 0.75f - _gridSizeY / 2);
				newHex.transform.position = _position;
				_hex.CreateHexagon (_position);
			}
		}
	}

	private void DestroyGrid() {
		CalculateHex[] _hexagons = FindObjectsOfType<CalculateHex> ();
		for (int i = 0; i < _hexagons.Length; i++) {
			Destroy (_hexagons [i].gameObject);
		}
	}
}
