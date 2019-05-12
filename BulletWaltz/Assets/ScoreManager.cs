using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	private int m_nScore = 0;
	private Text m_kScoreText;

	// Use this for initialization
	public void AddScore(int _nScore)
	{
		m_nScore += _nScore;
		m_kScoreText.text = m_nScore.ToString();
	}

	void Start () {
		m_kScoreText = this.GetComponent<Text> ();
	}

	public void Reset ()
	{
		m_nScore = 0;
		m_kScoreText.text = m_nScore.ToString();
	}
}
