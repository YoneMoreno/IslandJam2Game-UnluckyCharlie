using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {


	public Button exitButton;


	// Use this for initialization
	void Start () {
		exitButton.onClick.AddListener (TaskOnClick);
	}



	void TaskOnClick(){
		Application.Quit ();
	}
}
