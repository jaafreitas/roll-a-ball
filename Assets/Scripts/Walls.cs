using UnityEngine;
using System.Collections;

public class Walls : MonoBehaviour {
	void CreateWall(int px, int pz, float sx, float sz) {
		GameObject wall = GameObject.CreatePrimitive (PrimitiveType.Cube);
		wall.transform.localPosition = new Vector3 (px, 0, pz);
		wall.transform.localScale = new Vector3 (sx, 2.0f, sz);
	}

	void Start () {
		// North Wall.
		CreateWall (0, 10, 20.5f, 0.5f);
		// South Wall.
		CreateWall (0, -10, 20.5f, 0.5f);
		// East Wall.
		CreateWall (10, 0, 0.5f, 20.5f);
		// West Wall.
		CreateWall (-10, 0, 0.5f, 20.5f);
	}	
}
