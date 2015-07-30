using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Game;

public class Player : MonoBehaviour {
	private Rigidbody rb;
	private int count;

	private Text countText;
	private Text winText;

	void Start () {
		transform.localPosition = new Vector3 (0, 0.5f, 0);
		rb = gameObject.AddComponent<Rigidbody> ();
		count = 0;

		// FIXME: there must be a better way to do this...
		Object[] obj = FindObjectsOfType (typeof(Text));
		foreach (Text t in obj)  {
			if (t.text.Equals("Win Text")) {
				winText = t;
			}
			if (t.text.Equals("Count Text")) {
				countText = t;
			}
		}

		SetCountText ();
		winText.text = "";
	}
	
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		
		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);
		
		rb.AddForce (movement * Game.Config.speed);
	}
	
	void OnTriggerEnter (Collider other) {
		other.gameObject.SetActive (false);
		if (other.gameObject.CompareTag (Game.Tag.PickUp))
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
	}
	
	void SetCountText () {
		countText.text = "Count: " + count.ToString ();
		if (count >= Game.Config.numberOfObjects)
		{
			winText.text = "You Win!";
		}
	}
}
