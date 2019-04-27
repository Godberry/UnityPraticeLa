using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	private Text m_kTextBox;
	private int m_fCurentScore;
	const string DF_SCORE_PREFIX = "Score :";
	// Use this for initialization
	void Start () {
		m_kTextBox = this.GetComponent<Text> ();
		SetScore ();
	}

	public void AddScore (int _nScore)
	{
		m_fCurentScore += _nScore;
		SetScore ();
	}

	void SetScore ()
	{
		m_kTextBox.text = DF_SCORE_PREFIX + m_fCurentScore;
	}
}
