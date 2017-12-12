using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunghTimer : MonoBehaviour {

	public Lungh lungh;

	[Range(0,1)]
	public float lenght;
	float initTime;
	float nextLatido;

	SpriteRenderer timeRenderer;


	// Use this for initialization
	void Start () {
		timeRenderer = GetComponent<SpriteRenderer> ();
		initTime = Time.timeSinceLevelLoad;

		lungh = FindObjectOfType<Lungh> ();
		//print (lungh.getLunghRate());
	}

	// Update is called once per frame
	void Update () {
		//print (lungh.getLunghRate());
		if (Time.timeSinceLevelLoad >= nextLatido) {
			cambiaColor ();
			StartCoroutine (timer (lenght));
			nextLatido = nextLatido + lungh.getLunghRate();

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
