using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TurrentManagerScript : MonoBehaviour {

	private Animator m_kAnimator;
	int DF_DIRECTION_COUNT = 8;
	public Ease EaseFunction;
	public float RotateDuration;
	public Camera MainCamera;
	public float CameraShakeDuration;
	public float CameraShakeStrength;
	// Use this for initialization
	void Start () {
		m_kAnimator = this.GetComponent <Animator> ();
	}
	
	public void PlayShootAnimation ()
	{
		m_kAnimator.SetTrigger ("Shoot");
		MainCamera.transform.DOShakePosition (CameraShakeDuration, CameraShakeStrength);
	}

	public void PlayRotateAnimation ()
	{
		float targetDegree = 360.0f / DF_DIRECTION_COUNT * Random.Range (0, DF_DIRECTION_COUNT);
		this.transform.DORotate (new Vector3 (0, 0, targetDegree), RotateDuration);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			PlayShootAnimation ();
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			PlayRotateAnimation ();
		}
	}
}
