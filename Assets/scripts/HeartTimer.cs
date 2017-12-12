using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartTimer : MonoBehaviour {

	public Heart heart;

	[Range(0,1)]
	public float lenght;
	float initTime;
	float nextLatido;

	SpriteRenderer timeRenderer;


	// Use this for initialization
	void Start () {
		timeRenderer = GetComponent<SpriteRenderer> ();
		initTime = Time.timeSinceLevelLoad;
	
		heart = FindObjectOfType<Heart> ();
		//print (heart.getHearthRate());
	}
	
	// Update is called once per frame
	void Update () {
		//print (heart.getHearthRate());
		if (Time.timeSinceLevelLoad >= nextLatido) {
			cambiaColor ();
			StartCoroutine (timer (lenght));
			nextLatido = nextLatido + heart.getHearthRate();

			//print ("late" + Time.timeSinceLevelLoad);
		}else{

		}

	}
	void cambiaColor(){
		timeRenderer.color = Color.green;
	}

	void reseteaColor(){
		timeRenderer.color = Color.white;
	}


	IEnumerator timer(float time){

		yield return new WaitForSeconds (time);
		reseteaColor ();
	}
}
