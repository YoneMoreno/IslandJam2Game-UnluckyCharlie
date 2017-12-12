using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnStomach : MonoBehaviour {

	public GameObject stomach;

	void Start(){
		StartCoroutine (timer());
		StopCoroutine (timer ());
	}


	IEnumerator timer(float time=10f){

		yield return new WaitForSeconds (time);
		spawnStomachs ();
	}

	public void spawnStomachs(){
		Instantiate (stomach, new Vector3(-1.0f,-3f,0f), Quaternion.identity);
	}
}