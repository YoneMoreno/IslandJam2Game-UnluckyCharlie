using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RetryAfterWinning : MonoBehaviour {

	private int NUMBEROFLIVES;

	public Text score;
	public Button retryButton;

	// Use this for initialization
	void Start () {
		retryButton.onClick.AddListener (TaskOnClick);
		score.text = "Score: " + PlayerPrefs.GetInt ("countRights", 0);
	}



	void TaskOnClick(){
		harderLevel ();

		SceneManager.LoadScene ("base");
	}

	public void harderLevel(){
		NUMBEROFLIVES = PlayerPrefs.GetInt ("NUMBEROFLIVES", 0) + 5;
		print ("NUMBEROFLIVES: " + NUMBEROFLIVES);
		PlayerPrefs.SetInt ("NUMBEROFLIVES", NUMBEROFLIVES);
	}

}