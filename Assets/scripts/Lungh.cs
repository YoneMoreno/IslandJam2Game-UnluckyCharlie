using UnityEngine;
using System.Collections;



public class Lungh : MonoBehaviour {
	GameManager gameManager;

	AudioSource audioS;

	public Sprite lunghDefault;
	public Sprite lunghPopUp;
	SpriteRenderer srenderer;
	public float lunghBeatRate;
	private float currentLunghBeat;
	public float hearthBeatUpperTreshold;
	 float nextBeatTime;
	float lastBeatTime;
	float currentTime;


	void Start(){
		gameManager = FindObjectOfType<GameManager> ();

		audioS = GetComponent<AudioSource> ();

		currentLunghBeat = lunghBeatRate;
		lastBeatTime = 0;
		nextBeatTime = Time.timeSinceLevelLoad + lunghBeatRate;
		srenderer = GetComponent<SpriteRenderer> ();
		srenderer.sprite = lunghDefault;
	}



	void Update() {

		countdown ();


		checkIfPressedHearthKey ();




	}

	public void countdown(){
		currentTime = Time.timeSinceLevelLoad;

		if (currentTime >= nextBeatTime) {
			lastBeatTime = nextBeatTime;
			nextBeatTime = Time.timeSinceLevelLoad + currentLunghBeat;
			//Debug.Log ("Respiraaaa! " + Time.timeSinceLevelLoad);
			srenderer.color = Color.white;
			srenderer.sprite = lunghDefault;
			gameManager.setCountLittleErrors();
		}	
	}

	public bool IsPressedHearthKey(){
		if (Input.GetKeyDown (KeyCode.S)) {

			//print ("space key was pressed");
			return true;
		}
		return false;
	}



	public bool IsKeyPressedInHearthBeathTreshold(){
		if (currentTime >= lastBeatTime - hearthBeatUpperTreshold && currentTime <= lastBeatTime + hearthBeatUpperTreshold) {
			print ("pulse PULMON CON RITMO ANTERIOR");
			srenderer.color = Color.green;
			srenderer.sprite = lunghPopUp;
			gameManager.setCountRights ();
			audioS.Play ();
			return true;
		}
		if (currentTime >= nextBeatTime - hearthBeatUpperTreshold && currentTime <= nextBeatTime + hearthBeatUpperTreshold) {
			print ("pulse PULMON CON RITMO SIGUIENTE");
			srenderer.color = Color.green;
			srenderer.sprite = lunghPopUp;
			gameManager.setCountRights ();
			audioS.Play ();
			return true;
		}
		print("pulse PULMON sin ritmo");
		srenderer.color = Color.red;
		srenderer.sprite = lunghDefault;
		gameManager.setCountErrors ();
		return false;
	}




	public void checkIfPressedHearthKey(){
		if (IsPressedHearthKey()) {
			IsKeyPressedInHearthBeathTreshold ();
		}

	}

	public  float getLunghRate(){
		return lunghBeatRate;
	}



}