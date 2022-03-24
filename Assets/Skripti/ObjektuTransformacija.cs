using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjektuTransformacija : MonoBehaviour {
	public Objekti objektuSkripts;
	
	// Update is called once per frame
	void Update () {
		//Ja ir vilkts kāds objekts, tad to varēs koriģēt
		if (objektuSkripts.pedejaisVIlktais != null) {
			//Nospiežot Z taustiņu rotē pretēji pulksteņrādītāja virzienam
			if (Input.GetKey (KeyCode.Z)) {
				objektuSkripts.pedejaisVIlktais.GetComponent<RectTransform> ().Rotate (0, 0, Time.deltaTime * 15f);
			}
			//Nospiežot X taustiņu rotē pulksteņrādītāja virzienā
			if (Input.GetKey (KeyCode.X)) {
				objektuSkripts.pedejaisVIlktais.GetComponent<RectTransform> ().Rotate (0, 0, -Time.deltaTime * 15f);
			}


			//Nospiežot bultiņu uz augšu iespējams stiept objektu pa y asi
			if (Input.GetKey (KeyCode.UpArrow)) {
				if (objektuSkripts.pedejaisVIlktais.GetComponent<RectTransform> ().localScale.y <= 0.8f){
					objektuSkripts.pedejaisVIlktais.GetComponent<RectTransform> ().localScale = new Vector2 (objektuSkripts.pedejaisVIlktais.GetComponent<RectTransform> ().localScale.x, 
						objektuSkripts.pedejaisVIlktais.GetComponent<RectTransform> ().localScale.y + 0.001f);
			}
		}

			//Nospiežot bultiņu uz augšu iespējams stiept objektu pa y asi
			if (Input.GetKey (KeyCode.DownArrow)) {
				if (objektuSkripts.pedejaisVIlktais.GetComponent<RectTransform> ().localScale.y >= 0.3f) {
					objektuSkripts.pedejaisVIlktais.GetComponent<RectTransform> ().localScale = new Vector2 (objektuSkripts.pedejaisVIlktais.GetComponent<RectTransform> ().localScale.x, 
						objektuSkripts.pedejaisVIlktais.GetComponent<RectTransform> ().localScale.y  -0.001f);
				}
			}

			//Nospiežot bultiņu pa kreisi iespējams stiept objektu pa y asi
			if (Input.GetKey (KeyCode.LeftArrow)) {
				if (objektuSkripts.pedejaisVIlktais.GetComponent<RectTransform> ().localScale.y >= 0.3f) {
					objektuSkripts.pedejaisVIlktais.GetComponent<RectTransform> ().localScale = new Vector2 (objektuSkripts.pedejaisVIlktais.GetComponent<RectTransform> ().localScale.x - 0.001f, 
						objektuSkripts.pedejaisVIlktais.GetComponent<RectTransform> ().localScale.y);
				}
			}

			//Nospiežot bultiņu pa labi iespējams stiept objektu pa y asi
			if (Input.GetKey (KeyCode.RightArrow)) {
				if (objektuSkripts.pedejaisVIlktais.GetComponent<RectTransform> ().localScale.y <= 0.8f) {
					objektuSkripts.pedejaisVIlktais.GetComponent<RectTransform> ().localScale = new Vector2 (objektuSkripts.pedejaisVIlktais.GetComponent<RectTransform> ().localScale.x + 0.001f, 
						objektuSkripts.pedejaisVIlktais.GetComponent<RectTransform> ().localScale.y);
				}
			}
}
}
}
