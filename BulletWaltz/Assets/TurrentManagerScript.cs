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
	public GameObject bulletCandidate;
	public float DF_BULLET_OFFESET = 0.6f;
	public ScoreManager m_kScoreManager;
	public GameLoopManager m_kGameLoopManager;
	// Use this for initialization
	void Start () {
		m_kAnimator = this.GetComponent <Animator> ();
	}
	
	public void PlayShootAnimation ()
	{
		m_kAnimator.SetTrigger ("Shoot");
		MainCamera.transform.DOShakePosition (CameraShakeDuration, CameraShakeStrength);

		m_kScoreManager.AddScore(1);

		GameObject bulletObj = GameObject.Instantiate (bulletCandidate);
		BulletScript bulletScript = bulletObj.GetComponent <BulletScript> ();
		bulletScript.transform.position = this.transform.position + DF_BULLET_OFFESET * this.transform.right;
		bulletScript.transform.rotation = this.transform.rotation;
		bulletScript.InitAndShoot (new Vector2 (this.transform.right.x, this.transform.right.y));

		m_kGameLoopManager.bullets.Add(bulletScript);
	}

	public void PlayRotateAnimation ()
	{
		float targetDegree = 360.0f / DF_DIRECTION_COUNT * Random.Range (0, DF_DIRECTION_COUNT);
		this.transform.DORotate (new Vector3 (0, 0, targetDegree), RotateDuration);
	}
}
