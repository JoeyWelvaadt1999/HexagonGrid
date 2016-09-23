using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CalculateHex : MonoBehaviour {
	private float _degrees = 60;
	private float _maxDegrees = 360;
	private float _radius;
	public float Radius {
		get {
			return _radius;
		} set { 
			_radius = value;
		}
	}
	private List<Vector3> _points = new List<Vector3>();
	public List<Vector3> Points {
		get { 
			return _points;
		}
	}

	public float Height {
		get {
			return _radius * 2;
		}
	}

	public float Width {
		get { 
			return ( Mathf.Sqrt (3) / 2) * Height;
		}
	}


	private void Start() {
		
	}

	public void CreateHexagon (Vector3 _center) {
		_points.Add (_center);
		for (int i = 0; i < _maxDegrees / _degrees; i++) {
			float x = _center.x + _radius * Mathf.Sin ((_degrees * i) * Mathf.Deg2Rad);
			float z = _center.z + _radius * Mathf.Cos ((_degrees * i) * Mathf.Deg2Rad);
			Vector3 newPoint = new Vector3 (x, 0, z);
			_points.Add (newPoint);
		}
	}
//
//	void OnDrawGizmos() {
//		for (int i = 0; i < _points.Count - 2; i++) {
//			Gizmos.DrawLine (_points [i+1], _points [i+2]);
//		}
//
//		Gizmos.DrawLine (_points [_points.Count-1], _points [1]);
//	}
}
