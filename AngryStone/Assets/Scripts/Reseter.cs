using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reseter : MonoBehaviour {

	public Rigidbody2D projecTile;
	private float resetSpeed = 0.25f;
	private float resetSpeedSqr;
	private SpringJoint2D Spring; 
	void Start () {
		resetSpeedSqr = resetSpeed * resetSpeed;
		Spring = projecTile.GetComponent <SpringJoint2D> ();
	}
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) {
			Reset ();
		}

		if (Spring == null && projecTile.velocity.magnitude < resetSpeedSqr) {
			Reset ();
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.GetComponent <Rigidbody2D> () == projecTile) {
			Reset ();
		}	
	} 
	void Reset () {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
