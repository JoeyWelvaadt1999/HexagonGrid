using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(CalculateHex))]
public class HexagonMesh : MonoBehaviour {
	private Mesh _mesh;
	private CalculateHex _hex;
	private List<Vector3> _vertices = new List<Vector3>();
	private List<int> _triangles = new List<int>();
	private List<Vector2> _uvs = new List<Vector2>();
	private MeshRenderer _mr;

	private void Start() {

		_mr = GetComponent<MeshRenderer> ();
		StartCoroutine (ColorSwap());
		_mesh = GetComponent<MeshFilter> ().mesh;
		_hex = GetComponent<CalculateHex> ();
		_vertices = _hex.Points;
		Triangulate ();
		UVMapping ();
		_mesh.Clear ();
		_mesh.Optimize ();
		_mesh.vertices = _vertices.ToArray ();
		_mesh.triangles = _triangles.ToArray ();
		_mesh.uv = _uvs.ToArray ();
		_mesh.RecalculateNormals ();		
		transform.position = new Vector3(0, 0, 0);
	}
		


	private void Triangulate() {
		for (int i = 0; i < 6; i++) {
			_triangles.Add (0);
			_triangles.Add (i + 1);
			if (i + 2 > 6) {
				_triangles.Add (1);
			} else {
				_triangles.Add (i + 2);
			}
		}
	}

	private void UVMapping() {
//		for (int i = 0; i < _vertices.Count; i++) {
//			_uvs.Add (new Vector2 (_vertices[i].x + transform.position.x * _hex.Width, _vertices[i].z + transform.position.z * _hex.Height));
//		}
		_uvs.Add(new Vector2(0f, 0f));
		_uvs.Add(new Vector2(0f, _hex.Height * 0.5f));
		_uvs.Add(new Vector2(_hex.Width * 0.5f, _hex.Height * 0.25f));
		_uvs.Add(new Vector2(_hex.Width * 0.5f, _hex.Height * -0.25f));
		_uvs.Add(new Vector2(0f, _hex.Height * -0.5f));
		_uvs.Add(new Vector2(_hex.Width * -0.5f, _hex.Height * -0.25f));
		_uvs.Add(new Vector2(_hex.Width * -0.5f, _hex.Height * 0.25f));
	}

	private IEnumerator ColorSwap() {
		while (true) {
//			_mr.material.color = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f), 0.7ff);
			yield return new WaitForSeconds (10f);
		}
	}

}
