using UnityEngine;
using System.Collections;
using Game;

public class PickUps : MonoBehaviour {
	private GameObject[] pickUpGameObjects;

	void Start () {
		pickUpGameObjects = new GameObject[Game.Config.numberOfObjects];
		const float radius = 5f;
		for (int i = 0; i < Game.Config.numberOfObjects; i++) {
			GameObject pickUp = GameObject.CreatePrimitive (PrimitiveType.Cube);
			float angle = i * Mathf.PI * 2 / Game.Config.numberOfObjects;
			pickUp.transform.localPosition = new Vector3 (Mathf.Cos (angle) * radius, 0.5f, Mathf.Sin (angle) * radius);
			pickUp.transform.localEulerAngles = new Vector3 (45, 45, 45);
			pickUp.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
			pickUp.transform.tag = Game.Config.pickUpTag;

			BoxCollider bc = pickUp.GetComponent<BoxCollider> ();
			bc.isTrigger = true;

			Renderer rend = pickUp.GetComponent<MeshRenderer> ();
			rend.material.color = new Color (1, 1, 0, 1);

			Rigidbody rb = pickUp.AddComponent<Rigidbody> ();
			rb.isKinematic = true;

			pickUpGameObjects[i] = pickUp;
		}
	}

	void Update () {
		for (int i = 0; i < Game.Config.numberOfObjects; i++) {
			pickUpGameObjects[i].transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);	
		}
	}
}
