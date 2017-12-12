using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {



	public int savedInitialNumberOfLives = 0;

	public int  NUMBEROFLIVES;

	public Image screen;

	public Text fails;
	public Text rights;
	public Text relationBetweenActualBeatsAndLives;

	private byte screenModifier;

	int countErrors;
	 int countRights;



	void Start(){
		if (PlayerPrefs.GetInt ("savedInitialNumberOfLives", savedInitialNumberOfLives) == 0) {
			print ("LIVES SAVED");
			PlayerPrefs.SetInt ("NUMBEROFLIVES", NUMBEROFLIVES);
			savedInitialNumberOfLives = 1;
			PlayerPrefs.SetInt ("savedInitialNumberOfLives", savedInitialNumberOfLives);
		} else {
			print ("LIVES NOT SAVED");
		}
	}

	void Update(){
		fails.text = "Fails: " + getCountFails ();
		rights.text = "Rights: " + getCountRights ();
		relationBetweenActualBeatsAndLives.text = getCountRights () + "/" + PlayerPrefs.GetInt ("NUMBEROFLIVES", NUMBEROFLIVES);;
	}

	public int getCountRights(){
		return countRights ;
	}

	public int getCountFails(){
		return countErrors;
	}

	public void setCountLittleErrors(){
		countErrors++;
		screen.color = new Color32 (screenModifier,0,0,screenModifier);
		if (screenModifier < 200) {
			screenModifier += 10;
		} else {
			SceneManager.LoadScene ("perder");
		}
	}

	public void setCountRights() {
		countRights++;
		PlayerPrefs.SetInt ("countRights", countRights);	
		if (countRights >= PlayerPrefs.GetInt ("NUMBEROFLIVES", NUMBEROFLIVES)) {
			SceneManager.LoadScene ("ganar");
		}
	}

	public void setCountErrors(){
		countErrors++;
		screen.color = new Color32 (screenModifier,0,0,screenModifier);
		if (screenModifier < 200) {
			screenModifier += 20;
		} else {
			SceneManager.LoadScene ("perder");
		}
	}



}

