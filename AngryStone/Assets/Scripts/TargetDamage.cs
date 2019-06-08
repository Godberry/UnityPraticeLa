﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDamage : MonoBehaviour {

	public int hitPoints = 2;
	public Sprite damageSprite;
	public float damageImpactSpeed;
	
	private int currentHitPoints;
	private float damageImpactSpeedSqr;
	private SpriteRenderer spriteRenderer;
	void Start () {
		spriteRenderer = GetComponent <SpriteRenderer> ();
		currentHitPoints = hitPoints;
		damageImpactSpeedSqr = damageImpactSpeed * damageImpactSpeed;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.tag != "Damager") {
			return;
		}
		if (collision.relativeVelocity.sqrMagnitude < damageImpactSpeedSqr) {
			return;
		}

		spriteRenderer.sprite = damageSprite;
		currentHitPoints--;
		if (currentHitPoints <= 0) {
			Kill ();
		}
	}

	void Kill () {
		spriteRenderer.enabled = false;
		GetComponent<Collider2D> ().enabled = false;
		GetComponent<Rigidbody2D> ().isKinematic = true;
	}
}