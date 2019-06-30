using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
#region // enum
enum EMoveType {
	eMT_Forward,
	eMT_BackWard,
	eMT_Idle,
}
#endregion
#region // public member
public float p_fMoveSpeed;
public float p_fRotateSpeed;
public Transform p_kRotateXTransform;
public Transform p_kRotateYTransForm;
public Transform p_kMoveObj;
#endregion
#region // private member
private Animator m_kPlayerAnimation;
private float m_fCurSpeed = 0.0f;
private float m_fCurRotateX = 0.0f;
#endregion
	void Start () {
		m_kPlayerAnimation = GetComponent <Animator> ();
	}
	
	void Update () {
		HandleSight ();
		HandleInPut ();
		HandleAnimation ();
	}

	void HandleInPut () {
		if (Input.GetKey (KeyCode.W)) {
			Move (EMoveType.eMT_Forward);
		}
		else if  (Input.GetKey (KeyCode.S)) {
			Move (EMoveType.eMT_BackWard);
		}
		else {
			Move (EMoveType.eMT_Idle);
		}
	}

	void HandleAnimation ()
	{
		m_kPlayerAnimation.SetFloat ("Speed", m_fCurSpeed);
	}
	void Move (EMoveType type) {
		float result = 0.0f;
		switch (type) {
		case EMoveType.eMT_Forward : {
			result = p_fMoveSpeed;
			break;
		}
		case EMoveType.eMT_BackWard : {
			result = -1 * p_fMoveSpeed;
			break;
		}
		case EMoveType.eMT_Idle : {
			result = 0;
			break;
		}
		}
		SetCurSpeed (result);
		UpdatePosition ();
	}

	void UpdatePosition ()
	{
		p_kMoveObj.position += Time.deltaTime * m_fCurSpeed * p_kMoveObj.forward;
	}

	void HandleSight () {
		m_fCurRotateX += Input.GetAxis ("MoveSight_Vert") * p_fRotateSpeed;
		m_fCurRotateX = Mathf.Clamp (m_fCurRotateX, -90, 90);

		p_kRotateXTransform.localEulerAngles = new Vector3 (m_fCurRotateX, 0, 0);
		p_kMoveObj.Rotate (new Vector3 (0, Input.GetAxis ("MoveSight_Horz"), 0) * p_fRotateSpeed);
	}

	private void SetCurSpeed (float speed) {
		m_fCurSpeed = speed;
	}
}