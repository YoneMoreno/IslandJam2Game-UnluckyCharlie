using UnityEngine;
using System.Collections;



public class Heart : MonoBehaviour {
	GameManager gameManager;

	AudioSource audioS;

	public Sprite heartImage;
	public Sprite heartPopUp;
	SpriteRenderer srenderer;
	public float hearthRate;
	private float currentHearthBeat;
	public float hearthBeatUpperTreshold;
	float nextBeatTime;
	float lastBeatTime;
	float currentTime;


	void Start(){
		
		gameManager = FindObjectOfType<GameManager> ();
		srenderer = GetComponent<SpriteRenderer> ();

		currentHearthBeat = hearthRate;
		lastBeatTime = 0;
		nextBeatTime = Time.timeSinceLevelLoad + hearthRate;
		srenderer.sprite = heartImage;

		audioS = GetComponent<AudioSource>();
	}



	void Update() {

		countdown ();


		checkIfPressedHearthKey ();




	}

	public void countdown(){
		currentTime = Time.timeSinceLevelLoad;

		if (currentTime >= nextBeatTime) {
			lastBeatTime = nextBeatTime;
			nextBeatTime = Time.timeSinceLevelLoad + currentHearthBeat;
			srenderer.color = Color.white;
			srenderer.sprite = heartImage;
//			Debug.Log ("Pum! " + Time.timeSinceLevelLoad);
			gameManager.setCountLittleErrors();
		}	
	}

	public bool IsPressedHearthKey(){
		if (Input.GetKeyDown (KeyCode.A)) {

			//print ("space key was pressed");
			return true;
		}
		return false;
	}



	public bool IsKeyPressedInHearthBeathTreshold(){
		if (currentTime >= lastBeatTime - hearthBeatUpperTreshold && currentTime <= lastBeatTime + hearthBeatUpperTreshold) {
			print ("pulse corazon CON RITMO ANTERIOR");
			srenderer.color = Color.green;
			srenderer.sprite = heartPopUp;
			gameManager.setCountRights ();
			audioS.Play ();
			return true;
		}
		if (currentTime >= nextBeatTime - hearthBeatUpperTreshold && currentTime <= nextBeatTime + hearthBeatUpperTreshold) {
			print ("pulse corazon CON RITMO SIGUIENTE");
			srenderer.color = Color.green;
			srenderer.sprite = heartPopUp;
			gameManager.setCountRights ();
			audioS.Play ();
			return true;
		}
		print("pulse corazon sin ritmo");
		srenderer.color = Color.red;
		srenderer.sprite = heartImage;
		gameManager.setCountErrors ();
		return false;
	}




	public void checkIfPressedHearthKey(){
		if (IsPressedHearthKey()) {
			IsKeyPressedInHearthBeathTreshold ();
		}

	}

	public  float getHearthRate(){
		return hearthRate;
	}



}