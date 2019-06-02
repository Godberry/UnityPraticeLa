using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDragging : MonoBehaviour {

	public float MaxStretch = 3.0f;
	public LineRenderer catapultLineFront;
	public LineRenderer catapultLineBack;
	private Transform catapault;
	private SpringJoint2D Spring;
	private Rigidbody2D rigidBody2D;
	private Ray rayToMouse;
	private Ray leftCapataultToProjectile;
	private float maxStretchSqr;
	private float circleRadius;
	Vector2 PreVelovity = Vector2.zero;

	bool clickedOn = false;

	void Awake ()
	{
		Spring = GetComponent <SpringJoint2D> ();
		rigidBody2D = GetComponent <Rigidbody2D> ();
		catapault = Spring.connectedBody.transform;
	}
	void Start () {
		LineRendererStartup ();
		rayToMouse = new Ray (catapault.position, Vector3.zero);
		leftCapataultToProjectile = new Ray (catapultLineFront.transform.position, Vector3.zero);
		maxStretchSqr = MaxStretch * MaxStretch;
		CircleCollider2D circle = this.GetComponent <CircleCollider2D> ();
		circleRadius = circle.radius;
	}

	void Update () {
		if (clickedOn)
			Dragging ();

		if (Spring != null) 
		{
			if (!rigidBody2D.isKinematic && PreVelovity.sqrMagnitude > rigidBody2D.velocity.sqrMagnitude) {
				Destroy (Spring);
				rigidBody2D.velocity = PreVelovity;
			}

			if (!clickedOn) {
				PreVelovity = rigidBody2D.velocity;
			}

			LineRendererUpdate ();
		}
		else
		{
			catapultLineFront.enabled = false;
			catapultLineBack.enabled = false;
		}
	}

	void LineRendererStartup ()
	{
		catapultLineFront.SetPosition (0, catapultLineFront.transform.position);
		catapultLineBack.SetPosition (0, catapultLineBack.transform.position);

		catapultLineFront.sortingLayerName = "ForeGround";
		catapultLineBack.sortingLayerName = "ForeGround";

		catapultLineFront.sortingOrder = 3;
		catapultLineBack.sortingOrder = 1;
	}

	void LineRendererUpdate () {
		Vector2 catapaultToProjectile = transform.position - catapultLineFront.transform.position;
		leftCapataultToProjectile.direction = catapaultToProjectile;
		Vector3 holdPoint = leftCapataultToProjectile.GetPoint (catapaultToProjectile.magnitude + circleRadius);
		catapultLineFront.SetPosition (1, holdPoint);
		catapultLineBack.SetPosition (1, holdPoint);
	}

	void OnMouseDown ()
	{
		Spring.enabled = false;
		clickedOn = true;
	}

	void OnMouseUp ()
	{
		Spring.enabled = true;
		rigidBody2D.isKinematic = false;
		clickedOn = false;
	}

	void Dragging ()
	{
		Vector3 MouseToWorldPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 catapulToMouse = MouseToWorldPoint - catapault.position;
		if (catapulToMouse.sqrMagnitude > maxStretchSqr) {
			rayToMouse.direction = catapulToMouse;
			MouseToWorldPoint = rayToMouse.GetPoint (MaxStretch);
		}

		MouseToWorldPoint.z = 0;
		transform.position = MouseToWorldPoint;
	}
}
