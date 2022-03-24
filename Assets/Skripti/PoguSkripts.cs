using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PoguSkripts : MonoBehaviour {
	//Nodrosina ainu parslegsanu, uzkliksinot uz pogu Sakt parsledzas uz ainu Pilseta
	public void uzkliksinot (){
		SceneManager.LoadScene("Pilseta");
	}

	public void atskakt (){
		SceneManager.LoadScene("Izvelne");
	}
}
