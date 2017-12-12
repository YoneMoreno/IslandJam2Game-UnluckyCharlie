using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StomachTimer : MonoBehaviour {

	public Stomach stomach;

	[Range(0,1)]
	public float lenght;
	float initTime;
	float nextLatido;

	SpriteRenderer timeRenderer;


	// Use this for initialization
	void Start () {
		timeRenderer = GetComponent<SpriteRenderer> ();
		initTime = Time.timeSinceLevelLoad;

		stomach = FindObjectOfType<Stomach> ();
		//print (stomach.getstomachRate());
	}

	// Update is called once per frame
	void Update () {
		//print (stomach.getstomachRate());
		if (Time.timeSinceLevelLoad >= nextLatido) {
			cambiaColor ();
			StartCoroutine (timer (lenght));
			nextLatido = nextLatido + stomach.getStomachRate();

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
