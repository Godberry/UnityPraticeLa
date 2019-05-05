using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	private Rigidbody2D rigidBody2D;
	private SpriteRenderer spriteRenderer;
	const float DF_BULLET_SPEED = 2; 	
	const float DF_FLASH_DURATION = 0.1f;
	float m_nflashCounter = 0;
	
	public void InitAndShoot (Vector2 direction) {
		rigidBody2D = this.GetComponent <Rigidbody2D> ();
		spriteRenderer = this.GetComponent <SpriteRenderer> ();
		spriteRenderer.color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
		rigidBody2D.velocity = direction * DF_BULLET_SPEED;
		m_nflashCounter = DF_FLASH_DURATION;
	}

	void Update()
	{
		if (rigidBody2D.velocity == Vector2.zero) {
			rigidBody2D.velocity = new Vector2 (Random.Range (0, 1.0f), Random.Range (0, 1.0f)).normalized * DF_BULLET_SPEED;
		}	
		else {
			rigidBody2D.velocity = rigidBody2D.velocity.normalized * DF_BULLET_SPEED;
		}	

		// flashBullet
		if (m_nflashCounter > 0) {
			spriteRenderer.color = Color.white;
			m_nflashCounter -= Time.deltaTime;
		}
		else {
			spriteRenderer.color = Color.green;
		}

		// Rotate
		float rotationZ = Mathf.Atan2 (rigidBody2D.velocity.x, rigidBody2D.velocity.y) * Mathf.Rad2Deg;
		this.transform.eulerAngles = new Vector3 (0, 0, rotationZ);
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		m_nflashCounter = DF_FLASH_DURATION;
	}
}
