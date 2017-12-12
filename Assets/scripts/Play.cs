using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour {


	public Button playButton;


	// Use this for initialization
	void Start () {
		playButton.onClick.AddListener (TaskOnClick);
		PlayerPrefs.DeleteAll ();
	}



	void TaskOnClick(){
		SceneManager.LoadScene ("base");
	}
}
