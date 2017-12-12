using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnLungh : MonoBehaviour {

	public Lungh lungh;

	void Start(){
		StartCoroutine (timer());
		StopCoroutine (timer ());
	}


	IEnumerator timer(float time=5f){

		yield return new WaitForSeconds (time);
		spawnLunghs ();
	}

	public void spawnLunghs(){
		Instantiate (lungh, new Vector3(-1.2f,1.15f,0f), Quaternion.identity);
	}

}
