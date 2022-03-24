using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class Taimeris : MonoBehaviour {

	public Text laikaTeksts;
	private float sakumaLaiks;
	//gaida speles beigas
	static public bool beidzis = false;
	static public int zvaigznuMinutes = 0;

	// Use this for initialization
	void Start () {
		sakumaLaiks = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (beidzis) {
			return;
		}
		float t = Time.time - sakumaLaiks;

		//Aprekina izspelesanas laiku
		string minutes = ((int)t / 60).ToString ();
		string sekundes = (t % 60).ToString ("f2");
		zvaigznuMinutes = Int32.Parse(minutes);

		//Izvada taimeri(laiku)
		laikaTeksts.text = "Tavs Laiks\n" + minutes + ":" + sekundes;
	}
}
