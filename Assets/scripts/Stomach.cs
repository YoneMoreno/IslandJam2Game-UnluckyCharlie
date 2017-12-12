using UnityEngine;
using System.Collections;



public class Stomach : MonoBehaviour {
	GameManager gameManager;

	AudioSource audioS;

	public Sprite stomachDefault;
	public Sprite stomachPopUp;
	SpriteRenderer srenderer;
	public float stomachBeatRate;
	private float currentStomachBeat;
	public float stomachBeatUpperTreshold;
	float nextBeatTime;
	float lastBeatTime;
	float currentTime;


	void Start(){
		gameManager = FindObjectOfType<GameManager> ();

		currentStomachBeat = stomachBeatRate;
		lastBeatTime = 0;
		nextBeatTime = Time.timeSinceLevelLoad + stomachBeatRate;
		srenderer = GetComponent<SpriteRenderer> ();
		srenderer.sprite = stomachDefault;

		audioS = GetComponent<AudioSource> ();
	}



	void Update() {

		countdown ();


		checkIfPressedHearthKey ();




	}

	public void countdown(){
		currentTime = Time.timeSinceLevelLoad;

		if (currentTime >= nextBeatTime) {
			lastBeatTime = nextBeatTime;
			nextBeatTime = Time.timeSinceLevelLoad + currentStomachBeat;
			//Debug.Log ("Respiraaaa! " + Time.timeSinceLevelLoad);
			srenderer.color = Color.white;
			srenderer.sprite = stomachDefault;
			gameManager.setCountLittleErrors();
		}	
	}

	public bool IsPressedHearthKey(){
		if (Input.GetKeyDown (KeyCode.D)) {

			//print ("space key was pressed");
			return true;
		}
		return false;
	}



	public bool IsKeyPressedInHearthBeathTreshold(){
		if (currentTime >= lastBeatTime - stomachBeatUpperTreshold && currentTime <= lastBeatTime + stomachBeatUpperTreshold) {
			print ("pulse PULMON CON RITMO ANTERIOR");
			srenderer.color = Color.green;
			srenderer.sprite = stomachPopUp;
			gameManager.setCountRights ();
			audioS.Play ();
			return true;
		}
		if (currentTime >= nextBeatTime - stomachBeatUpperTreshold && currentTime <= nextBeatTime + stomachBeatUpperTreshold) {
			print ("pulse PULMON CON RITMO SIGUIENTE");
			srenderer.color = Color.green;
			srenderer.sprite = stomachPopUp;
			gameManager.setCountRights ();
			audioS.Play ();
			return true;
		}
		print("pulse PULMON sin ritmo");
		srenderer.color = Color.red;
		srenderer.sprite = stomachDefault;
		gameManager.setCountErrors ();
		return false;
	}




	public void checkIfPressedHearthKey(){
		if (IsPressedHearthKey()) {
			IsKeyPressedInHearthBeathTreshold ();
		}

	}

	public  float getStomachRate(){
		return stomachBeatRate;
	}



}