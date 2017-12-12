using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

	AudioSource audioS;

	// Use this for initialization
	void Start () {
		audioS = GetComponent<AudioSource>();
		audioS.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
