using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFollow : MonoBehaviour {

	public Transform projectile;
	public Transform LeftBound;
	public Transform RightBound;
	void Update () {
		Vector3 newPosition = transform.position;
		newPosition.x = projectile.position.x;
		newPosition.x = Mathf.Clamp (newPosition.x, LeftBound.position.x, RightBound.position.x);
		transform.position = newPosition;
	}
}
