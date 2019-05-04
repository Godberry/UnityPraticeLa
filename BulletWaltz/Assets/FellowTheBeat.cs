using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FellowTheBeat : MonoBehaviour {

	private const float DF_BEAT_PERIOD = 1.485f;
	private const float DF_SHOOT_PASS_OFFEST = DF_BEAT_PERIOD * 3;
	private const float DF_ROTATE_COUNTER_OFFESET = 0.2f;
	private const float DF_SHOOT_COUNTER_OFFESET = -0.5f;
	private float m_fRotateCounter;
	private float m_fShootCounter;
	private TurrentManagerScript m_kTurrent;
	// Use this for initialization
	void Start () {
		m_fRotateCounter = DF_ROTATE_COUNTER_OFFESET;
		m_fShootCounter = DF_SHOOT_COUNTER_OFFESET + m_fShootCounter - DF_SHOOT_PASS_OFFEST;
		m_kTurrent = this.GetComponent <TurrentManagerScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		m_fRotateCounter += Time.deltaTime;
		m_fShootCounter += Time.deltaTime;

		if (m_fRotateCounter > DF_BEAT_PERIOD) {
			m_kTurrent.PlayRotateAnimation ();
			m_fRotateCounter -= DF_BEAT_PERIOD;
		}
		if (m_fShootCounter > DF_BEAT_PERIOD) {
			m_kTurrent.PlayShootAnimation ();
			m_fShootCounter -= DF_BEAT_PERIOD;
		}
	}
}
