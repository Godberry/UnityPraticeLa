using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameLoopManager : MonoBehaviour {

	public AudioSource bgmAudioSource;
	public HUE_Rotate hueRotate;
	public List<BulletScript> bullets;
	public PlayerController playerController;
	public FellowTheBeat followTheBeat;
	public ScoreManager scoreManager;

	private bool PlayerAlive = true;
	public void GameOver ()
	{
		DOTween.To (()=>Time.timeScale,(x)=>Time.timeScale=x,0,0.5f).SetUpdate(true);

		bgmAudioSource.DOFade (0, 0.5f).OnComplete (()=>
		{
			bgmAudioSource.Stop();
			PlayerAlive = false;
		}).SetUpdate(true);

		hueRotate.RotateValue = Mathf.PI;
	}

	public void ReStartGame ()
	{
		PlayerAlive = true;
		hueRotate.RotateValue = 0;
		scoreManager.Reset();
		playerController.Reset();
		followTheBeat.Reset();

		for (int i = 0; i < bullets.Count; ++i) {
			GameObject.Destroy(bullets[i].gameObject);
		}

		bullets.Clear();
		bgmAudioSource.volume = 1;
		bgmAudioSource.Play();
		Time.timeScale = 1;

	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!PlayerAlive) {
			if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0)){
				ReStartGame();
			}
		}
	}
}
