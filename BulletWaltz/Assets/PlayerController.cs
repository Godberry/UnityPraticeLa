using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D rigidbody2D;
	public float ForceValueMove;
	public float MaxSpeed;
	public float DecreaseingSpeed;
	public ParticleSystem PlayerKillEffect;
	public AudioSource DieAudio;

	// Use this for initialization
	void Start () {
		rigidbody2D = this.GetComponent <Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		Vector2 force = Vector2.zero;

		if (Input.GetKey (KeyCode.UpArrow)) {
			force += new Vector2 (0, ForceValueMove);
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			force -= new Vector2 (0, ForceValueMove);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			force += new Vector2 (ForceValueMove, 0);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			force -= new Vector2 (ForceValueMove, 0);
		}

		if (force != Vector2.zero) {
			float fSpeed = rigidbody2D.velocity.magnitude;
			rigidbody2D.AddForce (force);
			if (fSpeed > MaxSpeed) {
				fSpeed = MaxSpeed;
			}
			rigidbody2D.velocity = rigidbody2D.velocity.normalized * fSpeed;
		}
		else {
			float fSpeed = rigidbody2D.velocity.magnitude;
			fSpeed -= DecreaseingSpeed;
			if (fSpeed < 0) {
				fSpeed = 0;
			}
			rigidbody2D.velocity = rigidbody2D.velocity.normalized * fSpeed;
		}
		
		// face
		if (force == Vector2.zero || rigidbody2D.velocity == Vector2.zero) {
			this.transform.eulerAngles = Vector3.zero;
		}
		else {
			float rotationZ = Mathf.Atan2 (rigidbody2D.velocity.x, rigidbody2D.velocity.y) * Mathf.Rad2Deg;
			this.transform.eulerAngles = new Vector3 (0, 0, rotationZ);
		}
		
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		this.gameObject.SetActive (false);
		PlayerKillEffect.transform.position = this.transform.position;
		PlayerKillEffect.gameObject.SetActive (true);	
		DieAudio.Play ();
	}
}
